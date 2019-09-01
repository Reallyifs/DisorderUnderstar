using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using DisorderUnderstar.Utils;
namespace DisorderUnderstar.Items.Star
{
    public class SurroundStar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("环绕之星");
            Tooltip.SetDefault("【星星-Star】\n" +
                "“这项链旁好像围着一些小的行星碎片？”\n" +
                "“嘿，看呐，流星雨。”\n" +
                "“听说流星的温度很高呢……”\n" +
                "-\n" +
                "最大生命增加100，最大魔法增加20\n" +
                "魔法、近战和远程伤害增加10%，魔法消耗减少1%\n" +
                "近战暴击增加5%，近战速度增加10%，速度增加50%，跳跃高度增加10%\n" +
                "免疫击退，着火，中毒，剧毒\n" +
                "如果你的生命低于你最大生命的30%，你会获得冰障Buff\n" +
                "-");
        }
        public override void SetDefaults()
        {
            item.rare = 5;
            item.value = Item.buyPrice(0, 0, 50, 0);
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.width = 30;
            item.height = 30;
            item.defense = 20;
            item.maxStack = 1;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            {
                player.statLifeMax2 += 100;
                player.statManaMax2 += 50;
            }
            {
                player.magicDamage += 0.1f;
                player.meleeDamage += 0.1f;
                player.rangedDamage += 0.1f;
            }
            {
                player.manaCost -= 0.01f;
                player.moveSpeed += 0.5f;
                player.meleeCrit += 5;
                player.meleeSpeed += 0.1f;
            }
            {
                player.noKnockback = true;
                player.jumpSpeedBoost += 0.1f;
            }
            {
                player.buffImmune[BuffID.Venom] = true;
                player.buffImmune[BuffID.OnFire] = true;
                player.buffImmune[BuffID.Poisoned] = true;
            }
            if (player.statLife < player.statLifeMax2 * 0.3f)
            {
                player.AddBuff(BuffID.IceBarrier, 1);
            }
            if (hideVisual == true)
            {
                for (int i = 0; i < 1; i++)
                {
                    Dust.NewDustDirect(player.position, player.width, player.height,
                        MyDustId.YellowGoldenFire, -player.velocity.X * 0.5f, -player.velocity.Y * 0.5f, 100, Color.White, 1.0f);
                }
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe0 = new ModRecipe(mod);
            recipe0.AddIngredient(ItemID.RoyalGel, 1);
            recipe0.AddIngredient(ItemID.EoCShield, 1);
            recipe0.AddIngredient(ItemID.WormScarf, 1);
            recipe0.AddIngredient(ItemID.FallenStar, 10);
            recipe0.AddIngredient(mod.ItemType<StarFrame>(), 5);
            recipe0.AddTile(TileID.Anvils);
            recipe0.SetResult(this);
            recipe0.AddRecipe();
        }
    }
}