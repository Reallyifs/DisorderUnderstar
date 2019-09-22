using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.Star.Boss
{
    public class ProStarStardust : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stardust");
            DisplayName.AddTranslation(GameCulture.Chinese, "星尘");
        }
        public override void SetDefaults()
        {
            projectile.magic = true;
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = -1;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.timeLeft = 300;
            projectile.knockBack = 2f;
            projectile.ignoreWater = false;
            projectile.tileCollide = false;
            projectile.extraUpdates = 2;
        }
        public override void AI()
        {
            projectile.damage = (int)(projectile.timeLeft / 10);
            Player player = Main.player[(int)projectile.ai[0]];
            if (player.active)
            {
                Vector2 tVEC = Vector2.Normalize(player.Center - projectile.Center) * 20;
                int nVEC = 20;
                if (nVEC > 0) { nVEC--; }
                projectile.velocity = (projectile.velocity * nVEC + tVEC) / (nVEC + 1);
            }
            else
            {
                foreach (Player target in Main.player)
                {
                    if (target.active) { player = target; }
                }
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int i = -5; i < 5; i++)
            {
                Dust dust = Dust.NewDustDirect(projectile.Center, projectile.width + 2, projectile.height + 2, MyDustId.TrailingYellow1,
                    projectile.oldVelocity.X / 2, projectile.oldVelocity.Y / 2);
                dust.alpha = Main.rand.Next(100, 200);
                dust.color = Color.LightYellow;
                dust.scale = Main.rand.NextFloat(0.8f, 1.2f);
                dust.velocity *= 0.4f;
                Player player = Main.player[(int)projectile.ai[0]];
                Vector2 tVEC = Vector2.Normalize(player.Center - projectile.Center) * 30;
                Vector2 tSVEC = tVEC + new Vector2(-tVEC.Y, tVEC.X) * i;
                Projectile.NewProjectile(projectile.Center, tSVEC, mod.ProjectileType<ProStarScatteredStardust>(), 24, 0.1f, projectile.owner,
                    player.whoAmI);
            }
        }
    }
}
