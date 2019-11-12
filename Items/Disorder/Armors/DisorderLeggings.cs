using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
namespace DisorderUnderstar.Items.Disorder.Armors
{
    [AutoloadEquip(EquipType.Legs)]
    public class DisorderLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Disorder ` Leggings");
            DisplayName.AddTranslation(GameCulture.Chinese, "无序·护腿");
            Tooltip.SetDefault("[Disorder]\n" +
                "\"Find the World's Footprint.\"\n" +
                "-Equipment Effect-\n" +
                "Allow you to jump multiple times, immune to Fall Damage, walking on the lava\n" +
                "Move Speed increase 80%, Jump Speed Boost 50%\n" +
                "[c/000000:All Damage] increase 60%, Move Speed increase 6.66% when you're moving\n" +
                "[c/0000FF:Mana Cost] reduce 50%, [c/000000:All Crit] increase 50% except [c/00FFFF:Summon], [c/000000:All Damage] increase 80% when you aren't moving");
            Tooltip.AddTranslation(GameCulture.Chinese, "【无序】\n" +
                "“寻找世界足迹。”\n" +
                "-装备效果-\n" +
                "允许玩家连跳，免疫摔落伤害，可在熔浆上行走\n" +
                "移动速度增加80%，跳跃高度增加50%\n" +
                "当你移动时，[c/000000:所有伤害]增加60%，移动速度增加6.66%\n" +
                "当你不移动时，[c/0000FF:魔法消耗]减少50%，除[c/00FFFF:召唤]外[c/000000:所有暴击]增加50%，[c/000000:所有伤害]增加80%");
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
            player.jumpBoost = true;
            player.noFallDmg = true;
            player.waterWalk2 = true;
            player.moveSpeed += 0.8f;
            player.jumpSpeedBoost += 5f;
            if (player.velocity.Length() > 0.05f)
            {
                player.allDamage += 0.6f;
                player.moveSpeed += 6.66f;
            }
            else
            {
                player.manaCost -= 0.5f;
                player.allDamage += 0.8f;
                player.magicCrit += 50;
                player.meleeCrit += 50;
                player.rangedCrit += 50;
                player.thrownCrit += 50;
            }
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
            recipe1.AddIngredient(ModContent.ItemType<DisorderBar>(), 15);
            recipe1.AddTile(TileID.LunarCraftingStation);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}
