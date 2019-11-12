using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
namespace DisorderUnderstar.Items.Disorder
{
    public class DisorderHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Disorder ` Hammer");
            DisplayName.AddTranslation(GameCulture.Chinese, "无序·锤");
            Tooltip.SetDefault("[Disorder]\n" +
                "Strong enough to destroy all walls.");
            Tooltip.AddTranslation(GameCulture.Chinese, "【无序】\n" +
                "强大到足以摧毁所有墙壁。");
        }
        public override void SetDefaults()
        {
            item.rare = 7;
            item.melee = true;
            item.scale = 1f;
            item.value = Item.sellPrice(0, 50, 0, 0);
            item.width = 44;
            item.height = 44;
            item.damage = 1723;
            item.hammer = 3455;
            item.useTime = 4;
            item.useTurn = true;
            item.maxStack = 1;
            item.useStyle = 1;
            item.knockBack = 3f;
            item.autoReuse = true;
            item.useAnimation = 15;
        }
        public override void AddRecipes()
        {
            ModRecipe _0 = new ModRecipe(mod);
            _0.AddIngredient(ItemID.LunarHamaxeStardust, 1);
            _0.AddIngredient(ItemID.LunarHamaxeVortex, 1);
            _0.AddIngredient(ItemID.LunarHamaxeNebula, 1);
            _0.AddIngredient(ItemID.LunarHamaxeSolar, 1);
            _0.AddIngredient(ItemID.MoltenHamaxe, 1);
            _0.AddIngredient(ItemID.ChlorophyteWarhammer, 1);
            _0.AddIngredient(ItemID.ChlorophyteJackhammer, 1);
            _0.AddIngredient(ItemID.HallowedBar, 9);
            _0.AddIngredient(ItemID.ShroomiteBar, 9);
            _0.AddIngredient(ModContent.ItemType<DisorderBar>(), 5);
            _0.AddTile(TileID.LunarCraftingStation);
            _0.SetResult(this);
            _0.AddRecipe();
        }
    }
}
