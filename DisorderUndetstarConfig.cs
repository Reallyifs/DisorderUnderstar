using Terraria.ModLoader.Config;
namespace DisorderUnderstar
{
    public class DisorderUndetstarClientConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Label("是否显示已加载的Mod")]
        [Tooltip("需重新加载")]
        [ReloadRequired]
        public bool ShowTheModLoader;

        [Label("使故事真实化")]
        [Tooltip("当此选项开启时，游戏中的故事将会发生改变\n击败邪教徒后生效\n需重新加载\n（未完成）")]
        [ReloadRequired]
        public bool LetTheStoryBecameTrue;

        [Label("显示物品售价")]
        [Tooltip("需重新加载\n（此功能暂时关闭）")]
        [ReloadRequired]
        public bool ShowItemValue;

        [Label("使介绍配上颜色")]
        [Tooltip("当开启时，使所有物品介绍中的特定词汇配上颜色\n需重新加载\n（此功能暂时关闭）")]
        [ReloadRequired]
        public bool LetTooltipBeColorful;

        [Label("作弊码")]
        [Tooltip("当作弊码完全正确时，人物要求符合内部设定\n你就可以使用HERO's Mod或Cheat Sheet其中之一\n需重新加载\n（此功能暂时关闭）")]
        [ReloadRequired]
        public string CanCheatValue;

        public override void OnLoaded() => DisorderUnderstar.DisorderUnderstarClientConfig = this;
    }
    public class DisorderUnderstarServerConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("Test / 测试")]
        [Tooltip("null")]
        public bool IsNull;

        public override void OnLoaded() => DisorderUnderstar.DisorderUnderstarServerConfig = this;
    }
}
