using System;
using Terraria;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
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
            projectile.ai[0] = 0f;
            {
                if (projectile.ai[0] <= 100f) projectile.ai[0]++;
                else if (projectile.ai[0] <= 1000f) projectile.ai[0] *= 2f;
                else projectile.ai[0]--;
            }
            int ai0 = 0;
            {
                if (ai0 <= 105f) ai0++;
            }
            if (Main.player[projectile.owner].channel)
            {
                Player player = Main.player[projectile.owner];
                Vector2 unit = Vector2.Normalize(Main.MouseWorld - player.Center);
                float rotaion = unit.ToRotation();
                player.direction = Main.MouseWorld.X < player.Center.X ? -1 : 1;
                player.itemRotation = (float)Math.Atan2
                    (rotaion.ToRotationVector2().Y * player.direction,
                    rotaion.ToRotationVector2().X * player.direction);
                player.itemTime = 2;
                player.itemAnimation = 2;
                for (float f = 0f; f < 1f; f += 0.1f)
                {
                    Dust d = Dust.NewDustDirect(projectile.Center, projectile.width,
                        projectile.height, MyDustId.BlueMagic, -player.velocity.X,
                        -player.velocity.Y, 128, Color.Blue, ai0 / (float)(106f / 1.5f));
                    d.rotation += 0.1f;
                    d.velocity *= 2;
                    Dust u = Dust.NewDustDirect(projectile.Center, projectile.width,
                        projectile.height, MyDustId.BlueCircle, -player.velocity.X,
                        -player.velocity.Y, 128, Color.Blue, ai0 / (float)(106f / 1.5f));
                    u.rotation += 0.3f;
                    u.velocity *= 1;
                }
            }
            else
            {
                var pro1 = Projectile.NewProjectileDirect(projectile.Center,
                    projectile.velocity * 7f,
                    mod.ProjectileType<ProSunsetElectromagneticProjectile>(),
                    (int)(projectile.ai[0] / 200f * 200), 5f, projectile.owner);
                pro1.scale = 1f + (float)(projectile.ai[0] / 1616f);
                if (projectile.timeLeft >= 30) projectile.timeLeft = 30;
                return;
            }
        }
        public override bool ShouldUpdatePosition()
        {
            return false;
        }
    }
}
