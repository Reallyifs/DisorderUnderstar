using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
using DisorderUnderstar.Projectiles.Glitch;
namespace DisorderUnderstar.Items.Glitch
{
    public class GlitchSIO : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glitch S.I.O.");
            Tooltip.SetDefault("知道了么？……\n" +
                "离最后只有一秒之差。");
        }
        public override void SetDefaults()
        {
            item.crit = 55;
            item.rare = ItemRarityID.Red;
            item.scale = 1f;
            item.value = Item.sellPrice(0, 30, 00, 00);
            item.width = 20;
            item.damage = 969;
            item.expert = true;
            item.height = 34;
            item.ranged = true;
            item.useAmmo = AmmoID.Arrow;
            item.useTime = 3;
            item.noMelee = false;
            item.useStyle = 5;
            item.maxStack = 1;
            item.autoReuse = true;
            item.knockBack = 2f;
            item.expertOnly = true;
            item.shootSpeed = 30f;
            item.useAnimation = 30;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
            ref float knockBack)
        {
            #region 发射粒子
            float dis = 5f;
            float disMAX = 300f;
            Vector2 uVEC = new Vector2(speedX, speedY);
            uVEC.Normalize();
            for (float i = 0f; i < disMAX; i += dis)
            {
                var d = Dust.NewDustDirect(position + uVEC * i, 4, 4, MyDustId.BlueMagic, 0, 0, 0, Color.Blue, 1.5f);
                d.velocity *= 0.3f;
                d.noGravity = true;
            }
            #endregion
            #region 向目标发射
            NPC tar = null;
            foreach (NPC npc in Main.npc)
            {
                if (npc.active && !npc.friendly && npc.type != NPCID.LunarTowerNebula && Collision.CanHit
                    (Main.MouseWorld, 1, 1, npc.position, npc.width, npc.height) && npc.type != NPCID.LunarTowerSolar &&
                    npc.type != NPCID.LunarTowerStardust && npc.type != NPCID.LunarTowerVortex)
                {
                    float dis2 = Vector2.Distance(npc.Center, Main.MouseWorld);
                    if (dis2 <= disMAX)
                    {
                        tar = npc;
                        disMAX = dis;
                    }
                }
            }
            if (tar != null)
            {
                Vector2 tVEC = Vector2.Normalize(tar.Center - Main.MouseWorld) * 40;
                Projectile.NewProjectile(player.Center, tVEC, mod.ProjectileType<ProGlitchHolyLaser>(), item.damage, item.knockBack, item.owner);
            }
            #endregion
            return false;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0.0f, 0.0f);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(mod.ItemType<GlitchRIO>(), 1);
            recipe1.AddIngredient(mod.ItemType<DXTBlade>(), 1);
            recipe1.AddIngredient(mod.ItemType<RSGun>(), 1);
            recipe1.AddIngredient(ItemID.MoltenFury, 1);
            recipe1.AddIngredient(ItemID.HallowedRepeater, 1);
            recipe1.AddIngredient(ItemID.ChlorophyteShotbow, 1);
            recipe1.AddTile(TileID.LunarCraftingStation);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}