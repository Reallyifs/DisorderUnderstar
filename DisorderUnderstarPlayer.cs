using Terraria;
using Terraria.ID;
using DisorderUnderstar;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
// using DisorderUnderstar.Events;
using DisorderUnderstar.Items.Star;
namespace DisorderUnderstar
{
    public class DisorderUnderstarPlayer : ModPlayer
    {
        #region 物品
        public bool 装备_蘑菇头甲;
        public bool 装备_无序我于万物之中;
        #endregion
        #region 透明
        /// <summary>
        /// 玩家的透明程度，0为完全透明，1为不透明
        /// </summary>
        public float 透明程度 = 0;
        #endregion
        #region 真实生命
        private readonly int realLife = 100;
        /// <summary>
        /// 装甲破碎了的玩家
        /// </summary>
        private bool Fixing { get; set; }
        private float fixTime = 600;
        private float maxMoveSpeed;
        #endregion
        #region 加载的Mod
        public bool 加载了Wtfway;
        public bool 加载了CalamityMod;
        public bool 加载了FallenStar49;
        public bool 加载了Eternalresolve;
        public bool 加载了EndlessGalaxyMod;
        public bool 加载了PeripateticismMod;
        public bool 加载了_1LifeMaxAccessories;
        #endregion
        #region 进世界提示（OnEnterWorld）
        public override void OnEnterWorld(Player player)
        {
            Main.NewText("感谢加载“DisorderUnderstar Mod”！", Color.Blue);
            检测Mod加载();
        }
        #endregion
        #region 难度判定（PlayerConnect，PlayerDisconnect）
        /*
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
                DisorderUnderstar.Easy = false;
                DisorderUnderstar.Hard = true;
                DisorderUnderstar.Normal = false;
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
        */
        #endregion
        public override void ResetEffects()
        {
            透明程度 = 1;
            装备_蘑菇头甲 = false;
            装备_无序我于万物之中 = false;
        }
        public override void ModifyDrawInfo(ref PlayerDrawInfo drawInfo)
        {
            #region 透明
            if (透明程度 < 1 && 装备_蘑菇头甲)
            {
                float sFLOAT = 透明程度;
                sFLOAT = MathHelper.Clamp(透明程度, 0, 1);
                drawInfo.eyeColor = Color.Multiply(drawInfo.eyeColor, sFLOAT);
                drawInfo.legColor = Color.Multiply(drawInfo.legColor, sFLOAT);
                drawInfo.bodyColor = Color.Multiply(drawInfo.bodyColor, sFLOAT);
                drawInfo.faceColor = Color.Multiply(drawInfo.faceColor, sFLOAT);
                drawInfo.hairColor = Color.Multiply(drawInfo.hairColor, sFLOAT);
                drawInfo.shoeColor = Color.Multiply(drawInfo.shoeColor, sFLOAT);
                drawInfo.pantsColor = Color.Multiply(drawInfo.pantsColor, sFLOAT);
                drawInfo.shirtColor = Color.Multiply(drawInfo.shirtColor, sFLOAT);
                drawInfo.eyeWhiteColor = Color.Multiply(drawInfo.eyeWhiteColor, sFLOAT);
                drawInfo.lowerArmorColor = Color.Multiply(drawInfo.lowerArmorColor, sFLOAT);
                drawInfo.upperArmorColor = Color.Multiply(drawInfo.upperArmorColor, sFLOAT);
                drawInfo.underShirtColor = Color.Multiply(drawInfo.underShirtColor, sFLOAT);
                drawInfo.armGlowMaskColor = Color.Multiply(drawInfo.armGlowMaskColor, sFLOAT);
                drawInfo.legGlowMaskColor = Color.Multiply(drawInfo.legGlowMaskColor, sFLOAT);
                drawInfo.middleArmorColor = Color.Multiply(drawInfo.middleArmorColor, sFLOAT);
                drawInfo.bodyGlowMaskColor = Color.Multiply(drawInfo.bodyGlowMaskColor, sFLOAT);
                drawInfo.headGlowMaskColor = Color.Multiply(drawInfo.headGlowMaskColor, sFLOAT);
            }
            #endregion
        }
        public override void PreUpdate()
        {
            // Item item = Main.item[player.HeldItem.type];
            // Projectile projectile = Main.projectile[item.shoot];
            bool 拥有_星体蓄意 = player.HasItem(ModContent.ItemType<StellarDeliberate>());
            if (player.GetModPlayer<DisorderUnderstarPlayer>().Fixing)
            {
                player.statDefense = 0;
                if (player.moveSpeed > player.GetModPlayer<DisorderUnderstarPlayer>().maxMoveSpeed) { player.moveSpeed = maxMoveSpeed; }
            }
            if (拥有_星体蓄意) { player.aggro -= 10; }/*
            #region 难度判定
            if (DisorderUnderstar.Easy)
            {
                player.aggro -= 10;
                player.moveSpeed += 0.5f;
                player.AddBuff(BuffID.Sunflower, 1);

            }
            if (DisorderUnderstar.Normal)
            {
                player.moveSpeed += 0.1f;
                player.AddBuff(BuffID.Sunflower, 1);
            }
            if (DisorderUnderstar.Hard)
            {
                #region 躲避子弹
                foreach (NPC npc in Main.npc)
                {
                    float disMAX = 5f;
                    if (npc.type != NPCID.LunarTowerNebula && npc.type != NPCID.LunarTowerSolar && npc.type != NPCID.LunarTowerStardust &&
                        npc.type != NPCID.LunarTowerVortex && npc.type != NPCID.EaterofWorldsHead && npc.type != NPCID.EaterofWorldsBody &&
                        npc.type != NPCID.EaterofWorldsTail && npc.type != NPCID.TheDestroyer && npc.type != NPCID.TheDestroyerBody &&
                        npc.type != NPCID.TheDestroyerTail)
                    {
                        float dis = Vector2.Distance(projectile.Center, npc.Center);
                        if (disMAX >= dis && projectile.friendly && Main.rand.Next(1, 10) <= 1)
                        {
                            Vector2 tVEC = Vector2.Normalize(projectile.Center - npc.Center) * item.shootSpeed;
                            npc.velocity *= tVEC.RotatedBy(Main.rand.NextFloatDirection() * 0.5f);
                        }
                        else if (Main.rand.Next(1, 100) <= 1)
                        {
                            projectile.position = projectile.Center;
                            projectile.velocity /= 2;
                        }
                    }
                }
                #endregion
            }
            #endregion*/
        }
        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            foreach (NPC target in Main.npc)
            {
                if (!target.friendly && target.active && 装备_无序我于万物之中)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        npc.whoAmI = i;
                        player.ApplyDamageToNPC(npc, damage * 2, 5f, 0, true);
                    }
                }
            }
        }
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore,
            ref PlayerDeathReason damageSource)
        {
            if (!player.GetModPlayer<DisorderUnderstarPlayer>().Fixing)
            {
                if (player.GetModPlayer<DisorderUnderstarPlayer>().装备_无序我于万物之中)
                {
                    if (DisorderUnderstar.Hell || DisorderUnderstar.Nightmare)
                    {
                        player.statLife = (realLife * 5) / 2;
                        player.GetModPlayer<DisorderUnderstarPlayer>().maxMoveSpeed = player.moveSpeed / 2.5f;
                    }
                    else
                    {
                        player.statLife = realLife * 5;
                        player.GetModPlayer<DisorderUnderstarPlayer>().maxMoveSpeed = player.moveSpeed / 1.25f;
                    }
                }
                else
                {
                    if (DisorderUnderstar.Hell || DisorderUnderstar.Nightmare)
                    {
                        player.statLife = realLife / 2;
                        player.GetModPlayer<DisorderUnderstarPlayer>().maxMoveSpeed = player.moveSpeed / 4;
                    }
                    player.statLife = realLife;
                    player.GetModPlayer<DisorderUnderstarPlayer>().maxMoveSpeed = player.moveSpeed / 2;
                }
                player.statDefense = 0;
                player.GetModPlayer<DisorderUnderstarPlayer>().Fixing = true;
                Main.NewText(player.name + "的装甲破碎了！", Color.OrangeRed);
                return false;
            }
            else { return true; }
        }
        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            player.GetModPlayer<DisorderUnderstarPlayer>().Fixing = false;
            player.GetModPlayer<DisorderUnderstarPlayer>().fixTime = 600;
            player.GetModPlayer<DisorderUnderstarPlayer>().maxMoveSpeed = 0;
        }
        public override void PostUpdate()
        {
            #region 真实生命判定
            if (player.GetModPlayer<DisorderUnderstarPlayer>().Fixing) { player.GetModPlayer<DisorderUnderstarPlayer>().fixTime--; }
            if (player.GetModPlayer<DisorderUnderstarPlayer>().fixTime <= 0)
            {
                player.GetModPlayer<DisorderUnderstarPlayer>().Fixing = false;
                player.GetModPlayer<DisorderUnderstarPlayer>().fixTime = 600;
                player.GetModPlayer<DisorderUnderstarPlayer>().maxMoveSpeed = 0;
            }
            #endregion
        }
        private void 检测Mod加载()
        {
            Mod Wtfway = ModLoader.GetMod("Wtfway");
            Mod 灾厄 = ModLoader.GetMod("CalamityMod");
            Mod 四十九落星 = ModLoader.GetMod("FallenStar49");
            Mod 永恒意志 = ModLoader.GetMod("Eternalresolve");
            Mod 无尽星云 = ModLoader.GetMod("EndlessGalaxyMod");
            Mod 华夏圣光 = ModLoader.GetMod("PeripateticismMod");
            Mod 一血上限 = ModLoader.GetMod("_1LifeMaxAccessories");
            if (四十九落星 != null && 永恒意志 != null && 无尽星云 != null && 华夏圣光 != null)
            {
                Main.NewText("感情你是专玩国产啊？？？", Color.Blue);
            }
            else
            {
                if (Wtfway != null)
                {
                    加载了Wtfway = true;
                    Main.NewText("诶，没想到你还加载了这个Mod，真是tql，那我就降低一点难度吧。", Color.Blue);
                }
                if (灾厄 != null)
                {
                    加载了CalamityMod = true;
                    Main.NewText("加载了灾厄，四大Mod之首");
                }
                if (四十九落星 != null)
                {
                    加载了FallenStar49 = true;
                    Main.NewText("加载了四十九落星，我最先听说的国产Mod");
                }
                if (永恒意志 != null)
                {
                    加载了Eternalresolve = true;
                    Main.NewText("加载了永恒意志，开荒噩梦啊喂！", Color.Blue);
                }
                if (无尽星云 != null)
                {
                    加载了EndlessGalaxyMod = true;
                    Main.NewText("加载了无尽星云，可还行。", Color.Blue);
                }
                if (华夏圣光 != null)
                {
                    加载了PeripateticismMod = true;
                    Main.NewText("加载了华夏圣光……", Color.Blue);
                }
                if (一血上限 != null)
                {
                    加载了_1LifeMaxAccessories = true;
                    Main.NewText("加载了1血上限？不愧是你。", Color.Blue);
                }
            }
        }
    }
}