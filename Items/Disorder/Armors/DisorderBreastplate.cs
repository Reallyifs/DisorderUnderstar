using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items.Disorder.Armors
{
    // ע���������C#�����һ��������﷨
    // �����Ǹ�һ���฽��һ������
    // ����������Ǹ�����฽��һ��װ����ʽΪͷ�������ԣ�����TML�ͻ����ʶ���ͷ��
    [AutoloadEquip(EquipType.Body)]
    public class DisorderBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("�����ؼ�");
            Tooltip.SetDefault("������-Disorder��\n" +
                "������������������\n" +
                "-\n" +
                "��������70%�������ָ�����40/s�����ٻ������б�������22%����ս�ٶ�����50%\n" +
                "���߻��ˣ������������300�����ħ������150\n" +
                "���߻�������\n" +
                "-");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 18;
            item.value = Item.sellPrice(0, 1, 1, 0);
            item.rare = ItemRarityID.Orange;
            item.defense = 80;
            item.expert = true;
            item.expertOnly = true;
            item.maxStack = 1;
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
            recipe0.AddIngredient(mod, "DisorderBar", 20);
            recipe0.AddTile(TileID.LunarCraftingStation);
            recipe0.SetResult(this);
            recipe0.AddRecipe();
        }
    }
}