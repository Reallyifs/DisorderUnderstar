using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.Disorder.Bosses
{
    public class DisorderEschatologyTriangleBlack : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("三角型攻击");
        }
        public override void SetDefaults()
        {
            projectile.alpha = 10;
            projectile.scale = 1f;
            projectile.width = 2;
            projectile.damage = 75;
            projectile.height = 40;
            projectile.ranged = true;
            projectile.aiStyle = -1;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.timeLeft = 150;
            projectile.knockBack = 0.1f;
            projectile.penetrate = 1;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            Main.projFrames[projectile.type] = 6;
        }
        public override void AI()
        {
            Dust dust = Dust.NewDustDirect
                (projectile.position, projectile.width, projectile.height,
                MyDustId.BlackFlakes, 0f, 0f, 100,
                Color.Black, 1f);
            dust.noGravity = true;
            dust.noLight = false;
        }
        public override void Kill(int timeLeft)
        {
            for (int r18 = 0; r18 < 5; r18++)
            {
                Dust dust = Dust.NewDustDirect
                    (projectile.position, projectile.width, projectile.height,
                    MyDustId.BlackFlakes, 0f, 0f, -10,
                    Color.Black, -0.5f);
                dust.noGravity = true;
                dust.noLight = false;
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Darkness, damage * 2);
            target.AddBuff(mod.BuffType("DebuffFourHeavyBlocking"), target.dpsDamage * 3);
        }
    }
}
