using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.LoadedMod
{
    public class ProWtfway : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("POWER");
            DisplayName.AddTranslation(GameCulture.Chinese, "力量");
        }
        public override void SetDefaults()
        {
            projectile.alpha = 200;
            projectile.width = 12;
            projectile.damage = 24;
            projectile.height = 30;
            projectile.aiStyle = -1;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.timeLeft = 500;
            projectile.knockBack = 1f;
            projectile.penetrate = 1;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
        }
        public override void AI()
        {
            projectile.alpha--;
            NPC tar = Main.npc[(int)projectile.ai[0]];
            if (tar.active)
            {
                float dis = Vector2.Distance(tar.Center, projectile.Center);
                Vector2 tVEC = Vector2.Normalize(tar.Center - projectile.Center) * 50;
                projectile.velocity += tVEC;
                if (projectile.timeLeft <= 1 && tar.dontTakeDamageFromHostiles && dis >= 0f) { projectile.timeLeft++; }
            }
        }
    }
}