using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items.Disorder
{
    public class DisorderOmnipotence : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("无序·万能型");
            Tooltip.SetDefault("【[c/FF0000:无序-Disorder]】\n" +
                "集合了工具上的无序之力。");
        }
        public override void SetDefaults()
        {
            item.axe = 1199;
            item.crit = 65;
            item.pick = 5995;
            item.rare = ItemRarityID.Purple;
            item.melee = true;
            item.scale = 1f;
            item.value = Item.sellPrice(1, 0, 0, 0);
            item.width = 30;
            item.damage = 4695;
            item.expert = true;
            item.hammer = 5995;
            item.height = 36;
            item.useTime = 3;
            item.useTurn = true;
            item.maxStack = 1;
            item.useStyle = 1;
            item.autoReuse = true;
            item.knockBack = 3f;
            item.expertOnly = true;
            item.useAnimation = 60;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(mod.ItemType<DisorderPickaxe>(), 1);
            recipe1.AddIngredient(mod.ItemType<DisorderAxe>(), 1);
            recipe1.AddIngredient(mod.ItemType<DisorderHammer>(), 1);
            recipe1.AddIngredient(mod.ItemType<ChaoticSword>(), 1);
            recipe1.AddIngredient(ItemID.SpectreBar, 10);
            recipe1.AddIngredient(mod.ItemType<DisorderBar>(), 10);
            recipe1.AddTile(TileID.LunarCraftingStation);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}