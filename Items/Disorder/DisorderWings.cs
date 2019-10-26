using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using DisorderUnderstar.Tools;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Items.Disorder
{
    [AutoloadEquip(EquipType.Wings)]
    public class DisorderWings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Disorder ` Wings");
            DisplayName.AddTranslation(GameCulture.Chinese, "无序·翅膀");
            Tooltip.SetDefault("[[c/FF0000:Disorder]]\n" +
                "\"Fly to everywhere.\"");
            Tooltip.AddTranslation(GameCulture.Chinese, "【[c/FF0000:无序]】\n" +
                "“飞向世界各地。”");
        }
        public override void SetDefaults()
        {
            item.height = 26;
            item.width = 24;
            item.accessory = true;
            item.value = Item.sellPrice(0, 10, 20, 30);
            item.expert = true;
            item.expertOnly = true;
            item.rare = ItemRarityID.Red;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTime = 10;
            if (hideVisual == true)
            {
                for (int i = 0; i < 1; i++)
                {
                    Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.Fire, -player.velocity.X * 0.5f,
                        -player.velocity.Y * 0.5f, 100, Color.White, 1.0f);
                }
            }
        }
        public override void VerticalWingSpeeds
            (Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier,
            ref float constantAscend)
        {
            ascentWhenFalling = 1.5f;
            ascentWhenRising = 0.25f;
            maxAscentMultiplier = 10f;
            maxCanAscendMultiplier = 11f;
            constantAscend = 0.1f;
        }
        public override void HorizontalWingSpeeds(Player player, ref float speed,
            ref float acceleration)
        {
            speed = 50f;
            acceleration *= 10f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.WingsStardust, 1);
            recipe1.AddIngredient(ItemID.WingsVortex, 1);
            recipe1.AddIngredient(ItemID.WingsNebula, 1);
            recipe1.AddIngredient(ItemID.WingsSolar, 1);
            recipe1.AddIngredient(ItemID.FlameWings, 1);
            recipe1.AddIngredient(ItemID.Hoverboard, 1);
            recipe1.AddIngredient(ItemID.SpookyWings, 1);
            recipe1.AddIngredient(ItemID.FestiveWings, 1);
            recipe1.AddIngredient(ModContent.ItemType<DisorderBar>(), 10);
            recipe1.AddTile(TileID.LunarCraftingStation);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}
