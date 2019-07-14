using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Items
{
    public class GlitchRIO : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glitch R.I.O.");
            Tooltip.SetDefault("Glitch S.I.O的老弟\n" +
                "离最后只有一秒之差。");
        }
        public override void SetDefaults()
        {
            item.crit = 50;
            item.mana = 13;
            item.rare = ItemRarityID.Pink;
            item.magic = true;
            item.scale = 1f;
            item.shoot = mod.ProjectileType("NHolyArrow");
            item.value = Item.sellPrice(1, 1, 1, 1);
            item.width = 43;
            item.damage = 100;
            item.height = 54;
            item.noMelee = true;
            item.useTime = 30;
            item.maxStack = 1;
            item.useStyle = 5;
            item.autoReuse = true;
            item.knockBack = 19.5f;
            item.shootSpeed = 20f;
            item.useAnimation = 30;
        }
        public override bool Shoot
            (Player player, ref Vector2 position, ref float speedX, ref float speedY,
            ref int type, ref int damage, ref float knockBack)
        {
            float dis = 5f;
            float disMAX = 500f;
            Vector2 uVEC = new Vector2(speedX, speedY);
            uVEC.Normalize();
            for (float i = 0f; i < disMAX; i += dis)
            {
                var d = Dust.NewDustDirect(position + uVEC * i, 1, 1, MyDustId.YellowHallowFx,
                    0, 0, 0, Color.Yellow, 1.5f);
                d.velocity *= 0;
                d.noGravity = true;
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.Wood, 33);
            recipe1.AddIngredient(ItemID.StoneBlock, 33);
            recipe1.AddIngredient(ItemID.FallenStar, 11);
            recipe1.AddIngredient(ItemID.HellstoneBar, 11);
            recipe1.AddTile(TileID.WorkBenches);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}