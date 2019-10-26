using System;
using Terraria;
using System.IO;
using Terraria.ID;
using Terraria.UI;
using Terraria.World;
using ReLogic.Graphics;
using Terraria.Graphics;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.Localization;
using DisorderUnderstar.Texts;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using DisorderUnderstar.Events;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.Config;
using System.Collections.Generic;
using DisorderUnderstar.Items.Star;
using Terraria.ModLoader.Exceptions;
using Microsoft.Xna.Framework.Graphics;
namespace DisorderUnderstar
{
    public class DisorderUnderstar : Mod
    {
        #region ♫关于孤独我想说的话♫
        private readonly string 如果你拆了这个Mod, 那么这是送给你的话 = "" +
            "如果你看到了这个，那么……" +
            "放心，我也不会对你做什么。" +
            "所以出于什么目的来导致你来拆这个Mod的源代码呢——" +
            "或许这个问题我永远也不会知道。" +
            "我也不会去谴责你什么的……" +
            "我只想提醒你一下" +
            "这是不对的！应当改正。" +
            "啊，我好像说太多了……" +
            "抱歉……" +
            "先走了……";
        #endregion
        #region 阅读
        /// <summary>
        /// 阅读上一小节
        /// </summary>
        public ModHotKey RTPS;
        /// <summary>
        /// 阅读下一小节
        /// </summary>
        public ModHotKey RTNS;
        #endregion
        #region 难度
        internal static int Difficulty;
        public static bool Easy;
        public static bool Normal;
        public static bool Hard;
        public static bool Hell;
        public static bool Nightmare;
        #endregion
        internal static DisorderUndetstarClientConfig DisorderUnderstarClientConfig;
        internal static DisorderUnderstarServerConfig DisorderUnderstarServerConfig;
        public DisorderUnderstar()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true,
                AutoloadBackgrounds = true
            };
        }
        public override void Load()
        {
            RTPS = RegisterHotKey("阅读上一小节（读书用）", "Left");
            RTNS = RegisterHotKey("阅读下一小节（读书用）", "Right");
        }
        public override void Unload()
        {
            RTPS = null;
            RTNS = null;
            DisorderUnderstarClientConfig = null;
            DisorderUnderstarServerConfig = null;
        }
        public override void HotKeyPressed(string name)
        {
            Player player = Main.player[Main.myPlayer];
            if (name == "阅读上一小节（读书用）" && player.GetModPlayer<HumanHistory>().IsReading && player.whoAmI == Main.myPlayer)
            {
                HumanHistory.ReadPages -= 1;
            }
            else if (name == "阅读下一小节（读书用）" && player.GetModPlayer<HumanHistory>().IsReading && player.whoAmI == Main.myPlayer)
            {
                HumanHistory.ReadPages += 1;
            }
        }
        public override void PostDrawInterface(SpriteBatch spriteBatch)
        {
            Player player = Main.player[Main.myPlayer];
            if (player.GetModPlayer<HumanHistory>().IsReading && player.whoAmI == Main.myPlayer)
            {
                Vector2 _0 = new Vector2(player.Center.X, player.Center.Y);
                Texture2D _1 = GetTexture("Images/Testament/Book");
                string _2 = HumanHistory.sText;
                Main.fontMouseText.MeasureString(_2);
                SpriteEffects _3 = HumanHistory.ReadPages % 2 == 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                Main.spriteBatch.Draw(_1, _0 - Main.screenPosition, null, Color.White, 0f, _1.Size() * 0.5f, 1f, _3, 0f);
                Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontMouseText, _2, _0.X, _0.Y, Color.White, Color.Black, _1.Size() * 0.5f, 1f);
            }
        }
    }
}