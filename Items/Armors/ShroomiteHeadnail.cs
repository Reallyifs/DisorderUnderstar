using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items.Armors
{
    [AutoloadEquip(EquipType.Head)]
    public class ShroomiteHeadnail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("蘑菇头甲");
            Tooltip.SetDefault("增加28%的箭、子弹及火箭的伤害\n" +
                "远程武器增加15%的暴击率\n" +
                "不移动会进入隐形状态");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(0, 22, 50, 0);
            item.width = 20;
            item.expert = true;
            item.height = 20;
            item.defense = 33;
            item.expertOnly = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.rangedCrit += 15;
            player.arrowDamage += 0.28f;
            player.rocketDamage += 0.28f;
            player.bulletDamage += 0.28f;
            player.shroomiteStealth = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe0 = new ModRecipe(mod);
            recipe0.AddIngredient(ItemID.ShroomiteHeadgear, 1);
            recipe0.AddIngredient(ItemID.ShroomiteMask, 1);
            recipe0.AddIngredient(ItemID.ShroomiteHelmet, 1);
            recipe0.AddIngredient(ItemID.ShroomiteBar, 20);
            recipe0.AddTile(TileID.MythrilAnvil);
            recipe0.SetResult(this);
            recipe0.AddRecipe();
        }
    }
}