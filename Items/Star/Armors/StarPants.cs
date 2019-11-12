using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
namespace DisorderUnderstar.Items.Star.Armors
{
    [AutoloadEquip(EquipType.Legs)]
    public class StarPants : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Pants");
            DisplayName.AddTranslation(GameCulture.Chinese, "星星裤子");
            Tooltip.SetDefault("[Star]\n" +
                "\"Go to star source.\"\n" +
                "-Equipment Effect-\n" +
                "[c/FF00FF:Magic Crit] increase 8%, Move Speed increase 40%\n" +
                "[c/FF00FF:Magic] damage increase 24, [c/0000FF:Maximum Mana] increase 15");
            Tooltip.AddTranslation(GameCulture.Chinese, "【星星】\n" +
                "“走向星空源头。”\n" +
                "-装备效果-\n" +
                "[c/FF00FF:魔法暴击]增加8%，移动速度增加40%\n" +
                "[c/FF00FF:魔法伤害]增加24，[c/0000FF:魔法上限]增加15");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Orange;
            item.value = Item.sellPrice(0, 2, 50, 0);
            item.width = 20;
            item.height = 16;
            item.defense = 9;
            item.maxStack = 1;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicCrit += 8;
            player.moveSpeed += 0.4f;
            player.magicDamage += 24;
            player.statManaMax2 += 15;
        }
        public override void AddRecipes()
        {
            ModRecipe A = new ModRecipe(mod);
            A.AddIngredient(ItemID.MeteorLeggings, 1);
            A.AddIngredient(ItemID.Meteorite, 4);
            A.AddIngredient(ModContent.ItemType<FireOfStarZero>(), 6);
            A.AddIngredient(ModContent.ItemType<StarFrame>(), 12);
            A.AddIngredient(ItemID.LesserManaPotion, 4);
            A.AddTile(TileID.Loom);
            A.SetResult(this);
            A.AddRecipe();
        }
    }
}
