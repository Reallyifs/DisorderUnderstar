using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using DisorderUnderstar.Items.Code;
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
            npc.width = 10;
            npc.height = 10;
            npc.defense = 0;
            npc.lifeMax = 9999999;
            if (npc.defense == 0)
            {
                npc.lifeRegen += 100;
                npc.defense += 1;
            }
            if (npc.timeLeft >= 6000)
            {
                if (npc.defense >= 1)
                {
                    npc.defense -= 1;
                    npc.lifeRegen -= 99;
                }
            }
            if (npc.lifeRegen >= 50)
            {
                npc.defense = 0;
                npc.damage = 999999999;
                npc.lifeRegen += 999999999;
            }
        }
        public override void AI()
        {
            for(int i = 0; i < Main.maxBuffTypes; i++)
            {
                npc.buffImmune[i] = true;
                foreach(Player player in Main.player)
                {
                    player.statLife--;
                }
            }
            Player player1 = Main.player[npc.target];
            if (player1.dead) { npc.life = int.MinValue; }
        }
        public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit)
        {
            item.crit -= 999999999;
            item.mana += 999999999;
            item.magic = true;
            item.melee = true;
            item.value = Item.sellPrice(0, 0, 0, 1);
            item.value += Item.buyPrice(999999999, 999999999, 999999999, 999999999);
            item.damage -= 999999999;
            item.ranged = false;
            item.summon = false;
            item.thrown = false;
            item.noMelee = true;
            item.notAmmo = true;
            item.useAmmo = AmmoID.Arrow;
            item.useAmmo = AmmoID.Bullet;
            item.useTime += 999999999;
            item.useStyle = 4;
            item.autoReuse = false;
            item.knockBack -= 999999999;
            item.useAnimation += 999999999;
            player.dead = true;
            player.statLife = 0;
            player.lifeRegen -= 999999999;
            player.maxMinions = 0;
            player.statLifeMax2 = 1;
            player.statManaMax2 = 1;
            player.KillMe(PlayerDeathReason.ByCustomReason(player.name + "的大剑反打了自己"), 9999, 0);
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.dead = true;
            target.statLife = 0;
            target.lifeRegen -= 999999999;
            target.magicCrit -= 999999999;
            target.maxMinions = 0;
            target.meleeSpeed += 999999999;
            target.meleeDamage -= 999999999;
            target.statLifeMax2 = 1;
            target.statManaMax2 = 1;
            target.KillMe(PlayerDeathReason.ByCustomReason(target.name + "被虚空的力量扭曲了。"), 9999, 0);
        }
        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            Player pl = Main.player[projectile.owner];
            pl.dead = true;
            pl.statLife = 0;
            projectile.magic = true;
            projectile.melee = false;
            projectile.damage = 0;
            projectile.minion = false;
            projectile.ranged = false;
            projectile.thrown = false;
            projectile.knockBack = 0f;
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
            return 0.0f;
        }
        public override void NPCLoot()
        {
            Player player = Main.player[npc.target];
            if (player.statLife < player.statLifeMax)
            {
                Item.NewItem((int)npc.velocity.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Heart, 200);
                Item.NewItem((int)npc.velocity.X, (int)npc.velocity.Y, npc.width, npc.height, ModContent.ItemType<CodeFragments>(), 9);
            }
            else
            {
                for (float f = float.NegativeInfinity; f < float.PositiveInfinity; f += float.Epsilon)
                {
                    Dust.NewDust(npc.Center, 1, 1, 1, 1, 1, 1, new Microsoft.Xna.Framework.Color(1, 1, 1), 1);
                }
            }
        }
    }
}