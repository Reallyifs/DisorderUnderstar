using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Buffs.Disorder
{
    public class BuffBlessingMoment : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("祝福时刻");
            Description.SetDefault("你身边的符号似乎会给予你好运");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            int timer = 0;
            if (Main.rand.Next(100) < 1) timer = 1;
            {
                #region timer的加减乘除
                if (timer == 1) timer++;
                else if (timer >= 2) timer *= 2;
                else if (timer > 500) timer = 0;
                #endregion
                #region player的加减乘除
                if (timer > 10 && timer <= 100)
                {
                    player.statLife += 12;
                }
                else if (timer > 100 && timer <= 450)
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
            Dust.NewDustDirect(pleft - Main.screenPosition, player.width, player.height,
                mod.DustType("DustGoldenSymbol"), player.velocity.X, player.velocity.Y);
        }
    }
}