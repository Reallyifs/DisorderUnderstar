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
using Microsoft.Xna.Framework.Graphics;
namespace DisorderUnderstar
{
    public class DisorderUnderstar : Mod
    {
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
        Player player = Main.player[Main.myPlayer];
        public override void PostDrawInterface(SpriteBatch spriteBatch)
        {
            if (player.GetModPlayer<HumanHistory>().HumanHistroy1 == true)
            {
                Vector2 _0 = new Vector2((float)(Main.screenWidth / 2), (float)(Main.screenHeight / 2)) + Main.screenPosition;
                string _1 = player.GetModPlayer<HumanHistory>().sHH;
                Main.fontMouseText.MeasureString(_1);
                Vector2 _2 = _0 - Main.screenPosition - new Vector2(244f, 151f);
                Main.spriteBatch.Draw(this.GetTexture("Images/Book"), _0 - Main.screenPosition - new Vector2(250f, 155f),
                    new Rectangle?(new Rectangle(0, 0, 500, 309)), Color.White, 0f, new Vector2(19f, 19f), 1f, SpriteEffects.None, 0f);
                Terraria.Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontMouseText, _1, _2.X, _2.Y, Color.White, Color.Black,
                    Vector2.Zero, 1f);
            }
        }
    }
}