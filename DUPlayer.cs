using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar
{
    public class DUPlayer : ModPlayer
    {
        public override void OnEnterWorld(Player player)
        {
            Main.NewText("欢迎加载“DisorderUnderstar Mod！”", Color.Blue);
            Main.NewText("我是这个Mod的制作人Really'if.s.",Color.Blue);
            Main.NewText("在此宣传一下官方群：824525819", Color.Blue);
            Main.NewText("目前的想法是添加一个真实生命和难度模式=_=", Color.Blue);
            Main.NewText("所以，敬请期待=v=！", Color.Blue);
        }
    }
}
