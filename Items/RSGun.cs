using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Items
{
	public class RSGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("RS之枪");
			Tooltip.SetDefault("它非常有用！恭喜你！\n" +
                "甚至可以用到钢铁三王后（不是）\n" +
                "(ノ｀Д)ノ");
		}
		public override void SetDefaults()
		{
			item.crit = 50;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(100, 100, 100, 99);
			item.scale = 1f;
			item.shoot = ProjectileID.ChlorophyteBullet;
			item.width = 40;
			item.damage = 123;
            item.expert = true;
			item.height = 38;
			item.ranged = true;
			item.noMelee = true;
			item.useTime = 6;
            item.useTurn = true;
			item.maxStack = 1;
            item.UseSound = null;
			item.useStyle = 5;
			item.autoReuse = true;
			item.knockBack = 19.5f;
			item.shootSpeed = 20f;
			item.useAnimation = 6;
		}
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.Next(10) < 9;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0.0f, 0.0f);
        }
        public override void AddRecipes()
		{
            ModRecipe recipe1 = new ModRecipe(mod)
            {
                anyIronBar = true
            };
            recipe1.AddIngredient(ItemID.Wood, 40);
            recipe1.AddIngredient(ItemID.StoneBlock, 20);
            recipe1.AddIngredient(ItemID.IronBar, 15);
            recipe1.AddIngredient(ItemID.FallenStar, 25);
            recipe1.AddIngredient(ItemID.MusketBall, 499);
            recipe1.AddTile(TileID.Hellforge);
			recipe1.SetResult(this);
			recipe1.AddRecipe();
		}
	}
}