using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items.Disorder
{
    public class DisorderBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("无序·锭");
            Tooltip.SetDefault("【无序-Disorder】\n"+
                "这些锭里散发出了许多能量，应该能拿来做些什么……");
        }
        public override void SetDefaults()
        {
            item.rare = 10;
            item.value = Item.buyPrice(6, 5, 4, 3);
            item.value = Item.sellPrice(5, 4, 3, 2);
            item.width = 28;
            item.expert = true;
            item.height = 22;
            item.maxStack = 999;
            item.expertOnly = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.FragmentStardust, 10);
            recipe1.AddIngredient(ItemID.FragmentVortex, 10);
            recipe1.AddIngredient(ItemID.FragmentNebula, 10);
            recipe1.AddIngredient(ItemID.FragmentSolar, 10);
            recipe1.AddIngredient(ItemID.LunarBar, 10);
            recipe1.AddIngredient(ItemID.ChlorophyteBar, 2);
            recipe1.AddIngredient(ItemID.ShroomiteBar, 2);
            recipe1.AddIngredient(ItemID.HallowedBar, 5);
            recipe1.AddIngredient(ItemID.HellstoneBar, 5);
            recipe1.AddIngredient(ItemID.Ectoplasm, 4);
            recipe1.AddTile(TileID.LunarCraftingStation);
            recipe1.SetResult(this, 6);
            recipe1.AddRecipe();
        }
    }
}