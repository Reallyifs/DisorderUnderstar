using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Tools;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.Glitch
{
    public class ProGlitchHolyLaser2 : ModProjectile
    {
        public bool[] visited;
        public float distance;
        public override string Texture => ProjectileOverride.弹幕贴图转换(true);
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("神圣激光");
        }
        public override void SetDefaults()
        {
            projectile.alpha = 250;
            projectile.width = 4;
            projectile.height = 4;
            projectile.aiStyle = -1;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.timeLeft = 400 - (int)distance;
            projectile.knockBack = 2f;
            projectile.penetrate = -1;
            projectile.extraUpdates = 90;
            distance = projectile.ai[1];
            visited = new bool[Main.npc.Length];
        }
        public override void AI()
        {
            #region 迷之发射机制
            NPC tar = null;
            float disMAX = 400f - distance;
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
                Vector2 tarVEC = Vector2.Normalize(tar.Center - projectile.Center) * 40;
                Projectile.NewProjectile(tar.Center, tarVEC, projectile.type, projectile.damage - (int)(distance / 5f), 1f, projectile.owner,
                    0, distance);
            }
            #endregion
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            distance += 5f;
            visited[target.whoAmI] = true;
        }
        public override void Kill(int timeLeft)
        {
            for(int i = -2; i <= 2; i++)
            {
                Dust d = Dust.NewDustDirect(projectile.Center, projectile.width + 4, projectile.height + 4, MyDustId.YellowHallowFx,
                    projectile.oldVelocity.X, projectile.oldVelocity.Y);
                d.alpha = Main.rand.Next(0, 255);
                d.color = Color.Yellow;
                d.scale = Main.rand.NextFloat(0.5f, 1.5f);
                d.velocity *= 1.1f;
                d.noGravity = true;
            }
        }
    }
}
