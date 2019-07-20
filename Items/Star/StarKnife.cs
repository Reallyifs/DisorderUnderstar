using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items.Star
{
    public class StarKnife : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("星星之剑");
            Tooltip.SetDefault("【星星-Star】\n" +
                "“你确定这有用？”");
        }
        public override void SetDefaults()
        {
            item.crit = 20;
            item.rare = ItemRarityID.LightRed;
            item.melee = true;
            item.scale = 1.5f;
            item.value = Item.buyPrice(0, 3, 0, 0);
            item.value = Item.sellPrice(0, 1, 50, 0);
            item.width = 30;
            item.damage = 43;
            item.height = 30;
            item.useTime = 10;
            item.useStyle = 1;
            item.autoReuse = true;
            item.knockBack = 0.1f;
            item.useAnimation = 10;
        }
        public override bool Shoot
            (Player player, ref Vector2 position, ref float speedX, ref float speedY,
            ref int type, ref int damage, ref float knockBack)
        {
            NPC tar = null;
            Player pla = null;
            #region 对敌方的无差别全方位打击
            #region NPC
            foreach (NPC npc in Main.npc)
            {
                if (npc.active && !npc.friendly && npc.type != NPCID.LunarTowerNebula &&
                    npc.type != NPCID.LunarTowerSolar &&
                    npc.type != NPCID.LunarTowerStardust &&
                    npc.type != NPCID.LunarTowerVortex) tar = npc;
            }
            if (tar != null)
            {
                Vector2 NPCUpVEC = new Vector2(tar.Center.X, tar.position.Y - tar.height);
                Vector2 NPCToVEC = Vector2.Normalize(tar.Center - NPCUpVEC) * 10;
                Projectile.NewProjectile(NPCUpVEC, NPCToVEC,
                    mod.ProjectileType("StarDownStar"), item.damage, item.knockBack,
                    item.owner, tar.whoAmI);
            }
            #endregion
            #region PLAYER
            foreach (Player pl in Main.player)
            {
                if (pl.team != player.team && pl.statLife >= 100 && pl.statDefense >= 10)
                    pla = pl;
            }
            if (pla != null)
            {
                Vector2 PLAYERUpVEC = new Vector2(pla.Center.X, pla.position.Y - pla.height);
                Vector2 PLAYERToVEC = Vector2.Normalize(tar.Center - PLAYERUpVEC) * 10;
                Projectile.NewProjectile(PLAYERUpVEC, PLAYERToVEC,
                    mod.ProjectileType("StarDownStar"), item.damage, item.knockBack,
                    item.owner, pla.whoAmI);
            }
            #endregion
            #endregion
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe real = new ModRecipe(mod);
            real.AddIngredient(ItemID.Starfury, 1);
            real.AddIngredient(ItemID.Hellstone, 10);
            real.AddIngredient(mod, "StarFrame", 5);
            real.AddIngredient(ItemID.FallenStar,10);
            real.AddTile(TileID.Anvils);
            real.SetResult(this);
            real.AddRecipe();
        }
    }
}
