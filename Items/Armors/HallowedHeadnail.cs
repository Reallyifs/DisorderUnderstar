using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items.Armors
{
    [AutoloadEquip(EquipType.Head)]
    public class HallowedHeadnail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("神圣头甲");
            Tooltip.SetDefault("增加10%的[c/FF8000:近战伤害]及[c/FF8000:近战暴击]，增加29%的[c/FF8000:近战攻速]\n" +
                "增加12%的[c/FF00FF:魔法伤害]及[c/FF00FF:魔法暴击]，增加100的[c/0000FF:魔法上限]，[c/0000FF:魔法消耗]减少20%\n" +
                "增加15%的[c/00007F:远程伤害]，增加8%的[c/00007F:远程暴击]，25%的几率不[c/00007F:消耗弹药]\n" +
                "移动速度增加19%");
        }
        public override void SetDefaults()
        {
            item.rare = 7;
            item.value = Item.sellPrice(0, 18, 0, 0);
            item.width = 20;
            item.expert = true;
            item.height = 20;
            item.defense = 38;
            item.expertOnly = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaCost -= 0.2f;
            player.magicCrit += 12;
            player.meleeCrit += 10;
            player.moveSpeed += 0.19f;
            player.meleeSpeed += 0.29f;
            player.rangedCrit += 8;
            player.magicDamage += 0.12f;
            player.meleeDamage += 0.10f;
            player.rangedDamage += 0.15f;
            player.statManaMax2 += 100;
        }
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.Next(100) < 25;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe0 = new ModRecipe(mod);
            recipe0.AddIngredient(ItemID.HallowedHelmet, 1);
            recipe0.AddIngredient(ItemID.HallowedHeadgear, 1);
            recipe0.AddIngredient(ItemID.HallowedMask, 1);
            recipe0.AddIngredient(ItemID.HallowedBar, 20);
            recipe0.AddTile(TileID.MythrilAnvil);
            recipe0.SetResult(this);
            recipe0.AddRecipe();
        }
    }
}