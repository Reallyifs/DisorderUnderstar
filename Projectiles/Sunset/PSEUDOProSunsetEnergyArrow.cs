using System;
using Terraria;
using Terraria.ModLoader;
using DisorderUnderstar.Tools;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.Sunset
{
    public class PSEUDOProSunsetEnergyArrow : ModProjectile
    {
        public override string Texture => ProjectileOverride.弹幕贴图转换(ProjectileImageType.Transparent);
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("???你还能被这个打死我服了");
        }
        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.scale = 0.9f;
            projectile.damage = 1;
            projectile.height = 1;
            projectile.ranged = true;
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
                if (projectile.ai[0] <= 152f) { projectile.ai[0]++; }
                else if (projectile.ai[0] <= 1520f) { projectile.ai[0] *= 2; }
                else { projectile.ai[0]--; }
            }
            int _0 = 0;
            if (_0 <= 156) { _0++; }
            #endregion
            Player _1 = Main.player[projectile.owner];
            if (_1.channel)
            {
                Vector2 _2 = Vector2.Normalize(Main.MouseWorld - _1.Center);
                float _3 = _2.ToRotation();
                _1.itemTime = 2;
                _1.direction = Main.MouseWorld.X < _1.Center.X ? -1 : 1;
                _1.itemRotation = (float)Math.Atan2(_3.ToRotationVector2().Y * _1.direction, _3.ToRotationVector2().X + _1.direction);
                _1.itemAnimationMax = 2;
                for(float _4 = 0f; _4 < 1f; _4 += 0.1f)
                {
                    Dust _5 = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, MyDustId.BlueMagic, -_1.velocity.X / 2,
                        -_1.velocity.Y / 2, 255 - (_0 + 99), Color.Blue, (float)(_0 / 104f));
                    _5.rotation += 0.09f;
                    _5.velocity *= 1.5f;
                }
            }
            else
            {
                Player _6 = Main.player[projectile.owner];
                var _7 = Projectile.NewProjectileDirect(_6.Center, projectile.velocity * 30f, ModContent.ProjectileType<ProSunsetEnergyArrow>(),
                    (int)(projectile.ai[0] / 200f * 200), 6f, projectile.owner);
                _7.scale = 1f + (float)(projectile.ai[0] / 2448f);
                if (projectile.timeLeft > 30) { projectile.timeLeft = 30; }
                return;
            }
        }
        public override bool ShouldUpdatePosition() => false;
    }
}
