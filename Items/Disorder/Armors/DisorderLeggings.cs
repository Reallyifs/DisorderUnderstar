using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items.Disorder.Armors
{
    // 注意这里，这是C#里面的一个神奇的语法
    // 作用是给一个类附加一个属性
    // 比如这里就是给这个类附加一个装备样式为护腿的属性，这样TML就会把它识别成护腿
    [AutoloadEquip(EquipType.Legs)]
    public class DisorderLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("无序·护腿");
            Tooltip.SetDefault("【无序-Disorder】\n" +
                "“寻找世界足迹。”\n" +
                "-\n" +
                "允许玩家连跳，免疫摔落伤害，可在熔浆上行走\n" +
                "移动速度增加80%，跳跃高度增加50%\n" +
                "当你移动时，所有伤害增加60%，移动速度增加6.66%\n" +
                "当你不移动时，魔法消耗减少50%，除召唤外所有暴击增加50%，所有伤害增加80%\n" +
                "-");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Orange;
            item.value = Item.sellPrice(0, 1, 1, 0);
            item.width = 20;
            item.expert = true;
            item.height = 18;
            item.defense = 69;
            item.maxStack = 1;
            item.expertOnly = true;
        }
        public override void UpdateEquip(Player player)
        {
            if (player.velocity.Length() > 0.05f)
            {
                player.magicDamage += 0.60f;
                player.meleeDamage += 0.60f;
                player.minionDamage += 0.60f;
                player.rangedDamage += 0.60f;
                player.thrownDamage += 0.60f;
                player.moveSpeed += 6.66f;
            }
            else
            {
                player.manaCost -= 0.5f;
                player.magicCrit += 50;
                player.meleeCrit += 50;
                player.rangedCrit += 50;
                player.thrownCrit += 50;
                player.magicDamage += 0.80f;
                player.meleeDamage += 0.80f;
                player.minionDamage += 0.80f;
                player.rangedDamage += 0.80f;
                player.thrownDamage += 0.80f;
            }
            player.jumpBoost = true;
            player.noFallDmg = true;
            player.waterWalk2 = true;
            player.moveSpeed += 0.8f;
            player.jumpSpeedBoost += 5f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.StardustLeggings, 1);
            recipe1.AddIngredient(ItemID.VortexLeggings, 1);
            recipe1.AddIngredient(ItemID.NebulaLeggings, 1);
            recipe1.AddIngredient(ItemID.SolarFlareLeggings, 1);
            recipe1.AddIngredient(ItemID.MoltenGreaves, 1);
            recipe1.AddIngredient(ItemID.HallowedGreaves, 1);
            recipe1.AddIngredient(ItemID.ChlorophyteGreaves, 1);
            recipe1.AddIngredient(ItemID.ShroomiteLeggings, 1);
            recipe1.AddIngredient(mod, "DisorderBar", 15);
            recipe1.AddTile(TileID.LunarCraftingStation);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}
