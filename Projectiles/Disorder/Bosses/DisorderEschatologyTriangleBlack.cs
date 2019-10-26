using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Tools;
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
            {
                projectile.frameCounter++;
                if (projectile.frameCounter >= 10)
                {
                    projectile.frame++;
                    projectile.frameCounter = 0;
                }
                if (projectile.frame >= 6) projectile.frame = 0;
            }
            if (projectile.timeLeft <= 149)
            {
                for(int i = 0; i < 2; i++)
                {
                    Dust dust = Dust.NewDustDirect
                        (projectile.Center, projectile.width + 2, projectile.height + 2,
                        MyDustId.BlackFlakes, 0f, 0f, 100,
                        Color.Black, 1f);
                    dust.noLight = false;
                    dust.noGravity = true;
                }
                Player pl = null;
                float disMAX = 300f;
                foreach (Player player in Main.player)
                {
                    if (player.active && player.aggro > 0 && Collision.CanHit
                        (projectile.Center, 1, 1, pl.position, pl.width, pl.height))
                    {
                        float dis = Vector2.Distance(projectile.Center, player.Center);
                        if (disMAX >= dis)
                        {
                            pl = player;
                            disMAX = dis;
                        }
                    }
                }
                if (pl != null)
                {
                    Vector2 plVEC = Vector2.Normalize(pl.Center - projectile.Center);
                    plVEC *= 35f;
                    float nVEC = 40f;
                    if (nVEC >= 40) nVEC -= 0.1f;
                    projectile.velocity =
                        (projectile.velocity * nVEC + plVEC) / (nVEC + 1f);
                }
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int r18 = 0; r18 < 5; r18++)
            {
                Dust dust = Dust.NewDustDirect
                    (projectile.Center, projectile.width + 2, projectile.height + 2,
                    MyDustId.BlackFlakes, 0f, 0f, 128,
                    Color.Black, 1.5f);
                dust.noLight = false;
                dust.noGravity = true;
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Darkness, damage * 2);
            target.AddBuff(mod.BuffType("DebuffFourHeavyBlocking"), target.dpsDamage * 3);
        }
    }
}