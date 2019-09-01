using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using DisorderUnderstar.Utils;
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
                "[c/FF0000:最大生命]增加400，最大魔法增加200\n" +
                "所有伤害增加40%\n" +
                "魔法消耗减少4%，近战暴击增加20%，近战速度加快40%\n" +
                "移动速度增加2%，跳跃高度增加40%，免疫摔落伤害\n" +
                "免疫摔落伤害，缓慢、着火、燃烧、黑暗、中毒、沉默、破甲\n" +
                "-\n" +
                "当你的[c/FF0000:生命上限]大于等于500，魔法上限大于等于200\n" +
                "且[c/FF0000:生命值]小于100，魔法值小于30时\n" +
                "你的随从伤害增加10，远程伤害增加20，魔法伤害增加30\n" +
                "近战伤害增加40，投掷伤害增加50\n" +
                "并给予一个持续20秒的冰障Buff\n" +
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
            {
                player.statLifeMax2 += 400;
                player.statManaMax2 += 200;
            }
            {
                player.magicDamage += 0.4f;
                player.meleeDamage += 0.4f;
                player.minionDamage += 0.4f;
                player.rangedDamage += 0.4f;
                player.thrownDamage += 0.4f;
            }
            {
                player.manaCost -= 0.04f;
                player.meleeCrit += 20;
                player.meleeSpeed += 0.4f;
            }
            {
                player.moveSpeed += 1f;
                player.moveSpeed += 1f;
                player.noFallDmg = true;
                player.jumpSpeedBoost += 0.4f;
            }
            {
                player.buffImmune[BuffID.Slow] = true;
                player.buffImmune[BuffID.OnFire] = true;
                player.buffImmune[BuffID.Burning] = true;
                player.buffImmune[BuffID.Darkness] = true;
                player.buffImmune[BuffID.Poisoned] = true;
                player.buffImmune[BuffID.Silenced] = true;
                player.buffImmune[BuffID.BrokenArmor] = true;
            }
            if (hideVisual == true)
            {
                for (int i = 0; i < 2; i++)
                {
                    Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.YellowTorch, -player.velocity.X * 0.5f,
                        -player.velocity.Y * 0.5f, 100, Color.Yellow, 1.0f);
                }
            }
            if (player.statLifeMax2 >= 500 && player.statManaMax2 >= 200 && player.statLife < 100 && player.statMana < 30)
            {
                player.minionDamage += 10;
                player.rangedDamage += 20;
                player.magicDamage += 30;
                player.meleeDamage += 40;
                player.thrownDamage += 50;
                player.AddBuff(BuffID.IceBarrier, 20);
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<StarSurround>(), 1);
            recipe.AddIngredient(mod.ItemType<SurroundStar>(), 1);
            recipe.AddIngredient(mod.ItemType<FireOfStarZero>(), 16);
            recipe.AddIngredient(mod.ItemType<StarFrame>(), 8);
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
