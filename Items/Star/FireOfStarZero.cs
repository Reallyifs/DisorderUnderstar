using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
namespace DisorderUnderstar.Items.Star
{
    public class FireOfStarZero : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("星零之火");
            Tooltip.SetDefault("【星星-Star】\n" +
                "“星星之火，可以燎原。”");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.LightRed;
            item.value = Item.buyPrice(0, 0, 50, 0);
            item.width = 18;
            item.height = 24;
            item.maxStack = 99;
        }
    }
}
