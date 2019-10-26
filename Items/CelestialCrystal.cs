using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using DisorderUnderstar.Projectiles;
namespace DisorderUnderstar.Items
{
    public class CelestialCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Celestial Crystal");
            DisplayName.AddTranslation(GameCulture.Chinese, "天体水晶");
            Tooltip.SetDefault("Expectation.");
            Tooltip.AddTranslation(GameCulture.Chinese, "展望。");
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.mana = 3;
            item.rare = ItemRarityID.Red;
            item.magic = true;
            item.shoot = ModContent.ProjectileType<ProRainbowLighting>();
            item.value = Item.sellPrice(0, 40, 0, 0);
            item.width = 38;
            item.damage = 150;
            item.height = 38;
            item.useTime = 3;
            item.channel = true;
            item.noMelee = true;
            item.useStyle = 5;
            item.UseSound = SoundID.Item78;
            item.knockBack = 6f;
            item.shootSpeed = 40f;
            item.useAnimation = 3;
        }
        public override void AddRecipes()
        {
            ModRecipe a = new ModRecipe(mod);
            a.AddIngredient(ItemID.RainbowCrystalStaff);
            a.AddIngredient(ItemID.LastPrism);
            a.AddIngredient(ItemID.FragmentVortex, 18);
            a.AddTile(TileID.LunarCraftingStation);
            a.SetResult(this);
            a.AddRecipe();
        }
    }
}
