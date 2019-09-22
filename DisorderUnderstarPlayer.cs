using Terraria;
using Terraria.ID;
using DisorderUnderstar;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using DisorderUnderstar.Events;
namespace DisorderUnderstar
{
    public class DisorderUnderstarPlayer : ModPlayer
    {
        #region 真实生命
        private int realLife = 100;
        private int velocityTime;
        /// <summary>
        /// 装甲破碎了的玩家
        /// </summary>
        private bool Fixing { get; set; }
        private float fixTime = 600;
        private float maxMoveSpeed;
        #endregion
        #region 检测Mod加载
        public bool 加载了Wtfway = false;
        public bool 加载了_1LifeMaxAccessories = false;
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
                加载了Wtfway = true;
            }
            if (_1LifeMaxAccessories != null)
            {
                Main.NewText("加载了1血上限？不愧是你。", Color.Blue);
                加载了_1LifeMaxAccessories = true;
            }
    }
        #endregion
        #region 难度判定（PlayerConnect，PlayerDisconnect）
        public override void PlayerConnect(Player player)
        {
            Main.NewText("欢迎来到" + Main.worldName + "，" + player.name + "！", Color.Blue);
            DisorderUnderstar.Difficulty += 1;
            if (DisorderUnderstar.Difficulty > 40)
            {
                Main.NewText("“你越来越没有耐心了……”", Color.OrangeRed);
                DisorderUnderstar.Nightmare = true;
                player.endurance -= 0.1f;
            }
            else if (DisorderUnderstar.Difficulty == 40)
            {
                Main.NewText("如此多的同伴，你可真是放心啊……", Color.OrangeRed);
                Main.NewText("那么……", Color.OrangeRed);
                Main.NewText("警告：当前难度不存在。", Color.Red);
                DisorderUnderstar.Nightmare = true;
            }
            else if (DisorderUnderstar.Difficulty == 20)
            {
                Main.NewText("地狱难度已开启，玩的愉快。", Color.Red);
                DisorderUnderstar.Hell = true;
            }
            else if (DisorderUnderstar.Difficulty == 10)
            {
                Main.NewText("困难难度已开启，玩的愉快。", Color.Red);
                DisorderUnderstar.Hard = true;
            }
            else if (DisorderUnderstar.Difficulty == 5)
            {
                Main.NewText("普通难度已开启，玩的愉快！", Color.Red);
                DisorderUnderstar.Normal = true;
            }
            else if (DisorderUnderstar.Difficulty == 1)
            {
                Main.NewText("简单难度已开启，玩的愉快！", Color.Red);
                DisorderUnderstar.Easy = true;
            }
        }
        public override void PlayerDisconnect(Player player)
        {
            Main.NewText("真遗憾，" + player.name + "退出了。", Color.Blue);
            DisorderUnderstar.Difficulty -= 1;
            if (DisorderUnderstar.Difficulty > 40)
            {
                player.endurance += 0.3f;
                DisorderUnderstar.Nightmare = true;
            }
            else if (DisorderUnderstar.Difficulty == 39)
            {
                Main.NewText("我看到了，你怂了。", Color.OrangeRed);
                DisorderUnderstar.Nightmare = false;
            }
            else if (DisorderUnderstar.Difficulty == 19)
            {
                Main.NewText("地狱难度已关闭，玩的愉快！", Color.Red);
                DisorderUnderstar.Hell = false;
            }
            else if (DisorderUnderstar.Difficulty == 10)
            {
                Main.NewText("困难难度已开启，玩的愉快！", Color.Red);
                DisorderUnderstar.Hard = false;
            }
            else if (DisorderUnderstar.Difficulty == 5)
            {
                Main.NewText("普通难度已关闭，玩的愉快。", Color.Red);
                DisorderUnderstar.Normal = false;
            }
            else if (DisorderUnderstar.Difficulty == 1)
            {
                Main.NewText("简单难度已关闭，玩的愉快。", Color.Red);
                DisorderUnderstar.Easy = false;
            }
        }
        #endregion
        public override void ResetEffects()
        {
            // LunarEclipse.判定(mod, null, null, player, null);
        }
        public override void PreUpdate()
        {
            Item item = Main.item[Main.myPlayer];
            Projectile projectile = Main.projectile[Main.myPlayer];
            if (Fixing)
            {
                player.statDefense = 0;
                if (player.moveSpeed > maxMoveSpeed) { player.moveSpeed = maxMoveSpeed; }
            }
            #region 难度判定
            if (DisorderUnderstar.Easy)
            {
                player.AddBuff(BuffID.Sunflower, 1);
                if (!DisorderUnderstar.Hard || !DisorderUnderstar.Hell || !DisorderUnderstar.Nightmare)
                {
                    player.aggro -= 10;
                    player.moveSpeed += 0.5f;
                }
            }
            if (DisorderUnderstar.Normal)
            {
                player.AddBuff(BuffID.Sunflower, 1);
                if (!DisorderUnderstar.Hard || !DisorderUnderstar.Hell || !DisorderUnderstar.Nightmare) { player.moveSpeed += 0.1f; }
            }
            if (DisorderUnderstar.Hard)
            {
                #region 躲避子弹
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    foreach (NPC npc in Main.npc)
                    {
                        float disMAX = 5f;
                        if (npc.type != NPCID.LunarTowerNebula && npc.type != NPCID.LunarTowerSolar && npc.type != NPCID.LunarTowerStardust &&
                            npc.type != NPCID.LunarTowerVortex && npc.type == NPCID.EaterofWorldsHead && npc.type == NPCID.EaterofWorldsBody &&
                            npc.type == NPCID.EaterofWorldsTail && npc.type == NPCID.TheDestroyer && npc.type == NPCID.TheDestroyerBody &&
                            npc.type == NPCID.TheDestroyerTail)
                        {
                            float dis = Vector2.Distance(projectile.Center, npc.Center);
                            if (disMAX >= dis && projectile.friendly && Main.rand.Next(1, 10) == 1)
                            {
                                Vector2 tVEC = Vector2.Normalize(projectile.Center - npc.Center) * item.shootSpeed;
                                npc.velocity *= tVEC.RotatedBy(Main.rand.NextFloatDirection() * 0.5f);
                            }
                            else
                            {
                                projectile.position = projectile.Center;
                                projectile.velocity /= 2;
                            }
                        }
                        else
                        {
                            projectile.damage -= 100;
                        }
                    }
                }
                #endregion
            }
            #endregion
        }
        #region 装甲判定（PreKill，Kill）
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound,
            ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (!Fixing)
            {
                player.statLife = realLife;
                maxMoveSpeed = player.moveSpeed / 4;
                player.statDefense = 0;
                player.GetModPlayer<DisorderUnderstarPlayer>().Fixing = true;
                Main.NewText(player.name + "的装甲破碎了！", Color.OrangeRed);
            }
            else { return true; }
            return !Fixing;
        }
        public override void Kill(double damage, int hitDirection, bool pvp,
            PlayerDeathReason damageSource)
        {
            Fixing = false;
            fixTime = 600;
            maxMoveSpeed = 0;
            velocityTime = 0;
        }
        #endregion
        public override void PostUpdate()
        {
            #region 真实生命判定
            if (Fixing == true)
            {
                fixTime--;
                if (velocityTime == 0)
                {
                    velocityTime = 1;
                    player.velocity *= 0.6f;
                }
            }
            if (fixTime <= 0)
            {
                Fixing = false;
                fixTime = 600;
                maxMoveSpeed = 0;
                velocityTime = 0;
            }
            #endregion
        }
    }
}
