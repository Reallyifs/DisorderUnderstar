using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using DisorderUnderstar.Tools;
using Microsoft.Xna.Framework;
using DisorderUnderstar.Projectiles.Disorder;
namespace DisorderUnderstar.Items.Disorder
{
    public class ChaoticSword : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chaotic Sword");
            DisplayName.AddTranslation(GameCulture.Chinese, "无序大剑");
            Tooltip.SetDefault("[Disorder]\n" +
                "Strong enough to defeat all enemies.");
            Tooltip.AddTranslation(GameCulture.Chinese, "【无序】\n" +
                "强大到可以打败所有敌人。");
        }
        public override void SetDefaults()
        {
            item.crit = 60;
            item.rare = ItemRarityID.Red;
            item.melee = true;
            item.scale = 1.1f;
            item.shoot = ModContent.ProjectileType<ProDisorderBeam>();
            item.value = Item.sellPrice(5, 5, 10, 10);
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
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            #region 粒子设定
            int dINT;
            int rINT = Main.rand.Next(1, 3);
            if (rINT == 1) { dINT = MyDustId.OrangeFire1; }
            else if(rINT == 2) { dINT = MyDustId.PurpleLight; }
            else if(rINT == 3) { dINT = MyDustId.DarkBluePinkLight; }
            else { dINT = MyDustId.BlueCircle; }
            #endregion
            Dust.NewDust(player.Center, hitbox.Width, hitbox.Height, dINT, player.velocity.X / 3, player.velocity.Y / 3, Main.rand.Next(100, 200),
                Color.White, Main.rand.NextFloat(0.8f, 1.2f));
        }
        public override void AddRecipes()
        {
            ModRecipe _0 = new ModRecipe(mod);
            _0.AddIngredient(ItemID.StardustDragonStaff, 1);
            _0.AddIngredient(ItemID.StardustCellStaff, 1);
            _0.AddIngredient(ItemID.Phantasm, 1);
            _0.AddIngredient(ItemID.VortexBeater, 1);
            _0.AddIngredient(ItemID.NebulaArcanum, 1);
            _0.AddIngredient(ItemID.NebulaBlaze, 1);
            _0.AddIngredient(ItemID.SolarEruption, 1);
            _0.AddIngredient(ItemID.DayBreak, 1);
            _0.AddRecipeGroup("钯金或钴蓝剑", 1);
            _0.AddIngredient(ModContent.ItemType<DisorderBar>(), 10);
            _0.AddTile(TileID.LunarCraftingStation);
            _0.SetResult(this);
            _0.AddRecipe();
        }
    }
}