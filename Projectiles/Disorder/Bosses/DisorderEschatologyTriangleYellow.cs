using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.Disorder.Bosses
{
    public class DisorderEschatologyTriangleYellow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("三角型攻击");
            Main.projFrames[projectile.type] = 6;
            projectile.frameCounter++;
            if (projectile.frameCounter >= 10)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 6) projectile.frame = 0;
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
        }
        public override void AI()
        {
            if (projectile.timeLeft <= 149)
            {
                for (int i = 0; i < 2; i++)
                {
                    Dust dust = Dust.NewDustDirect
                        (projectile.Center, projectile.width + 2, projectile.height + 2,
                        MyDustId.YellowFx, 0f, 0f, 100,
                        Color.Yellow, 1f);
                    dust.noLight = false;
                    dust.noGravity = true;
                }
                Player pl = null;
                float disMAX = 300f;
                foreach (Player player in Main.player)
                {
                    if (player.active && player.aggro > 0)
                    {
                        float dis = Vector2.Distance(projectile.Center, player.Center);
                        if (disMAX >= dis)
                        {
                            pl = player;
                            disMAX = dis;
                        }
                    }
                    else if (pl != null)
                    {
                        Vector2 plVEC = Vector2.Normalize(pl.Center - projectile.Center);
                        plVEC *= 35f;
                        float nVEC = 40f;
                        if (nVEC >= 40) nVEC -= 0.1f;
                        projectile.velocity =
                            (projectile.velocity * nVEC + plVEC) / (nVEC += 1f);
                    }

                }
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                Dust dust = Dust.NewDustDirect
                    (projectile.Center, projectile.width + 2, projectile.height + 2,
                    MyDustId.YellowFx, 0f, 0f, 128,
                    Color.Yellow, 1.5f);
                dust.noLight = false;
                dust.noGravity = true;
            }
        }
        public override void OnHitPlayer(Terraria.Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Ichor, damage * 2);
            target.AddBuff(mod.BuffType("DebuffFourHeavyBlocking"), target.dpsDamage * 3);
        }
    }
}