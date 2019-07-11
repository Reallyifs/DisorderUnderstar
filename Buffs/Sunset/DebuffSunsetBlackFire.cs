using Terraria;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Buffs.Sunset
{
    public class DebuffSunsetBlackFire : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("黑色火焰");
            Description.SetDefault("这些黑色的火焰包围在你身边……");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.lightPet[Type] = false;
            Main.vanityPet[Type] = false;
            Main.buffNoSave[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;
            this.canBeCleared = false;
            this.longerExpertDebuff = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen = 0;
            player.lifeRegen -= 12;
            if (player.buffTime[buffIndex] >= 30)
            {
                for (int i = 0; i < 2; i++)
                {
                    Dust dust = Dust.NewDustDirect
                        (player.position, player.width, player.height,
                        MyDustId.BlackFlakes, 0, 0, 100,
                        Color.Black, 1f);
                    dust.noGravity = true;
                    player.lifeRegen -= 1;
                }
            }
            else if (player.buffTime[buffIndex] >= 10)
            {
                for (int i = 0; i < 2; i++)
                {
                    Dust dust = Dust.NewDustDirect
                        (player.position, player.width, player.height,
                        MyDustId.BlackMaterial, 0, 0, 100,
                        Color.Black, 1f);
                    dust.noGravity = true;
                    player.lifeRegen -= 1;
                }
            }
            else
            {
                for(int i = 0; i < 3; i++)
                {
                    Dust dust = Dust.NewDustDirect
                        (player.position, player.width, player.height,
                        MyDustId.Fire, 0, 0, 100,
                        Color.Black, 1f);
                    dust.noGravity = true;
                    player.lifeRegen = 0;
                }
                Description.SetDefault("它开始消失了……");
            }
            if (Main.rand.Next(20) < 1)
                for (int i = 0; i < 5; i++)
                    player.statLife -= 10;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.lifeRegen = 0;
            npc.lifeRegen -= 1;
            if (npc.buffTime[buffIndex] >= 60)
            {
                for (int i = 0; i < 2; i++)
                {
                    Dust dust = Dust.NewDustDirect
                        (npc.position, npc.width, npc.height,
                        MyDustId.BlackFlakes, 0, 0, 100,
                        Color.Black, 1f);
                    dust.noGravity = true;
                }
            }
            else if (npc.buffTime[buffIndex] >= 20)
            {
                for (int i = 0; i < 2; i++)
                {
                    Dust dust = Dust.NewDustDirect
                        (npc.position, npc.width, npc.height,
                        MyDustId.BlackMaterial, 0, 0, 100,
                        Color.Black, 1f);
                    dust.noGravity = true;
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Dust dust = Dust.NewDustDirect
                        (npc.position, npc.width, npc.height,
                        MyDustId.Fire, 0, 0, 100,
                        Color.Black, 1f);
                    dust.noGravity = true;
                }
            }
            if (Main.rand.Next(5) < 1)
                for (int i = 0; i < 20; i++)
                    npc.life -= 10;
        }
    }
}
