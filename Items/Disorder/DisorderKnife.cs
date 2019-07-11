using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items.Disorder
{
    public class DisorderKnife : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("无序·剑");
            Tooltip.SetDefault("【无序-Disorder】\n" +
                "强大到可以打败所有敌人。");
        }
        public override void SetDefaults()
        {
            item.crit = 60;
            item.rare = ItemRarityID.Red;
            item.melee = true;
            item.scale = 1.1f;
            item.shoot = mod.ProjectileType("ProDisorderBeam");
            item.value = Item.sellPrice(10, 10, 10, 10);
            item.width = 56;
            item.damage = 3440;
            item.height = 56;
            item.useTime = 8;
            item.maxStack = 1;
            item.useStyle = 1;
            item.autoReuse = true;
            item.knockBack = 2f;
            item.expertOnly = true;
            item.shootSpeed = 20f;
            item.useAnimation = 8;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            ModRecipe recipe0 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.StardustDragonStaff, 1);
            recipe1.AddIngredient(ItemID.StardustCellStaff, 1);
            recipe1.AddIngredient(ItemID.Phantasm, 1);
            recipe1.AddIngredient(ItemID.VortexBeater, 1);
            recipe1.AddIngredient(ItemID.NebulaArcanum, 1);
            recipe1.AddIngredient(ItemID.NebulaBlaze, 1);
            recipe1.AddIngredient(ItemID.SolarEruption, 1);
            recipe1.AddIngredient(ItemID.DayBreak, 1);
            recipe1.AddIngredient(ItemID.Meowmere, 1);
            recipe1.AddIngredient(ItemID.CobaltSword, 1);
            recipe1.AddIngredient(mod, "DisorderBar", 20);
            recipe0.AddIngredient(ItemID.StardustDragonStaff, 1);
            recipe0.AddIngredient(ItemID.StardustCellStaff, 1);
            recipe0.AddIngredient(ItemID.Phantasm, 1);
            recipe0.AddIngredient(ItemID.VortexBeater, 1);
            recipe0.AddIngredient(ItemID.NebulaArcanum, 1);
            recipe0.AddIngredient(ItemID.NebulaBlaze, 1);
            recipe0.AddIngredient(ItemID.SolarEruption, 1);
            recipe0.AddIngredient(ItemID.DayBreak, 1);
            recipe0.AddIngredient(ItemID.Meowmere, 1);
            recipe0.AddIngredient(ItemID.PalladiumSword, 1);
            recipe0.AddIngredient(mod, "DisorderBar", 20);
            recipe1.AddTile(TileID.LunarCraftingStation);
            recipe0.AddTile(TileID.LunarCraftingStation);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
            recipe0.SetResult(this);
            recipe0.AddRecipe();
        }
    }
}