﻿using Terraria;
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
                "\"The stars are shining for you!\"");
            Tooltip.AddTranslation(GameCulture.Chinese, "【星星】\n" +
                "“星星正在为你照耀！”");
        }
        public override void SetDefaults()
        {
            item.crit = 10;
            item.rare = ItemRarityID.Lime;
            item.scale = 1f;
            item.shoot = mod.ProjectileType<ProStarArrow>();
            item.value = Item.sellPrice(0, 1, 50, 0);
            item.width = 28;
            item.damage = 60;
            item.expert = true;
            item.height = 60;
            item.ranged = true;
            item.noMelee = true;
            item.useAmmo = AmmoID.Arrow;
            item.useTime = 10;
            item.maxStack = 1;
            item.useStyle = 5;
            item.autoReuse = true;
            item.knockBack = 3f;
            item.shootSpeed = 20f;
            item.useAnimation = 20;
        }
        public override bool ConsumeAmmo(Player player)
        {
            if (Main.rand.Next(0, 4) < 3) { return false; }
            else { return true; }
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
            ref float knockBack)
        {
            if (item.shoot == ProjectileID.WoodenArrowFriendly)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType<ProStarArrow>(), item.damage,
                    item.knockBack / 2f, item.owner);
            }
            else if (item.shoot == ProjectileID.FireArrow)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType<ProStarArrow>(), item.damage,
                    item.knockBack / 2f, item.owner);
            }
            else { Projectile.NewProjectile(position.X, position.Y, speedX, speedY, item.shoot, item.damage, item.knockBack, item.owner); }
            return false;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0.0f, 0.0f);
        }
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
            recipe1.AddIngredient(mod.ItemType<FireOfStarZero>(), 8);
            recipe1.AddIngredient(mod.ItemType<StarFrame>(), 4);
            recipe1.AddTile(TileID.Anvils);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}