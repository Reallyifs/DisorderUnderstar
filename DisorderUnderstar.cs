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
using DisorderUnderstar.NPCs.Bosses.Star;
namespace DisorderUnderstar
{
    public class DisorderUnderstar : Mod
    {
        public static DisorderUnderstar Mod实例;
        #region ♫关于孤独我想说的话♫
        private readonly string 如果你拆了这个Mod, 那么这是送给你的话 = "" +
            "如果你看到了这个，那么……" +
            "所以你是有什么目的呢？" +
            "或许我永远也不会知道。" +
            "其实吧，我也不反感你拆我Mod" +
            "只是我觉得，这样做有些不对。" +
            "不论你是出于什么目的" +
            "至少不要外传此Mod源码，好吗？" +
            "那么，再会！" +
            "QQ：1249014149";
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
        public static int Difficulty;
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
            Mod实例 = this;
            RTPS = RegisterHotKey("阅读上一小节（读书用）", "Left");
            RTNS = RegisterHotKey("阅读下一小节（读书用）", "Right");
            Main.versionNumber = "感谢加载DisorderUnderstar无序之星Mod！\n" +
                "QQ讨论群：824525819\n" +
                (DisorderUnderstarClientConfig.ShowTheModLoader ? "检测到您还加载了以下Mod：\n" + 检测Mod加载() : null) +
                "DisorderUnderstar Terraria v1.3.6.3";
            Main.versionNumber2 = "DisorderUnderstar Terraria v1.3.6.3";
            #region ♫关于孤独我想说的话♫
            if (如果你拆了这个Mod == 那么这是送给你的话) { return; }
            #endregion
        }
        public override void Unload()
        {
            Main.versionNumber = "Terraria v1.3.5.2";
            Main.versionNumber2 = "Terraria v1.3.5.2";
            RTPS = null;
            RTNS = null;
            DisorderUnderstarClientConfig = null;
            DisorderUnderstarServerConfig = null;
        }
        public override void HotKeyPressed(string name)
        {
            Player player = Main.player[Main.myPlayer];
            if (name == "阅读上一小节（读书用）" && player.GetModPlayer<HumanHistory>().IsReading)
            {
                player.GetModPlayer<HumanHistory>().ReadPages -= 1;
            }
            else if (name == "阅读下一小节（读书用）" && player.GetModPlayer<HumanHistory>().IsReading)
            {
                player.GetModPlayer<HumanHistory>().ReadPages++;
            }
        }
        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            Player player = Main.player[Main.myPlayer];
            if (Main.musicVolume != 0f && Main.myPlayer != -1 && !Main.gameMenu && Main.LocalPlayer.active)
            {
                if (player.ZoneSkyHeight && player.ZoneRain) { music = GetSoundSlot(SoundType.Music, "Sounds/AnotherMusic/Sky"); }
            }
        }
        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                string[] NT = new string[]
                {
                    ModContent.GetInstance<MeteorTidal>().Name
                };
                bossChecklist.Call("AddBoss", NT[0], 2.3f, (Func<bool>)(() => DisorderUnderstarWorld.downedMeteorTidal), "");
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
                SpriteEffects _3 = player.GetModPlayer<HumanHistory>().ReadPages % 2 == 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                Main.spriteBatch.Draw(_1, _0 - Main.screenPosition, null, Color.White, 0f, _1.Size() * 0.5f, 1f, _3, 0f);
                Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontMouseText, _2, _0.X, _0.Y, Color.White, Color.Black, _1.Size() * 0.5f, 1f);
            }
        }
        public override void AddRecipeGroups()
        {
            RecipeGroup 蘑菇头盔 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + "蘑菇头盔", new int[]
            {
                ItemID.ShroomiteMask,
                ItemID.ShroomiteHelmet,
                ItemID.ShroomiteHeadgear
            });
            RecipeGroup 神圣头盔 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + "神圣头盔", new int[]
            {
                ItemID.HallowedMask,
                ItemID.HallowedHelmet,
                ItemID.HallowedHeadgear
            });
            RecipeGroup 叶绿头盔 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + "叶绿头盔", new int[]
            {
                ItemID.ChlorophyteMask,
                ItemID.ChlorophyteHelmet,
                ItemID.ChlorophyteHeadgear
            });
            RecipeGroup 钯金或钴蓝剑 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + "钯金剑", new int[]
            {
                ItemID.CobaltSword,
                ItemID.PalladiumSword
            });
            RecipeGroup.RegisterGroup("蘑菇头盔", 蘑菇头盔);
            RecipeGroup.RegisterGroup("神圣头盔", 神圣头盔);
            RecipeGroup.RegisterGroup("叶绿头盔", 叶绿头盔);
            RecipeGroup.RegisterGroup("钯金或钴蓝剑", 钯金或钴蓝剑);
        }
        private string 检测Mod加载()
        {
            string 加载了的Mod = "";
            if (ModLoader.Mods.Length == 2) { 加载了的Mod += "无\n"; }
            for (int i = 0; i < ModLoader.Mods.Length; i++)
            {
                if (ModLoader.GetMod(i) != ModLoader.GetMod("DisorderUnderstar") && ModLoader.GetMod(i) != ModLoader.GetMod("ModLoader"))
                {
                    加载了的Mod += ModLoader.GetMod(i).DisplayName + "\n";
                }
            }
            return 加载了的Mod;
        }
    }
}