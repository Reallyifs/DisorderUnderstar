using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Items.Armors
{
    [AutoloadEquip(EquipType.Head)]
    public class ChlorophyteHeadnail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("叶绿头甲");
            Tooltip.SetDefault("增加16%的[c/FF8000:近战伤害]，增加6%的[c/FF8000:近战暴击]\n" +
                "增加64%的[c/00007F:远程伤害]，20%的几率不[c/00007F:消耗弹药]\n" +
                "增加16%的[c/FF00FF:魔法伤害]，增加80的[c/0000FF:魔法上限]，减少17%的[c/0000FF:魔法消耗]\n" +
                "直接召唤一个[c/00FF00:叶绿水晶]为你而战");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(0, 18, 0, 0);
            item.width = 20;
            item.expert = true;
            item.height = 20;
            item.defense = 45;
            item.expertOnly = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            item.shoot = ProjectileID.CrystalLeaf;
            player.manaCost -= 0.17f;
            player.meleeCrit += 6;
            player.crystalLeaf = true;
            player.magicDamage += 0.16f;
            player.meleeDamage += 0.16f;
            player.rangedDamage += 0.64f;
            player.statManaMax2 += 80;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
            ref float knockBack)
        {
            Vector2 positionVEC = new Vector2(player.Center.X, player.position.Y - player.height);
            Projectile.NewProjectile(positionVEC, player.velocity, ProjectileID.CrystalLeaf, 100, 2f, player.whoAmI);
            return false;
        }
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.Next(100) < 20;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe0 = new ModRecipe(mod);
            recipe0.AddIngredient(ItemID.ChlorophyteMask, 1);
            recipe0.AddIngredient(ItemID.ChlorophyteHelmet, 1);
            recipe0.AddIngredient(ItemID.ChlorophyteHeadgear, 1);
            recipe0.AddIngredient(ItemID.ChlorophyteBar, 20);
            recipe0.AddTile(TileID.MythrilAnvil);
            recipe0.SetResult(this);
            recipe0.AddRecipe();
        }
    }
}