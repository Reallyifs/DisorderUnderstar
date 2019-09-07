using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items.Star.Armors
{
    [AutoloadEquip(EquipType.Legs)]
    public class StarPants : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("星星裤子");
            Tooltip.SetDefault("【星星-Star】\n" +
                "“走向星空源头。”\n" +
                "-\n" +
                "[c/FF00FF:魔法暴击]增加8%，移动速度增加40%\n" +
                "[c/FF00FF:魔法伤害]增加24，[c/0000FF:魔法上限]增加15\n" +
                "-");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Orange;
            item.value = Item.sellPrice(0, 2, 50, 0);
            item.value = Item.buyPrice(0, 5, 0, 0);
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
            A.AddIngredient(mod.ItemType<FireOfStarZero>(), 6);
            A.AddIngredient(mod.ItemType<StarFrame>(), 12);
            A.AddIngredient(ItemID.LesserManaPotion, 4);
            A.AddTile(TileID.Loom);
            A.SetResult(this);
            A.AddRecipe();
        }
    }
}
