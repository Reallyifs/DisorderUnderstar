using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Items
{
    public class GlitchSIO : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glitch S.I.O.");
            Tooltip.SetDefault("知道了么？……\n" +
                "离最后只有一秒之差。");
        }
        public override void SetDefaults()
        {
            item.crit = 55;
            item.rare = ItemRarityID.Red;
            item.scale = 1f;
            item.shoot = ProjectileID.MoonlordArrow;
            item.value = Item.sellPrice(121, 31, 41, 50);
            item.width = 20;
            item.damage = 969;
            item.expert = true;
            item.height = 34;
            item.ranged = true;
            item.useTime = 3;
            item.noMelee = false;
            item.useStyle = 5;
            item.maxStack = 1;
            item.autoReuse = true;
            item.knockBack = 2f;
            item.expertOnly = true;
            item.shootSpeed = 30f;
            item.useAnimation = 30;
        }
        public override bool ConsumeAmmo(Player player)
        {
            return true;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0.0f, 0.0f);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(mod, "GlitchRIO", 1);
            recipe1.AddIngredient(mod, "DXTBlade", 1);
            recipe1.AddIngredient(mod, "RSGun", 1);
            recipe1.AddIngredient(ItemID.MoltenFury, 1);
            recipe1.AddIngredient(ItemID.HallowedRepeater, 1);
            recipe1.AddIngredient(ItemID.ChlorophyteShotbow, 1);
            recipe1.AddIngredient(ItemID.Phantasm, 1);
            recipe1.AddIngredient(mod, "DisorderBar", 2);
            recipe1.AddTile(TileID.LunarCraftingStation);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}