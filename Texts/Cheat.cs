using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Texts
{
    public class Cheat : ModPlayer
    {
        public bool CheatItem = false;
        public override void PostUpdate()
        {
            if (CheatItem)
            {
                player.dead = true;
                player.GetModPlayer<Cheat>().CheatItem = false;
                Main.NewText("那么，你好，作弊者。", Color.Red);
                Main.NewText("告辞。", Color.Red);
            }
        }
        public override void ResetEffects()
        {
            CheatItem = false;
        }
    }
}