using Terraria;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
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
            {
                Lighting.AddLight(projectile.position, 1f, 1f, 0.5f);
                Lighting.AddLight(projectile.position, 0f, 0f, 0f);
            }
            for (int i = 0; i < 2; i++)
            {
                Dust d = Dust.NewDustDirect(projectile.position, projectile.width,
                    projectile.height, MyDustId.YellowGoldenFire, 0, 0, 100, Color.Yellow, 1f);
                d.position = projectile.Center - projectile.velocity * i / 3f;
                d.velocity *= 0.2f;
                d.noGravity = true;
                d.scale = (float)Main.rand.Next(90, 110) * 0.014f;
                Dust u = Dust.NewDustDirect(projectile.position, projectile.width,
                    projectile.height, MyDustId.WhiteLight, 0, 0, 100, Color.White, 1f);
                u.position = projectile.Center - projectile.velocity * i / 3f;
                u.velocity *= 0.2f;
                u.noGravity = true;
                u.scale = (float)Main.rand.Next(90, 110) * 0.014f;
            }
            NPC tar = Main.npc[(int)projectile.ai[0]];
            if (tar.active)
            {
                float nVEC = 28f;
                if (nVEC <= 28f && nVEC > 0) nVEC -= 0.1f;
                Vector2 tarVEC = Vector2.Normalize(tar.Center - projectile.Center);
                tarVEC *= 6f;
                projectile.velocity = (projectile.velocity * nVEC + tarVEC) / (nVEC + 1f);
                if (projectile.velocity.Length() < 30) projectile.velocity *= 2;
            }
        }
    }
}
