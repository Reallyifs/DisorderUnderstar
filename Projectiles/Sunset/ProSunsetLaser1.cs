using Terraria;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.Sunset
{
    public class ProSunsetLaser1 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("金辉激光");
        }
        public override void SetDefaults()
        {
            projectile.width = 4;
            projectile.damage = 50;
            projectile.height = 4;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.timeLeft = 500;
            projectile.knockBack = 3f;
            projectile.ignoreWater = true;
            projectile.extraUpdates = 100;
        }
        public override void AI()
        {
            Lighting.AddLight(projectile.position, 1f, 1f, 0.5f);
            for (int i = 0; i < 3; i++)
            {
                Dust d = Dust.NewDustDirect(projectile.position, projectile.width,
                    projectile.height, MyDustId.YellowGoldenFire, 0, 0, 100, Color.Yellow, 1f);
                d.position = projectile.Center - projectile.velocity * i / 3f;
                d.velocity *= 0.2f;
                d.noGravity = true;
                d.scale = (float)Main.rand.Next(90, 110) * 0.014f;
            }
            NPC tar = null;
            float disMAX = 1000f;
            foreach (NPC npc in Main.npc)
            {
                if (npc.active && !npc.friendly)
                {
                    float dis = Vector2.Distance(npc.Center, projectile.Center);
                    if (dis <= disMAX)
                    {
                        disMAX = dis;
                        tar = npc;
                    }
                }
            }
            if (tar != null && projectile.timeLeft % 10 < 1)
            {
                Vector2 tarVEC = Vector2.Normalize(tar.Center - projectile.Center);
                tarVEC *= 6f;
                tarVEC = tarVEC.RotatedBy(Main.rand.NextFloatDirection() * 0.3f);
                Projectile.NewProjectile(projectile.Center + projectile.velocity * 4f,
                            tarVEC, mod.ProjectileType("ProSunsetLaser2"), 100, 5f,
                            projectile.owner);
            }
        }
    }
}
