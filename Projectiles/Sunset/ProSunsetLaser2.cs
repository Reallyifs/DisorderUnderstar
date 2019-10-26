using Terraria;
using Terraria.ModLoader;
using DisorderUnderstar.Tools;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.Sunset
{
    public class ProSunsetLaser2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("金辉激光");
        }
        public override void SetDefaults()
        {
            projectile.magic = true;
            projectile.width = 4;
            projectile.damage = 74;
            projectile.height = 4;
            projectile.aiStyle = -1;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.timeLeft = 100;
            projectile.knockBack = 4f;
            projectile.ignoreWater = true;
            projectile.extraUpdates = 100;
        }
        public override void AI()
        {
            Lighting.AddLight(projectile.position, 1f, 1f, 0.5f);
            Lighting.AddLight(projectile.position, 0f, 0f, 0f);
            Dust d = Dust.NewDustDirect(projectile.position, 2, 2, MyDustId.YellowGoldenFire, 0, 0, 100, Color.Yellow, 1f);
            d.scale = (float)Main.rand.Next(90, 110) * 0.014f;
            d.position = projectile.Center - projectile.velocity / 3f;
            d.velocity *= 0.2f;
            d.noGravity = true;
            Dust u = Dust.NewDustDirect(projectile.position, 2, 2, MyDustId.WhiteLight, 0, 0, 100, Color.White, 1f);
            u.scale = (float)Main.rand.Next(90, 110) * 0.014f;
            u.position = projectile.Center - projectile.velocity / 3f;
            u.velocity *= 0.2f;
            u.noGravity = true;
            NPC tar = Main.npc[(int)projectile.ai[0]];
            if (tar.active)
            {
                Vector2 tarVEC = Vector2.Normalize(tar.Center - projectile.Center) * 6;
                float nVEC = 28f;
                if (nVEC > 0) { nVEC -= 0.1f; }
                projectile.velocity = (projectile.velocity * nVEC + tarVEC) / (nVEC + 1f);
            }
        }
    }
}