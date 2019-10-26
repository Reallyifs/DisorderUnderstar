using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items
{
    public class StartStarsStory : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("S式魔法线");
            Tooltip.SetDefault("你的魔力在增强！");
        }
        public override void SetDefaults()
        {
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.width = 18;
            item.height = 28;
            item.potion = true;
            item.useTime = 17;
            item.useTurn = true;
            item.healMana = 500;
            item.maxStack = 99;
            item.UseSound = SoundID.Item3;
            item.useStyle = 2;
            item.consumable = true;
            item.useAnimation = 17;
        }
        public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.MagicPower, +60000);
            player.AddBuff(BuffID.NebulaUpMana3, +60000);
            player.AddBuff(BuffID.ManaRegeneration, +60000);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.SuperManaPotion, 2);
            recipe1.AddIngredient(ItemID.BottledWater, 2);
            recipe1.AddIngredient(ItemID.Daybloom, 4);
            recipe1.AddIngredient(ItemID.Moonglow, 4);
            recipe1.AddIngredient(ItemID.Waterleaf, 4);
            recipe1.AddIngredient(ItemID.Fireblossom, 4);
            recipe1.AddIngredient(ItemID.FragmentVortex, 1);
            recipe1.AddIngredient(ItemID.FragmentNebula, 1);
            recipe1.AddIngredient(ItemID.FragmentSolar, 1);
            recipe1.AddIngredient(ItemID.FragmentStardust, 1);
            recipe1.SetResult(this, 2);
            recipe1.AddRecipe();
        }
    }
}
