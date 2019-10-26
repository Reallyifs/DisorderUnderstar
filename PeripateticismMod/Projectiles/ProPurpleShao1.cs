using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.PeripateticismMod.Projectiles
{
    public class ProPurpleShao1 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mana Power");
            DisplayName.AddTranslation(GameCulture.Chinese, "魔力");
        }
        public override void SetDefaults()
        {
            projectile.alpha = 250;
            projectile.width = 4;
            projectile.height = 4;
            projectile.aiStyle = -1;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.timeLeft = 100;
            projectile.knockBack = 0.5f;
            projectile.penetrate = -1;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.extraUpdates = 50;
        }
        public override void AI()
        {
            Dust dust = Dust.NewDustDirect(projectile.Center, 4, 4, Tools.MyDustId.PurpleHighFx, 0, 0);
            dust.alpha = Main.rand.Next(0, 255);
            dust.color = Color.Purple;
            dust.scale = Main.rand.NextFloat(0.8f, 1.2f);
            dust.noGravity = true;
            NPC tar = null;
            float disMAX = 100f;
            foreach (NPC npc in Main.npc)
            {
                if (npc.active && !npc.friendly && npc.type != NPCID.LunarTowerNebula && Collision.CanHit
                    (projectile.Center, 1, 1, npc.position, npc.width, npc.height) && npc.type != NPCID.LunarTowerSolar &&
                    npc.type != NPCID.LunarTowerStardust && npc.type != NPCID.LunarTowerVortex && !npc.dontTakeDamage)
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
                Vector2 tarVEC = Vector2.Normalize(tar.Center - projectile.Center) * 50;
                for (int i = 0; i < 5; i++)
                {
                    Projectile.NewProjectile(tar.Center, tarVEC, ModContent.ProjectileType<ProPurpleShao2>(), projectile.damage, 1f,
                        projectile.owner, tar.whoAmI);
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.tileCollide = true;
            if (projectile.velocity.X != oldVelocity.X) { projectile.velocity.X = -oldVelocity.X; }
            if (projectile.velocity.Y != oldVelocity.Y) { projectile.velocity.Y = -oldVelocity.Y; }
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.buffImmune[BuffID.Venom] = false;
            target.AddBuff(BuffID.Venom, damage);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            target.buffImmune[BuffID.Venom] = false;
            target.AddBuff(BuffID.Venom, damage);
        }
    }
}