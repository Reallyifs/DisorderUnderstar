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
        public bool IsReading { get; set; }
        #endregion
        public bool HumanHistroy1 = false; public bool HumanHistroy2 = false;
        public bool HumanHistroy3 = false; public bool HumanHistroy4 = false;
        public bool HumanHistroy5 = false; public bool HumanHistory6 = false;
        #endregion
        #region 文字设置&几章几节判定
        /// <summary>
        /// 文字设定（String）
        /// </summary>
        public static string sText;
        /// <summary>
        /// 在阅读的小节
        /// </summary>
        public int ReadPages = 1;
        #endregion
        public override void PreUpdate()
        {
            if (player.GetModPlayer<HumanHistory>().IsReading)
            {
                player.hideMerman = true;
                player.hideInfo[player.whoAmI] = true;
                player.hideVisual[player.whoAmI] = true;
                //if (language == GameCulture.Chinese)
                {
                    if (HumanHistroy1)
                    {
                        #region 故事本体
                        if (ReadPages == 1)
                        {
                            sText = "在泰拉大陆里，人们代代相传着这样一个故事……\n" +
                                "从前存在着两大古城：斯回城和福然城，这两个城镇的人终为对立，互相都想着击败对方以示自己的强大。\n" +
                                "斯回城和福然城的生活方式与各自的截然不同，不过都是最基本的奴隶制，而且人民终身为国家而抛颅撒血，还不敢有半点怨言。\n" +
                                "由于“斯”与“死”同音，在当时被福然城的人解释为“死了也要回来”，意喻为“死了也要回来并继续为国家做贡献”，并对这个进行了解读，导致福然城直到全盘皆崩也没有解开对斯回城的误会。\n" +
                                "在这个过程中，斯回城一直都是默默承受的。\n" +
                                "泰拉公元前9012年，福然城的首领——余至成劫持了在泰拉大陆上到处流浪的斯回商人，将他们“护送”进了血腥之地，并且还把他们绑了起来扔进深不见底的万丈深渊，余至成被只长于血腥之地的藤蔓刮得伤痕累累，在这悲剧之前，他那健壮的身躯上还有斯回商人们顽抗时留下的伤痕。\n" +
                                "于是，余至成顺理成章的借着这个理由挑起了与斯回城之间的战争，这场战争仅持续了不到十天，福然城就凭借着庞大的军队攻到了斯回城墙旁。\n" +
                                "所到之处皆是断垣残壁。\n" +
                                "就在这个时候，奇迹发生了。\n" +
                                "一位少年突然出现在了斯回城门前，身边还悬浮着八块不同颜色的宝石——在那时的传说中，八块宝石分别代表着人类的种种情绪。\n" +
                                "他飘了起来，身边的八块宝石猛的绕着他转，愈转愈快，愈转愈亮。再瞧另一边，这时的余至成早已带着百万雄师冲到城墙下。\n" +
                                "突然，斯回城墙上浮现出了一道屏障，将福然大军弹了回去，一阵圣光掠过，天上降下了五彩缤纷的箭，重创了福然大军，在此期间，福然军长被一箭射中，便驾鹤西去，余至成身为首领，一身本领了得，在闪过了所有的箭之后，突然一道闪电从天而降，不偏不倚地劈在了余至成的头上，整齐一致的福然大军瞬间乱作一团，溃不成军。福然大军那不可一世的骄傲化为歇斯底里的尖叫。\n" +
                                "在这期间，少年的八块宝石都不在他身边，他仅是飘在一旁，冷酷无情地看着这场大局已定的战争。\n" +
                                "在福然大军的大部分都逃跑后，少年开始清理周围残余的福然军，更多的时候，他只是冷眼看着他们，然后转身离去，留下一阵唏嘘。\n" +
                                "斯回城主——画京顺为了感谢那位少年，邀请他在斯回城内住下，而且答应一定招待他好吃好喝，那位少年像是早就料到，回绝了画京顺，但将那八块宝石赠予了他。\n" +
                                "在福然之战之后的几天，福然城灭亡，据说在那一天，福然城的方向发生过一次大爆炸，并且经过后人考察，那个地方出现了一棵墨绿色的参天大树，直插云霄，令人心生寒意。\n" +
                                "随着福然城一同消失的，还有那位传奇般的少年。\n" +
                                "画京顺将这八块宝石嵌进了他的专属佩剑，同年，斯回城也灭亡了，据后人考察并推测出是因为当地环境被大肆破坏导致的，万幸中，当时有几个人早已逃离了那个地方，人类的火种才得以继续延续。所剩无几的人类在离斯回城遥远的北方建立了一个新的城市——斯布城。\n" +
                                "根据古时传说中记载，将八块宝石嵌入佩剑的日期计算出当时是新历的一月，所以这把剑又被后人叫做——\n" +
                                "一月遗言。";
                        }
                        else if (ReadPages == 2)
                        {
                            sText = "";
                        }
                        else if (ReadPages == 3)
                        {
                            sText = "";
                        }
                        #endregion
                        #region 防止溢出
                        if (ReadPages <= 0) { ReadPages = 1; }
                        else if (ReadPages >= 4) { ReadPages = 3; }
                        #endregion
                    }
                    else if (HumanHistroy2) { }
                    else if (HumanHistroy3) { }
                    else if (HumanHistroy4) { }
                    else if (HumanHistroy5) { }
                    else if (HumanHistory6) { }
                }
                /*else if (language == GameCulture.English)
                {
                    if (HumanHistroy1)
                    {
                        #region Story
                        if (ReadPages == 1)
                        {
                            sText = "This is a long story...\n" +
                                "";
                        }
                        else if (ReadPages == 2)
                        {
                            sText = "";
                        }
                        else if (ReadPages == 3)
                        {
                            sText = "";
                        }
                        #endregion
                        #region Preventive measures
                        if (ReadPages <= 0) { ReadPages = 1; }
                        else if (ReadPages >= 4) { ReadPages = 3; }
                        #endregion
                    }
                    else if (HumanHistroy2) { }
                    else if (HumanHistroy3) { }
                    else if (HumanHistroy4) { }
                    else if (HumanHistroy5) { }
                    else if (HumanHistory6) { }
                }
                else
                {
                    sText = "Sorry!\n" +
                        "This story does not support your language\n" +
                        "please switch to English for your normal reading!";
                }
                */
            }
        }
    }
}