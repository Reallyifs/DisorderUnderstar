using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
namespace DisorderUnderstar.Items
{
	public class PoisonousPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("һƿҩ");
            Tooltip.SetDefault("��Ҫ����ʲôЧ�������˾�֪����\n" +
                "��ϡ�ɼ�\"����ҩˮ\"�ĸ���");
		}
		public override void SetDefaults()
		{
			item.width = 14;
			item.height = 24;
			item.useAnimation = 17;
			item.useTime = 17;
			item.maxStack = 30;
			item.useStyle = 2;
			item.UseSound = SoundID.Item3;
			item.rare = 5;
			item.value = Item.sellPrice(0, 0, 0, 0);

			// *����-���������Ʒʹ���Ժ�᲻����٣�true����ʹ�ú���Ʒ����һ����Ĭ��Ϊfalse
			item.consumable = true;

			// *����-����ʹ�ö������ֺ����ת��᲻��Ӱ�춯���ķ���true���ǻᣬĬ��Ϊfalse
			item.useTurn = true;

            // *����-����TR�ڲ�ϵͳ�������Ʒ��һ������ҩˮ��Ʒ������TRϵͳ������Ŀ�ģ�����һ����ҩˮ����Ĭ��Ϊfalse
            // item.potion = false;

            // *����-���ҩˮ�ܸ���ҼӶ���Ѫ����potionһ��ʹ�ú���ҩ�ͻ��п�ҩ��debuff
            item.healLife = 500000000;

			// *����-��buff�ķ���1��������Ʒ��buffTypeΪbuff��ID
			// �������������Ż�debuff��2333
			item.buffType = BuffID.OnFire;

			// *����-��������Ʒ��������ʾbuff����ʱ��
			item.buffTime = 60000;
		}

		// ����Ʒ�Ӻϳɱ�
		public override void AddRecipes()
		{
			ModRecipe recipe1 = new ModRecipe(mod);

			// ԭ�ϣ�һƿˮ
			recipe1.AddIngredient(ItemID.BottledWater, 10);

			// ��������̨��Ҳ������ҩˮ�Ĺ���̨���ϳ�
			recipe1.AddTile(TileID.Bottles);

            // �㶮��
            recipe1.SetResult(this, 1);
			recipe1.AddRecipe();
		}

		/* ��������Ҫ�Ĳ��֣�����������������ʹ�������Ʒ��ʱ�򣬳���SetDefault����ļ�����������
		 * �Զ���ҩˮ�����Ժ��Ч������Ҫ������������������
		 * ����������Զ�Player����ң������Խ����޸� */
		public override bool UseItem(Player player)
		{
			// ����Ҽ�buff�ĵڶ�����ʽ���Ƽ���
			// ����Ҽ����ж�buff������ 60000 / 60 = 1000��
			// ��һ����buff��ID���ڶ��������ʱ��
			player.AddBuff(BuffID.Poisoned, 60000);

			// ����Ҽ����Ͷ�buff������ 60000 / 60 = 1000�� 
			player.AddBuff(BuffID.Venom, 60000);
            player.AddBuff(mod.BuffType("GreenLight"), 999999);

            // �ٺ�
            player.KillMe(PlayerDeathReason.ByCustomReason
                (player.name + " ������ҩˮ���ָ���������Ѫ�ܱ�ը����"), 9999, 0);

			// ���������һ���������ͷ���ֵ�����ǵ���ɶ��
			// ����true��˵��ʹ�óɹ��ˣ���ʵûɶ�ã����������ж�����false��Ĭ��ֵ
			// �����㲻д����ֵ�ͻᱨ��
			return true;
		}
	}
}