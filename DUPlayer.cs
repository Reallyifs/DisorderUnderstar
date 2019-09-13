using Terraria;
using Terraria.ID;
using DisorderUnderstar;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
namespace DisorderUnderstar
{
    public class DUPlayer : ModPlayer
    {
        #region 真实生命
        private int realLife = 100;
        private int saveDefense;
        private int velocityTime;
        /// <summary>
        /// 装甲破碎了的玩家
        /// </summary>
        private bool fixing = false;
        private float fixTime = 600;
        private float saveMoveSpeed;
        private Vector2 saveVelocity;
        #endregion
        #region 难度模式
        public int Difficulty;
        public bool Easy;
        public bool Normal;
        public bool Hard;
        public bool Hell;
        public bool Nightmare;
        #endregion
        #region 检测Mod加载
        public bool LoadedWtfway = false;
        public bool Loaded_1LifeMaxAccessories = false;
        #endregion
        #region 进世界提示（OnEnterWorld）
        public override void OnEnterWorld(Player player)
        {
            Main.NewText("感谢加载“DisorderUnderstar Mod”！", Color.Blue);
            Mod Wtfway = ModLoader.GetMod("Wtfway");
            Mod _1LifeMaxAccessories = ModLoader.GetMod("_1LifeMaxAccessories");
            if (Wtfway != null)
            {
                Main.NewText("诶，没想到你还加载了这个Mod，真是tql，那我就降低一点难度吧。", Color.Blue);
                LoadedWtfway = true;
            }
            if (_1LifeMaxAccessories != null)
            {
                Main.NewText("加载了1血上限？不愧是你。", Color.Blue);
                Loaded_1LifeMaxAccessories = true;
            }
    }
        #endregion
        #region 难度判定（PlayerConnect，PlayerDisconnect）
        public override void PlayerConnect(Player player)
        {
            Main.NewText("欢迎来到" + Main.worldName + "，" + player.name + "！", Color.Blue);
            Difficulty += 1;
            if (Difficulty > 40) {
                Main.NewText("“你越来越没有耐心了……”", Color.OrangeRed);
                Nightmare = true;
                player.endurance -= 0.3f;
            }
            else if (Difficulty == 40) {
                Main.NewText("如此多的同伴，你可真是放心啊……", Color.OrangeRed);
                Main.NewText("那么……", Color.OrangeRed);
                Main.NewText("警告：当前难度不存在。", Color.Red);
                Nightmare = true;
            }
            else if (Difficulty == 20) {
                Main.NewText("地狱难度已开启，玩的愉快。", Color.Red);
                Hell = true;
            }
            else if (Difficulty == 10) {
                Main.NewText("困难难度已开启，玩的愉快。", Color.Red);
                Hard = true;
            }
            else if (Difficulty == 5) {
                Main.NewText("普通难度已开启，玩的愉快！", Color.Red);
                Normal = true;
            }
            else if (Difficulty == 1) {
                Main.NewText("简单难度已开启，玩的愉快！", Color.Red);
                Easy = true;
            }
        }
        public override void PlayerDisconnect(Player player)
        {
            Main.NewText("真遗憾，" + player.name + "退出了。", Color.Blue);
            Difficulty -= 1;
            if (Difficulty > 40)
            {
                player.endurance += 0.3f;
                Nightmare = true;
            }
            else if (Difficulty == 39)
            {
                Main.NewText("我看到了，你怂了。", Color.OrangeRed);
                Nightmare = false;
            }
            else if (Difficulty == 19)
            {
                Main.NewText("地狱难度已关闭，玩的愉快！", Color.Red);
                Hell = false;
            }
            else if (Difficulty == 10)
            {
                Main.NewText("困难难度已开启，玩的愉快！", Color.Red);
                Hard = false;
            }
            else if (Difficulty == 5)
            {
                Main.NewText("普通难度已关闭，玩的愉快。", Color.Red);
                Normal = false;
            }
            else if (Difficulty == 1)
            {
                Main.NewText("简单难度已关闭，玩的愉快。", Color.Red);
                Easy = false;
            }
        }
        #endregion
        #region 装甲判定（PreKill，Kill）
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound,
            ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (fixing == false)
            {
                saveDefense = player.statDefense;
                saveMoveSpeed = player.moveSpeed;
                player.statLife = realLife;
                player.statDefense = 0;
                player.GetModPlayer<DUPlayer>().fixing = true;
                Main.NewText(player.name + "的装甲破碎了！", Color.OrangeRed);
            }
            else return true;
            return !fixing;
        }
        public override void Kill(double damage, int hitDirection, bool pvp,
            PlayerDeathReason damageSource)
        {
            fixing = false;
            fixTime = 600;
            velocityTime = 0;
            player.statDefense = saveDefense;
        }
        #endregion
        public override void PostUpdate()
        {
            #region 真实生命判定
            if (fixing == true)
            {
                fixTime--;
                if (velocityTime == 0)
                {
                    velocityTime = 1;
                    saveVelocity = player.velocity;
                    player.velocity *= 0.6f;
                }
            }
            if (fixTime <= 0)
            {
                fixing = false;
                fixTime = 600;
                velocityTime = 0;
                player.velocity = saveVelocity;
                player.moveSpeed = saveMoveSpeed;
                player.statDefense = saveDefense;
            }
            #endregion
        }
    }
}
