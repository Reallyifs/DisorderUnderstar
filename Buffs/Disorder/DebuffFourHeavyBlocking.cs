using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Buffs.Disorder
{
    public class DebuffFourHeavyBlocking : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("四重打击");
            Description.SetDefault("你周围包含着毒药的空气正在被诅咒火焰燃烧……");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.lightPet[Type] = false;
            Main.vanityPet[Type] = false;
            Main.buffNoSave[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;
            this.canBeCleared = false;
            this.longerExpertDebuff = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            #region Buff的设置
            if (player.buffTime[buffIndex] > 10)
            {
                player.buffImmune[BuffID.Venom] = false;
                player.AddBuff(BuffID.Venom, player.buffTime[buffIndex] * 40);
                player.buffImmune[BuffID.Bleeding] = false;
                player.AddBuff(BuffID.Bleeding, player.buffTime[buffIndex] * 30);
                player.buffImmune[BuffID.Suffocation] = false;
                player.AddBuff(BuffID.Suffocation, player.buffTime[buffIndex] * 20);
                player.buffImmune[BuffID.CursedInferno] = false;
                player.AddBuff(BuffID.CursedInferno, player.buffTime[buffIndex] * 10);
                player.lifeRegen = 40;
                player.lifeRegen -= 160;
                player.altFunctionUse = 1;
                #region 粒子效果
                for (int _0 = 0; _0 < 5; _0++)
                {
                    Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.GreenBubble1, 0, 0, 128,
                        Color.Green, -0.5f);
                    dust.noGravity = true;
                }
                for (int _1 = 0; _1 < 5; _1++)
                {
                    Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.RedBlood, 0, 0, 128, Color.Red,
                        -0.5f);
                    dust.noGravity = true;
                }
                for (int _2 = 0; _2 < 5; _2++)
                {
                    Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.PurpleBlackGrey, 0, 0, 128,
                        Color.Lime, -0.5f);
                    dust.noGravity = true;
                }
                for (int _3 = 0; _3 < 5; _3++)
                {
                    Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.CursedFire, 0, 0, 128,
                        Color.GreenYellow, -0.5f);
                    dust.noGravity = true;
                }
                for (int _4 = 0; _4 < 1; _4++) player.statLife -= 15;
                #endregion
            }
            else
            {
                Description.SetDefault("你周围包含着毒药的空气正在被诅咒火焰燃烧……\n" +
                    "你 应 得 的 =)");
                player.lifeRegen = 40;
                player.lifeRegen -= 160;
                player.altFunctionUse = 1;
                #region 粒子效果
                for (int _0 = 0; _0 < 5; _0++)
                {
                    Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.GreenBubble1, 0, 0, 128,
                        Color.Green, -0.5f);
                    dust.noGravity = true;
                }
                for (int _1 = 0; _1 < 5; _1++)
                {
                    Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.RedBlood, 0, 0, 128, Color.Red,
                        -0.5f);
                    dust.noGravity = true;
                }
                for (int _2 = 0; _2 < 5; _2++)
                {
                    Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.PurpleBlackGrey, 0, 0, 128,
                        Color.Lime, -0.5f);
                    dust.noGravity = true;
                }
                for (int _3 = 0; _3 < 5; _3++)
                {
                    Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.CursedFire, 0, 0, 128,
                        Color.GreenYellow, -0.5f);
                    dust.noGravity = true;
                }
                for (int _4 = 0; _4 < 2; _4++) player.statLife -= 30;
                if (Main.rand.Next(0, 1) < 1) player.statLifeMax2 -= 10;
                else player.statLifeMax2 += 1;
                #endregion
            }
            #endregion
        }
    }
}
