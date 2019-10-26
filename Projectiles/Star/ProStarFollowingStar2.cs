using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.Star
{
    public class ProStarFollowingStar2 : ModProjectile
    {
        private int aiVisited;
        private bool[] visited;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("星星");
        }
        public override void SetDefaults()
        {
            projectile.damage = 43;
            projectile.melee = true;
            projectile.aiStyle = -1;
            projectile.timeLeft = 1000;
            projectile.knockBack = 0.1f;
            projectile.penetrate = -1;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.extraUpdates = 5;
            aiVisited = (int)projectile.ai[0];
            visited = new bool[Main.npc.Length];
        }
        public override void AI()
        {
            #region 跟踪算法
            float disMAX = 300f;
            NPC tar = null;
            foreach (NPC npc in Main.npc)
            {
                if (npc.active && !npc.friendly && npc.type != NPCID.TargetDummy && Collision.CanHit
                    (projectile.Center, 1, 1, npc.position, npc.width, npc.height) && !visited[npc.whoAmI] &&
                    npc.type != NPCID.LunarTowerNebula && npc.type != aiVisited && npc.type != NPCID.LunarTowerSolar &&
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
                Vector2 tarVEC = Vector2.Normalize(tar.Center - projectile.Center) * 20;
                float nVEC = 30f;
                if (nVEC > 0) { nVEC -= 0.1f; }
                projectile.velocity = (projectile.velocity * nVEC + tarVEC) / (nVEC + 1f);
            }
            #endregion
            #region 速度算法
            if (projectile.timeLeft <= 1000 && projectile.timeLeft > 800) { projectile.velocity *= 1.5f; }
            else if (projectile.timeLeft <= 800 && projectile.timeLeft > 300) { projectile.velocity *= 0.99f; }
            else
            {
                projectile.alpha += 1;
                projectile.velocity *= 0.5f;
            }
            #endregion
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            visited[target.whoAmI] = true;
        }
    }
}