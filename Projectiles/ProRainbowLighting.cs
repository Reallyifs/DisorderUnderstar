using System;
using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.Localization;
using DisorderUnderstar.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace DisorderUnderstar.Projectiles
{
    public class ProRainbowLighting : ModProjectile
    {
        private const float 最大蓄力值 = 50f;
        private const float 从玩家到粒子效果 = 60f;
        public float 距离
        {
            get => projectile.ai[0];
            set => projectile.ai[0] = value;
        }
        public float 蓄力时间
        {
            get => projectile.localAI[0];
            set => projectile.localAI[0] = value;
        }
        public bool 蓄能时间已到 => 蓄力时间 == 最大蓄力值;
        public override string Texture => ProjectileOverride.弹幕贴图转换(true);
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rainbow Lighting");
            DisplayName.AddTranslation(GameCulture.Chinese, "胜彩耀光");
        }
        public override void SetDefaults()
        {
            projectile.hide = true;
            projectile.magic = true;
            projectile.scale = 1f;
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = -1;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.timeLeft = 1000;
            projectile.penetrate = -1;
            projectile.tileCollide = true;
            projectile.ignoreWater = false;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (蓄能时间已到)
            {
                Vector2 方向 = projectile.velocity;
                Vector2 开始 = Main.player[projectile.owner].Center;
                Texture2D 材质 = Main.projectileTexture[projectile.type];
                绘制激光(spriteBatch, 材质, 开始, 方向, 10, projectile.damage, 1f, 1f, 1000, Color.White, (int)从玩家到粒子效果);
            }
            return false;
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            projectile.position = player.Center + projectile.velocity * 从玩家到粒子效果;
            projectile.timeLeft = 2;
            更新玩家(player);
            激光蓄力(player);
            if (蓄力时间 < 最大蓄力值) { return; }
            设置激光位置(player);
            生成粒子(player);
            发光();
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            Player player = Main.player[projectile.owner];
            Vector2 方向 = projectile.velocity;
            float 点 = 0f;
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), player.Center,
                player.Center + 方向 * 距离, 22, ref 点);
        }
        public override bool ShouldUpdatePosition() => false;
        public override void CutTiles()
        {
            DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
            Utils.PlotTileLine(projectile.Center, projectile.Center + projectile.velocity * 距离, (projectile.width + 16) * projectile.scale,
                DelegateMethods.CutTiles);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            if (Main.rand.Next(1, 4) <= 1)
            {
                player.ApplyDamageToNPC(target, target.life / Main.rand.Next(4, 8), 3f, 0, Main.rand.NextBool());
            }
            target.immune[projectile.type] = 0;
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            target.statLife -= target.statLife / Main.rand.Next(5, 10);
            target.immune = true;
            target.immuneTime = 5;
        }
        public void 绘制激光(SpriteBatch spriteBatch, Texture2D 材质, Vector2 开始, Vector2 方向, float 步长, int 伤害, float 旋转 = 0f,
           float 倍数 = 1f, float 最大距离 = 2000f, Color 颜色 = default(Color), int transDist = 50)
        {
            float 旋转2 = 方向.ToRotation() + 旋转;
            Vector2 首位置 = 开始 + 方向 * (距离 + 步长) - Main.screenPosition;
            Vector2 尾位置 = 开始 + 方向 * (transDist - 步长) - Main.screenPosition;
            for (float f = transDist; f < 最大距离; f += 步长)
            {
                Color 透明 = Color.Transparent;
                Color 不染色 = Color.White;
                Vector2 位置 = 开始 + 方向 * f - Main.screenPosition;
                spriteBatch.Draw(材质, 位置, new Rectangle(0, 26, 28, 26), f < transDist ? 透明 : 不染色, 旋转2, new Vector2(28 * 0.5f, 26 * 0.5f),
                    倍数, 0, 0);
            }
            spriteBatch.Draw(材质, 首位置, new Rectangle(0, 0, 28, 26), Color.White, 旋转2, new Vector2(28 * 0.5f, 26 * 0.5f), 倍数, 0, 0);
            spriteBatch.Draw(材质, 尾位置, new Rectangle(0, 56, 28, 26), Color.White, 旋转2, new Vector2(28 * 0.5f, 26 * 0.5f), 倍数, 0, 0);
        }
        private void 更新玩家(Player player)
        {
            if (projectile.owner == Main.myPlayer)
            {
                Vector2 tVEC = Vector2.Normalize(Main.MouseWorld - player.Center);
                projectile.velocity = tVEC;
                projectile.direction = Main.MouseWorld.X > player.Center.X ? 1 : -1;
                projectile.netUpdate = true;
            }
            player.heldProj = projectile.whoAmI;
            player.itemTime = 2;
            player.itemRotation = (float)Math.Atan2(projectile.velocity.Y * projectile.rotation, projectile.velocity.X * projectile.rotation);
            player.itemAnimation = 2;
            player.ChangeDir(projectile.direction);
        }
        private void 激光蓄力(Player player)
        {
            if (!player.channel) { projectile.Kill(); }
            else
            {
                if (Main.time % 10 < 1 && player.CheckMana(player.inventory[player.selectedItem].mana, true)) { projectile.Kill(); }
                if (蓄力时间 < 最大蓄力值) { 蓄力时间++; }
                int cINT = (int)(蓄力时间 / 20f);
                Vector2 位置 = player.Center + projectile.velocity * (从玩家到粒子效果 - 20f) - new Vector2(10, 10);
                Vector2 粒子速度 = Vector2.UnitX * 18f;
                粒子速度 = 粒子速度.RotatedBy(projectile.rotation - 1.57f);
                Vector2 产生位置 = projectile.Center + 粒子速度;
                for (int i = 0; i < cINT + 1; i++)
                {
                    Vector2 产生 = 产生位置 + ((float)Main.rand.NextDouble() * 6.28f).ToRotationVector2() * (12f - cINT * 2);
                    Dust dust = Dust.NewDustDirect(位置, 20, 20, MyDustId.WhiteLight, projectile.velocity.X / 3, projectile.velocity.Y / 3);
                    dust.scale = Main.rand.Next(10, 20) * 0.005f;
                    dust.velocity = Vector2.Normalize(产生位置 - 产生) * (10f - cINT * 2f) * 1.5f / 10;
                    dust.noGravity = true;
                }
            }
        }
        private void 设置激光位置(Player player)
        {
            for (距离 = 从玩家到粒子效果; 距离 <= 2200f; 距离 += 5f)
            {
                var 开始 = player.Center + projectile.velocity * 距离;
                if (!Collision.CanHit(player.Center, 1, 1, 开始, 1, 1))
                {
                    距离 -= 5f;
                    break;
                }
            }
        }
        private void 生成粒子(Player player)
        {
            Vector2 方向 = projectile.velocity * -1;
            Vector2 粒子位置 = player.Center + projectile.velocity * 距离;
            for (int i = 0; i < 2; i++)
            {
                float 变量1 = projectile.velocity.ToRotation() + (Main.rand.Next(2) == 1 ? -1 : 1) * 1.57f;
                float 变量2 = (float)(Main.rand.NextDouble() * 0.8f + 1f);
                Vector2 粒子速度 = new Vector2((float)Math.Cos(变量1) * 变量2, (float)Math.Sin(变量1) * 变量2);
                Dust d = Dust.NewDustDirect(粒子位置, 0, 0, 226, 粒子速度.X, 粒子速度.Y);
                d.scale = 1.2f;
                d.noGravity = true;
                Dust u = Dust.NewDustDirect(player.Center, 0, 0, 31, -方向.X * 距离, -方向.Y * 距离);
                u.color = Color.Cyan;
                u.scale = 0.88f;
                u.fadeIn = 0;
                u.noGravity = true;
            }
            if (Main.rand.NextBool(5))
            {
                方向 = Vector2.Normalize(粒子位置 - player.Center);
                Vector2 起点 = projectile.velocity.RotatedBy(1.75f) * ((float)Main.rand.NextDouble() - 0.5f) * projectile.width;
                Dust d = Dust.NewDustDirect(粒子位置 + 起点 - Vector2.One * 4, 8, 8, MyDustId.Smoke, 0, 0, 100, new Color(), 1.5f);
                d.velocity *= 0.5f;
                d.velocity.Y = -Math.Abs(d.velocity.Y);
                Dust u = Dust.NewDustDirect(player.Center + 55 * 方向, 8, 8, MyDustId.Smoke, 0, 0, 100, new Color(), 1.5f);
                u.velocity *= 0.5f;
                u.velocity.Y = -Math.Abs(d.velocity.Y);
            }
        }
        private void 发光()
        {
            DelegateMethods.v3_1 = new Vector3(0.8f, 0.8f, 1f);
            Utils.PlotTileLine(projectile.Center, projectile.Center + projectile.velocity * (距离 - 从玩家到粒子效果), projectile.width,
                DelegateMethods.CastLight);
        }
    }
}