using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items.Disorder
{
    public class DisorderCross : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("无序·十字架");
            Tooltip.SetDefault("【[c/FF0000:无序-Disorder]】\n" +
                "它的样子非常的奇怪。\n" +
                "-装备效果-\n" +
                "[c/0000FF:魔法消耗]减少40%，[c/FF0000:生命上限]增加350，[c/0000FF:魔法上限]增加175\n" +
                "[c/FF8000:近战暴击]增加32%，[c/00FFFF:随从上限]增加15个，[c/FF8000:近战速度]增加9%\n" +
                "[c/FF00FF:魔法]、[c/FF8000:近战]和[c/00007F:远程伤害]增加55%\n" +
                "允许玩家连跳，速度增加80%，站着不动[c/FF0000:生命恢复]会大大提高，跳跃高度增加50%\n" +
                "-");
        }
        public override void SetDefaults()
        {
            item.rare = 9;
            item.value = Item.sellPrice(1, 2, 3, 4);
            item.width = 38;
            item.expert = true;
            item.height = 43;
            item.defense = 25;
            item.accessory = true;
            item.expertOnly = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            #region 生命和魔法
            player.manaCost -= 0.4f;
            player.statLifeMax2 += 350;
            player.statManaMax2 += 175;
            #endregion
            #region 伤害和暴击
            player.meleeCrit += 32;
            player.maxMinions += 15;
            player.meleeSpeed += 0.09f;
            player.magicDamage += 0.55f;
            player.meleeDamage += 0.55f;
            player.rangedDamage += 0.55f;
            #endregion
            #region 其他
            player.jumpBoost = true;
            player.moveSpeed += 0.8f;
            player.shinyStone = true;
            player.jumpSpeedBoost += 0.5f;
            #endregion
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.ShinyStone, 2);
            recipe1.AddIngredient(ModContent.ItemType<DisorderBar>(), 5);
            recipe1.AddIngredient(ItemID.LifeCrystal, 10);
            recipe1.AddIngredient(ItemID.ManaCrystal, 10);
            recipe1.AddIngredient(ItemID.FallenStar, 20);
            recipe1.AddTile(TileID.LunarCraftingStation);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}