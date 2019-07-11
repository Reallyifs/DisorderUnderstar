using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
namespace DisorderUnderstar.Projectiles
{
    public class FalseBeam : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("假剑气");
		}
		public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
			projectile.scale = 1.5f;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.melee = true;
            projectile.timeLeft = 600;
			projectile.ignoreWater = true;
			projectile.aiStyle = 132;

			// 如果写这句话粒子效果也变成泰拉剑气的了
			// aiType = ProjectileID.TerraBeam;
        }
		public override void AI()
		{
            if (projectile.timeLeft < 597)
            {
                Dust dust = Dust.NewDustDirect
                        (projectile.position, projectile.width, projectile.height,
                        MyDustId.Fire, 0f, 0f, 100,
                        Color.LightGreen, 3f);
                dust.noGravity = true;
                dust.noLight = false;
            }
		}
        public override void Kill(int timeLeft)
        {
            for (int r18 = 0; r18 < 5; r18++)
            {
                Dust dust = Dust.NewDustDirect
                    (projectile.position, projectile.width, projectile.height,
                    MyDustId.Fire, 0f, 0f, 100,
                    Color.LightGreen, 3f);
                dust.noGravity = true;
                dust.noLight = false;
            }
        }
	}
}
