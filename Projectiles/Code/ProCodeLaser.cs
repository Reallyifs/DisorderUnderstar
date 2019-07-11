using Terraria;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.Code
{
    public class ProCodeLaser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("代码激光");
        }
        public override void SetDefaults()
        {
            projectile.light = 0.5f;
            projectile.magic = true;
            projectile.scale = 0.9f;
            projectile.width = 7;
            projectile.height = 38;
            projectile.aiStyle = -1;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.timeLeft = 600;
            projectile.penetrate = 2;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
        }
        public override void AI()
        {
            if (projectile.timeLeft < 597)
            {
                Dust dust = Dust.NewDustDirect
                    (projectile.position, projectile.width, projectile.height,
                    MyDustId.SicklyGreen, 0f, 0f, 100,
                    Color.Green, 3f);
                dust.noGravity = true;
                Dust no = Dust.NewDustDirect
                        (projectile.position, projectile.width, projectile.height,
                        mod.DustType("DustCodeParticle"), 0f, +0.1f, +10,
                        Color.Green, -0.4f);
                no.noLight = false;
                Dust tsud = Dust.NewDustDirect
                    (projectile.position, projectile.width, projectile.height,
                    mod.DustType("DustCodeNumber"), 0f, +0.2f, +25,
                    Color.Green, -0.1f);
                tsud.noLight = false;
            }
        }
        public override void Kill(int timeLeft)
        {
            for(int i = 0; i < 5; i++)
            {
                Dust dust = Dust.NewDustDirect
                        (projectile.position, projectile.width, projectile.height,
                        mod.DustType("DustCodeParticle"), 0f, +0.1f, +10,
                        Color.Green, -0.4f);
                dust.noLight = false;
                Dust tsud = Dust.NewDustDirect
                    (projectile.position, projectile.width, projectile.height,
                    mod.DustType("DustCodeNumber"), 0f, +0.2f, +25,
                    Color.Green, -0.1f);
                tsud.noLight = false;
            }
        }
    }
}