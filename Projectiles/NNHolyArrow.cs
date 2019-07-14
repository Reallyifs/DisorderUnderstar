using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Projectiles
{
    public class NNHolyArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("神圣之箭");
        }
        public override void SetDefaults()
        {
            aiType = ItemID.HolyArrow;
            projectile.CloneDefaults(ItemID.HolyArrow);
            projectile.alpha = 20;
            projectile.damage = 200;
            projectile.knockBack = 2f;
        }
    }
}
