using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
namespace DisorderUnderstar.Dusts.Code
{
    public class DustCodeNumber : ModDust
    {
        public override void SetDefaults()
        {
            Dust.dCount = 10;
        }
        public override void OnSpawn(Dust dust)
        {
            dust.alpha += 26;
            dust.color = new Color(000, 128, 000);
            dust.noLight = false;
            dust.dustIndex = 300;
            dust.noGravity = false;
            Main.RegisterItemAnimation(dust.type, new DrawAnimationVertical(10, 10));
        }
    }
}
