using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Tools;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.Star
{
    public class ProStarArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("星星之箭");
        }
        public override void SetDefaults()
        {
            projectile.alpha = 10;
            projectile.light = 0.3f;
            projectile.scale = 1f;
            projectile.width = 18;
            projectile.height = 22;
            projectile.ranged = true;
            projectile.aiStyle = 1;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.timeLeft = 600;
            projectile.penetrate = 1;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
        }
        public override void AI()
        {
            if (projectile.timeLeft < 597)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, MyDustId.YellowGoldenFire, 0f, 0f,
                    100, default(Color), 1f);
                dust.noGravity = true;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, damage * 5);
            target.AddBuff(BuffID.Confused, damage * 2);
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, MyDustId.YellowFx, 0f, 0f, 100,
                    Color.Yellow, 1f);
                dust.noLight = false;
                dust.noGravity = true;
            }
        }
    }
}
