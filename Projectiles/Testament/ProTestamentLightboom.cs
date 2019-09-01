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
        }
        public override void SetDefaults()
        {
            projectile.melee = true;
            projectile.width = 16;
            projectile.damage = 130;
            projectile.height = 16;
            projectile.aiStyle = -1;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.timeLeft = 60;
            projectile.penetrate = -1;
        }
        public override void AI()
        {
            base.AI();
        }
    }
}
