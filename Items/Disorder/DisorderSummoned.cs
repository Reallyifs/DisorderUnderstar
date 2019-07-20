using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items.Disorder
{
    public class DisorderSummoned : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("无序·混乱晶体");
            Tooltip.SetDefault("【无序-Disorder】\n" +
                "它发出的能量……\n" +
                "让你不寒而栗……\n" +
                "“我，回来了。”\n" +
                "-\n" +
                "召唤[无序·恐惧症]\n" +
                "-\n" +
                "目前因为作者的咕咕咕，所以此物品暂不能使用。\n" +
                "敬请期待。\n" +
                "-");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Red;
            item.value = Item.buyPrice(0, 60, 99, 99);
            item.value = Item.sellPrice(0, 30, 99, 99);
            item.width = 28;
            item.height = 58;
            item.maxStack = 10;
            item.expertOnly = true;
        }
        public override void AddRecipes()
        {
            ModRecipe rs = new ModRecipe(mod);
            rs.AddIngredient(mod, "DisorderBar", 10);
            rs.AddIngredient(ItemID.CelestialSigil, 1);
            rs.AddIngredient(ItemID.GuideVoodooDoll, 1);
            rs.AddIngredient(mod, "DisorderSummoned", 999999);
            rs.AddTile(TileID.LunarCraftingStation);
            rs.AddTile(TileID.Tables);
            rs.AddTile(TileID.Chairs);
            rs.SetResult(this, 1);
            rs.AddRecipe();

            rs = new ModRecipe(mod);
            rs.AddIngredient(ItemID.WoodWall, 1);
            rs.SetResult(this, 10);
            rs.AddRecipe();
        }
    }
}