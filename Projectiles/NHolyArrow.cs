using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles
{
    public class NHolyArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("神圣激光");
        }
        public override void SetDefaults()
        {
            projectile.alpha = 250;
            projectile.width = 4;
            projectile.damage = 100;
            projectile.height = 14;
            projectile.aiStyle = -1;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.timeLeft = 1000;
            projectile.extraUpdates = 100;
        }
        public override void AI()
        {

        }
    }
}
