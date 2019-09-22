using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.Testament
{
    public class ProTestamentLightboom : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("光爆");
            Main.projFrames[projectile.type] = 7;
        }
        public override void SetDefaults()
        {
            projectile.melee = true;
            projectile.width = 49;
            projectile.damage = 130;
            projectile.height = 49;
            projectile.aiStyle = -1;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.timeLeft = 70;
            projectile.penetrate = -1;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }
        public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 10)
            {
                projectile.frame++;
                projectile.width += 3;
                projectile.height += 3;
                projectile.frameCounter = 0;
            }
            if (projectile.frame == 8) { projectile.Kill(); }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.life -= 13;
            target.lifeMax -= 13;
            if (!target.active)
            {
                target.life = target.lifeMax / 2;
                target.active = true;
                target.lifeMax -= target.lifeMax / 2;
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            Player player = Main.player[projectile.owner];
            if (target.team != player.team && target.statLife >= target.statLifeMax2 / 10) { target.statLife -= target.statLifeMax2 / 10; }
        }
    }
}
