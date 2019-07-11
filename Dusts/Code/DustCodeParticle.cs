using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
namespace DisorderUnderstar.Dusts.Code
{
    public class DustCodeParticle : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.alpha += 50;
            dust.color = new Color(000, 128, 000);
            dust.noLight = false;
            dust.noGravity = true;
            Main.RegisterItemAnimation(dust.type, new DrawAnimationVertical(10, 4));
        }
    }
}
