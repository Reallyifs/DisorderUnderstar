using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar
{
    public class ItemOverride : GlobalItem
    {
        public static void 事件_月蚀(Item item)
        {
            int type = item.type;
            if (type == ItemID.TerraBlade)
            {
                item.rare = ItemRarityID.Lime;
                item.scale = 1f;
                item.damage = 80;
                item.useTime = 20;
                item.knockBack = 4f;
                item.shootSpeed = 10f;
                item.useAnimation = 20;
            }
            if (type == ItemID.StarWrath)
            {
                item.rare = ItemRarityID.Yellow;
                item.scale = 1f;
                item.damage = 100;
                item.channel = true;
                item.useTime = 20;
                item.knockBack = 5f;
                item.shootSpeed = 5f;
                item.useAnimation = 20;
            }
        }
        public override void SetDefaults(Item item)
        {
            int type = item.type;
            if (type == ItemID.StarWrath)
            {
                item.rare = ItemRarityID.Red;
                item.scale = 1.5f;
                item.damage = 150;
                item.channel = true;
                item.useTime = 10;
                item.useStyle = 5;
                item.knockBack = 7f;
                item.shootSpeed = 10f;
                item.useAnimation = 10;
            }
        }
    }
}
