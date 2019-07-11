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
                Dust dust = Dust.NewDustDirect
                    (projectile.position, projectile.width, projectile.height,
                    MyDustId.BlueMagic, -projectile.velocity.X, -projectile.velocity.Y, 100,
                    Color.LightBlue, 1f);
                dust.noGravity = true;
                dust.noLight = false;
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                Dust dust = Dust.NewDustDirect
                    (projectile.position, projectile.width, projectile.height,
                    MyDustId.BlueCircle, 0f, 0f, -10,
                    Color.LightBlue, +0.5f);
                dust.noGravity = true;
                dust.noLight = true;
            }
        }
    }
}
