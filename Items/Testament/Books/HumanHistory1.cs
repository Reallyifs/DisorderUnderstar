using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using DisorderUnderstar.Texts;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Items.Testament.Books
{
    public class HumanHistory1 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("《人类历史》第一章");
            DisplayName.AddTranslation(GameCulture.English, "Human History Chapter 1");
        }
        public override bool CanUseItem(Player player)
        {
            if (player.GetModPlayer<HumanHistory>().HumanHistroy1 == false)
            {
                player.GetModPlayer<HumanHistory>().HumanHistroy1 = true;
            }
            else
            {
                player.GetModPlayer<HumanHistory>().HumanHistroy1 = false;
            }
            return true;
        }
    }
}
