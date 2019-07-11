using Terraria.ModLoader;
using Terraria;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.Disorder
{
    public class ProDisorderBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("无序剑气");
        }
        public override void SetDefaults()
        {
            projectile.melee = true;
            projectile.scale = 1.5f;
            projectile.width = 18;
            projectile.height = 18;
            projectile.aiStyle = -1;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.timeLeft = 1200;
        }
        public override void AI()
        {
            if (projectile.timeLeft < 1000)
            {
                projectile.damage = projectile.timeLeft * 2 - 666;
            }
            else if (projectile.timeLeft < 500)
            {
                projectile.damage = projectile.timeLeft * 2 + 2333;
                Dust dust = Dust.NewDustDirect
                        (projectile.position, projectile.width, projectile.height,
                        MyDustId.Fire, 0f, 0f, 10);
                dust.noGravity = true;
            }
            else
            {
                projectile.damage = projectile.timeLeft * 3 + 666;
            }
        }
    }
}
