using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Items.Star
{
    public class StarManaGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("星法光枪");
            Tooltip.SetDefault("【星星-Star】\n" +
                "“射出激光！”");
        }
        public override void SetDefaults()
        {
            item.crit = 24;
            item.mana = 8;
            item.rare = ItemRarityID.Lime;
            item.magic = true;
            item.scale = 0.9f;
            item.shoot = mod.ProjectileType("ProStarLight");
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
            if (Main.dayTime)
            {
                item.damage = 49;
            }
            else if (!Main.dayTime)
            {
                item.damage = 82;
            }
            else if (Main.bloodMoon)
            {
                item.damage = 93;
            }
            else if (Main.snowMoon)
            {
                item.damage = 104;
            }
            else if (Main.pumpkinMoon)
            {
                item.damage = 104;
            }
            else
            {
                item.damage = 115;
            }
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == mod.ItemType("StarHat") &&
                body.type == mod.ItemType("StarVest") &&
                legs.type == mod.ItemType("StarPants");
        }
        public override void UpdateArmorSet(Player player)
        {
            item.mana = 0;
            item.crit = 35;
            item.damage = 71;
            if (Main.dayTime)
            {
                item.damage = 60;
            }
            else if (!Main.dayTime)
            {
                item.damage = 93;
            }
            else if (Main.bloodMoon)
            {
                item.damage = 104;
            }
            else if (Main.snowMoon)
            {
                item.damage = 115;
            }
            else if (Main.pumpkinMoon)
            {
                item.damage = 115;
            }
            else
            {
                item.damage = 126;
            }
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
            real.AddIngredient(mod, "StarFrame", 7);
            real.AddIngredient(ItemID.FallenStar, 14);
            real.AddTile(TileID.Tables);
            real.AddTile(TileID.Chairs);
            real.AddTile(TileID.Anvils);
            real.SetResult(this);
            real.AddRecipe();
        }
    }
}
