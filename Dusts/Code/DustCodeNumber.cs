using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Dusts.Code
{
    public class DustCodeNumber : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.alpha = 255;
            dust.color = new Color(000, 128, 000);
            dust.noLight = true;
            dust.dustIndex = 300;
            dust.noGravity = true;
        }
        public override bool Update(Dust dust)
        {
            #region 生成Dust本体
            int Number = Main.rand.Next(0, 9);
            if (Number == 0)
                Dust.NewDustDirect(dust.position, 1, 1, mod.DustType("DustCodeNumber0"),
                    0, 0, 100, Color.Green, 1f);
            else if (Number == 1)
                Dust.NewDustDirect(dust.position, 1, 1, mod.DustType("DustCodeNumber1"),
                    0, 0, 100, Color.Green, 1f);
            else if (Number == 2)
                Dust.NewDustDirect(dust.position, 1, 1, mod.DustType("DustCodeNumber2"),
                    0, 0, 100, Color.Green, 1f);
            else if (Number == 3)
                Dust.NewDustDirect(dust.position, 1, 1, mod.DustType("DustCodeNumber3"),
                    0, 0, 100, Color.Green, 1f);
            else if (Number == 4)
                Dust.NewDustDirect(dust.position, 1, 1, mod.DustType("DustCodeNumber4"),
                    0, 0, 100, Color.Green, 1f);
            else if (Number == 5)
                Dust.NewDustDirect(dust.position, 1, 1, mod.DustType("DustCodeNumber5"),
                    0, 0, 100, Color.Green, 1f);
            else if (Number == 6)
                Dust.NewDustDirect(dust.position, 1, 1, mod.DustType("DustCodeNumber6"),
                    0, 0, 100, Color.Green, 1f);
            else if (Number == 7)
                Dust.NewDustDirect(dust.position, 1, 1, mod.DustType("DustCodeNumber7"),
                    0, 0, 100, Color.Green, 1f);
            else if (Number == 8)
                Dust.NewDustDirect(dust.position, 1, 1, mod.DustType("DustCodeNumber8"),
                    0, 0, 100, Color.Green, 1f);
            else if (Number == 9)
                Dust.NewDustDirect(dust.position, 1, 1, mod.DustType("DustCodeNumber9"),
                    0, 0, 100, Color.Green, 1f);
            #endregion
            return false;
        }
    }
}
