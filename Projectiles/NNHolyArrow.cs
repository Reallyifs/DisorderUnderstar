using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles
{
    public class NNHolyArrow : ModProjectile
    {
        public float distance;
        private bool[] visited;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("神圣激光");
        }
        public override void SetDefaults()
        {
            projectile.alpha = 250;
            projectile.width = 4;
            projectile.damage = 100;
            projectile.height = 4;
            projectile.aiStyle = -1;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.timeLeft = 1000;
            projectile.knockBack = 2f;
            projectile.penetrate = 1;
            projectile.extraUpdates = 100;
            visited = new bool[Main.npc.Length];
        }
        public override void AI()
        {
            if (projectile.ai[0] == 0)
            {
                NPC tar = null;
                float disMAX = 400f;
                foreach (NPC npc in Main.npc)
                {
                    if (npc.active && !npc.friendly && npc.type != NPCID.LunarTowerNebula &&
                        !npc.behindTiles && Collision.CanHit
                        (projectile.Center, 1, 1, npc.position, npc.width, npc.height) &&
                        !visited[npc.whoAmI] && npc.type != NPCID.LunarTowerSolar &&
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
                if (tar != null)
                {
                    Vector2 tarVEC = Vector2.Normalize(tar.Center - projectile.Center) * 40;
                    Projectile.NewProjectile(tar.Center, tarVEC, projectile.type, 100, 5f,
                                projectile.owner, 1);
                }
            }
            if (projectile.ai[0] == 1)
            {
                NPC tar = null;
                float disMAX = 200f - distance;
                foreach (NPC npc in Main.npc)
                {
                    if (npc.active && !npc.friendly && npc.type != NPCID.LunarTowerNebula &&
                        !npc.behindTiles && Collision.CanHit
                        (projectile.Center, 1, 1, npc.position, npc.width, npc.height) &&
                        !visited[npc.whoAmI] && npc.type != NPCID.LunarTowerSolar &&
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
                if (tar != null)
                {
                    Vector2 tarVEC = Vector2.Normalize(tar.Center - projectile.Center) * 30;
                    Projectile.NewProjectile(tar.Center, tarVEC,
                        mod.ProjectileType("NNNHolyArrow"), 90, 2.5f,
                                projectile.owner, tar.whoAmI);
                }
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            distance += 5f;
            visited[target.whoAmI] = true;
        }
    }
}
