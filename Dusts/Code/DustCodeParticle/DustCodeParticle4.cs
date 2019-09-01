using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Dusts.Code.DustCodeParticle
{
    public class DustCodeParticle4 : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.alpha = 51;
            dust.color = new Color(000, 128, 000);
            dust.noLight = false;
            dust.dustIndex = 13;
            dust.noGravity = true;
        }
    }
}
