using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Texts
{
    public class HumanHistory : ModPlayer
    {
        #region 判定
        #region 玩家的语言判定
        /// <summary>
        /// 玩家的语言判定
        /// </summary>
        public GameCulture language;
        #endregion
        #region 玩家是否在阅读
        /// <summary>
        /// 玩家是否在阅读
        /// </summary>
        public bool IsReading = false;
        #endregion
        public bool HumanHistroy1 = false; public bool HumanHistroy2 = false;
        public bool HumanHistroy3 = false; public bool HumanHistroy4 = false;
        public bool HumanHistroy5 = false; public bool HumanHistory6 = false;
        #region 是否使用作弊物品
        /// <summary>
        /// 是否使用作弊物品
        /// </summary>
        public bool CheatItem = false;
        #endregion
        #endregion
        #region 文字设置&几章几节判定
        /// <summary>
        /// 文字设定（String）
        /// </summary>
        public string sHH;
        /// <summary>
        /// 在阅读的小节
        /// </summary>
        public int ReadPages = 1;
        #endregion
        public override void PostUpdate()
        {
            if (ReadPages == 0) { IsReading = false; }
            if (IsReading == true)
            {
                player.hideInfo[player.whoAmI] = true;
                player.hideVisual[player.whoAmI] = true;
                if (language == GameCulture.Chinese)
                {
                    if (HumanHistroy1 == true)
                    {
                        #region 故事本体
                        if (ReadPages == 1)
                        {
                            sHH = "     《人类历史》第一章——明华\n\n" +
                                "  故事，要从很久很久以前说起……\n\n" +
                                "  在公元前100多世纪的一个小村落里，有一个叫做张万勇的孩子，他人正如它的名字\n" +
                                "一般，非常地勇敢、机灵。他在青年时，可以带领村民们进山打猎，可以赶走盘旋在村子周围\n" +
                                "的野兽，可以";
                        }
                        else if (ReadPages == 2)
                        {
                            sHH = "";
                        }
                        else if (ReadPages == 3)
                        {
                            sHH = "";
                        }
                        #endregion
                        #region 防止溢出
                        if (ReadPages <= 0) { ReadPages = 1; }
                        else if (ReadPages >= 4) { ReadPages = 3; }
                        #endregion
                    }
                    else if (HumanHistroy2 == true) { }
                    else if (HumanHistroy3 == true) { }
                    else if (HumanHistroy4 == true) { }
                    else if (HumanHistroy5 == true) { }
                    else if (HumanHistory6 == true) { }
                    #region 作弊
                    else if (CheatItem == true)
                    {
                        sHH = "那么，你好，作弊者。\n" +
                            "告辞。";
                        CheatItem = false;
                        IsReading = false;
                        Main.NewText(sHH, Color.Red);
                    }
                    #endregion
                }
                else if (language == GameCulture.English)
                {
                    if (HumanHistroy1 == true)
                    {
                        #region Story
                        if (ReadPages == 1)
                        {
                            sHH = "This is a long story...\n" +
                                "";
                        }
                        else if (ReadPages == 2)
                        {
                            sHH = "";
                        }
                        else if (ReadPages == 3)
                        {
                            sHH = "";
                        }
                        #endregion
                        #region Preventive measures
                        if (ReadPages <= 0) { ReadPages = 1; }
                        else if (ReadPages >= 4) { ReadPages = 3; }
                        #endregion
                    }
                    else if (HumanHistroy2 == true) { }
                    else if (HumanHistroy3 == true) { }
                    else if (HumanHistroy4 == true) { }
                    else if (HumanHistroy5 == true) { }
                    else if (HumanHistory6 == true) { }
                    #region Cheat
                    else if (CheatItem == true)
                    {
                        sHH = "Then, welcome, hacker.\n" +
                            "Goodbye.";
                        CheatItem = false;
                        IsReading = false;
                        Main.NewText(sHH, Color.Red);
                    }
                    #endregion
                }
                else
                {
                    sHH = "Sorry!\n" +
                        "This story does not support your language\n" +
                        "please switch to English for your normal reading!";
                }
            }
        }
    }
}
