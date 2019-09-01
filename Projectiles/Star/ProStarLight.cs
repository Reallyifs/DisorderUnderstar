using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.Star
{
    public class ProStarLight : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("金色激光");
        }
        public override void SetDefaults()
        {
            aiType = ProjectileID.MeteorShot;
            projectile.alpha = 10;
            projectile.light = 0.3f;
            projectile.scale = 1f;
            projectile.width = 2;
            projectile.height = 40;
            projectile.ranged = true;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.timeLeft = 600;
            projectile.penetrate = -1;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }
        public override void AI()
        {
            if (projectile.timeLeft < 597)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, MyDustId.YellowFx, 0f, 0f, +10,
                    Color.LightYellow, -0.5f);
                dust.noLight = false;
                dust.noGravity = true;
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, MyDustId.YellowFx, 0f, 0f, +10,
                    Color.LightYellow, -0.5f);
                dust.noLight = false;
                dust.noGravity = true;
            }
        }
    }
}
