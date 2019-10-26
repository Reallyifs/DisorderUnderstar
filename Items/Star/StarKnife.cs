using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using DisorderUnderstar.Projectiles.Star;
namespace DisorderUnderstar.Items.Star
{
    public class StarKnife : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Knife");
            DisplayName.AddTranslation(GameCulture.Chinese, "星星之剑");
            Tooltip.SetDefault("[Star]\n" +
                "\"Hope is in hand.\"");
            Tooltip.AddTranslation(GameCulture.Chinese, "【星星】\n" +
                "“手握希望。”");
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
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
            ref float knockBack)
        {
            #region 对敌方的无差别全方位打击
            #region NPC
            NPC _1 = null;
            foreach (NPC _2 in Main.npc)
            {
                if (_2.active && !_2.friendly && _2.type != NPCID.LunarTowerNebula && _2.type != NPCID.LunarTowerSolar &&
                    _2.type != NPCID.LunarTowerStardust && _2.type != NPCID.LunarTowerVortex) { _1 = _2; }
            }
            if (_1 != null)
            {
                Vector2 _3 = new Vector2(_1.Center.X, _1.position.Y - _1.height);
                Vector2 _4 = Vector2.Normalize(_1.Center - _3) * 10 * _1.velocity;
                Projectile.NewProjectile(_3, _4, ModContent.ProjectileType<ProStarDownStar>(), item.damage, item.knockBack, item.owner, _1.whoAmI);
            }
            #endregion
            #region PLAYER
            Player _5 = null;
            foreach (Player _6 in Main.player)
            {
                if (_6.team != player.team && _6.statLife >= 100 && _6.statDefense >= 10) { _5 = _6; }
            }
            if (_5 != null)
            {
                Vector2 _7 = new Vector2(_5.Center.X, _5.position.Y - _5.height);
                Vector2 _8 = Vector2.Normalize(_1.Center - _7) * 10 * _5.velocity;
                Projectile.NewProjectile(_7, _8, ModContent.ProjectileType<ProStarDownStar>(), item.damage, item.knockBack, item.owner, _5.whoAmI);
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
            real.AddIngredient(ModContent.ItemType<StarFrame>(), 5);
            real.AddIngredient(ItemID.FallenStar,10);
            real.AddTile(TileID.Anvils);
            real.SetResult(this);
            real.AddRecipe();
        }
    }
}
