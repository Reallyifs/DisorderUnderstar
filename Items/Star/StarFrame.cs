using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
namespace DisorderUnderstar.Items.Star
{
    public class StarFrame : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Frame");
            DisplayName.AddTranslation(GameCulture.Chinese, "星型框架");
            Tooltip.SetDefault("[Star]\n" +
                "Empty. What can I do with it?");
            Tooltip.AddTranslation(GameCulture.Chinese, "【星星】\n" +
                "空空的，应该能拿来做东西？");
        }
        public override void SetDefaults()
        {
            item.rare = 4;
            item.value = Item.sellPrice(0, 0, 5, 0);
            item.width = 40;
            item.height = 40;
            item.maxStack = 999;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod)
            {
                anyIronBar = true
            };
            recipe1.AddIngredient(ItemID.IronBar, 10);
            recipe1.AddIngredient(ItemID.MeteoriteBar, 4);
            recipe1.AddIngredient(ItemID.ManaCrystal, 1);
            recipe1.AddIngredient(ItemID.LifeCrystal, 1);
            recipe1.AddTile(TileID.Anvils);
            recipe1.SetResult(this, 8);
            recipe1.AddRecipe();
        }
    }
}