using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.Star.Monsters
{
    public class ProStarITSOF1 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("灵液弹幕");
        }
        public override void SetDefaults()
        {
            projectile.alpha = 10;
            projectile.light = 0.1f;
            projectile.magic = true;
            projectile.scale = 1f;
            projectile.width = 46;
            projectile.height = 26;
            projectile.aiStyle = 44;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.timeLeft = 600;
            projectile.penetrate = -1;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }
        public override void AI()
        {
            projectile.alpha += 10;
            if (projectile.rotation >= 1) projectile.rotation = 0;
            else projectile.rotation += 0.2f;
            if (projectile.timeLeft < 597)
            {
                Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, MyDustId.GreenFXPowder, 0f, 0f, +85,
                    Color.Yellow, -0.3f);
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.OnFire, damage * 2);
        }
    }
}
