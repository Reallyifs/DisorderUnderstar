using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using DisorderUnderstar.Tools;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Buffs.Sunset
{
    public class DebuffSunsetBlackFire : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Black Fire");
            DisplayName.AddTranslation(GameCulture.Chinese, "黑色火焰");
            Description.SetDefault("These Black flames were surround you...");
            Description.AddTranslation(GameCulture.Chinese,"这些黑色的火焰包围在你身边……");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;
            this.longerExpertDebuff = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen = 0;
            player.lifeRegen -= 12;
            if (player.buffTime[buffIndex] >= 30) { for (int _0 = 0; _0 < 2; _0++) {
                    Dust _1 = Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.BlackFlakes, 0, 0, 100, Color.Black,
                        1f);
                    _1.noGravity = true;
                    player.lifeRegen -= 1;
                }
            }
            else if (player.buffTime[buffIndex] >= 10) { for (int _2 = 0; _2 < 2; _2++) {
                    Dust _3 = Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.BlackMaterial, 0, 0, 100,
                        Color.Black, 1f);
                    _3.noGravity = true;
                    player.lifeRegen -= 1;
                }
            }
            else { for (int _4 = 0; _4 < 3; _4++) {
                    Dust _5 = Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.Fire, 0, 0, 100, Color.Black, 1f);
                    _5.noGravity = true;
                    player.lifeRegen = 0;
                }
                Description.SetDefault("It starts to dissipation...");
                Description.AddTranslation(GameCulture.Chinese,"它开始消失了……");
            }
            if (Main.rand.Next(20) < 1) { for (int _6 = 0; _6 < 5; _6++) { player.statLife -= 10; } }
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.lifeRegen = 0;
            npc.lifeRegen -= 1;
            if (npc.buffTime[buffIndex] >= 60) { for (int _7 = 0; _7 < 2; _7++) {
                    Dust _8 = Dust.NewDustDirect(npc.position, npc.width, npc.height, MyDustId.BlackFlakes, 0, 0, 100, Color.Black, 1f);
                    _8.noGravity = true;
                }
            }
            else if (npc.buffTime[buffIndex] >= 20) { for (int _9 = 0; _9 < 2; _9++) {
                    Dust _10 = Dust.NewDustDirect(npc.position, npc.width, npc.height, MyDustId.BlackMaterial, 0, 0, 100, Color.Black, 1f);
                    _10.noGravity = true;
                }
            }
            else { for (int _11 = 0; _11 < 3; _11++) {
                    Dust _12 = Dust.NewDustDirect(npc.position, npc.width, npc.height, MyDustId.Fire, 0, 0, 100, Color.Black, 1f);
                    _12.noGravity = true;
                }
            }
            if (Main.rand.Next(5) < 1) { for (int _13 = 0; _13 < 20; _13++) { npc.life -= 10; } }
        }
    }
}