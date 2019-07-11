using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items
{
	public class DXTBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("鬼畜之剑");
			Tooltip.SetDefault("够鬼畜吧！\n" +
				"虽然……哈？");
		}
		public override void SetDefaults()
		{
			item.crit = 50;
			item.rare = ItemRarityID.Purple;
			item.scale = 22f;
			item.melee = true;
            item.shoot = mod.ProjectileType("FalseBeam");
			item.value = Item.sellPrice(100, 0, 0, 0);
			item.width = 30;
			item.damage = 100;
			item.height = 30;
			item.useTime = 6;
            item.useTurn = true;
			item.maxStack = 1;
			item.UseSound = SoundID.Item1;
			item.useStyle = 1;
			item.autoReuse = true;
			item.knockBack = 8.25f;
            item.shootSpeed = 20f;
			item.useAnimation = 6;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe1 = new ModRecipe(mod);
			recipe1.AddIngredient(ItemID.Wood, 999);
            recipe1.AddIngredient(ItemID.StoneBlock, 999);
            recipe1.AddTile(TileID.Anvils);
			recipe1.SetResult(this);
			recipe1.AddRecipe();
		}
	}
}