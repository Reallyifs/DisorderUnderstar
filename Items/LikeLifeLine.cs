using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items
{
    public class LikeLifeLine : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("L式生命线");
            Tooltip.SetDefault("你的生命力在增强！");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Lime;
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.width = 18;
            item.height = 28;
            item.potion = true;
            item.useTime = 17;
            item.useTurn = true;
            item.healLife = 1000;
            item.maxStack = 99;
            item.UseSound = SoundID.Item3;
            item.useStyle = 2;
            item.consumable = true;
            item.useAnimation = 17;
        }
        public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Ironskin, +60000);
            player.AddBuff(BuffID.Lifeforce, +60000);
            player.AddBuff(BuffID.NebulaUpLife3, +60000);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.SuperHealingPotion, 1);
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