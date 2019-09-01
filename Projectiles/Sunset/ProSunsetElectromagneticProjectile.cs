using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.Sunset
{
    public class ProSunsetElectromagneticProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("电磁炮弹");
        }
        public override void SetDefaults()
        {
            projectile.alpha = 0;
            projectile.light = 0.4f;
            projectile.magic = true;
            projectile.width = 15;
            projectile.height = 13;
            projectile.aiStyle = -1;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.timeLeft = 6000;
            projectile.penetrate = 1;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            Main.projFrames[projectile.type] = 3;
        }
        public override void AI()
        {
            Lighting.AddLight(projectile.position, 0f, 0f, 0.5f);
            {
                projectile.frameCounter++;
                if (projectile.frameCounter >= 10)
                {
                    projectile.frame++;
                    projectile.frameCounter = 0;
                }
                if (projectile.frame >= 3) projectile.frame = 0;
            }
            for (int i = 0; i < 3; i++)
            {
                Dust.NewDustDirect(projectile.Center, projectile.width * 2, projectile.height * 2, MyDustId.BlueMagic, -projectile.velocity.X,
                    -projectile.velocity.Y, 128, Color.Blue, 1.5f);
            }
            if(projectile.timeLeft<=5997)
            {
                NPC tar = null;
                float disMAX = 1000f;
                foreach (NPC npc in Main.npc)
                {
                    if (npc.active && !npc.friendly && npc.type != NPCID.LunarTowerNebula && Collision.CanHit
                        (projectile.Center, 1, 1, npc.position, npc.width, npc.height) && npc.type != NPCID.LunarTowerSolar &&
                        npc.type != NPCID.LunarTowerStardust && npc.type != NPCID.LunarTowerVortex)
                    {
                        float dis = Vector2.Distance(npc.Center, projectile.Center);
                        if (disMAX >= dis)
                        {
                            tar = npc;
                            disMAX = dis;
                        }
                    }
                }
                if (tar != null)
                {
                    Vector2 tarVEC = Vector2.Normalize(tar.Center - projectile.Center) * 20;
                    float nVEC = 10f;
                    if (nVEC <= 10f) nVEC -= 0.1f;
                    projectile.velocity = (projectile.velocity * nVEC + tarVEC) / (nVEC + 1f);
                }
            }
        }
        public override void Kill(int timeLeft)
        {
            for(int i = 0; i < 5; i++)
            {
                Dust.NewDustDirect(projectile.Center, projectile.width * 3, projectile.height * 3, MyDustId.BlueCircle, 3f, 3f, 128,
                    Color.Blue, 1f);
            }
        }
    }
}
