﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using DisorderUnderstar.Projectiles.Star;
namespace DisorderUnderstar.Items.Star
{
    public class GalaxyLight : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galaxy Light");
            DisplayName.AddTranslation(GameCulture.Chinese, "星系之光");
            Tooltip.SetDefault("[Star]\n" +
                "\"The bright yellow stars glow blue...\"\n" +
                "\"That's strange.\"");
            Tooltip.AddTranslation(GameCulture.Chinese, "【星星】\n" +
                "“明明是黄色的星星却发出蓝色的光……”\n" +
                "“那可真奇怪。”");
        }
        public override void SetDefaults()
        {
            item.crit = 25;
            item.mana = 10;
            item.rare = ItemRarityID.LightPurple;
            item.magic = true;
            item.scale = 1f;
            item.shoot = ModContent.ProjectileType<ProStarFollowingStar1>();
            item.value = Item.sellPrice(0, 1, 50, 0);
            item.width = 40;
            item.damage = 12;
            item.height = 40;
            item.noMelee = true;
            item.useTime = 10;
            item.useTurn = true;
            item.maxStack = 1;
            item.useStyle = 5;
            item.autoReuse = true;
            item.knockBack = 1.5f;
            item.expertOnly = true;
            item.shootSpeed = 9f;
            item.useAnimation = 60;
            if (item.Prefix(PrefixID.Mythical)) { item.prefix = PrefixID.Godly; }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod)
            {
                anyIronBar = true
            };
            recipe1.AddIngredient(ItemID.StarCannon, 1);
            recipe1.AddIngredient(ItemID.Starfury, 1);
            recipe1.AddIngredient(ItemID.MeteoriteBar, 30);
            recipe1.AddIngredient(ModContent.ItemType<FireOfStarZero>(), 6);
            recipe1.AddIngredient(ItemID.FallenStar, 20);
            recipe1.AddIngredient(ModContent.ItemType<StarFrame>(), 3);
            recipe1.AddTile(TileID.Anvils);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}