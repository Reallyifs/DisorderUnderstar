using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using DisorderUnderstar.Projectiles.Star;
namespace DisorderUnderstar.Items.Star
{
    public class StellarDeliberate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stellar Deliberate");
            DisplayName.AddTranslation(GameCulture.Chinese, "星体蓄意");
            Tooltip.SetDefault("[Star]\n" +
                "\"The stars are shining for you!\"\n" +
                "60% chance to not [c/00007F:consume arrow]\n" +
                (Main.expertMode ? "Turn Wooden arrow, Fire arrow and Jesters arrow into Star arrow." : "Turn Wooden arrow to Star arrow"));
            Tooltip.AddTranslation(GameCulture.Chinese, "【星星】\n" +
                "“星星正在为你照耀！”\n" +
                "60%的几率不[c/00007F:消耗箭]\n" +
                (Main.expertMode ? "将木剑，火焰箭和小丑箭转换为星星箭" : "将木剑转换为星星之箭"));
        }
        public override void SetDefaults()
        {
            item.crit = 10;
            item.rare = ItemRarityID.Yellow;
            item.scale = 1f;
            item.shoot = ModContent.ProjectileType<ProStarArrow>();
            item.value = Item.sellPrice(0, 1, 50, 0);
            item.width = 28;
            item.damage = 60;
            item.height = 60;
            item.ranged = true;
            item.noMelee = true;
            item.useAmmo = AmmoID.Arrow;
            item.useTime = 10;
            item.maxStack = 1;
            item.useStyle = 5;
            item.autoReuse = true;
            item.knockBack = 3f;
            item.expertOnly = true;
            item.shootSpeed = 20f;
            item.useAnimation = 20;
        }
        public override bool ConsumeAmmo(Player player) => Main.rand.Next(0, 4) > 3;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
            ref float knockBack)
        {
            Vector2 tVEC = Vector2.Normalize(Main.MouseWorld - player.Center) * item.shootSpeed;
            if (Main.expertMode)
            {
                if (type == ProjectileID.WoodenArrowFriendly || type == ProjectileID.FireArrow || type == ProjectileID.JestersArrow)
                {
                    type = ModContent.ProjectileType<ProStarArrow>();
                }
            }
            else if (type == ProjectileID.WoodenArrowFriendly) { type = ModContent.ProjectileType<ProStarArrow>(); }
            Projectile.NewProjectile(position, tVEC, type, damage, knockBack, item.owner);
            return false;
        }
        public override Vector2? HoldoutOffset() => new Vector2(0f, 0f);
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod)
            {
                anyIronBar = true
            };
            recipe1.AddIngredient(ItemID.FallenStar, 20);
            recipe1.AddIngredient(ItemID.LifeCrystal, 1);
            recipe1.AddIngredient(ItemID.ManaCrystal, 1);
            recipe1.AddIngredient(ItemID.Wood, 30);
            recipe1.AddIngredient(ItemID.IronBar, 20);
            recipe1.AddIngredient(ModContent.ItemType<FireOfStarZero>(), 8);
            recipe1.AddIngredient(ModContent.ItemType<StarFrame>(), 4);
            recipe1.AddTile(TileID.Anvils);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}