using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.Star.Boss
{
    public class ProStarScatteredStardust : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scattered StarDust");
            DisplayName.AddTranslation(GameCulture.Chinese, "零散星尘");
        }
        public override void SetDefaults()
        {
            projectile.magic = true;
            projectile.width = 14;
            projectile.height = 30;
            projectile.aiStyle = -1;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.timeLeft = 150;
            projectile.knockBack = 2f;
            projectile.ignoreWater = false;
            projectile.tileCollide = false;
            projectile.extraUpdates = 4;
        }
        public override void AI()
        {
            if (projectile.timeLeft <= 140)
            {
                Player player = Main.player[(int)projectile.ai[0]];
                if (player.active)
                {
                    Vector2 tVEC = Vector2.Normalize(player.Center - projectile.Center) * 40;
                    int nVEC = 10;
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
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (target.statLife >= target.statLifeMax2 / 10) { target.statLife -= target.statLifeMax2 / 10; }
            else { target.statLife -= target.statLifeMax2 / 20; }
        }
    }
}
