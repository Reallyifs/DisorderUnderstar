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
                for (int i = 0; i < 5; i++)
                {
                    Dust dust = Dust.NewDustDirect
                        (player.position, player.width, player.height,
                        MyDustId.GreenBubble1, 0, 0, 128,
                        Color.Green, -0.5f);
                    dust.noGravity = true;
                }
                for (int i = 0; i < 5; i++)
                {
                    Dust dust = Dust.NewDustDirect
                        (player.position, player.width, player.height,
                        MyDustId.RedBlood, 0, 0, 128,
                        Color.Red, -0.5f);
                    dust.noGravity = true;
                }
                for (int i = 0; i < 5; i++)
                {
                    Dust dust = Dust.NewDustDirect
                        (player.position, player.width, player.height,
                        MyDustId.PurpleBlackGrey, 0, 0, 128,
                        Color.Lime, -0.5f);
                    dust.noGravity = true;
                }
                for (int i = 0; i < 5; i++)
                {
                    Dust dust = Dust.NewDustDirect
                        (player.position, player.width, player.height,
                        MyDustId.CursedFire, 0, 0, 128,
                        Color.GreenYellow, -0.5f);
                    dust.noGravity = true;
                }
                for (int li = 0; li < 1; li++)
                {
                    player.statLife -= 15;
                }
            }
            else
            {
                Description.SetDefault("你周围包含着毒药的空气正在被诅咒火焰燃烧……\n" +
                    "你 应 得 的 =)");
                player.lifeRegen = 40;
                player.lifeRegen -= 160;
                player.altFunctionUse = 1;
                for (int i = 0; i < 5; i++)
                {
                    Dust dust = Dust.NewDustDirect
                        (player.position, player.width, player.height,
                        MyDustId.GreenBubble1, 0, 0, 128,
                        Color.Green, -0.5f);
                    dust.noGravity = true;
                }
                for (int i = 0; i < 5; i++)
                {
                    Dust dust = Dust.NewDustDirect
                        (player.position, player.width, player.height,
                        MyDustId.RedBlood, 0, 0, 128,
                        Color.Red, -0.5f);
                    dust.noGravity = true;
                }
                for (int i = 0; i < 5; i++)
                {
                    Dust dust = Dust.NewDustDirect
                        (player.position, player.width, player.height,
                        MyDustId.PurpleBlackGrey, 0, 0, 128,
                        Color.Lime, -0.5f);
                    dust.noGravity = true;
                }
                for (int i = 0; i < 5; i++)
                {
                    Dust dust = Dust.NewDustDirect
                        (player.position, player.width, player.height,
                        MyDustId.CursedFire, 0, 0, 128,
                        Color.GreenYellow, -0.5f);
                    dust.noGravity = true;
                }
                for (int li = 0; li < 2; li++) 
                {
                    player.statLife -= 30;
                }
                {
                    if (Main.rand.Next(5) < 1) player.statLifeMax2 -= 10;
                    else player.statLifeMax2 += 1;
                }
            }
            #endregion
        }
    }
}
