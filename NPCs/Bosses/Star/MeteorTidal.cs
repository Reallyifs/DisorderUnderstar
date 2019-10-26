using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
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
            DisplayName.SetDefault("Meteor Tidal");
            DisplayName.AddTranslation(GameCulture.Chinese, "流星潮汐");
        }
        public override void SetDefaults()
        {
            music = MusicID.Boss4;
            aiType = NPCID.SkeletronHead;
            bossBag = ModContent.ItemType<MeteorTidalBossBag>();
            npc.boss = true;
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
            float _0 = 100;
            float _1 = Vector2.Distance(player.Center, Main.MouseWorld);
            if (Main.rand.Next(1, 10) < 1) { npc.position = npc.Center = player.Center; }
            else if (_0 >= _1)
            {
                Vector2 _2 = (Main.rand.NextFloatDirection() / 10f) * (Vector2.Normalize(player.Center - Main.MouseWorld) / 10);
                npc.position = npc.Center = _2;
            }
            else
            {
                Vector2 _3 = Vector2.Normalize(npc.Center - player.Center) * 30;
                Projectile.NewProjectile(npc.Center, _3, ModContent.ProjectileType<ProStarStardust>(), 240, 1f, npc.whoAmI, player.whoAmI);
            }
        }
        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            float _0 = 100;
            float _1 = Vector2.Distance(player.Center, Main.MouseWorld);
            if (Main.rand.Next(1, 10) < 1) { npc.position = npc.Center = player.Center; }
            else if (_0 >= _1)
            {
                Vector2 _2 = (Main.rand.NextFloatDirection() / 10f) * (Vector2.Normalize(player.Center - Main.MouseWorld) / 10);
                npc.position = npc.Center = _2;
            }
            else
            {
                Vector2 _3 = Vector2.Normalize(npc.Center - player.Center) * 30;
                Projectile.NewProjectile(npc.Center, _3, ModContent.ProjectileType<ProStarStardust>(), 240, 1f, npc.whoAmI, player.whoAmI);
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            float _0 = 100;
            float _1 = Vector2.Distance(target.Center, Main.MouseWorld);
            if (Main.rand.Next(1, 10) < 1) { npc.position = npc.Center = target.Center; }
            else if (_0 >= _1)
            {
                Vector2 _2 = (Main.rand.NextFloatDirection() / 10f) * (Vector2.Normalize(target.Center - Main.MouseWorld) / 10);
                npc.position = npc.Center = _2;
                target.AddBuff(BuffID.Silenced, damage);
                if (target.statLife >= target.statLifeMax2 / 4) { target.statLife -= target.statLifeMax2 / 8; }
            }
            else
            {
                Vector2 _3 = Vector2.Normalize(npc.Center - target.Center) * 30;
                Projectile.NewProjectile(npc.Center, _3, ModContent.ProjectileType<ProStarStardust>(), 240, 1f, npc.whoAmI, target.whoAmI);
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
                npc.DropBossBags();
                if (Main.rand.Next(0, 1000) < 1 && pl.ZoneCorrupt)
                {
                    Main.NewText("环绕着星空的碎片降于这个世界！", Color.LightYellow);
                    Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, ModContent.ItemType<SurroundStar>(), 1);
                }
                if (Main.rand.Next(0, 1000) < 1 && pl.ZoneCrimson)
                {
                    Main.NewText("环绕着星空的碎片降于这个世界！", Color.LightYellow);
                    Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, ModContent.ItemType<StarSurround>(), 1);
                }
            }
            else
            {
                Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, ModContent.ItemType<StarFrame>(), Main.rand.Next(1, 3));
                Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, ItemID.CopperCoin, Main.rand.Next(10, 31));
                Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, ItemID.SilverCoin, Main.rand.Next(20, 42));
                if (Main.rand.Next(0, 1000) <= 0)
                {
                    Main.NewText("一颗怪异的星星落了下来", Color.LightSkyBlue);
                    Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, ModContent.ItemType<GalaxyLight>(), 1);
                }
                else
                {
                    if (Main.rand.Next(0, 10000) < 1 && pl.ZoneCorrupt && pl.statLife >= pl.statLifeMax2 / 10)
                    {
                        Main.NewText("环绕着星空的碎片降于这个世界！", Color.LightYellow);
                        Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, ModContent.ItemType<SurroundStar>(), 1);
                    }
                    if (Main.rand.Next(0, 10000) < 1 && pl.ZoneCrimson && pl.statLife >= pl.statLifeMax2 / 10)
                    {
                        Main.NewText("环绕着星空的碎片降于这个世界！", Color.LightYellow);
                        Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, ModContent.ItemType<StarSurround>(), 1);
                    }
                }
            }
        }
    }
}