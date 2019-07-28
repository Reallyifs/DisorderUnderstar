using Terraria;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles
{
    public class NHolyArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("神圣激光");
        }
        public override void SetDefaults()
        {
            projectile.alpha = 250;
            projectile.width = 4;
            projectile.damage = 100;
            projectile.height = 4;
            projectile.aiStyle = -1;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.timeLeft = 1000;
            projectile.penetrate = 10;
            projectile.extraUpdates = 100;
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 4; i++)
                Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height,
                    MyDustId.YellowHallowFx, projectile.oldVelocity.X,
                    projectile.oldVelocity.Y, 20, Color.Yellow, 1.3f);
        }
    }
}
