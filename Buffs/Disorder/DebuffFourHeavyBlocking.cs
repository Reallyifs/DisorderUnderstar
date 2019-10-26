using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using DisorderUnderstar.Tools;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Buffs.Disorder
{
    public class DebuffFourHeavyBlocking : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Four Heavy BLOCKING");
            DisplayName.AddTranslation(GameCulture.Chinese, "四重打击");
            Description.SetDefault("The air around you that contains poison is burning in a cursed flame...");
            Description.AddTranslation(GameCulture.Chinese, "你周围包含着毒药的空气正在被诅咒火焰燃烧……");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;
            this.longerExpertDebuff = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            #region Buff的设置
            if (player.buffTime[buffIndex] > 10)
            {
                int _0 = player.whoAmI;
                if (_0 > 10) { _0 = 10; }
                int _1 = _0 / buffIndex;
                if (_1 < 5) { _1 = 5; }
                player.buffImmune[BuffID.Venom] = false;
                player.AddBuff(BuffID.Venom, buffIndex * _1);
                player.buffImmune[BuffID.Bleeding] = false;
                player.AddBuff(BuffID.Bleeding, buffIndex * _1);
                player.buffImmune[BuffID.Suffocation] = false;
                player.AddBuff(BuffID.Suffocation, buffIndex * _1);
                player.buffImmune[BuffID.CursedInferno] = false;
                player.AddBuff(BuffID.CursedInferno, buffIndex * _1);
                player.lifeRegen = 40;
                player.lifeRegen -= 160;
                player.altFunctionUse = 1;
                #region 粒子效果
                for (int _2 = 0; _2 < 5; _2++)
                {
                    Dust _3 = Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.GreenBubble1, 0, 0, 128,
                        Color.Green, -0.5f);
                    _3.noGravity = true;
                }
                for (int _4 = 0; _4 < 5; _4++)
                {
                    Dust _5 = Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.RedBlood, 0, 0, 128, Color.Red,
                        -0.5f);
                    _5.noGravity = true;
                }
                for (int _6 = 0; _6 < 5; _6++)
                {
                    Dust _7 = Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.PurpleBlackGrey, 0, 0, 128,
                        Color.Lime, -0.5f);
                    _7.noGravity = true;
                }
                for (int _8 = 0; _8 < 5; _8++)
                {
                    Dust _9 = Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.CursedFire, 0, 0, 128,
                        Color.GreenYellow, -0.5f);
                    _9.noGravity = true;
                }
                for (int _10 = 0; _10 < 1; _10++) { player.statLife -= 15; }
                #endregion
            }
            else
            {
                Description.SetDefault("The air around you that contains poison is burning in a cursed flame...\n" +
                    "YOU DESERVE IT. =)");
                Description.AddTranslation(GameCulture.Chinese, "你周围包含着毒药的空气正在被诅咒火焰燃烧……\n" +
                    "你 应 得 的。 =)");
                player.lifeRegen = 40;
                player.lifeRegen -= 160;
                player.altFunctionUse = 1;
                #region 粒子效果
                for (int _11 = 0; _11 < 5; _11++)
                {
                    Dust _12 = Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.GreenBubble1, 0, 0, 128,
                        Color.Green, -0.5f);
                    _12.noGravity = true;
                }
                for (int _13 = 0; _13 < 5; _13++)
                {
                    Dust _14 = Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.RedBlood, 0, 0, 128, Color.Red,
                        -0.5f);
                    _14.noGravity = true;
                }
                for (int _15 = 0; _15 < 5; _15++)
                {
                    Dust _16 = Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.PurpleBlackGrey, 0, 0, 128,
                        Color.Lime, -0.5f);
                    _16.noGravity = true;
                }
                for (int _17 = 0; _17 < 5; _17++)
                {
                    Dust _18 = Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.CursedFire, 0, 0, 128,
                        Color.GreenYellow, -0.5f);
                    _18.noGravity = true;
                }
                for (int _19 = 0; _19 < 2; _19++) { player.statLife -= 30; }
                if (Main.rand.Next(0, 1) < 1) { player.statLifeMax2 -= 10; }
                else { player.statLifeMax2 += 1; }
                #endregion
            }
            #endregion
        }
    }
}
