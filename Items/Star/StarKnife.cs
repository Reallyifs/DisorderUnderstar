using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using DisorderUnderstar.Projectiles.Star;
namespace DisorderUnderstar.Items.Star
{
    public class StarKnife : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("星星之剑");
            Tooltip.SetDefault("【星星-Star】\n" +
                "“手握希望。”");
        }
        public override void SetDefaults()
        {
            item.crit = 20;
            item.rare = ItemRarityID.LightRed;
            item.melee = true;
            item.scale = 1.5f;
            item.value = Item.buyPrice(0, 3, 0, 0);
            item.value = Item.sellPrice(0, 1, 50, 0);
            item.width = 30;
            item.damage = 43;
            item.height = 30;
            item.useTime = 10;
            item.useStyle = 1;
            item.autoReuse = true;
            item.knockBack = 0.1f;
            item.useAnimation = 10;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
            ref float knockBack)
        {
            NPC _1 = null;
            Player _2 = null;
            #region 对敌方的无差别全方位打击
            #region NPC
            foreach (NPC _3 in Main.npc)
            {
                if (_3.active && !_3.friendly && _3.type != NPCID.LunarTowerNebula && _3.type != NPCID.LunarTowerSolar &&
                    _3.type != NPCID.LunarTowerStardust && _3.type != NPCID.LunarTowerVortex) _1 = _3;
            }
            if (_1 != null)
            {
                Vector2 NPCUpVEC = new Vector2(_1.Center.X, _1.position.Y - _1.height);
                Vector2 NPCToVEC = Vector2.Normalize(_1.Center - NPCUpVEC) * 10;
                Projectile.NewProjectile(NPCUpVEC, NPCToVEC, mod.ProjectileType<ProStarDownStar>(), item.damage, item.knockBack, item.owner,
                    _1.whoAmI);
            }
            #endregion
            #region PLAYER
            foreach (Player _3 in Main.player)
            {
                if (_3.team != player.team && _3.statLife >= 100 && _3.statDefense >= 10) _2 = _3;
            }
            if (_2 != null)
            {
                Vector2 PLAYERUpVEC = new Vector2(_2.Center.X, _2.position.Y - _2.height);
                Vector2 PLAYERToVEC = Vector2.Normalize(_1.Center - PLAYERUpVEC) * 10;
                Projectile.NewProjectile(PLAYERUpVEC, PLAYERToVEC, mod.ProjectileType<ProStarDownStar>(), item.damage, item.knockBack,
                    item.owner, _2.whoAmI);
            }
            #endregion
            #endregion
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe real = new ModRecipe(mod);
            real.AddIngredient(ItemID.Starfury, 1);
            real.AddIngredient(ItemID.Hellstone, 10);
            real.AddIngredient(mod.ItemType<StarFrame>(), 5);
            real.AddIngredient(ItemID.FallenStar,10);
            real.AddTile(TileID.Anvils);
            real.SetResult(this);
            real.AddRecipe();
        }
    }
}
