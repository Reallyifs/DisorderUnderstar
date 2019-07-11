using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Items.Disorder
{
    [AutoloadEquip(EquipType.Wings)]
    public class DisorderFourtype : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("无序·四型");
            Tooltip.SetDefault("【无序-Disorder】\n" +
                "集合了你身上的无序之力。\n" +
                "-\n" +
                "免疫十字盾免疫的所有debuff和旋涡漂浮\n" +
                "耐力增加95%，生命回复增加290/s，魔法回复增加145/s，最大生命增加1800，最大魔法增加900\n" +
                "除召唤外暴击增加38%，近战速度增加75%，召唤一个叶绿水晶为你而战，所有伤害乘以7.4\n" +
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
            {
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
            }
            {
                player.endurance += 0.95f;
                player.lifeRegen += 290;
                player.manaRegen += 145;
                player.statLifeMax2 += 1800;
                player.statManaMax2 += 900;
            }
            {
                player.magicCrit += 38;
                player.meleeCrit += 38;
                player.meleeSpeed += 0.75f;
                player.rangedCrit += 38;
                player.thrownCrit += 38;
                player.crystalLeaf = true;
                player.magicDamage += 6.4f;
                player.meleeDamage += 6.4f;
                player.minionDamage += 6.4f;
                player.rangedDamage += 6.4f;
                player.thrownDamage += 6.4f;
                player.shroomiteStealth = true;
            }
            {
                player.swimTime = 6000;
                player.wingTime = 50;
                player.jumpBoost = true;
                player.moveSpeed += 1f;
                player.noFallDmg = true;
                player.waterWalk2 = true;
                player.noKnockback = true;
                player.CollectTaxes();
                player.jumpSpeedBoost += 7.5f;
            }
            if (hideVisual == true)
            {
                for (int i = 0; i < 2; i++)
                {
                    Dust.NewDustDirect
                        (player.position, player.width, player.height,
                        MyDustId.Fire, -player.velocity.X * 0.5f, -player.velocity.Y * 0.5f, 100,
                        Color.White, 1.0f);
                }
            }
        }
        public override void VerticalWingSpeeds
            (Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier,
            ref float constantAscend)
        {
            ascentWhenFalling = 1.75f;
            ascentWhenRising = 0.5f;
            maxAscentMultiplier = 15f;
            maxCanAscendMultiplier = 16f;
            constantAscend = 0.35f;
        }
        public override void HorizontalWingSpeeds
            (Player player, ref float speed, ref float acceleration)
        {
            speed = 75f;
            acceleration *= 12.5f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(mod, "DisorderHelmet", 1);
            recipe1.AddIngredient(mod, "DisorderBreastplate", 1);
            recipe1.AddIngredient(mod, "DisorderLeggings", 1);
            recipe1.AddIngredient(mod, "DisorderWings", 1);
            recipe1.AddIngredient(ItemID.AnkhShield, 1);
            recipe1.AddIngredient(ItemID.SpectreBar, 10);
            recipe1.AddIngredient(mod, "DisorderBar", 10);
            recipe1.AddTile(TileID.LunarCraftingStation);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}
