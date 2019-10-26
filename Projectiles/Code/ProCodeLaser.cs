using Terraria;
using Terraria.ModLoader;
using DisorderUnderstar.Tools;
using Microsoft.Xna.Framework;
using DisorderUnderstar.Dusts.Code.DustCodeNumber;
using DisorderUnderstar.Dusts.Code.DustCodeParticle;
namespace DisorderUnderstar.Projectiles.Code
{
    public class ProCodeLaser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("代码激光");
        }
        public override void SetDefaults()
        {
            projectile.light = 0.5f;
            projectile.magic = true;
            projectile.scale = 0.9f;
            projectile.width = 7;
            projectile.height = 38;
            projectile.aiStyle = -1;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.timeLeft = 600;
            projectile.penetrate = 2;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
        }
        public override void AI()
        {
            if (projectile.timeLeft < 597)
            {
                float _0 = Main.rand.NextFloatDirection() * 0.8f;
                Dust _1 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, MyDustId.SicklyGreen, _0, _0, 100,
                    Color.Green, 3f);
                _1.noGravity = true;
                Dust _2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, ModContent.DustType<DustCodeParticle0>(), _0,
                    _0, 10, Color.Green, 1f);
                _2.noLight = false;
                Dust _3 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, ModContent.DustType<DustCodeNumberAll>(), _0,
                    _0, 25, Color.Green, 1f);
                _3.noLight = false;
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int _4 = 0; _4 < 5; _4++)
            {
                Dust _5 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, ModContent.DustType<DustCodeParticle0>(), 0f,
                    0f, 10, Color.Green, 1f);
                _5.noLight = false;
                Dust _6 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, ModContent.DustType<DustCodeNumberAll>(), 0f,
                    0f, 25, Color.Green, 1f);
                _6.noLight = false;
            }
        }
    }
}