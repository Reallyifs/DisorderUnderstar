using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using DisorderUnderstar.Projectiles.Testament;
namespace DisorderUnderstar.Items.Testament
{
    public class OctoberOath : ModItem
    {
        private bool[] visited;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("十月誓言");
            Tooltip.SetDefault("【遗言-Testament】\n" +
                "-十月-\n" +
                "“在绝望的北端斩掉失色的紫罗兰。”\n" +
                "-\n" +
                "第十把剑，由Wedderst Stariver制作\n" +
                "普通人的一家、传奇般的经历造就了这把剑\n" +
                "虽然剑的主人已经逝去，而精神却是永存的\n" +
                "人们歌颂这精神，直到永远……\n" +
                "     ——摘自《人类历史》第五章\n" +
                "-");
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
                Player pl = Main.player[item.owner];
                foreach (NPC npc in Main.npc)
                {
                    if (npc.active && !npc.friendly && npc.type != NPCID.LunarTowerNebula && !visited[npc.whoAmI] &&
                        npc.type != NPCID.LunarTowerSolar && npc.type != NPCID.LunarTowerStardust && npc.type != NPCID.LunarTowerVortex)
                    {
                        float dis = Vector2.Distance(pl.Center, npc.Center);
                        if (disMAX >= dis) { tar = npc; }
                    }
                }
                if (tar != null)
                {
                    for (int _1 = 0; _1 < 6; _1++)
                    {
                        if (_1 % 2 == 0)
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
    }
}