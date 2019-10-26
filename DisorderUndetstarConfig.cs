using Terraria.ModLoader.Config;
namespace DisorderUnderstar
{
    public class DisorderUndetstarClientConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Label("使故事真实化（未完成）")]
        [Tooltip("当此选项开启时，游戏中的故事将会发生改变\n击败邪教徒后生效")]
        public bool LetTheStoryBecameTrue;

        [Label("显示物品售价（未完成）")]
        public bool ShowItemValue;

        public override void OnLoaded()
        {
            DisorderUnderstar.DisorderUnderstarClientConfig = this;
        }
    }
    public class DisorderUnderstarServerConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("Test / 测试")]
        [Tooltip("null")]
        public bool IsNull;

        public override void OnLoaded()
        {
            DisorderUnderstar.DisorderUnderstarServerConfig = this;
        }
    }
}
