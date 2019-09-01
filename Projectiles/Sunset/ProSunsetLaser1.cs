using Terraria;
using Terraria.ID;
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
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.timeLeft = 5000;
            projectile.knockBack = 3f;
            projectile.ignoreWater = true;
            projectile.extraUpdates = 100;
        }
        public override void AI()
        {
            Lighting.AddLight(projectile.position, 1f, 1f, 0.5f);
            for (int i = 0; i < 1; i++)
            {
                Dust d = Dust.NewDustDirect(projectile.position, 1, 1, MyDustId.YellowGoldenFire, 0, 0, 100, Color.Yellow, 1f);
                d.scale = (float)Main.rand.Next(90, 110) * 0.014f;
                d.position = projectile.Center - projectile.velocity * i / 3f;
                d.velocity *= 0.2f;
                d.noGravity = true;
            }
            {
                NPC tar = null;
                float disMAX = 500f;
                foreach (NPC npc in Main.npc)
                {
                    if (npc.active && !npc.friendly && npc.type != NPCID.LunarTowerNebula && Collision.CanHit
                        (projectile.Center, 1, 1, npc.position, npc.width, npc.height) && npc.type != NPCID.LunarTowerSolar &&
                        npc.type != NPCID.LunarTowerStardust && npc.type != NPCID.LunarTowerVortex)
                    {
                        float dis = Vector2.Distance(npc.Center, projectile.Center);
                        if (dis <= disMAX)
                        {
                            tar = npc;
                            disMAX = dis;
                        }
                    }
                }
                if (tar != null)
                {
                    Vector2 tarVEC = Vector2.Normalize(tar.Center - projectile.Center) * 6;
                    tarVEC = tarVEC.RotatedBy(Main.rand.NextFloatDirection() * 0.3f);
                    Projectile.NewProjectile(projectile.Center + projectile.velocity * 4f, tarVEC, mod.ProjectileType("ProSunsetLaser2"), 100,
                        5f, projectile.owner, tar.whoAmI);
                }
            }
        }
    }
}
