using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Buffs;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Events;
using DisorderUnderstar.Items.Disorder;
using DisorderUnderstar.Projectiles.Star;
using DisorderUnderstar.Projectiles.LoadedMod;
using DisorderUnderstar.NPCs.Events.LunarEclipse;
namespace DisorderUnderstar.Events
{
    public class LunarEclipse
    {
        private static bool 持续事件 = false;
        public static bool 每夜晚检测 = true;
        public static bool 使用月蚀耀碑 = false;
        #region 难度递增
        public static bool 打败世纪之花 = false;
        public static bool 打败月球领主 = false;
        public static bool 打败月球领主后克鲁苏之眼 = false;
        public static bool 打败月球领主后血肉之墙 = false;
        public static bool 打败月球领主后世纪之花 = false;
        #endregion
        #region 特定怪物生成
        private static int 生成_世纪之花;
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
        public static bool 判定(Mod mod, NPC target, Item item, Player player, Projectile projectile)
        {
            if (Main.dayTime)
            {
                持续事件 = false;
                使用月蚀耀碑 = false;
            }
            if (使用月蚀耀碑 || 符合事件出现条件_月蚀_有概率() || 持续事件)
            {
                持续事件 = true;
                事件发生(mod, target, item, player, projectile);
            }
            return 持续事件;
        }
        public static void 事件发生(Mod mod, NPC target, Item item, Player player, Projectile projectile)
        {
            if (target.active)
            {
                if (target.friendly)
                {
                    target.velocity *= 0.5f;
                    target.knockBackResist = 5f;
                }
            }
            if (item.accessory)
            {
                if (item.defense > 10)
                {
                    item.value = Item.sellPrice(0, 0, 50, 0);
                    item.defense = 10;
                }
            }
            if (item.melee)
            {
                if (item.crit > 20) { item.crit = 20; }
                if (item.damage > item.crit * 5) { item.damage = item.crit * 5; }
                if (item.useTime < item.useAnimation) { item.useTime = item.useAnimation; }
                if (item.useAnimation < 30) { item.useAnimation = 30; }
                ItemOverride.事件_月蚀(item);
            }
            if (item.magic)
            {
                if (item.crit > 20) { item.crit = 20; }
                if (item.mana < item.crit * 2) { item.mana = item.crit * 2; }
                if (item.damage > item.crit * 5) { item.damage = item.crit * 5; }
                if (item.useTime < item.useAnimation) { item.useTime = item.useAnimation; }
                if (item.useAnimation < 30) { item.useAnimation = 30; }
            }
            if (item.ranged)
            {
                Projectile pOWNER = Main.projectile[item.shoot];
                if (item.useAmmo == AmmoID.Arrow &&
                    (pOWNER.Name.Contains("Arrow") || pOWNER.Name.Contains("箭") || pOWNER.Name.Contains("矢")) &&
                    projectile.owner == item.owner)
                { item.shoot = ProjectileID.WoodenArrowFriendly; }
                else if (item.useAmmo == AmmoID.Bullet &&
                    (pOWNER.Name.Contains("Bullet") || pOWNER.Name.Contains("子弹")) &&
                    projectile.owner == item.owner)
                { item.shoot = ProjectileID.Bullet; }
                else if (item.useAmmo == AmmoID.Coin &&
                    (pOWNER.Name.Contains("Coin") || pOWNER.Name.Contains("币") || pOWNER.Name.Contains("钱")) &&
                    projectile.owner == item.owner)
                { item.shoot = ProjectileID.CopperCoin; }
            }
            if (player.active)
            {
                player.nightVision = true;
                if (player.statDefense > 128) { player.statDefense = 128; }
            }
            if (projectile.active && projectile.friendly &&
                (projectile.type != mod.ProjectileType<ProStarArrow>() || projectile.type != mod.ProjectileType<ProWtfway>()))
            {
                projectile.penetrate = 1;
                projectile.extraUpdates += 2;
                if (projectile.damage > 0) { projectile.damage = 0; }
                if (projectile.knockBack > 5f) { projectile.knockBack = 5f; }
            }
            if (projectile.active && projectile.hostile)
            {
                float disP = Vector2.Distance(projectile.Center, player.Center);
                float disMAX = 0.5f;
                if (disMAX >= disP)
                {
                    projectile.Kill();
                    player.statLife -= 100;
                    player.AddBuff(mod.BuffType<DebuffLunarErosion>(), 60);
                }
                else
                {
                    Vector2 tVEC = Vector2.Normalize(player.Center - projectile.Center) * 30;
                    float nVEC = 40f;
                    if (nVEC > 30f) { nVEC--; }
                    projectile.velocity = (projectile.velocity * nVEC + tVEC) / (nVEC + 1f);
                }
                foreach (NPC npc in Main.npc)
                {
                    float disN = Vector2.Distance(projectile.Center, npc.Center);
                    if (npc.friendly && npc.active && disMAX >= disN)
                    {
                        projectile.Kill();
                        npc.life -= 100;
                        npc.lifeMax -= npc.lifeMax / 10;
                        npc.AddBuff(mod.BuffType<DebuffLunarErosion>(), 120);
                    }
                    else if (!npc.friendly && npc.active && disMAX >= disN)
                    {
                        projectile.Kill();
                        npc.life += npc.lifeMax / 2;
                        npc.lifeMax += npc.lifeMax / 4;
                    }
                }
            }
            if (打败世纪之花) { 生成怪物_世纪之花后(mod, player); }
        }
        public static void 生成怪物_世纪之花后(Mod mod, Player player)
        {
            if (Main.rand.Next(1, 1000) <= 1 && 生成_世纪之花 <= 2)
            {
                NPC.NewNPC((int)player.Center.X + Main.screenWidth + Main.rand.Next(-30, 30), (int)player.Center.Y + Main.rand.Next(-30, 30),
                    mod.NPCType<暂定名_以后要改>());
                生成_世纪之花 += 1;
            }
        }
    }
}
