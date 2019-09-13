using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using DisorderUnderstar.Dusts.Disorder;
namespace DisorderUnderstar.Buffs.Disorder
{
    public class BuffBlessingMoment : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Blessing Moment");
            DisplayName.AddTranslation(GameCulture.Chinese, "祝福时刻");
            Description.SetDefault("The symbols around you seem to give you good luck.");
            Description.AddTranslation(GameCulture.Chinese, "你身边的符号似乎会给予你好运");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            int _0 = 0;
            if (Main.rand.Next(100) < 1) _0 = 1;
            {
                #region timer的加减乘除
                if (_0 == 1) _0++;
                else if (_0 >= 2) _0 *= 2;
                else if (_0 > 500) _0 = 0;
                #endregion
                #region player的加减乘除
                if (_0 > 10 && _0 <= 100) player.statLife += 12;
                else if (_0 > 100 && _0 <= 450)
                {
                    player.statLife += 5;
                    player.AddBuff(BuffID.Daybreak, 1);
                }
                else
                {
                    player.statLife += 30;
                    player.AddBuff(BuffID.AmmoBox, 1);
                    player.AddBuff(BuffID.Daybreak, 1);
                    player.AddBuff(BuffID.MagicLantern, 1);
                }
                #endregion
            }
            Vector2 pleft = new Vector2(player.Center.X - player.width, player.Center.Y);
            Dust.NewDustDirect(pleft - Main.screenPosition, player.width, player.height, mod.DustType<DustGoldenSymbol>(), player.velocity.X,
                player.velocity.Y);
        }
    }
}