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
            item.shoot = ProjectileID.FallingStar;
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
