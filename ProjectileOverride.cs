using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using DisorderUnderstar.Events;
using System.Collections.Generic;
using DisorderUnderstar.Projectiles;
namespace DisorderUnderstar
{
    public class ProjectileOverride : GlobalProjectile
    {
        public override void ModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit,
            ref int hitDirection)
        {
            if (LunarEclipse.事件发生中)
            {
                damage = target.lifeMax / 8;
                projectile.Kill();
            }
        }
        public static string 弹幕贴图转换(ProjectileImageType 贴图类)
        {
            if (贴图类 == ProjectileImageType.Transparent) { return "DisorderUnderstar/Projectiles/TransparentProjectile"; }
            else if (贴图类 == ProjectileImageType.Star) { return "DisorderUnderstar/Projectiles/Star"; }
            else { return null; }
        }
    }
}