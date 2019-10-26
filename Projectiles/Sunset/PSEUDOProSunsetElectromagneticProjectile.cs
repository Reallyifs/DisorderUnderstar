using System;
using Terraria;
using Terraria.ModLoader;
using DisorderUnderstar.Tools;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.Sunset
{
    public class PSEUDOProSunsetElectromagneticProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("???你还能被这个打死我服了");
        }
        public override void SetDefaults()
        {
            projectile.magic = true;
            projectile.width = 1;
            projectile.scale = 0.9f;
            projectile.damage = 1;
            projectile.height = 1;
            projectile.aiStyle = -1;
            projectile.hostile = true;
            projectile.friendly = true;
            projectile.timeLeft = 999999999;
            projectile.knockBack = 0.1f;
            projectile.penetrate = -1;
            projectile.ignoreWater = false;
            projectile.tileCollide = false;
        }
        public override void AI()
        {
            #region 相关数值
            projectile.ai[0] = 0f;
            {
                if (projectile.ai[0] <= 100f) { projectile.ai[0]++; }
                else if (projectile.ai[0] <= 1000f) { projectile.ai[0] *= 2f; }
                else { projectile.ai[0]--; }
            }
            int _0 = 0;
            if (_0 <= 105f) _0++;
            #endregion
            if (Main.player[projectile.owner].channel)
            {
                Player _1 = Main.player[projectile.owner];
                Vector2 _2 = Vector2.Normalize(Main.MouseWorld - _1.Center);
                float _3 = _2.ToRotation();
                _1.itemTime = 2;
                _1.direction = Main.MouseWorld.X < _1.Center.X ? -1 : 1;
                _1.itemRotation = (float)Math.Atan2(_3.ToRotationVector2().Y * _1.direction, _3.ToRotationVector2().X * _1.direction);
                _1.itemAnimation = 2;
                for (float _4 = 0f; _4 < 1f; _4 += 0.1f)
                {
                    Dust _5 = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, MyDustId.BlueMagic, -_1.velocity.X / 2,
                        -_1.velocity.Y / 2, 128, Color.Blue, _0 / (float)(106f / 1.5f));
                    _5.rotation += 0.1f;
                    _5.velocity *= 2;
                    Dust _6 = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, MyDustId.BlueCircle, -_1.velocity.X,
                        -_1.velocity.Y, 128, Color.Blue, _0 / (float)(106f / 1.5f));
                    _6.rotation += 0.3f;
                    _6.velocity *= 1;
                }
            }
            else
            {
                Player _7 = Main.player[projectile.owner];
                var _8 = Projectile.NewProjectileDirect(_7.Center, projectile.velocity * 7f,
                    ModContent.ProjectileType<ProSunsetElectromagneticProjectile>(), (int)(projectile.ai[0] / 200f * 200), 5f, projectile.owner);
                _8.scale = 1f + (float)(projectile.ai[0] / 1616f);
                if (projectile.timeLeft >= 30) { projectile.timeLeft = 30; }
                return;
            }
        }
        public override bool ShouldUpdatePosition()
        {
            return false;
        }
    }
}