using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
namespace DisorderUnderstar.Items.Star
{
    public class StarMana : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Mana");
            DisplayName.AddTranslation(GameCulture.Chinese, "星之魔法");
            Tooltip.SetDefault("[Star]\n" +
                "\"Call the stars from the book!\"");
            Tooltip.SetDefault("【星星】\n" +
                "“从书中召唤天上的星星！”");
        }
        public override void SetDefaults()
        {
            item.crit = 39;
            item.mana = 4;
            item.rare = ItemRarityID.LightPurple;
            item.magic = true;
            item.shoot = ProjectileID.StarWrath;
            item.value = Item.buyPrice(0, 1, 50, 0);
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.width = 26;
            item.damage = 20;
            item.expert = true;
            item.height = 28;
            item.noMelee = true;
            item.useTime = 20;
            item.useStyle = 5;
            item.autoReuse = true;
            item.knockBack = 0.1f;
            item.shootSpeed = 10f;
            item.useAnimation = 60;
        }
        public override void AddRecipes()
        {
            ModRecipe q = new ModRecipe(mod);
            q.AddIngredient(ItemID.WaterBolt, 1);
            q.AddIngredient(ItemID.BookofSkulls, 1);
            q.AddIngredient(ItemID.SpaceGun, 1);
            q.AddIngredient(ItemID.Book, 3);
            q.AddIngredient(ItemID.MeteoriteBar, 20);
            q.AddIngredient(mod.ItemType<FireOfStarZero>(), 6);
            q.AddIngredient(ItemID.FallenStar, 10);
            q.AddIngredient(mod.ItemType<StarFrame>(), 3);
            q.AddTile(TileID.Bookcases);
            q.SetResult(this, 1);
            q.AddRecipe();
        }
    }
}
