using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Buffs;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Events;
using DisorderUnderstar.NPCs.Events.LunarEclipse;
namespace DisorderUnderstar.Events
{
    public class LunarEclipse
    {
        public static int 杀怪分数 = 0;
        public static bool 事件发生中 = false;
        public static bool 使用月蚀耀碑 = false;
        private static int 波数 = 0;
        private static bool 每夜晚检测 = true;
        #region 特定怪物生成
        private static int 生成_月耀之眼;
        #endregion
        public static bool 符合事件出现条件_月蚀()
        {
            return !Main.dayTime && !Main.bloodMoon && Main.hardMode && !Main.pumpkinMoon && !Main.snowMoon && !DD2Event.Ongoing;
        }
        public static bool 符合事件出现条件_月蚀_有概率()
        {
            bool 概率选中 = false;
            if (每夜晚检测 && !Main.dayTime)
            {
                概率选中 = Main.rand.Next(1, 10000) <= 1;
                每夜晚检测 = false;
            }
            else if (!每夜晚检测 && Main.dayTime) { 每夜晚检测 = true; }
            return !Main.dayTime && !Main.bloodMoon && Main.hardMode && !Main.pumpkinMoon && !Main.snowMoon && !DD2Event.Ongoing && 概率选中;
        }
        public static bool 判定()
        {
            if (Main.dayTime || 完成事件())
            {
                事件发生中 = false;
                使用月蚀耀碑 = false;
                return false;
            }
            if (使用月蚀耀碑 || 符合事件出现条件_月蚀_有概率() || 事件发生中) { 事件发生中 = true; }
            return 事件发生中;
        }
        private static bool 完成事件()
        {
            if (波数 > 月蚀.月蚀_杀怪分数.Length) { return true; }
            else if (杀怪分数 >= 月蚀.月蚀_杀怪分数[波数]) { 波数 += 1; }
            return false;
        }
        public static void 事件发生(Item item)
        {
            if (!判定()) { return; }
            if (item.crit > 20) { item.crit = 20; }
            if (item.mana < item.crit * 2) { item.mana = item.crit * 2; }
            if (item.damage > item.crit * 5) { item.damage = item.crit * 5; }
            if (item.useAnimation < 30) { item.useAnimation = 30; }
            if (item.useTime < item.useAnimation) { item.useTime = item.useAnimation; }
            if (item.accessory)
            {
                if (item.defense > 10) { item.defense = 10; }
            }
            if (item.ranged)
            {
                Projectile projectile = Main.projectile[item.shoot];
                if (projectile.Name.Contains("Arrow") || projectile.Name.Contains("箭") || projectile.Name.Contains("矢"))
                { item.shoot = ProjectileID.WoodenArrowFriendly; }
                else if (projectile.Name.Contains("Bullet") || projectile.Name.Contains("子弹"))
                { item.shoot = ProjectileID.Bullet; }
                else if (projectile.Name.Contains("Coin") || projectile.Name.Contains("币") || projectile.Name.Contains("钱"))
                { item.shoot = ProjectileID.CopperCoin; }
            }
            return;
        }
        public static void 事件发生(Player player)
        {
            if (player.active)
            {
                player.nightVision = true;
                if (player.statDefense > 100) { player.statDefense = 100; }
            }
        }
        public static void 事件发生(NPC target)
        {
            if (target.active)
            {
                if (target.friendly)
                {
                    target.velocity *= 0.8f;
                    target.knockBackResist = 5f;
                }
            }
            if (NPC.downedPlantBoss && 波数 >= 5) { 生成怪物_世纪之花后(); }
            return;
        }
        public static void 事件发生(Projectile projectile)
        {
            Player player = Main.player[Main.myPlayer];
            if (projectile.active && projectile.hostile)
            {
                float disP = Vector2.Distance(projectile.Center, player.Center);
                float disMAX = 0.5f;
                if (disMAX >= disP)
                {
                    player.statLife -= 100;
                    player.AddBuff(ModContent.BuffType<DebuffLunarErosion>(), 60);
                    projectile.Kill();
                }
                else
                {
                    Vector2 tVEC = (Vector2.Normalize(player.Center - projectile.Center) + player.velocity * 4) * 30;
                    float nVEC = 40f;
                    if (nVEC > 30f) { nVEC -= 0.1f; }
                    projectile.velocity = (projectile.velocity * nVEC + tVEC) / (nVEC + 1f);
                }
                foreach (NPC npc in Main.npc)
                {
                    float disN = Vector2.Distance(projectile.Center, npc.Center);
                    if (npc.friendly && npc.active && disMAX >= disN)
                    {
                        npc.life -= 100;
                        npc.lifeMax -= npc.lifeMax / 10;
                        npc.AddBuff(ModContent.BuffType<DebuffLunarErosion>(), 120);
                        projectile.Kill();
                    }
                    else if (!npc.friendly && npc.active && npc.life != npc.lifeMax && Main.rand.Next(1, 100) <= 1 && disMAX >= disN)
                    {
                        npc.life += npc.lifeMax / 4;
                        npc.lifeMax += npc.lifeMax / 8;
                        npc.HealEffect(npc.lifeMax / 2);
                        projectile.Kill();
                    }
                }
            }
            return;
        }
        private static void 生成怪物_世纪之花后()
        {
            Player player = Main.player[Main.myPlayer];
            #region 月耀之眼
            if (Main.rand.Next(1, 1000) <= 1 && 生成_月耀之眼 <= 2)
            {
                if (Main.rand.NextBool())
                {
                    int xPosition = (int)player.Center.X + Main.screenWidth + Main.rand.Next(-20, 20);
                    int yPosition = (int)player.Center.Y + Main.rand.Next(-20, 20);
                    NPC.NewNPC(xPosition, yPosition, ModContent.NPCType<EyeofLunarShine>());
                }
                else
                {
                    int xPosition = (int)player.Center.X - Main.screenWidth + Main.rand.Next(-20, 20);
                    int yPosition = (int)player.Center.Y + Main.rand.Next(-20, 20);
                    NPC.NewNPC(xPosition, yPosition, ModContent.NPCType<EyeofLunarShine>());
                }
                生成_月耀之眼 += 1;
                return;
            }
            #endregion
        }
    }
}