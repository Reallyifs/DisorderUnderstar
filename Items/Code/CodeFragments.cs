using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items.Code
{
    public class CodeFragments : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("代码碎片");
            Tooltip.SetDefault("【代码-Code】\n" +
                "这些代码好像来自一些内部程序……");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.LightPurple;
            item.value = Item.buyPrice(0, 0, 71, 0);
            item.value = Item.sellPrice(0, 0, 35, 50);
            item.width = 18;
            item.height = 24;
            item.maxStack = 99;
        }
    }
}
