using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
namespace DisorderUnderstar.Dusts.Disorder
{
    public class DustGoldenSymbol : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.alpha = 25;
            dust.color = Color.Gold;
            dust.scale = 0.9f;
            dust.noGravity = false;
            Main.RegisterItemAnimation(dust.type, new DrawAnimationVertical(8, 60));
        }
    }
}