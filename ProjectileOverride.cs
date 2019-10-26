using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using DisorderUnderstar.Projectiles;
namespace DisorderUnderstar
{
    public class ProjectileOverride : GlobalProjectile
    {
        public override bool CloneNewInstances => true;
        public override bool InstancePerEntity => true;
        public static string 弹幕贴图转换(bool 透明贴图)
        {
            string 输出;
            if (透明贴图)
            {
                输出 = "DisorderUnderstar/Projectiles/TransparentProjectile";
            }
            else { return null; }
            return 输出;
        }
    }
}