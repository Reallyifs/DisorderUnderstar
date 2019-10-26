using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using DisorderUnderstar.Tools;
namespace DisorderUnderstar.Items.Star
{
    public class BiDirectionalMeteor : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("双向流星");
            Tooltip.SetDefault("快看！流星雨来了！\n" +
                "“听说，对着流星许下愿望……”\n" +
                "“就会实现哦！”\n" +
                "-\n" +
                "[c/FF0000:生命上限]增加400，[c/0000FF:魔法上限]增加200\n" +
                "[c/000000:所有伤害]增加40%\n" +
                "[c/0000FF:魔法消耗]减少4%，近战暴击增加20%，近战速度加快40%\n" +
                "移动速度增加2%，跳跃高度增加40%，免疫摔落伤害\n" +
                "免疫摔落伤害，[c/3F3F3F:缓慢]、[c/3F3F3F:着火]、[c/3F3F3F:燃烧]、[c/3F3F3F:黑暗]、[c/3F3F3F:中毒]、[c/3F3F3F:沉默]、[c/3F3F3F:破甲]\n" +
                "-\n" +
                "当你的[c/FF0000:生命上限]大于等于500，[c/0000FF:魔法上限]大于等于200\n" +
                "且[c/FF0000:生命值]小于100，[c/0000FF:魔法值]小于30时\n" +
                "你的[c/00FFFF:随从伤害]增加10，[c/00007F:远程伤害]增加20，[c/0000FF:魔法伤害]增加30\n" +
                "[c/FF8000:近战伤害]增加40，[c/7F7F7F:投掷伤害]增加50\n" +
                "并给予一个持续20秒的[c/BFBFBF:冰障buff]\n" +
                "-");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Yellow;
            item.value = Item.buyPrice(0, 5, 0, 0);
            item.value = Item.sellPrice(0, 2, 50, 0);
            item.width = 30;
            item.expert = true;
            item.height = 30;
            item.defense = 40;
            item.maxStack = 1;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            #region 生命&伤害
            player.allDamage += 0.4f;
            player.statLifeMax2 += 400;
            player.statManaMax2 += 200;
            #endregion
            #region 加成
            player.manaCost -= 0.04f;
            player.meleeCrit += 20;
            player.noFallDmg = true;
            player.moveSpeed += 1f;
            player.moveSpeed += 1f;
            player.meleeSpeed += 0.4f;
            player.jumpSpeedBoost += 0.4f;
            #endregion
            #region Buff免疫
            player.buffImmune[BuffID.Slow] = true;
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.Burning] = true;
            player.buffImmune[BuffID.Darkness] = true;
            player.buffImmune[BuffID.Poisoned] = true;
            player.buffImmune[BuffID.Silenced] = true;
            player.buffImmune[BuffID.BrokenArmor] = true;
            #endregion
            if (player.statLifeMax2 >= 500 && player.statManaMax2 >= 200 && player.statLife < 100 && player.statMana < 30)
            {
                player.minionDamage += 10;
                player.rangedDamage += 20;
                player.magicDamage += 30;
                player.meleeDamage += 40;
                player.thrownDamage += 50;
                player.AddBuff(BuffID.IceBarrier, 20);
            }
            if (hideVisual)
            {
                for (int _0 = 0; _0 < 2; _0++)
                {
                    Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.YellowTorch, player.velocity.X * 0.5f,
                        player.velocity.Y * 0.5f, 100, Color.Yellow, 1.0f);
                }
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<StarSurround>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SurroundStar>(), 1);
            recipe.AddIngredient(ModContent.ItemType<FireOfStarZero>(), 16);
            recipe.AddIngredient(ModContent.ItemType<StarFrame>(), 8);
            recipe.AddIngredient(ItemID.BoneGlove, 1);
            recipe.AddIngredient(ItemID.HiveBackpack, 1);
            recipe.AddIngredient(ItemID.HellstoneBar, 20);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
