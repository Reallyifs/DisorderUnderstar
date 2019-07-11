using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
namespace DisorderUnderstar.Dusts.Disorder
{
    public class DustBodyDebris : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.alpha += 10;
            dust.color = new Color(230, 200, 150);
            dust.noLight = false;
            dust.noGravity = false;
            Main.RegisterItemAnimation(dust.type, new DrawAnimationVertical(4, 20));
        }
    }
}