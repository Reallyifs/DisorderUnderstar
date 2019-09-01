using System;
using Terraria;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.Sunset
{
    public class PSEUDOProSunsetEnergyArrow : ModProjectile
    {
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
            projectile.ai[0] = 0f;
            {
                if (projectile.ai[0] <= 152f) projectile.ai[0]++;
                else if (projectile.ai[0] <= 1520f) projectile.ai[0] *= 2;
                else projectile.ai[0]--;
            }
            int ai0 = 0;
            {
                if (ai0 <= 156) ai0++;
            }
            Player pl = Main.player[projectile.owner];
            if (pl.channel)
            {
                Vector2 uVEC = Vector2.Normalize(Main.MouseWorld - pl.Center);
                float rVEC = uVEC.ToRotation();
                pl.direction = Main.MouseWorld.X < pl.Center.X ? -1 : 1;
                pl.itemRotation = (float)Math.Atan2(rVEC.ToRotationVector2().Y * pl.direction, rVEC.ToRotationVector2().X + pl.direction);
                pl.itemTime = 2;
                pl.itemAnimationMax = 2;
                for(float f = 0f; f < 1f; f += 0.1f)
                {
                    Dust d = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, MyDustId.BlueMagic, -pl.velocity.X,
                        -pl.velocity.Y, 255 - (ai0 + 99), Color.Blue, (float)(ai0 / 104f));
                    d.rotation += 0.09f;
                    d.velocity *= 1.5f;
                }
            }
            else
            {
                var pVEC = Projectile.NewProjectileDirect(projectile.Center, projectile.velocity * 30f,
                    mod.ProjectileType<ProSunsetEnergyArrow>(), (int)(projectile.ai[0] / 200f * 200), 6f, projectile.owner);
                pVEC.scale = 1f + (float)(projectile.ai[0] / 2448f);
                if (projectile.timeLeft > 30) projectile.timeLeft = 30;
                return;
            }
        }
        public override bool ShouldUpdatePosition()
        {
            return false;
        }
    }
}
