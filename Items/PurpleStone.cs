using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Items
{
	public class PurpleStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("紫色为零");
			Tooltip.SetDefault("紫七之东。");
		}
		public override void SetDefaults()
		{
			item.rare = 8;
			item.value = Item.sellPrice(5, 5, 5, 5);
			item.width = 24;
			item.expert = true;
			item.height = 24;
			item.defense = 25;
			item.accessory = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe1 = new ModRecipe(mod);
			recipe1.AddIngredient(ItemID.StoneBlock, 999);
            recipe1.AddIngredient(ItemID.ShinyStone, 1);
			recipe1.AddTile(TileID.Anvils);
			recipe1.SetResult(this);
			recipe1.AddRecipe();
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			// 让玩家的生命值上限增加100
			player.statLifeMax2 += 100;

			// 让玩家魔法值上限增加100
			player.statManaMax2 += 100;

			// 玩家近战伤害增加15%，注意这里的值
			player.meleeDamage += 0.15f;

			// 玩家远程伤害增加15%
			player.rangedDamage += 0.15f;

			// 玩家魔法伤害增加15%
			player.magicDamage += 0.15f;

			// 玩家近战暴击率增加20%，注意这是个int
			player.meleeCrit += 20;

			// 玩家的近战攻速增加20%
			player.meleeSpeed += 0.2f;

			// 玩家的移动速度增加70%，最大能设到1，因为tr设置了上限
			player.moveSpeed += 0.7f;

			// 玩家魔力消耗减少99%
			player.manaCost -= 0.2f;

			// 增加玩家10召唤物上限
			player.maxMinions += 10;

			// 玩家的跳跃速度增加7.5倍
			player.jumpSpeedBoost += 7.5f;

			// 玩家不受掉落伤害
			player.noFallDmg = true;

			// 玩家不受击退
			player.noKnockback = true;

			// 允许玩家连跳
			player.jumpBoost = true;

			// 自动收税？？？
			player.CollectTaxes();

            player.shinyStone = true;

			// 这个循环里的代码执行3次，也就是每一帧放出3次粒子，一秒就是180个，还挺多的
			if (hideVisual == true)
            {
                for (int i = 0; i < 3; i++)
                {
                    Dust.NewDust(player.position, player.width, player.height, MyDustId.PurpleLight, -player.velocity.X / 2,
                        -player.velocity.Y / 2, 10, Color.White, 1.0f);
                }
            }
		}
	}
}