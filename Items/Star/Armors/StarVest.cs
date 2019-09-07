using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items.Star.Armors
{
    [AutoloadEquip(EquipType.Body)]
    public class StarVest : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("星星外套");
            Tooltip.SetDefault("【星星-Star】\n" +
                "“沉浸星空奥秘。”\n" +
                "-\n" +
                "[c/0000FF:魔法消耗]减少20%，[c/5E5E5E:耐力]增加10%\n" +
                "[c/FF00FF:魔法暴击]增加11%，[c/FF00FF:魔法伤害]增加28\n" +
                "[c/0000FF:魔法上限]增加20\n" +
                "-");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Orange;
            item.value = Item.sellPrice(0, 2, 50, 0);
            item.value = Item.buyPrice(0, 5, 0, 0);
            item.width = 20;
            item.height = 18;
            item.defense = 10;
            item.maxStack = 1;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaCost -= 0.2f;
            player.endurance += 0.1f;
            player.magicCrit += 11;
            player.magicDamage += 28;
            player.statManaMax2 += 20;
        }
        public override void AddRecipes()
        {
            ModRecipe A = new ModRecipe(mod);
            A.AddIngredient(ItemID.MeteorSuit, 1);
            A.AddIngredient(ItemID.Meteorite, 5);
            A.AddIngredient(mod.ItemType<FireOfStarZero>(), 7);
            A.AddIngredient(mod.ItemType<StarFrame>(), 14);
            A.AddIngredient(ItemID.LesserManaPotion, 6);
            A.AddTile(TileID.Loom);
            A.SetResult(this);
            A.AddRecipe();
        }
    }
}
