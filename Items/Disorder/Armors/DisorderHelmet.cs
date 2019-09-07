﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Items.Armors;
namespace DisorderUnderstar.Items.Disorder.Armors
{
    // 注意这里，这是C#里面的一个神奇的语法
    // 作用是给一个类附加一个属性
    // 比如这里就是给这个类附加一个装备样式为头盔的属性，这样TML就会把它识别成头盔
    // Head = 头盔
    // Body = 胸甲
    // Legs = 护腿
    [AutoloadEquip(EquipType.Head)]
    public class DisorderHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("无序·头盔");
            Tooltip.SetDefault("【[c/FF0000:无序-Disorder]】\n" +
                "“聆听世界寂静。”\n" +
                "-\n" +
                "[c/FF0000:生命恢复]增加100，[c/0000FF:魔法恢复]增加30\n" +
                "[c/FF0000:最大生命]增加500，[c/0000FF:最大魔法]增加250\n" +
                "[c/FF8000:近战暴击]增加40%，除[c/00FFFF:召唤]外其他暴击增加45%\n" +
                "[c/0000FF:魔法]、[c/FF8000:近战]和[c/00007F:远程]伤害乘以2.5，[c/7F7F7F:投掷]和[c/00FFFF:召唤]伤害乘以4.5\n" +
                "40%不[c/00007F:消耗弹药]，[c/00FFFF:召唤]一个[c/00FF00:叶绿水晶]为你而战\n" +
                "站着不动进入隐身状态\n" +
                "-");
        }
        public override void SetDefaults()
        {
            item.rare = 10;
            item.value = Item.sellPrice(0, 15, 15, 0);
            item.width = 20;
            item.expert = true;
            item.height = 18;
            item.defense = 58;
            item.maxStack = 1;
            item.expertOnly = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            {
                player.lifeRegen += 100;
                player.manaRegen += 30;
                player.statLifeMax2 += 500;
                player.statManaMax2 += 250;
            }
            {
                player.magicCrit += 45;
                player.meleeCrit += 40;
                player.rangedCrit += 45;
                player.thrownCrit += 45;
                player.magicDamage *= 2.5f;
                player.meleeDamage *= 2.5f;
                player.minionDamage *= 4.5f;
                player.rangedDamage *= 2.5f;
                player.thrownDamage *= 4.5f;
                //player.AddBuff(mod.BuffType("NMODCrystalLeaf"), 1);
            }
        }
        public override bool ConsumeAmmo(Player player)
        {
            if (item.bodySlot == mod.ItemType("DisorderBreastplate") &&
                item.legSlot == mod.ItemType("DisorderLeggings"))
            {
                return Main.rand.Next(20) < 13;
            }
            else return Main.rand.Next(5) < 2;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("DisorderBreastplate") &&
                legs.type == mod.ItemType("DisorderLeggings");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "-\n" +
                "“你的身体看起来……没有顺序？”\n" +
                "-\n" +
                "[c/0000FF:魔法消耗]减少60%，[c/00FFFF:召唤物]击退增加10%，[c/FF0000:生命恢复]增加100\n" +
                "[c/7F7F7F:耐力]增加70%，免疫熔浆，[c/FF0000:红心拾取范围]加大\n" +
                "[c/00FFFF:最大随从]增加10个，[c/000000:所有伤害]乘以6.66\n" +
                "改为65%不[c/00007F:消耗弹药]\n" +
                "[c/00FFFF:召唤星辰守护者]为你而战，拥有[c/FF00FF:星云套]效果\n" +
                "改为双击下键进入隐身状态\n" +
                "-";
            player.manaCost -= 0.6f;
            player.minionKB += 0.1f;
            player.lifeRegen += 100;
            player.endurance += 0.7f;
            player.setNebula = true;
            player.lavaImmune = true;
            player.lifeMagnet = true;
            player.maxMinions += 10;
            player.magicDamage *= 6.66f;
            player.meleeDamage *= 6.66f;
            player.minionDamage *= 6.66f;
            player.rangedDamage *= 6.66f;
            player.thrownDamage *= 6.66f;
            player.vortexStealthActive = true;
            //player.AddBuff(mod.BuffType("NMODStardustGuardian"), 1);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe0 = new ModRecipe(mod);
            recipe0.AddIngredient(ItemID.StardustHelmet, 1);
            recipe0.AddIngredient(ItemID.VortexHelmet, 1);
            recipe0.AddIngredient(ItemID.NebulaHelmet, 1);
            recipe0.AddIngredient(ItemID.SolarFlareHelmet, 1);
            recipe0.AddIngredient(ItemID.MoltenHelmet, 1);
            recipe0.AddIngredient(mod.ItemType<HallowedHeadnail>(), 1);
            recipe0.AddIngredient(mod.ItemType<ChlorophyteHeadnail>(), 1);
            recipe0.AddIngredient(mod.ItemType<ShroomiteHeadnail>(), 1);
            recipe0.AddIngredient(mod.ItemType<DisorderBar>(), 10);
            recipe0.AddTile(TileID.LunarCraftingStation);
            recipe0.SetResult(this);
            recipe0.AddRecipe();
        }
    }
}
// 以上详情（更多）请询问群里dalao
// ！以上复制模板，这只是个简化版！
// 模板位置http://www.fs49.org/2018/04/28/%e5%a5%97%e8%a3%85/
// 作者说模板没版权，但还是要注明作者=v=