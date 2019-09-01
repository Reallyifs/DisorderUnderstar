using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.Testament
{
    public class ProTestamentLightsaber : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("光剑");
        }
        public override void SetDefaults()
        {
            projectile.melee = true;
            projectile.width = 2;
            projectile.damage = 100;
            projectile.height = 2;
            projectile.aiStyle = -1;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.timeLeft = 100;
            projectile.penetrate = -1;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.extraUpdates = 100;
        }
        public override void AI()
        {
            Lighting.AddLight(projectile.position, 1f, 1f, 1f);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Projectile.NewProjectile(target.Center, target.velocity, mod.ProjectileType<ProTestamentLightboom>(), projectile.damage,
                projectile.knockBack, projectile.owner, target.whoAmI);
        }
    }
}
