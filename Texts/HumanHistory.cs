using Terraria.ModLoader;
using Terraria.Localization;
namespace DisorderUnderstar.Texts
{
    public class HumanHistory : ModPlayer
    {
        #region 判定
        public GameCulture language; public bool HumanHistroy1 = false;
        public bool HumanHistroy2 = false; public bool HumanHistroy3 = false;
        public bool HumanHistroy4 = false; public bool HumanHistroy5 = false;
        #endregion
        #region 文字设置&几章几节判定
        public string sHH;
        public bool bHH1_1; public bool bHH1_2;
        public bool bHH2_1; public bool bHH2_2;
        public bool bHH3_1; public bool bHH3_2;
        public bool bHH4_1; public bool bHH4_2;
        public bool bHH5_1; public bool bHH5_2;
        public bool bHH6_1; public bool bHH6_2;
        #endregion
        public override void PostUpdate()
        {
            if (language == GameCulture.Chinese)
            {
                if (player.GetModPlayer<HumanHistory>().HumanHistroy1 == true)
                {
                    if (player.GetModPlayer<HumanHistory>().bHH1_1 == true)
                    {
                        sHH = "故事，要从很久很久以前说起……\n" +
                            "";
                    }
                    else if (player.GetModPlayer<HumanHistory>().bHH1_2 == true)
                    {
                        sHH = "";
                    }
                    else
                    {
                        sHH = "";
                    }
                }
                else if (player.GetModPlayer<HumanHistory>().HumanHistroy2 == true) { }
                else if (player.GetModPlayer<HumanHistory>().HumanHistroy3 == true) { }
                else if (player.GetModPlayer<HumanHistory>().HumanHistroy4 == true) { }
                else if (player.GetModPlayer<HumanHistory>().HumanHistroy5 == true) { }
                else { }
            }
            else if (language == GameCulture.English)
            {
                if (player.GetModPlayer<HumanHistory>().HumanHistroy1 == true)
                {
                    if (player.GetModPlayer<HumanHistory>().bHH1_1 == true)
                    {
                        sHH = "This is a long story...\n" +
                            "";
                    }
                    else if (player.GetModPlayer<HumanHistory>().bHH1_2 == true)
                    {
                        sHH = "";
                    }
                    else
                    {
                        sHH = "";
                    }
                }
                else if (player.GetModPlayer<HumanHistory>().HumanHistroy2 == true) { }
                else if (player.GetModPlayer<HumanHistory>().HumanHistroy3 == true) { }
                else if (player.GetModPlayer<HumanHistory>().HumanHistroy4 == true) { }
                else if (player.GetModPlayer<HumanHistory>().HumanHistroy5 == true) { }
                else { }
            }
        }
    }
}
