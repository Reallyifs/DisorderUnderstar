using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Items.Star.Armors
{
    [AutoloadEquip(EquipType.Head)]
    public class StarHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("星星帽子");
            Tooltip.SetDefault("【星星-Star】\n" +
                "“望向星空虚无。”\n" +
                "-\n" +
                "魔法暴击增加5%，魔法伤害增加20\n" +
                "拥有夜视（？），最大魔法增加10\n" +
                "-");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Orange;
            item.value = Item.sellPrice(0, 2, 50, 0);
            item.value = Item.buyPrice(0, 5, 0, 0);
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
            return body.type == mod.ItemType("StarVest") &&
                legs.type == mod.ItemType("StarPants");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = ("“时不时有星星碎片从你身上跌落。”\n" +
                "-\n"+
                "魔力消耗减少30%，生命恢复增加10/s\n" +
                "魔法回复增加20/s，魔法暴击增加20%\n" +
                "魔法伤害增加10，最大魔法增加40\n"+
                "星法光枪不消耗魔力并增加11的伤害和暴击\n"+
                "-");
            player.manaCost -= 0.3f;
            player.lifeRegen += 10;
            player.manaRegen += 20;
            player.magicCrit += 20;
            player.magicDamage += 10;
            player.statManaMax2 += 40;
            if (Main.rand.Next(10) < 1)
            {
                for (int i = 0; i < 1; i++)
                {
                    Dust.NewDustDirect
                        (player.position, player.width, player.height,
                        MyDustId.YellowHallowFx,
                        -player.velocity.X * 0.5f, -player.velocity.Y * 0.5f, +85,
                        Color.Yellow, -0.1f);
                }
            }
        }
        public override void AddRecipes()
        {
            ModRecipe A = new ModRecipe(mod);
            A.AddIngredient(ItemID.MeteorHelmet, 1);
            A.AddIngredient(ItemID.Meteorite, 3);
            A.AddIngredient(mod, "FireOfStarZero", 5);
            A.AddIngredient(mod, "StarFrame", 10);
            A.AddIngredient(ItemID.LesserManaPotion, 2);
            A.AddTile(TileID.Loom);
            A.SetResult(this);
            A.AddRecipe();
        }
    }
}
