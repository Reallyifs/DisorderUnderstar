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
            projectile.friendly = true;
            projectile.timeLeft = 5000;
            projectile.knockBack = 3f;
            projectile.ignoreWater = true;
            projectile.extraUpdates = 100;
        }
        public override void AI()
        {
            Lighting.AddLight(projectile.position, 1f, 1f, 0.5f);
            for (int i = 0; i < 2; i++)
            {
                Dust d = Dust.NewDustDirect(projectile.position, projectile.width,
                    projectile.height, MyDustId.YellowGoldenFire, 0, 0, 100, Color.Yellow, 1f);
                d.scale = (float)Main.rand.Next(90, 110) * 0.014f;
                d.position = projectile.Center - projectile.velocity * i / 3f;
                d.velocity *= 0.2f;
                d.noGravity = true;
            }
            NPC tar = null;
            float disMAX = 1000f;
            foreach (NPC npc in Main.npc)
            {
                if (npc.active && !npc.friendly && npc.type != NPCID.LunarTowerNebula &&
                    !npc.behindTiles && Collision.CanHit
                    (projectile.Center, 1, 1, npc.position, npc.width, npc.height) &&
                    npc.type != NPCID.LunarTowerSolar &&
                    npc.type != NPCID.LunarTowerStardust &&
                    npc.type != NPCID.LunarTowerVortex)
                {
                    float dis = Vector2.Distance(npc.Center, projectile.Center);
                    if (dis <= disMAX)
                    {
                        tar = npc;
                        disMAX = dis;
                    }
                }
            }
            int attack = 0;
            {
                if (attack >= 0) attack++;
                if (attack == 5) attack = 0;
            }
            if (tar != null && attack == 5)
            {
                Vector2 tarVEC = Vector2.Normalize(tar.Center - projectile.Center) * 6;
                tarVEC = tarVEC.RotatedBy(Main.rand.NextFloatDirection() * 0.3f);
                Projectile.NewProjectile(projectile.Center + projectile.velocity * 4f,
                            tarVEC, mod.ProjectileType("ProSunsetLaser2"), 100, 5f,
                            projectile.owner, tar.whoAmI);
            }
        }
    }
}
