using Terraria;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.Sunset
{
    public class ProSunsetBlackFireArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("黑炎箭");
        }
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.damage = 12;
            projectile.height = 34;
            projectile.ranged = true;
            projectile.aiStyle = 1;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.timeLeft = 9999999;
            projectile.knockBack = 0.5f;
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
                    MyDustId.Fire, -projectile.velocity.X, -projectile.velocity.Y, 100,
                    Color.Firebrick, 1f);
                dust.noLight = false;
                dust.noGravity = true;
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                Dust dust = Dust.NewDustDirect
                    (projectile.position, projectile.width, projectile.height,
                    MyDustId.Fire, 0f, 0f, -10,
                    Color.Firebrick, -0.5f);
                dust.noLight = false;
                dust.noGravity = true;
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("DebuffSunsetBlackFire"), damage);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("DebuffSunsetBlackFire"), damage);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("DebuffSunsetBlackFire"), damage);
        }
    }
}
