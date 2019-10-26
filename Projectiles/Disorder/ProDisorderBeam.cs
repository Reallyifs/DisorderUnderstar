using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Tools;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.Disorder
{
    public class ProDisorderBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("无序剑气");
        }
        public override void SetDefaults()
        {
            projectile.melee = true;
            projectile.scale = 1f;
            projectile.width = 30;
            projectile.height = 30;
            projectile.aiStyle = -1;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.timeLeft = 1200;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
        }
        public override void AI()
        {
            #region 伤害计算
            if (projectile.timeLeft <= 250) { projectile.damage = projectile.timeLeft * 3 + 666; }
            else if (projectile.timeLeft <= 500)
            {
                projectile.damage = projectile.timeLeft * 2 + 2333;
                Dust _0 = Dust.NewDustDirect(projectile.Center, projectile.width + 2, projectile.height + 2, MyDustId.Fire, -projectile.velocity.X,
                    -projectile.velocity.Y, 128, default(Color), 1.5f);
                _0.noLight = false;
                _0.noGravity = true;
            }
            else { projectile.damage = projectile.timeLeft * 2 - 666; }
            #endregion
            if (projectile.timeLeft <= 1197)
            {
                NPC tar = null;
                float disMAX = 1000f;
                foreach(NPC npc in Main.npc)
                {
                    if (npc.active && !npc.friendly && npc.type != NPCID.TargetDummy && Collision.CanHit
                        (projectile.Center, 1, 1, npc.position, npc.width, npc.height) && npc.type != NPCID.LunarTowerNebula &&
                        npc.type != NPCID.LunarTowerSolar && npc.type != NPCID.LunarTowerStardust && npc.type != NPCID.LunarTowerVortex)
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
                    float nVEC = 20f;
                    if (nVEC <= 20f) { nVEC -= 0.1f; }
                    projectile.velocity = (projectile.velocity * nVEC + tarVEC) / (nVEC + 1f);
                }
            }
        }
    }
}