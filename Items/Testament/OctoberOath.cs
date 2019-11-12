using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using DisorderUnderstar.Projectiles.Testament;
namespace DisorderUnderstar.Items.Testament
{
    public class OctoberOath : ModItem
    {
        private bool[] visited;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("October Oath");
            DisplayName.AddTranslation(GameCulture.Chinese, "十月誓言");
            Tooltip.SetDefault("[Testament]\n" +
                "-October-\n" +
                "\"Cut off the lost violets at the north end of despair.\"\n" +
                "Attack enemy and release 5 Lightsaber");
            Tooltip.SetDefault("【遗言】\n" +
                "-十月-\n" +
                "“在绝望的北端斩掉失色的紫罗兰。”\n" +
                "砍中敌人将释放5个光剑");
        }
        public override void SetDefaults()
        {
            item.crit = 10;
            item.rare = ItemRarityID.Red;
            item.melee = true;
            item.scale = 1f;
            item.value = Item.sellPrice(0, 10, 10, 10);
            item.width = 56;
            item.damage = 10;
            item.height = 56;
            item.useTime = 10;
            item.maxStack = 1;
            item.useStyle = 1;
            item.autoReuse = true;
            item.knockBack = 5f;
            item.shootSpeed = 10f;
            item.useAnimation = 10;
            visited = new bool[Main.npc.Length];
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            for (int _0 = 0; _0 < 5; _0++)
            {
                NPC tar = null;
                float disMAX = 750;
                foreach (NPC npc in Main.npc)
                {
                    if (npc.active && !npc.friendly && npc.type != NPCID.LunarTowerNebula && !visited[npc.whoAmI] &&
                        npc.type != NPCID.LunarTowerSolar && npc.type != NPCID.LunarTowerStardust && npc.type != NPCID.LunarTowerVortex)
                    {
                        float dis = Vector2.Distance(player.Center, npc.Center);
                        if (disMAX >= dis) { tar = npc; }
                    }
                }
                if (tar != null)
                {
                    Vector2 positionVEC = new Vector2(tar.Center.X, tar.Center.Y - tar.height * 3);
                    Vector2 shootVEC = Vector2.Normalize(tar.Center - positionVEC) * 100;
                    Projectile.NewProjectile(positionVEC, shootVEC, ModContent.ProjectileType<ProTestamentLightsaber>(), item.damage,
                        item.knockBack, item.owner, item.type);
                }
            }
        }
    }
}