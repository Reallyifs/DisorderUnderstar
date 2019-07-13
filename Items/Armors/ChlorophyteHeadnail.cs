using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items.Armors
{
    [AutoloadEquip(EquipType.Head)]
    public class ChlorophyteHeadnail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("叶绿头甲");
            Tooltip.SetDefault("增加16%的近战伤害，增加6%的近战暴击\n" +
                "增加64%的远程伤害，20%的几率不消耗弹药\n" +
                "增加16%的魔法伤害，增加80的魔法上限，减少17%的魔法消耗\n" +
                "直接召唤一个叶绿水晶为你而战");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(0, 18, 0, 0);
            item.width = 20;
            item.expert = true;
            item.height = 20;
            item.defense = 45;
            item.expertOnly = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaCost -= 0.17f;
            player.meleeCrit += 6;
            player.crystalLeaf = true;
            player.magicDamage += 0.16f;
            player.meleeDamage += 0.16f;
            player.rangedDamage += 0.64f;
            player.statManaMax2 += 80;
            // player.AddBuff(mod.BuffType("NNMODCrystalLeaf"), 1);
        }
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.Next(100) < 20;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe0 = new ModRecipe(mod);
            recipe0.AddIngredient(ItemID.ChlorophyteMask, 1);
            recipe0.AddIngredient(ItemID.ChlorophyteHelmet, 1);
            recipe0.AddIngredient(ItemID.ChlorophyteHeadgear, 1);
            recipe0.AddIngredient(ItemID.ChlorophyteBar, 20);
            recipe0.AddTile(TileID.MythrilAnvil);
            recipe0.SetResult(this);
            recipe0.AddRecipe();
        }
    }
}
// 以上详情（更多）请询问群里dalao
// ！以上复制模板，这只是个简化版！
// 模板位置http://www.fs49.org/2018/04/28/%e5%a5%97%e8%a3%85/
// 作者说模板没版权，但还是要注明作者=v=
