using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Dusts.Code.DustCodeParticle
{
    public class DustCodeParticle0 : ModDust
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
            #region 生成下一个Dust
            if (dust.dustIndex <= 1)
                Dust.NewDustDirect(dust.position, 1, 1, mod.DustType("DustCodeParticle1"),
                    0, 0, 102, Color.Green, 1f);
            #endregion
            return false;
        }
    }
}
