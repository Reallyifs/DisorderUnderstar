using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items.Disorder
{
    public class DisorderHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("无序·锤");
            Tooltip.SetDefault("【无序-Disorder】\n" +
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
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.LunarHamaxeStardust, 1);
            recipe1.AddIngredient(ItemID.LunarHamaxeVortex, 1);
            recipe1.AddIngredient(ItemID.LunarHamaxeNebula, 1);
            recipe1.AddIngredient(ItemID.LunarHamaxeSolar, 1);
            recipe1.AddIngredient(ItemID.MoltenHamaxe, 1);
            recipe1.AddIngredient(ItemID.ChlorophyteWarhammer, 1);
            recipe1.AddIngredient(ItemID.ChlorophyteJackhammer, 1);
            recipe1.AddIngredient(ItemID.HallowedBar, 9);
            recipe1.AddIngredient(ItemID.ShroomiteBar, 9);
            recipe1.AddIngredient(mod, "DisorderBar", 5);
            recipe1.AddTile(TileID.LunarCraftingStation);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}
