﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using DisorderUnderstar.Projectiles.Star;
using DisorderUnderstar.Items.Star.Armors;
namespace DisorderUnderstar.Items.Star
{
    public class StarManaGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Mana Gun");
            DisplayName.AddTranslation(GameCulture.Chinese, "星法光枪");
            Tooltip.SetDefault("[Star]\n" +
                "\"Shoot a laser!\"");
            Tooltip.AddTranslation(GameCulture.Chinese, "【星星】\n" +
                "“射出激光！”");
        }
        public override void SetDefaults()
        {
            item.crit = 24;
            item.mana = 8;
            item.rare = ItemRarityID.Lime;
            item.magic = true;
            item.scale = 0.9f;
            item.shoot = ModContent.ProjectileType<ProStarLight>();
            item.value = Item.buyPrice(0, 12, 0, 0);
            item.value = Item.sellPrice(0, 6, 0, 0);
            item.width = 34;
            item.damage = 60;
            item.height = 24;
            item.noMelee = true;
            item.useTime = 30;
            item.useStyle = 5;
            item.autoReuse = true;
            item.knockBack = 2f;
            item.shootSpeed = 40f;
            item.useAnimation = 30;
            #region 神奇的判定
            if (Main.dayTime) { item.damage = 49; }
            else if (!Main.dayTime) { item.damage = 82; }
            else if (Main.bloodMoon) { item.damage = 93; }
            else if (Main.snowMoon) { item.damage = 104; }
            else if (Main.pumpkinMoon) { item.damage = 104; }
            else { item.damage = 115; }
            #endregion
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ModContent.ItemType<StarHat>() && body.type == ModContent.ItemType<StarVest>() &&
                legs.type == ModContent.ItemType<StarPants>();
        }
        public override void UpdateArmorSet(Player player)
        {
            item.mana = 0;
            item.crit = 35;
            item.damage = 71;
            #region 神奇的判定2
            if (Main.dayTime) { item.damage = 60; }
            else if (!Main.dayTime) { item.damage = 93; }
            else if (Main.bloodMoon) { item.damage = 104; }
            else if (Main.snowMoon) { item.damage = 115; }
            else if (Main.pumpkinMoon) { item.damage = 115; }
            else { item.damage = 126; }
            #endregion
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0.0f, 0.0f);
        }
        public override void AddRecipes()
        {
            ModRecipe real = new ModRecipe(mod)
            {
                anyIronBar = true
            };
            real.AddIngredient(ItemID.SpaceGun, 1);
            real.AddIngredient(ItemID.IronBar, 20);
            real.AddIngredient(ItemID.MeteoriteBar, 7);
            real.AddIngredient(ModContent.ItemType<StarFrame>(), 7);
            real.AddIngredient(ItemID.FallenStar, 14);
            real.AddTile(TileID.Tables);
            real.AddTile(TileID.Chairs);
            real.AddTile(TileID.Anvils);
            real.SetResult(this);
            real.AddRecipe();
        }
    }
}