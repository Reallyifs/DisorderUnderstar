using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
namespace DisorderUnderstar.Items.Disorder.Armors
{
    [AutoloadEquip(EquipType.Body)]
    public class DisorderBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Disorder ` Breastplate");
            DisplayName.AddTranslation(GameCulture.Chinese, "无序·胸甲");
            Tooltip.SetDefault("[Disorder]\n" +
                "\"Feel the World's Heart.\"" +
                "-Equipment Effect-\n" +
                "[c/5E5E5E:Endurance] increase 70%, [c/FF0000:Life Regen] increase 40/s, [c/000000:All Crit] increase 22% except [c/00FFFF:Summon], [c/FF8000:Melee Speed] increase 50%\n" +
                "Immune to Knockback, [c/FF0000:Maximum Life] increase 300, [c/0000FF:Maximum Mana] increase 150\n" +
                "Immune to On Fire! debuff");
            Tooltip.AddTranslation(GameCulture.Chinese, "【无序】\n" +
                "“感受世界心跳。”\n" +
                "-装备效果-\n" +
                "[c/5E5E5E:耐力]增加70%，[c/FF0000:生命恢复]增加40/s，除[c/00FFFF:召唤]外[c/000000:所有暴击]增加22%，[c/FF8000:近战速度]增加50%\n" +
                "免疫击退，[c/FF0000:最大生命]增加300，[c/0000FF:最大魔法]增加150\n" +
                "免疫火焰烧伤");
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
            recipe0.AddIngredient(ModContent.ItemType<DisorderBar>(), 20);
            recipe0.AddTile(TileID.LunarCraftingStation);
            recipe0.SetResult(this);
            recipe0.AddRecipe();
        }
    }
}