using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace DisorderUnderstar.Items.Disorder
{
    public class DisorderBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Disorder ` Bar");
            DisplayName.AddTranslation(GameCulture.Chinese, "无序·锭");
            Tooltip.SetDefault("[Disorder]\n" +
                "There is a lot of energy in these ingots, what should be used for...");
            Tooltip.AddTranslation(GameCulture.Chinese, "【无序】\n" +
                "这些锭里散发出了许多能量，应该能拿来做些什么……");
            if (item.stack == 1)
            {
                Tooltip.SetDefault("[Disorder]\n" +
                    "There is a lot of energy in this ingot, what should be used for...\n" +
                    "But... Not enough...");
                Tooltip.AddTranslation(GameCulture.Chinese, "【无序】\n" +
                    "这个锭里散发出了许多能量，应该能拿来做些什么……\n" +
                    "但是……还不够……");
            }
        }
        public override void SetDefaults()
        {
            item.rare = 10;
            item.value = Item.sellPrice(4, 3, 2, 1);
            item.width = 28;
            item.expert = true;
            item.height = 22;
            item.maxStack = 999;
            item.expertOnly = true;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color((byte)Main.DiscoR, (byte)Main.DiscoG, (byte)Main.DiscoB, Main.mouseTextColor);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.FragmentStardust, 3);
            recipe1.AddIngredient(ItemID.FragmentVortex, 3);
            recipe1.AddIngredient(ItemID.FragmentNebula, 3);
            recipe1.AddIngredient(ItemID.FragmentSolar, 3);
            recipe1.AddIngredient(ItemID.LunarBar, 3);
            recipe1.AddIngredient(ItemID.ChlorophyteBar, 1);
            recipe1.AddIngredient(ItemID.ShroomiteBar, 1);
            recipe1.AddIngredient(ItemID.HallowedBar, 2);
            recipe1.AddIngredient(ItemID.HellstoneBar, 2);
            recipe1.AddIngredient(ItemID.Ectoplasm, 1);
            recipe1.AddTile(TileID.LunarCraftingStation);
            recipe1.SetResult(this, 2);
            recipe1.AddRecipe();
        }
    }
}