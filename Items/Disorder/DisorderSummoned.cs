using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
// using DisorderUnderstar.Events;
namespace DisorderUnderstar.Items.Disorder
{
    public class DisorderSummoned : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Disorder ` Chaotic Crystals");
            DisplayName.AddTranslation(GameCulture.Chinese, "无序·混乱晶体");
            Tooltip.SetDefault("[[c/FF0000:Disorder]]\n" +
                "The energy it emits...\n" +
                "Let you shiver...\n" +
                "\"I'm BACK.\"\n" +
                "-\n" +
                "Summon [Disorder ` Eschatology]\n" +
                "-\n" +
                "Can't use now.\n" +
                "Coming s∞n.\n" +
                "-");
            Tooltip.AddTranslation(GameCulture.Chinese, "【[c/FF0000:无序]】\n" +
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
            item.useStyle = 4;
            item.maxStack = 10;
            item.expertOnly = true;
        }
        public override bool UseItem(Player player)
        {
            /*
            if (LunarEclipse.符合事件出现条件_月蚀())
            {
                item.stack -= 1;
                LunarEclipse.使用月蚀耀碑 = true;
            }
            */
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe rs = new ModRecipe(mod);
            rs.AddIngredient(ModContent.ItemType<DisorderBar>(), 10);
            rs.AddIngredient(ItemID.CelestialSigil, 1);
            rs.AddIngredient(ItemID.GuideVoodooDoll, 1);
            rs.AddIngredient(item.type, 999999);
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