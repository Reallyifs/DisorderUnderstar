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
			item.width = 40;
			item.damage = 123;
            item.expert = true;
			item.height = 38;
			item.ranged = true;
			item.noMelee = true;
            item.useAmmo = AmmoID.Bullet;
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
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0.0f, 0.0f);
        }
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.Next(10) < 9;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
            ref float knockBack)
        {
            #region 发射
            #region 弹药和设定
            int _1 = item.useAmmo;
            int _2 = ProjectileID.Bullet;
            int _3 = ProjectileID.ChlorophyteBullet;
            int _4 = 0;
            Vector2 _5 = new Vector2(player.Center.X, player.Center.Y);
            Vector2 _6 = Vector2.Normalize(Main.MouseWorld - _5) * item.shootSpeed;
            #endregion
            if (Main.rand.Next(0, 100) <= 33) _4 = _3;
            else if (Main.rand.Next(0, 100) <= 50) _4 = _2;
            else _4 = _1;
            Projectile.NewProjectile(_5, _6, _4, item.damage, item.knockBack, item.owner);
            #endregion
            return false;
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