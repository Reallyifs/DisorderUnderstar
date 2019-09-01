using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items.Disorder
{
    public class DisorderPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("无序·镐");
            Tooltip.SetDefault("【[c/FF0000:无序-Disorder]】\n" +
                "强大到足以摧毁所有方块。");
        }
        public override void SetDefaults()
        {
            item.crit = 55;
            item.pick = 3455;
            item.rare = 7;
            item.melee = true;
            item.scale = 1f;
            item.value = Item.sellPrice(0, 50, 0, 0);
            item.width = 36;
            item.damage = 1721;
            item.height = 36;
            item.expert = true;
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
            ModRecipe recipe3 = new ModRecipe(mod);
            recipe3.AddIngredient(ItemID.StardustPickaxe, 1);
            recipe3.AddIngredient(ItemID.VortexPickaxe, 1);
            recipe3.AddIngredient(ItemID.NebulaPickaxe, 1);
            recipe3.AddIngredient(ItemID.SolarFlarePickaxe, 1);
            recipe3.AddIngredient(ItemID.MoltenPickaxe, 1);
            recipe3.AddIngredient(ItemID.Drax, 1);
            recipe3.AddIngredient(ItemID.PickaxeAxe, 1);
            recipe3.AddIngredient(ItemID.ChlorophytePickaxe, 1);
            recipe3.AddIngredient(ItemID.ChlorophyteDrill, 1);
            recipe3.AddIngredient(ItemID.ShroomiteDiggingClaw, 1);
            recipe3.AddIngredient(mod, "DisorderBar", 11);
            recipe3.AddTile(TileID.LunarCraftingStation);
            recipe3.SetResult(this);
            recipe3.AddRecipe();
        }
    }
}