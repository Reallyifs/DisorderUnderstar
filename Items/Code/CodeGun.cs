using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Projectiles.Code;
namespace DisorderUnderstar.Items.Code
{
    public class CodeGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("代码枪");
            Tooltip.SetDefault("【代码-Code】\n" +
                "用代码将敌人置于死地！");
        }
        public override void SetDefaults()
        {
            item.crit = 56;
            item.mana = 4;
            item.rare = ItemRarityID.LightPurple;
            item.magic = true;
            item.scale = 1f;
            item.shoot = mod.ProjectileType<ProCodeLaser>();
            item.value = Item.buyPrice(0, 0, 14, 100);
            item.value = Item.sellPrice(0, 0, 0, 100);
            item.width = 24;
            item.damage = 27;
            item.height = 20;
            item.noMelee = true;
            item.useTurn = false;
            item.useTime = 24;
            item.maxStack = 1;
            item.useStyle = 5;
            item.autoReuse = true;
            item.knockBack = 1f;
            item.shootSpeed = 20f;
            item.useAnimation = 24;
        }
        public override void AddRecipes()
        {
            ModRecipe R = new ModRecipe(mod)
            {
                anyIronBar = true
            };
            R.AddIngredient(ItemID.SpaceGun, 1);
            R.AddIngredient(mod.ItemType<CodeFragments>(), 10);
            R.AddIngredient(ItemID.IronBar, 30);
            R.AddIngredient(ItemID.Sapphire, 10);
            R.AddTile(TileID.Tables);
            R.AddTile(TileID.Chairs);
            R.SetResult(this);
            R.AddRecipe();
        }
    }
}
