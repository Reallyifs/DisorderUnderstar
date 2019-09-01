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
            Tooltip.SetDefault("增加10%的近战伤害及暴击率\n" +
                "增加29%的近战攻速\n" +
                "增加12%的魔法伤害及暴击率，增加100的魔法上限\n" +
                "魔法消耗减少20%\n" +
                "增加15%的远程伤害，增加8%的暴击率\n" +
                "25%的几率不消耗弹药\n" +
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