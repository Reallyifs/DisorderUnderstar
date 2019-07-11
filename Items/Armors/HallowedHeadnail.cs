using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items.Armors
{
    [AutoloadEquip(EquipType.Head)]
    public class HallowedHeadnail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("��ʥͷ��");
            Tooltip.SetDefault("����10%�Ľ�ս�˺���������\n" +
                "����29%�Ľ�ս����\n" +
                "����12%��ħ���˺��������ʣ�����100��ħ������\n" +
                "ħ�����ļ���20%\n" +
                "����15%��Զ���˺�������8%�ı�����\n" +
                "25%�ļ��ʲ����ĵ�ҩ\n" +
                "�ƶ��ٶ�����19%");
        }
        public override void SetDefaults()
        {
            item.rare = 7;
            item.value = Item.sellPrice(0, 18, 0, 0);
            item.width = 20;
            item.expert = true;
            item.height = 20;
            item.defense = 38;
            item.expertOnly = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaCost -= 0.2f;
            player.magicCrit += 12;
            player.meleeCrit += 10;
            player.moveSpeed += 0.19f;
            player.meleeSpeed += 0.29f;
            player.rangedCrit += 8;
            player.magicDamage += 0.12f;
            player.meleeDamage += 0.10f;
            player.rangedDamage += 0.15f;
            player.statManaMax2 += 100;
        }
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.Next(100) < 25;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe0 = new ModRecipe(mod);
            recipe0.AddIngredient(ItemID.HallowedHelmet, 1);
            recipe0.AddIngredient(ItemID.HallowedHeadgear, 1);
            recipe0.AddIngredient(ItemID.HallowedMask, 1);
            recipe0.AddIngredient(ItemID.HallowedBar, 20);
            recipe0.AddTile(TileID.MythrilAnvil);
            recipe0.SetResult(this);
            recipe0.AddRecipe();
        }
    }
}