using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
namespace DisorderUnderstar.Dusts.Disorder
{
    public class DustGoldenSymbol : ModDust
    {
        private readonly Player pl = Main.player[Main.myPlayer];
        public override void OnSpawn(Dust dust)
        {
            dust.alpha = 25;
            dust.color = Color.Gold;
            dust.scale = 0.9f;
            dust.fadeIn = 0f;
            dust.noLight = false;
            dust.noGravity = false;
            dust.velocity *= pl.velocity.X + pl.moveSpeed;
            dust.velocity *= pl.velocity.Y;
        }
        public override bool Update(Dust dust)
        {
            Main.maxDustToDraw = pl.whoAmI;
            dust.fadeIn++;
            #region dust的位移
            if (dust.position.Y < pl.position.Y) dust.velocity.Y += 0.1f;
            else if (dust.position.Y == pl.velocity.Y) dust.velocity.Y = 0;
            else dust.position.Y -= 0.1f;
            if (dust.position.X < pl.position.X) dust.velocity.X += 0.1f;
            else if (dust.position.X == pl.velocity.X) dust.velocity.X = 0;
            else dust.position.X -= 0.1f;
            #endregion
            #region dust的消失
            if (dust.active && dust.fadeIn < 3f)
            {
                Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f),
                    0.5f, 0.5f, 0f);
                dust.alpha = 100;
                dust.color = Color.Lerp(new Color(200, 200, 20), Color.Yellow, (dust.fadeIn / 5f));
                dust.scale = 1.5f;
                dust.rotation += 0.1f;
            }
            else if (dust.fadeIn < 8f)
            {
                dust.color = Color.Lerp(Color.Yellow, Color.Gold, (dust.fadeIn - 5f) / 5f);
                dust.scale -= 0.125f;
                dust.rotation += 0.1f;
            }
            else
            {
                dust.scale -= 0.1f;
                dust.rotation += 0.1f;
            }
            if (dust.scale == 0.4f) dust.active = false;
            #endregion
            return false;
        }
    }
}