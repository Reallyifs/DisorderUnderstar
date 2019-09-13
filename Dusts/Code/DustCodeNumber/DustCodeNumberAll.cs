using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ColinUtils;
namespace DisorderUnderstar.Dusts.Code.DustCodeNumber
{
    public class DustCodeNumberAll : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.alpha = 255;
            dust.color = new Color(000, 128, 000);
            dust.noLight = true;
            dust.dustIndex = 1;
            dust.noGravity = true;
        }
        public override bool Update(Dust dust)
        {
            #region Dust的消失
            if (dust.dustIndex >= 1) dust.dustIndex--;
            if (dust.dustIndex <= 0) dust.active = false;
            #endregion
            #region 生成Dust本体
            int _0 = Main.rand.Next(0, 9);
            float _1 = Main.rand.NextFloat(0.1f, 25.5f);
            if (_0 == 0) Dust.NewDustDirect(dust.position, 1, 1, mod.DustType("DustCodeNumber0"), 0, 0, (int)((_0 + 1) * _1), Color.Green, 0.5f);
            else if (_0 == 1) Dust.NewDustDirect(dust.position, 1, 1, mod.DustType("DustCodeNumber1"), 0, 0, (int)((_0 + 1) * _1), Color.Green, 0.5f);
            else if (_0 == 2) Dust.NewDustDirect(dust.position, 1, 1, mod.DustType("DustCodeNumber2"), 0, 0, (int)((_0 + 1) * _1), Color.Green, 0.5f);
            else if (_0 == 3) Dust.NewDustDirect(dust.position, 1, 1, mod.DustType("DustCodeNumber3"), 0, 0, (int)((_0 + 1) * _1), Color.Green, 0.5f);
            else if (_0 == 4) Dust.NewDustDirect(dust.position, 1, 1, mod.DustType("DustCodeNumber4"), 0, 0, (int)((_0 + 1) * _1), Color.Green, 0.5f);
            else if (_0 == 5) Dust.NewDustDirect(dust.position, 1, 1, mod.DustType("DustCodeNumber5"), 0, 0, (int)((_0 + 1) * _1), Color.Green, 0.5f);
            else if (_0 == 6) Dust.NewDustDirect(dust.position, 1, 1, mod.DustType("DustCodeNumber6"), 0, 0, (int)((_0 + 1) * _1), Color.Green, 0.5f);
            else if (_0 == 7) Dust.NewDustDirect(dust.position, 1, 1, mod.DustType("DustCodeNumber7"), 0, 0, (int)((_0 + 1) * _1), Color.Green, 0.5f);
            else if (_0 == 8) Dust.NewDustDirect(dust.position, 1, 1, mod.DustType("DustCodeNumber8"), 0, 0, (int)((_0 + 1) * _1), Color.Green, 0.5f);
            else if (_0 == 9) Dust.NewDustDirect(dust.position, 1, 1, mod.DustType("DustCodeNumber9"), 0, 0, (int)((_0 + 1) * _1), Color.Green, 0.5f);
            #endregion
            return false;
        }
    }
    #region 本体
    public class DustCodeNumber0 : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.color = new Color(000, 128, 000);
            dust.noLight = true;
            dust.dustIndex = 60;
            dust.noGravity = true;
        }
        public override bool Update(Dust dust)
        {
            if (dust.velocity.Y >= -0.1f) dust.velocity.Y = -1f;
            #region Dust的消失
            if (dust.dustIndex >= 1) dust.dustIndex--;
            if (dust.dustIndex <= 0) dust.active = false;
            #endregion
            return false;
        }
    }
    public class DustCodeNumber1 : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.color = new Color(000, 128, 000);
            dust.noLight = true;
            dust.dustIndex = 60;
            dust.noGravity = true;
        }
        public override bool Update(Dust dust)
        {
            if (dust.velocity.Y >= -0.1f) dust.velocity.Y = -1f;
            #region Dust的消失
            if (dust.dustIndex >= 1) dust.dustIndex--;
            if (dust.dustIndex <= 0) dust.active = false;
            #endregion
            return false;
        }
    }
    public class DustCodeNumber2 : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.color = new Color(000, 128, 000);
            dust.noLight = true;
            dust.dustIndex = 60;
            dust.noGravity = true;
        }
        public override bool Update(Dust dust)
        {
            if (dust.velocity.Y >= -0.1f) dust.velocity.Y = -1f;
            #region Dust的消失
            if (dust.dustIndex >= 1) dust.dustIndex--;
            if (dust.dustIndex <= 0) dust.active = false;
            #endregion
            return false;
        }
    }
    public class DustCodeNumber3 : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.color = new Color(000, 128, 000);
            dust.noLight = true;
            dust.dustIndex = 60;
            dust.noGravity = true;
        }
        public override bool Update(Dust dust)
        {
            if (dust.velocity.Y >= -0.1f) dust.velocity.Y = -1f;
            #region Dust的消失
            if (dust.dustIndex >= 1) dust.dustIndex--;
            if (dust.dustIndex <= 0) dust.active = false;
            #endregion
            return false;
        }
    }
    public class DustCodeNumber4 : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.color = new Color(000, 128, 000);
            dust.noLight = true;
            dust.dustIndex = 60;
            dust.noGravity = true;
        }
        public override bool Update(Dust dust)
        {
            if (dust.velocity.Y >= -0.1f) dust.velocity.Y = -1f;
            #region Dust的消失
            if (dust.dustIndex >= 1) dust.dustIndex--;
            if (dust.dustIndex <= 0) dust.active = false;
            #endregion
            return false;
        }
    }
    public class DustCodeNumber5 : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.color = new Color(000, 128, 000);
            dust.noLight = true;
            dust.dustIndex = 60;
            dust.noGravity = true;
        }
        public override bool Update(Dust dust)
        {
            if (dust.velocity.Y >= -0.1f) dust.velocity.Y = -1f;
            #region Dust的消失
            if (dust.dustIndex >= 1) dust.dustIndex--;
            if (dust.dustIndex <= 0) dust.active = false;
            #endregion
            return false;
        }
    }
    public class DustCodeNumber6 : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.color = new Color(000, 128, 000);
            dust.noLight = true;
            dust.dustIndex = 60;
            dust.noGravity = true;
        }
        public override bool Update(Dust dust)
        {
            if (dust.velocity.Y >= -0.1f) dust.velocity.Y = -1f;
            #region Dust的消失
            if (dust.dustIndex >= 1) dust.dustIndex--;
            if (dust.dustIndex <= 0) dust.active = false;
            #endregion
            return false;
        }
    }
    public class DustCodeNumber7 : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.color = new Color(000, 128, 000);
            dust.noLight = true;
            dust.dustIndex = 60;
            dust.noGravity = true;
        }
        public override bool Update(Dust dust)
        {
            if (dust.velocity.Y >= -0.1f) dust.velocity.Y = -1f;
            #region Dust的消失
            if (dust.dustIndex >= 1) dust.dustIndex--;
            if (dust.dustIndex <= 0) dust.active = false;
            #endregion
            return false;
        }
    }
    public class DustCodeNumber8 : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.color = new Color(000, 128, 000);
            dust.noLight = true;
            dust.dustIndex = 60;
            dust.noGravity = true;
        }
        public override bool Update(Dust dust)
        {
            if (dust.velocity.Y >= -0.1f) dust.velocity.Y = -1f;
            #region Dust的消失
            if (dust.dustIndex >= 1) dust.dustIndex--;
            if (dust.dustIndex <= 0) dust.active = false;
            #endregion
            return false;
        }
    }
    public class DustCodeNumber9 : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.color = new Color(000, 128, 000);
            dust.noLight = true;
            dust.dustIndex = 60;
            dust.noGravity = true;
        }
        public override bool Update(Dust dust)
        {
            if (dust.velocity.Y >= -0.1f) dust.velocity.Y = -1f;
            #region Dust的消失
            if (dust.dustIndex >= 1) dust.dustIndex--;
            if (dust.dustIndex <= 0) dust.active = false;
            #endregion
            return false;
        }
    }
    #endregion
}
