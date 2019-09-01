using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items.Disorder.Armors
{
    // 注意这里，这是C#里面的一个神奇的语法
    // 作用是给一个类附加一个属性
    // 比如这里就是给这个类附加一个装备样式为头盔的属性，这样TML就会把它识别成头盔
    [AutoloadEquip(EquipType.Body)]
    public class DisorderBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("无序·胸甲");
            Tooltip.SetDefault("【无序-Disorder】\n" +
                "“感受世界心跳。”\n" +
                "-\n" +
                "[c/7F7F7F:耐力]增加70%，[c/FF0000:生命恢复]增加40，除[c/00FFFF:召唤]外[c/000000:所有暴击]增加22%，[c/FF8000:近战速度]增加50%\n" +
                "免疫击退，[c/FF0000:最大生命]增加300，[c/0000FF:最大魔法]增加150\n" +
                "免疫火焰烧伤\n" +
                "-");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Orange;
            item.value = Item.sellPrice(0, 1, 1, 0);
            item.width = 28;
            item.expert = true;
            item.height = 18;
            item.defense = 80;
            item.maxStack = 1;
            item.expertOnly = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.endurance += 0.7f;
            player.lifeRegen += 40;
            player.magicCrit += 22;
            player.meleeCrit += 22;
            player.meleeSpeed += 0.5f;
            player.rangedCrit += 22;
            player.thrownCrit += 22;
            player.noKnockback = true;
            player.statLifeMax2 += 300;
            player.statManaMax2 += 150;
            player.buffImmune[BuffID.OnFire] = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe0 = new ModRecipe(mod);
            recipe0.AddIngredient(ItemID.StardustBreastplate, 1);
            recipe0.AddIngredient(ItemID.VortexBreastplate, 1);
            recipe0.AddIngredient(ItemID.NebulaBreastplate, 1);
            recipe0.AddIngredient(ItemID.SolarFlareBreastplate, 1);
            recipe0.AddIngredient(ItemID.MoltenBreastplate, 1);
            recipe0.AddIngredient(ItemID.HallowedPlateMail, 1);
            recipe0.AddIngredient(ItemID.ChlorophytePlateMail, 1);
            recipe0.AddIngredient(ItemID.ShroomiteBreastplate, 1);
            recipe0.AddIngredient(mod.ItemType<DisorderBar>(), 20);
            recipe0.AddTile(TileID.LunarCraftingStation);
            recipe0.SetResult(this);
            recipe0.AddRecipe();
        }
    }
}