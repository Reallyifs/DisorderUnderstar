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
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using System.Collections.Generic;
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
        #region 月蚀事件
        public bool MeetingTheEventConditions_LunarEclipse(NPCSpawnInfo spawnInfo)
        {
            Player player = spawnInfo.player;
            return !Main.dayTime && !Main.pumpkinMoon && !Main.snowMoon && !Main.bloodMoon && !player.ZoneOldOneArmy;
        }
        #endregion
        private Player player = Main.player[Main.myPlayer];
        private static Queue<Texture2D> VanillaChangeTexture;
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
            #region Dequeue
            Main.buffTexture[BuffID.SolarShield1] = VanillaChangeTexture.Dequeue();
            Main.buffTexture[BuffID.SolarShield2] = VanillaChangeTexture.Dequeue();
            Main.buffTexture[BuffID.SolarShield3] = VanillaChangeTexture.Dequeue();
            #endregion
            RTPS = null;
            RTNS = null;
        }
        public override void PostSetupContent()
        {
            if (!Main.dedServ)
            {
                #region Enqueue
                VanillaChangeTexture.Enqueue(Main.buffTexture[BuffID.SolarShield1]);
                VanillaChangeTexture.Enqueue(Main.buffTexture[BuffID.SolarShield2]);
                VanillaChangeTexture.Enqueue(Main.buffTexture[BuffID.SolarShield3]);
                #endregion
                #region GetTexture
                Main.buffTexture[BuffID.SolarShield1] = GetTexture("Images/VanillaChange/SolarShield_I");
                Main.buffTexture[BuffID.SolarShield2] = GetTexture("Images/VanillaChange/SolarShield_II");
                Main.buffTexture[BuffID.SolarShield3] = GetTexture("Images/VanillaChange/SolarShield_III");
                #endregion
            }
        }
        public override void HotKeyPressed(string name)
        {
            if (name == "阅读上一小节（读书用）" && player.GetModPlayer<HumanHistory>().IsReading == true)
            {
                player.GetModPlayer<HumanHistory>().ReadPages -= 1;
            }
            else if (name == "阅读下一小节（读书用）" && player.GetModPlayer<HumanHistory>().IsReading == true)
            {
                player.GetModPlayer<HumanHistory>().ReadPages += 1;
            }
        }
        public override void PostDrawInterface(SpriteBatch spriteBatch)
        {
            if (player.GetModPlayer<HumanHistory>().IsReading == true)
            {
                Vector2 _0 = new Vector2(player.Center.X, player.Center.Y);
                Texture2D _1 = GetTexture("Images/Testament/Books");
                string _2 = player.GetModPlayer<HumanHistory>().sHH;
                Main.fontMouseText.MeasureString(_2);
                bool _3 = player.GetModPlayer<HumanHistory>().ReadPages % 2 == 0 ? false : true;
                SpriteEffects _4 = SpriteEffects.None;
                if (_3 == true) { _4 = SpriteEffects.FlipHorizontally; }
                Main.spriteBatch.Draw(_1, _0 - Main.screenPosition, null, Color.White, 0f, _1.Size() * 0.5f, 1f, _4 , 0f);
                Terraria.Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontMouseText, _2, _0.X, _0.Y, Color.White, Color.Black,
                    _1.Size() * 0.5f, 1f);
            }
        }
    }
}