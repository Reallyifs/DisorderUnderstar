using Terraria;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.Star
{
    public class ProStarDownStar : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("星星");
        }
        public override void SetDefaults()
        {
            projectile.damage = 43;
            projectile.melee = true;
            projectile.aiStyle = -1;
            projectile.timeLeft = 60;
            projectile.knockBack = 0.1f;
            projectile.penetrate = -1;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }
        public override void AI()
        {
            #region 弹幕的粒子效果
            for(int i = 0; i < 8; i++)
            {
                Dust d = Dust.NewDustDirect(projectile.Center, projectile.width + 4,
                    projectile.height + 4, MyDustId.TrailingYellow1, -projectile.velocity.X,
                    -projectile.velocity.Y);
                d.alpha = Main.rand.Next(0, 200);
                d.color = Color.Yellow;
                d.scale = Main.rand.NextFloat(0.5f, 1.5f);
                d.velocity *= 0.3f;
            }
            #endregion
            #region 弹幕的速度快慢
            if (projectile.timeLeft <= 60 && projectile.timeLeft > 30) projectile.velocity *= 1.5f;
            else if (projectile.timeLeft == 30) projectile.velocity *= 0.99f;
            else
            {
                projectile.alpha += 9;
                projectile.velocity *= 0.5f;
            }
            #endregion
        }
        #region 发射FollowingStar2
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target = Main.npc[(int)projectile.ai[0]];
            Vector2 NPCUpVEC = new Vector2(target.Center.X, target.position.Y - target.height);
            Vector2 NPCToVEC = Vector2.Normalize(target.Center - NPCUpVEC) * 5;
            Projectile.NewProjectile(NPCUpVEC, NPCToVEC,
                mod.ProjectileType("ProStarFollowingStar2"), projectile.damage / 2,
                projectile.knockBack / 2, projectile.owner, target.whoAmI);
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target = Main.player[(int)projectile.ai[0]];
            Vector2 PLAYERUpVEC = new Vector2(target.Center.X, target.position.Y - target.height);
            Vector2 PLAYERToVEC = Vector2.Normalize(target.Center - PLAYERUpVEC) * 5;
            Projectile.NewProjectile(PLAYERUpVEC, PLAYERToVEC,
                mod.ProjectileType("ProStarFollowingStar2"), projectile.damage / 2,
                projectile.knockBack / 2, projectile.owner, target.whoAmI);
        }
        #endregion
        public override void Kill(int timeLeft)
        {
            for(int i = 0; i < 8; i++)
            {
                Dust d = Dust.NewDustDirect(projectile.Center, projectile.width + 6,
                    projectile.height + 6, MyDustId.TrailingYellow1, -projectile.velocity.X,
                    -projectile.velocity.Y);
                d.alpha = Main.rand.Next(0, 200);
                d.color = Color.Yellow;
                d.scale = Main.rand.NextFloat(0.5f, 1.5f);
                d.velocity *= 0.3f;
            }
        }
    }
}