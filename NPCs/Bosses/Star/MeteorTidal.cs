using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using DisorderUnderstar.Items.Star;
using DisorderUnderstar.Items.Star.BossBags;
using DisorderUnderstar.Projectiles.Star.Boss;
namespace DisorderUnderstar.NPCs.Bosses.Star
{
    public class MeteorTidal : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("流星潮汐");
        }
        public override void SetDefaults()
        {
            aiType = NPCID.SkeletronHead;
            npc.boss = true;
            npc.value = Item.buyPrice(0, 0, 31, 42);
            npc.width = 28;
            npc.height = 28;
            npc.lifeMax = 23000;
            npc.friendly = false;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0;
        }
        #region 迷之传送机制&发射弹幕
        public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit)
        {
            float _0 = 200;
            float _1 = Vector2.Distance(player.Center, Main.MouseWorld);
            Vector2 _2 = (Main.rand.NextFloatDirection() / 10f) * (Vector2.Normalize(player.Center - Main.MouseWorld) / 10);
            if (Main.rand.Next(1, 10) < 1) { npc.position = npc.Center = player.Center; }
            else if (_0 >= _1) { npc.position = npc.Center = _2; }
            else
            {
                Vector2 _3 = Vector2.Normalize(npc.Center - player.Center) * 30;
                Projectile.NewProjectile(npc.Center, _3, mod.ProjectileType<ProStarStardust>(), 240, 1f, npc.whoAmI);
            }
        }
        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            float _0 = 200;
            float _1 = Vector2.Distance(player.Center, Main.MouseWorld);
            Vector2 _2 = (Main.rand.NextFloatDirection() / 10f) * (Vector2.Normalize(player.Center - Main.MouseWorld) / 10);
            if (Main.rand.Next(1, 10) < 1) { npc.position = npc.Center = player.Center; }
            else if (_0 >= _1) { npc.position = npc.Center = _2; }
            else
            {
                Vector2 _3 = Vector2.Normalize(npc.Center - player.Center) * 30;
                Projectile.NewProjectile(npc.Center, _3, mod.ProjectileType<ProStarStardust>(), 240, 1f, npc.whoAmI);
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            float _0 = 200;
            float _1 = Vector2.Distance(target.Center, Main.MouseWorld);
            Vector2 _2 = (Main.rand.NextFloatDirection() / 10f) * (Vector2.Normalize(target.Center - Main.MouseWorld) / 10);
            if (Main.rand.Next(1, 10) < 1) { npc.position = npc.Center = target.Center; }
            else if (_0 >= _1)
            {
                npc.position = npc.Center = _2;
                target.AddBuff(BuffID.Silenced, damage);
                if (target.statLife >= target.statLifeMax2 / 4) target.statLife -= target.statLifeMax2 / 8;
            }
            else
            {
                Vector2 _3 = Vector2.Normalize(npc.Center - target.Center) * 30;
                Projectile.NewProjectile(npc.Center, _3, mod.ProjectileType<ProStarStardust>(), 240, 1f, npc.whoAmI);
            }
        }
        #endregion
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.HealingPotion;
        }
        public override void NPCLoot()
        {
            Player pl = Main.player[npc.target];
            if (Main.expertMode)
            {
                Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType<MeteorTidalBossBag>(), 1);
                if (Main.rand.Next(0, 100) < 1 && pl.ZoneCorrupt)
                {
                    Main.NewText("环绕着星空的碎片降于这个世界！", Color.LightYellow);
                    Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType<SurroundStar>(), 1);
                }
                if (Main.rand.Next(0, 100) < 1 && pl.ZoneCrimson)
                {
                    Main.NewText("环绕着星空的碎片降于这个世界！", Color.LightYellow);
                    Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType<StarSurround>(), 1);
                }
            }
            else
            {
                Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType<StarFrame>(), 3);
            }
        }
    }
}
