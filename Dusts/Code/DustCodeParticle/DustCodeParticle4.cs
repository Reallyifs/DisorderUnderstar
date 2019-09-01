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
        public override bool Update(Dust dust)
        {
            #region Dust的消失
            if (dust.dustIndex >= 1) dust.dustIndex--;
            if (dust.dustIndex <= 0) dust.active = false;
            #endregion
            return false;
        }
    }
}
