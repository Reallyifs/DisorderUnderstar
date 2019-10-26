using Terraria; 
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items.Armors
{
    [AutoloadEquip(EquipType.Head)]
    public class SwimwearHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("泳装头巾");
            Tooltip.SetDefault("“来一场泳装派对吧！”");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(1, 1, 1, 1);
            item.value = Item.buyPrice(2, 3, 4, 5);
            item.width = 20;
            item.height = 18;
            item.vanity = true;
            item.maxStack = 1;
        }
        public override void UpdateVanity(Player player, EquipType type)
        {
            player.AddBuff(BuffID.Sunflower, 1);
            player.AddBuff(BuffID.PeaceCandle, 1);
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<SwimwearBody>() && legs.type == ModContent.ItemType<SwimwearLegs>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "……谁会无聊到把时装穿在装备栏\n" +
                "然后发现这个彩蛋？？？";
            player.minionKB += 10000f;
            player.statLife += 999999999;
            player.statMana += 999999999;
            player.endurance += 10000f;
            player.AddBuff(BuffID.Fishing, 1);
            player.armorEffectDrawOutlines = true;
        }
    }
}
