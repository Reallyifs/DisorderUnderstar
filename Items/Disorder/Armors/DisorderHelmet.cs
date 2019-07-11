using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
            Tooltip.SetDefault("【无序-Disorder】\n" +
                "“聆听世界寂静。”\n" +
                "-\n" +
                "生命恢复增加100/s，魔法回复增加30/s\n" +
                "最大生命增加500，最大魔法增加250\n" +
                "近战暴击增加40%，除召唤外其他暴击增加45%\n" +
                "魔法、近战和远程伤害乘以2.5，投掷和召唤伤害乘以4.5\n" +
                "40%不消耗弹药，召唤一个叶绿水晶为你而战\n" +
                "站着不动进入隐身状态\n" +
                "-");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 18;
            item.value = Item.sellPrice(0, 15, 15, 0);
            item.rare = 10;
            item.defense = 58;
            item.maxStack = 1;
            item.expert = true;
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
                player.meleeCrit = 40;
                player.rangedCrit += 45;
                player.thrownCrit += 45;
                player.magicDamage += 1.5f;
                player.meleeDamage += 1.5f;
                player.minionDamage += 3.5f;
                player.rangedDamage += 1.5f;
                player.thrownDamage += 3.5f;
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
                "魔法消耗减少60%，召唤物击退增加10%，生命恢复增加100/s\n" +
                "耐力增加70%，免疫熔浆，红心拾取范围加大\n" +
                "最大随从增加10个，所有伤害乘以6.66\n" +
                "改为65%不消耗弹药\n" +
                "召唤星辰守护者为你而战，拥有星云套效果\n" +
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
            player.magicDamage += 6.66f;
            player.meleeDamage += 6.66f;
            player.minionDamage += 6.66f;
            player.rangedDamage += 6.66f;
            player.thrownDamage += 6.66f;
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
            recipe0.AddIngredient(mod, "HallowedHeadnail", 1);
            recipe0.AddIngredient(mod, "ChlorophyteHeadnail", 1);
            recipe0.AddIngredient(mod, "ShroomiteHeadnail", 1);
            recipe0.AddIngredient(mod, "DisorderBar", 10);
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