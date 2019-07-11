using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using DisorderUnderstar.Utils;
namespace DisorderUnderstar.Items.Disorder
{
    public class DisorderCross : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("无序·十字架");
            Tooltip.SetDefault("【无序-Disorder】\n" +
                "它的样子非常的奇怪。\n" +
                "-\n" +
                "最大生命增加350，最大魔法增加175\n" +
                "魔法消耗减少40%，近战暴击增加32%，最大随从增加15个，近战速度增加9%\n" +
                "魔法、近战和远程伤害增加55%\n" +
                "允许玩家连跳，速度增加80%，免疫摔落伤害及击退\n" +
                "站着不动生命恢复会大大提高，自动收税，跳跃高度增加20%\n" +
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
            {
                player.statLifeMax2 += 350;
                player.statManaMax2 += 175;
            }
            {
                player.manaCost -= 0.4f;
                player.meleeCrit += 32;
                player.maxMinions += 15;
                player.meleeSpeed += 0.09f;
                player.magicDamage += 0.55f;
                player.meleeDamage += 0.55f;
                player.rangedDamage += 0.55f;
            }
            {
                player.jumpBoost = true;
                player.moveSpeed += 0.8f;
                player.noFallDmg = true;
                player.shinyStone = true;
                player.noKnockback = true;
                player.CollectTaxes();
                player.jumpSpeedBoost += 0.2f;
            }
            if (hideVisual == true)
            {
                for (int i = 0; i < 1; i++)
                {
                    Dust.NewDustDirect
                        (player.position, player.width, player.height,
                        MyDustId.WhiteLingering,
                        -player.velocity.X * 0.5f, -player.velocity.Y * 0.5f, 100,
                        Color.White, 1.0f);
                }
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(mod, "PurpleStone", 1);
            recipe1.AddIngredient(ItemID.ShinyStone, 2);
            recipe1.AddIngredient(ItemID.EoCShield, 3);
            recipe1.AddIngredient(mod, "DisorderBar", 10);
            recipe1.AddIngredient(ItemID.LifeCrystal, 10);
            recipe1.AddIngredient(ItemID.ManaCrystal, 10);
            recipe1.AddIngredient(ItemID.FallenStar, 20);
            recipe1.AddTile(TileID.LunarCraftingStation);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}
// 以上详情（更多）请询问群里dalao
// ！以上复制模板，这只是个简化版！
// 模板位置http://www.fs49.org/2018/04/25/%e8%87%aa%e5%ae%9a%e4%b9%89%e9%a5%b0%e5%93%81/
// 作者说模板没版权，但还是要注明作者=v=