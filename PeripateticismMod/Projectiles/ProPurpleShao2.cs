using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.PeripateticismMod.Projectiles
{
    public class ProPurpleShao2 : ModProjectile
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
            projectile.timeLeft = 500;
            projectile.knockBack = 1.5f;
            projectile.penetrate = 1;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.extraUpdates = 50;
        }
        public override void AI()
        {
            Dust dust = Dust.NewDustDirect(projectile.Center, 4, 4, Tools.MyDustId.PurpleHighFx, 0, 0);
            dust.alpha = Main.rand.Next(0, 255);
            dust.color = Color.Purple;
            dust.scale = Main.rand.NextFloat(0.4f, 0.8f);
            dust.noGravity = true;
            NPC tar = Main.npc[(int)projectile.ai[0]];
            if (tar.active)
            {
                Vector2 tarVEC = Vector2.Normalize(tar.Center - projectile.Center) * 50;
                float nVEC = 30f;
                if (nVEC > 0f) { nVEC--; }
                projectile.velocity = (projectile.velocity * nVEC + tarVEC) / (nVEC + 1f);
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
            if (Main.rand.Next(1, 20) <= 1)
            {
                target.buffImmune[BuffID.Poisoned] = false;
                target.AddBuff(BuffID.Poisoned, 600);
            }
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            if (Main.rand.Next(1, 20) <= 1)
            {
                target.buffImmune[BuffID.Poisoned] = false;
                target.AddBuff(BuffID.Poisoned, 600);
            }
        }
    }
}