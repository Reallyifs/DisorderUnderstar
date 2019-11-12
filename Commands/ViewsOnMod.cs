using Terraria;
using Terraria.ModLoader;
using static DisorderUnderstar.AllType;
namespace DisorderUnderstar.Commands
{
    public class ViewsOnWtfway : ModCommand
    {
        public override CommandType Type => CommandType.Chat;
        public override string Command => "对Wtfway的看法";
        public override string Description => "DisorderUndertar作者对Wtfway的看法";
        public override string Usage => "对Wtfway的看法";
        public override void Action(CommandCaller caller, string input, string[] args)
        {
            Main.NewText("本来这个Mod也是和Weapontesting一样，拿来测试已写的武器的", 随机数(), 随机数(), 随机数());
            Main.NewText("后来就想着官方的教程很难看懂，小裙子也只教基础", 随机数(), 随机数(), 随机数());
            Main.NewText("于是就想自己做一个，现在也是在弃坑边缘无限徘徊（趴）", 随机数(), 随机数(), 随机数());
        }
    }
    public class ViewsOnCalamityMod : ModCommand
    {
        public override CommandType Type => CommandType.Chat;
        public override string Command => "对Calamity Mod的看法";
        public override string Description => "DisorderUnderstar作者对Calamity Mod的看法";
        public override string Usage => "对CalamityMod的看法";
        public override void Action(CommandCaller caller, string input, string[] args)
        {
            Main.NewText("这个Mod为四大Mod之首，当之无愧倒是真的", 随机数(), 随机数(), 随机数());
            Main.NewText("但是由于更新得太频繁，导致汉化常常跟不上版本", 随机数(), 随机数(), 随机数());
            Main.NewText("这也算是灾厄的厉害之处吧", 随机数(), 随机数(), 随机数());
        }
    }
}
