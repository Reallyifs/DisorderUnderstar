using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using DisorderUnderstar.PeripateticismMod.Projectiles;
namespace DisorderUnderstar.PeripateticismMod.Items
{
    public class PurpleShao : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Purple Shao");
            DisplayName.AddTranslation(GameCulture.Chinese, "紫绍");
            Tooltip.SetDefault("Starcloud.");
            Tooltip.AddTranslation(GameCulture.Chinese, "星之云。");
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.crit = 20;
            item.mana = 16;
            item.magic = true;
            item.scale = 0.9f;
            item.shoot = ModContent.ProjectileType<ProPurpleShao1>();
            item.value = Item.sellPrice(0, 1, 49, 99);
            item.width = 58;
            item.damage = 118;
            item.height = 58;
            item.useTime = 42;
            item.knockBack = 1f;
            item.shootSpeed = 20;
            item.useAnimation = 42;
        }
        public override void AddRecipes()
        {
            ModRecipe Reallyifs = new ModRecipe(mod)
            {
                anyIronBar = true
            };
            Reallyifs.AddIngredient(ItemID.IronBar, 30);
            Reallyifs.AddIngredient(ItemID.SpiderFang, 4);
            Reallyifs.AddIngredient(ItemID.AmethystStaff, 1);
            Reallyifs.AddIngredient(ItemID.SpaceGun, 1);
            Reallyifs.AddTile(TileID.Anvils);
            Reallyifs.SetResult(this);
            Reallyifs.AddRecipe();
        }
    }
}
