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
            {
                Main.projFrames[projectile.type] = 3;
                projectile.frameCounter++;
                if (projectile.frameCounter >= 10)
                {
                    projectile.frameCounter = 0;
                    projectile.frame++;
                    if (projectile.frame >= 3)
                        projectile.frame = 0;
                }
            }
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
        }
        public override void AI()
        {
            Lighting.AddLight(projectile.position, 0f, 0f, 0.5f);
            for (int i = 0; i < 3; i++)
            {
                Dust.NewDustDirect(projectile.Center, projectile.width * 2,
                    projectile.height * 2, MyDustId.BlueMagic, -projectile.velocity.X,
                    -projectile.velocity.Y, 128, Color.Blue, 1.5f);
            }
            {
                NPC tar = null;
                float disMAX = 1000f;
                Player player = Main.player[projectile.owner];
                foreach (NPC npc in Main.npc)
                {
                    if (npc.active && !npc.friendly && npc.type != NPCID.TargetDummy)
                    {
                        float dis = Vector2.Distance(npc.Center, player.Center);
                        if (disMAX > dis)
                        {
                            disMAX = dis;
                            tar = npc;
                        }
                    }
                }
                if (tar != null)
                {
                    Vector2 tarVEC = Vector2.Normalize(tar.Center - projectile.Center);
                    tarVEC *= 20f;
                    float nVEC = 10f;
                    if (nVEC <= 10f)
                        nVEC -= 0.1f;
                    projectile.velocity = (projectile.velocity * nVEC + tarVEC) / (nVEC + 1f);
                }
            }
        }
        public override void Kill(int timeLeft)
        {
            for(int i = 0; i < 5; i++)
            {
                Dust.NewDustDirect(projectile.Center, projectile.width * 3,
                    projectile.height * 3, MyDustId.BlueCircle, 3f, 3f, 128, Color.Blue,
                    1f);
            }
        }
    }
}
