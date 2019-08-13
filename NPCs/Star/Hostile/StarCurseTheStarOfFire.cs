using Terraria;
using System.Linq;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.NPCs.Star.Hostile
{
    public class StarCurseTheStarOfFire : DUNPC
    {
        enum NPCState
        {
            Normal,
            NAttack,
            YAttack,
            LAttack
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("诅咒火之星");
        }
        public override void SetDefaults()
        {
            animationType = NPCID.MeteorHead;
            npc.damage = 32;
            npc.defense = 12;
            npc.lifeMax = 2400;
            npc.friendly = false;
            npc.lifeRegen += 9;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0.1f;
            npc.buffImmune[BuffID.Ichor] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.Confused] = true;
            banner = npc.type;
            bannerItem = mod.ItemType("FireOfStarZero");
            Main.npcFrameCount[npc.type] = 2;
        }
        public override void AI()
        {
            switch ((NPCState)State)
            {
                case NPCState.Normal:
                    {
                        npc.color = Color.Green;
                        npc.defense = 210;
                        for (int i = 0; i < 1; i++)
                        {
                            Dust.NewDustDirect
                                (npc.position, npc.width, npc.height,
                                MyDustId.GreenFXPowder, 0f, 0f, +85,
                                Color.Yellow, -0.3f);
                        }
                        break;
                    }
                case NPCState.NAttack:
                    {
                        aiType = NPCID.MeteorHead;
                        npc.color = Color.Green;
                        npc.defense = 12;
                        for (int i = 0; i < 1; i++)
                        {
                            Dust.NewDustDirect
                                (npc.position, npc.width, npc.height,
                                MyDustId.GreenFXPowder, 0f, 0f, +85,
                                Color.Green, -0.3f);
                            Player p = Main.player[npc.target];
                            Projectile.NewProjectile
                                (p.position, p.velocity, mod.ProjectileType("ProStarCTSOF1"),
                                npc.damage + npc.life, 2f, npc.damage);
                        }
                        break;
                    }
                case NPCState.YAttack:
                    {
                        aiType = NPCID.MeteorHead;
                        npc.color = Color.LimeGreen;
                        npc.damage += 28;
                        npc.defense += 34;
                        for (int i = 0; i < 1; i++)
                        {
                            Dust.NewDustDirect
                                (npc.position, npc.width, npc.height,
                                MyDustId.GreenFXPowder, 0f, 0f, +85,
                                Color.LimeGreen, -0.3f);
                            Player p = Main.player[npc.target];
                            Projectile.NewProjectile
                                (p.position, p.velocity, mod.ProjectileType("ProStarCTSOF2"),
                                npc.damage + p.dpsDamage, 2.5f, npc.damage + 10);
                        }
                        break;
                    }
                case NPCState.LAttack:
                    {
                        aiType = NPCID.EyeofCthulhu;
                        npc.color = Color.Lime;
                        npc.damage += 16;
                        npc.defense += 7;
                        npc.behindTiles = true;
                        for (int i = 0; i < 2; i++)
                        {
                            Dust.NewDustDirect
                                (npc.position, npc.width, npc.height,
                                MyDustId.GreenFXPowder, 0f, 0f, +128,
                                Color.Lime, -0.5f);
                        }
                        if (Main.rand.Next(10) < 3)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                Player p = Main.player[npc.target];
                                Projectile.NewProjectile
                                    (p.position, p.velocity, mod.ProjectileType("ProStarCTSOF3"),
                                    npc.damage + p.dpsDamage + 10, 3.5f, npc.damage + 20);
                            }
                        }
                        break;
                    }
                default:
                    {
                        npc.damage = 64;
                        npc.defense = 24;
                        npc.lifeMax = 4800;
                        npc.lifeRegen += 18;
                        npc.knockBackResist = 0.05f;
                        for (int i = 0; i < 2; i++)
                        {
                            Dust.NewDustDirect
                                    (npc.position, npc.width, npc.height,
                                    MyDustId.GreenFXPowder, 0f, 0f, +128,
                                    Color.LimeGreen, -0.5f);
                        }
                        {
                            if (Main.player.Any
                                (p => p.active && p.Distance(npc.Center) < 600))
                            {
                                SwitchState((int)NPCState.NAttack);
                            }
                            else if (npc.life <= 480)
                            {
                                SwitchState((int)NPCState.LAttack);
                            }
                            else if (npc.life <= 1200)
                            {
                                SwitchState((int)NPCState.YAttack);
                            }
                        }
                    }
                    break;
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.OnFire, damage * 2);
            target.AddBuff(BuffID.CursedInferno, 6000 / damage);
            target.AddBuff(BuffID.BrokenArmor, Player.tileRangeX / Player.tileRangeY);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.dayTime) return SpawnCondition.Corruption.Chance * 0.1f;
            else if (!Main.dayTime) return SpawnCondition.Corruption.Chance * 0.2f;
            return 0.0f;
        }
        public override void NPCLoot()
        {
            Item.NewItem((int)npc.velocity.X, (int)npc.velocity.Y,
                npc.width, npc.height, ItemID.SilverCoin, 31);
            Item.NewItem((int)npc.velocity.X, (int)npc.velocity.Y,
                npc.width, npc.height, ItemID.CopperCoin, 72);
            if (Main.rand.Next(100) < 1)
            {
                Item.NewItem((int)npc.velocity.X, (int)npc.velocity.Y,
                    npc.width, npc.height, ItemID.DepthMeter);
            }
            else if (Main.rand.Next(99) < 1)
            {
                Item.NewItem((int)npc.velocity.X, (int)npc.velocity.Y,
                    npc.width, npc.height, ItemID.Compass);
            }
            if (Main.rand.Next(5) < 1)
            {
                Item.NewItem((int)npc.velocity.X, (int)npc.velocity.Y,
                    npc.width, npc.height, mod.ItemType("FireOfStarZero"), 1);
            }
            else if (Main.rand.Next(10) < 1)
            {
                Item.NewItem((int)npc.velocity.X, (int)npc.velocity.Y,
                    npc.width, npc.height, mod.ItemType("FireOfStarZero"), 2);
            }
            else if (Main.rand.Next(20) < 1)
            {
                Item.NewItem((int)npc.velocity.X, (int)npc.velocity.Y,
                    npc.width, npc.height, mod.ItemType("FireOfStarZero"), 3);
            }
            if (Main.hardMode)
            {
                if (Main.rand.Next(15) < 1)
                {
                    Item.NewItem((int)npc.velocity.X, (int)npc.velocity.Y,
                        npc.width, npc.height, mod.ItemType("FireOfStarZero"), 3);
                }
                else if (Main.rand.Next(5) < 1)
                {
                    Item.NewItem((int)npc.velocity.X, (int)npc.velocity.Y,
                        npc.width, npc.height, mod.ItemType("FireOfStarZero"), 2);
                }
                else if (Main.rand.Next(1) < 1)
                {
                    Item.NewItem((int)npc.velocity.X, (int)npc.velocity.Y,
                        npc.width, npc.height, mod.ItemType("FireOfStarZero"), 1);
                }
                if (Main.rand.Next(4) < 1)
                {
                    Item.NewItem((int)npc.velocity.X, (int)npc.velocity.Y,
                        npc.width, npc.height, ItemID.Ichor, 2);
                }
            }
        }
    }
}