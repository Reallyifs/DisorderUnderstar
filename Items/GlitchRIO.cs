using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items
{
    public class GlitchRIO : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glitch R.I.O.");
            Tooltip.SetDefault("Glitch S.I.O的老弟\n" +
                "离最后只有一秒之差。");
        }
        public override void SetDefaults()
        {
            item.crit = 50;
            item.rare = ItemRarityID.Pink;
            item.scale = 1f;
            item.shoot = ProjectileID.HolyArrow;
            item.value = Item.sellPrice(1, 1, 1, 1);
            item.width = 43;
            item.damage = 100;
            item.height = 54;
            item.ranged = true;
            item.noMelee = true;
            item.useTime = 30;
            item.maxStack = 1;
            item.useStyle = 5;
            item.autoReuse = true;
            item.knockBack = 19.5f;
            item.shootSpeed = 20f;
            item.useAnimation = 30;
        }
        public override bool ConsumeAmmo(Player player)
        {
            item.useAmmo = AmmoID.Arrow;
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.Wood, 33);
            recipe1.AddIngredient(ItemID.StoneBlock, 33);
            recipe1.AddIngredient(ItemID.FallenStar, 11);
            recipe1.AddIngredient(ItemID.HellstoneBar, 11);
            recipe1.AddTile(TileID.WorkBenches);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}