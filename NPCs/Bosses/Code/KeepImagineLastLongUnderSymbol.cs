using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
namespace DisorderUnderstar.NPCs.Bosses.Code
{
    public class KeepImagineLastLongUnderSymbol : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("杀.死.我.们.");
        }
        public override void SetDefaults()
        {
            npc.boss = true;
            npc.lifeMax = 9999999;
            npc.defense = 0;
            if (npc.defense == 0)
            {
                npc.lifeRegen += 100;
                npc.defense += 1;
            }
            if (npc.timeLeft > 6000)
            {
                if (npc.defense >= 1)
                {
                    npc.defense -= 1;
                    npc.lifeRegen -= 99;
                }
            }
            if (npc.lifeRegen > 50)
            {
                npc.defense = 0;
                npc.damage = 999999999;
                npc.lifeRegen += 999999999;
            }
        }
        public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit)
        {
            item.mana += 999999999;
            item.damage -= 999999999;
            item.crit -= 999999999;
            item.knockBack -= 999999999;
            item.autoReuse = false;
            item.useAnimation += 999999999;
            item.useTime += 999999999;
            item.useAmmo = AmmoID.Bullet;
            item.useAmmo = AmmoID.Arrow;
            item.useStyle = 4;
            item.value = Item.sellPrice(0, 0, 0, 1);
            item.value += Item.buyPrice(999999999, 999999999, 999999999, 999999999);
            item.magic = true;
            item.melee = true;
            item.noMelee = true;
            item.notAmmo = true;
            item.thrown = false;
            item.summon = false;
            item.ranged = false;
            player.lifeRegen -= 999999999;
            player.statLifeMax2 = 1;
            player.dead = true;
            player.maxMinions = 0;
            player.statManaMax2 = 1;
            player.KillMe(PlayerDeathReason.ByCustomReason(player.name + "的大剑反打了自己"), 9999, 0);
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.lifeRegen -= 999999999;
            target.statLifeMax2 = 1;
            target.dead = true;
            target.maxMinions = 0;
            target.statManaMax2 = 1;
            target.magicCrit -= 999999999;
            target.meleeDamage -= 999999999;
            target.meleeSpeed += 999999999;
            target.KillMe(PlayerDeathReason.ByCustomReason(target.name + "被虚空的力量扭曲了。"), 9999, 0);
        }
        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            projectile.damage -= 999999999;
            projectile.knockBack -= 999999999;
            projectile.melee = false;
            projectile.ranged = false;
            projectile.minion = false;
            projectile.magic = true;
            projectile.thrown = false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.damage -= 999999999;
            target.defense -= 999999999;
            target.AddBuff(BuffID.Venom, target.damage + target.life);
            target.AddBuff(BuffID.OnFire, target.damage + target.lifeMax);
            target.AddBuff(BuffID.Burning, target.damage + target.lifeRegen);
            target.AddBuff(BuffID.Poisoned, target.damage + target.lifeRegenCount);
            target.AddBuff(BuffID.ShadowFlame, target.damage + target.lifeRegenExpectedLossPerSecond);
            target.AddBuff(BuffID.CursedInferno, target.damage + target.realLife);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.pumpkinMoon)
            {
                return 0.09f;
            }
            else if (Main.snowMoon)
            {
                return 0.09f;
            }
            else if (Main.bloodMoon)
            {
                return 0.01f;
            }
            return 0.0f;
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            Item.NewItem((int)npc.velocity.X, (int)npc.position.Y,
                npc.width, npc.height, ItemID.Heart, 200);
            Item.NewItem((int)npc.velocity.X, (int)npc.velocity.Y,
                npc.width, npc.height, mod.ItemType("CodeFragments"), 9);
        }
    }
}
