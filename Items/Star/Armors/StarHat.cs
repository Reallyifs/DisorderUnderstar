using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using DisorderUnderstar.Tools;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Items.Star.Armors
{
    [AutoloadEquip(EquipType.Head)]
    public class StarHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Hat");
            DisplayName.AddTranslation(GameCulture.Chinese, "星星帽子");
            Tooltip.SetDefault("[Star]\n" +
                "\"Look to star void.\"\n" +
                "-Equipment Effect-\n" +
                "[c/FF00FF:Mana Crit] increase 5%, [c/FF00FF:Magic] damage increase 20%\n" +
                "You have Night Vision, [c/0000FF:Maximum Mana] increase 10");
            Tooltip.AddTranslation(GameCulture.Chinese, "【星星】\n" +
                "“望向星空虚无。”\n" +
                "-装备效果-\n" +
                "[c/FF00FF:魔法暴击]增加5%，[c/FF00FF:魔法伤害]增加20\n" +
                "拥有夜视，[c/0000FF:魔法上限]增加10");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Orange;
            item.value = Item.sellPrice(0, 2, 50, 0);
            item.width = 22;
            item.height = 12;
            item.defense = 8;
            item.maxStack = 1;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicCrit += 5;
            player.magicDamage += 20;
            player.nightVision = true;
            player.statManaMax2 += 10;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<StarVest>() && legs.type == ModContent.ItemType<StarPants>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "“时不时有星星碎片从你身上跌落。”\n" +
                "-\n" +
                "[c/0000FF:魔力消耗]减少30%，[c/FF0000:生命恢复]增加10/s\n" +
                "[c/0000FF:魔法回复]增加20/s，[c/FF00FF:魔法暴击]增加20%\n" +
                "[c/FF00FF:魔法伤害]增加10，[c/0000FF:最大魔法]增加40\n" +
                "星法光枪不[c/0000FF消耗魔力]并增加11的伤害和暴击";
            player.manaCost -= 0.3f;
            player.lifeRegen += 10;
            player.manaRegen += 20;
            player.magicCrit += 20;
            player.magicDamage += 10;
            player.statManaMax2 += 40;
            if (Main.rand.Next(10) < 1)
            {
                for (int _0 = 0; _0 < 2; _0++)
                {
                    Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.YellowHallowFx, 0, player.velocity.Y * 0.5f,
                        85, Color.Yellow, Main.rand.NextFloat(0.5f, 1.3f));
                }
            }
        }
        public override void AddRecipes()
        {
            ModRecipe A = new ModRecipe(mod);
            A.AddIngredient(ItemID.MeteorHelmet, 1);
            A.AddIngredient(ItemID.Meteorite, 3);
            A.AddIngredient(ModContent.ItemType<FireOfStarZero>(), 5);
            A.AddIngredient(ModContent.ItemType<StarFrame>(), 10);
            A.AddIngredient(ItemID.LesserManaPotion, 2);
            A.AddTile(TileID.Loom);
            A.SetResult(this);
            A.AddRecipe();
        }
    }
}
