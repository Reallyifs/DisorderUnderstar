using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using DisorderUnderstar.Texts;
namespace DisorderUnderstar.Items.Testament.Books
{
    public class HumanHistory1 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Human History Chapter 1");
            DisplayName.AddTranslation(GameCulture.Chinese, "《人类历史》第一章");
        }
        public override void SetDefaults()
        {
            item.value = 0;
            item.width = 51;
            item.height = 67;
            item.useStyle = 0;
        }
        public override bool CanUseItem(Player player)
        {
            if (!player.GetModPlayer<HumanHistory>().HumanHistroy1)
            {
                player.GetModPlayer<HumanHistory>().IsReading = true;
                player.GetModPlayer<HumanHistory>().HumanHistroy1 = true;
            }
            else { player.GetModPlayer<HumanHistory>().HumanHistroy1 = false; }
            return true;
        }
    }
}