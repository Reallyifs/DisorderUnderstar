using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
namespace DisorderUnderstar.Items.Disorder
{
    public class DisorderAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Disorder ` Axe");
            DisplayName.AddTranslation(GameCulture.Chinese, "无序·斧");
            Tooltip.SetDefault("[Disorder]\n" +
                "Strong enough to destroy all wood");
            Tooltip.AddTranslation(GameCulture.Chinese, "【无序】\n" +
                "强大到足以摧毁所有木头。");
        }
        public override void SetDefaults()
        {
            item.axe = 691;
            item.crit = 55;
            item.rare = 7;
            item.melee = true;
            item.scale = 1f;
            item.value = Item.sellPrice(0, 50, 0, 0);
            item.width = 54;
            item.damage = 1722;
            item.expert = true;
            item.height = 54;
            item.useTime = 4;
            item.useTurn = true;
            item.maxStack = 1;
            item.useStyle = 1;
            item.autoReuse = true;
            item.knockBack = 3f;
            item.expertOnly = true;
            item.useAnimation = 15;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.LunarHamaxeStardust, 1);
            recipe1.AddIngredient(ItemID.LunarHamaxeVortex, 1);
            recipe1.AddIngredient(ItemID.LunarHamaxeNebula, 1);
            recipe1.AddIngredient(ItemID.LunarHamaxeSolar, 1);
            recipe1.AddIngredient(ItemID.MoltenHamaxe, 1);
            recipe1.AddIngredient(ItemID.ChlorophyteChainsaw, 1);
            recipe1.AddIngredient(ItemID.ChlorophyteGreataxe, 1);
            recipe1.AddIngredient(ItemID.HallowedBar, 9);
            recipe1.AddIngredient(ItemID.ShroomiteBar, 9);
            recipe1.AddIngredient(ModContent.ItemType<DisorderBar>(), 5);
            recipe1.AddTile(TileID.LunarCraftingStation);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}