using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using DisorderUnderstar.NPCs.Bosses.Star;
namespace DisorderUnderstar.Items.Star.BossBags
{
    public class MeteorTidalBossBag : ModItem
    {
        public override int BossBagNPC => ModContent.NPCType<MeteorTidal>();
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            DisplayName.AddTranslation(GameCulture.Chinese, "宝藏袋");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.LightRed;
            item.value = Item.buyPrice(0, 0, 0, 0);
            item.width = 18;
            item.expert = true;
            item.height = 24;
            item.maxStack = 999;
            item.expertOnly = true;
        }
        public override void RightClick(Player player)
        {
            item.stack -= 1;
            Item.NewItem(player.Center, ModContent.ItemType<ShiningShield>(), 1);
            Item.NewItem(player.Center, ModContent.ItemType<FireOfStarZero>(), Main.rand.Next(5, 10));
            if (Main.rand.Next(1, 1000) <= 1) { Item.NewItem(player.Center, ModContent.ItemType<FireOfStarZero>(), Main.rand.Next(1, 10)); }
            return;
        }
    }
}
