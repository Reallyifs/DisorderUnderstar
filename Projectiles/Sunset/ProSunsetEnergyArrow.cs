using Terraria;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.Sunset
{
    public class ProSunsetEnergyArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("能量箭");
        }
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.damage = 31;
            projectile.height = 34;
            projectile.ranged = true;
            projectile.aiStyle = -1;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.timeLeft = 9999999;
            projectile.knockBack = 1f;
            projectile.penetrate = 1;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }
        public override void AI()
        {
            if (projectile.timeLeft < 9999996)
            {
                Dust _0 = Dust.NewDustDirect(projectile.position, projectile.width + 2, projectile.height + 2, MyDustId.BlueMagic,
                    projectile.velocity.X, projectile.velocity.Y, 100, Color.LightBlue, 1f);
                _0.noLight = false;
                _0.velocity *= 1.2f;
                _0.noGravity = true;
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int _1 = 0; _1 < 5; _1++)
            {
                Dust _2 = Dust.NewDustDirect(projectile.Center, projectile.width + 4, projectile.height + 4, MyDustId.BlueCircle,
                    projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, Color.LightBlue, 1.5f);
                _2.noLight = true;
                _2.velocity *= 1.2f;
                _2.noGravity = true;
            }
        }
    }
}
