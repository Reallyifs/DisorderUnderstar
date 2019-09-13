using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
using DisorderUnderstar.Items.Disorder.Armors;
namespace DisorderUnderstar.Items.Disorder
{
    [AutoloadEquip(EquipType.Wings)]
    public class DisorderFourtype : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("无序·四型");
            Tooltip.SetDefault("【[c/FF0000:无序-Disorder]】\n" +
                "集合了你身上的无序之力。\n" +
                "-\n" +
                "免疫十字盾免疫的所有[c/3F3F3F:debuff]和[c/3F3F3F:旋涡漂浮debuff]\n" +
                "[c/5E5E5E:耐力]增加95%，[c/FF0000:生命恢复]增加290，[c/0000FF:魔法恢复]增加145，[c/FF0000:生命上限]增加1800，[c/0000FF:魔法上限]增加900\n" +
                "除[c/00FFFF:召唤]外[c/000000:所有暴击]增加38%，[c/FF8000:近战速度]增加75%，[c/000000:所有伤害]乘以7.4\n" +
                "站着不动进入隐身状态，但是会产生火焰粒子暴露位置\n" +
                "可无限飞行，延长水下呼吸100秒，可以让玩家连跳，跳跃高度增加7.5%，速度翻一倍\n" +
                "免疫摔落伤害及击退，可在熔浆、水和蜂蜜上行走，自动收取租金\n" +
                "飞行及其不稳定\n" +
                "-");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Purple;
            item.value = Item.sellPrice(25, 20, 10, 5);
            item.width = 16;
            item.expert = true;
            item.height = 38;
            item.defense = 207;
            item.accessory = true;
            item.expertOnly = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            #region BuffImmune
            player.buffImmune[BuffID.Slow] = true;
            player.buffImmune[BuffID.Weak] = true;
            player.buffImmune[BuffID.Cursed] = true;
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.Bleeding] = true;
            player.buffImmune[BuffID.Confused] = true;
            player.buffImmune[BuffID.Darkness] = true;
            player.buffImmune[BuffID.Poisoned] = true;
            player.buffImmune[BuffID.Silenced] = true;
            player.buffImmune[BuffID.BrokenArmor] = true;
            player.buffImmune[BuffID.VortexDebuff] = true;
            #endregion
            #region Life & Mana
            player.endurance += 0.95f;
            player.lifeRegen += 290;
            player.manaRegen += 145;
            player.statLifeMax2 += 1800;
            player.statManaMax2 += 900;
            #endregion
            #region Damage & Crit
            player.magicCrit += 38;
            player.meleeCrit += 38;
            player.meleeSpeed += 0.75f;
            player.rangedCrit += 38;
            player.thrownCrit += 38;
            player.crystalLeaf = true;
            player.magicDamage *= 7.4f;
            player.meleeDamage *= 7.4f;
            player.minionDamage *= 7.4f;
            player.rangedDamage *= 7.4f;
            player.thrownDamage *= 7.4f;
            player.shroomiteStealth = true;
            #endregion
            #region Other
            player.swimTime = 6000;
            player.wingTime = 50;
            player.jumpBoost = true;
            player.moveSpeed += 1f;
            player.noFallDmg = true;
            player.waterWalk2 = true;
            player.noKnockback = true;
            player.CollectTaxes();
            player.jumpSpeedBoost += 7.5f;
            #endregion
            if (hideVisual == true)
            {
                for (int i = 0; i < 2; i++)
                {
                    Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.Fire, -player.velocity.X * 0.5f,
                        -player.velocity.Y * 0.5f, 100, Color.White, 1.0f);
                }
            }
        }
        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 1.75f;
            ascentWhenRising = 0.5f;
            maxAscentMultiplier = 15f;
            maxCanAscendMultiplier = 16f;
            constantAscend = 0.35f;
        }
        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 75f;
            acceleration *= 12.5f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(mod.ItemType<DisorderHelmet>(), 1);
            recipe1.AddIngredient(mod.ItemType<DisorderBreastplate>(), 1);
            recipe1.AddIngredient(mod.ItemType<DisorderLeggings>(), 1);
            recipe1.AddIngredient(mod.ItemType<DisorderWings>(), 1);
            recipe1.AddIngredient(ItemID.AnkhShield, 1);
            recipe1.AddIngredient(ItemID.SpectreBar, 10);
            recipe1.AddIngredient(mod.ItemType<DisorderBar>(), 10);
            recipe1.AddTile(TileID.LunarCraftingStation);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}
