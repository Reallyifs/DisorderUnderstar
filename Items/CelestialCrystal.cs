using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Items
{
    public class CelestialCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("天体水晶");
            Tooltip.SetDefault("展望。");
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.RainbowCrystalStaff);
            item.width = 40;
            item.damage = 10;
            item.height = 40;
        }
    }
}
