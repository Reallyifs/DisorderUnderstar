using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using DisorderUnderstar.Events;
namespace DisorderUnderstar
{
    public class NPCOverride : GlobalNPC
    {
        public override void AI(NPC npc)
        {
            int type = npc.type;
            #region Boss判定
            bool 世界吞噬者 = type == NPCID.EaterofWorldsHead || type == NPCID.EaterofWorldsBody || type == NPCID.EaterofWorldsTail;
            bool 克鲁苏之脑 = type == NPCID.BrainofCthulhu || type == NPCID.Creeper;
            bool 骷髅王 = type == NPCID.SkeletronHead || type == NPCID.SkeletronHand;
            bool 血肉之墙 = type == NPCID.WallofFlesh || type == NPCID.WallofFleshEye;
            bool 双子魔眼 = type == NPCID.Retinazer || type == NPCID.Spazmatism;
            bool 毁灭者 = type == NPCID.TheDestroyer || type == NPCID.TheDestroyerBody || type == NPCID.TheDestroyerTail || type == NPCID.Probe;
            bool 骷髅队长 = type == NPCID.SkeletronPrime || type == NPCID.PrimeCannon || type == NPCID.PrimeSaw || type == NPCID.PrimeVice ||
                type == NPCID.PrimeLaser;
            bool 石巨人 = type == NPCID.Golem || type == NPCID.GolemFistLeft || type == NPCID.GolemFistRight || type == NPCID.GolemHead;
            bool 猪鲨龙公爵 = type == NPCID.DukeFishron || type == NPCID.Sharkron || type == NPCID.Sharkron2;
            bool 月神教徒 = type == NPCID.CultistBoss || type == NPCID.CultistBossClone || type == NPCID.CultistDevote;
            bool 月球领主 = type == NPCID.MoonLordCore || type == NPCID.MoonLordHead || type == NPCID.MoonLordHand ||
                type == NPCID.MoonLordLeechBlob;
            bool 旧日支配者事件 = type == NPCID.DD2OgreT2 || type == NPCID.DD2OgreT3 || type == NPCID.DD2DarkMageT1 ||
                type == NPCID.DD2DarkMageT3 || type == NPCID.DD2Betsy;
            bool 海盗事件 = type == NPCID.PirateShip || type == NPCID.PirateShipCannon;
            bool 南瓜月与霜月 = type == NPCID.MourningWood || type == NPCID.Pumpking || type == NPCID.Everscream || type == NPCID.SantaNK1 ||
                type == NPCID.IceQueen;
            bool 火星暴乱事件 = type == NPCID.MartianSaucer || type == NPCID.MartianSaucerCore || type == NPCID.MartianSaucerTurret ||
                type == NPCID.MartianSaucerCannon;
            bool Boss = type == NPCID.KingSlime || type == NPCID.EyeofCthulhu || 世界吞噬者 || 克鲁苏之脑 || type == NPCID.QueenBee || 骷髅王 ||
                血肉之墙 || 双子魔眼 || 毁灭者 || 骷髅队长 || type == NPCID.Plantera || 石巨人 || 猪鲨龙公爵 || 月神教徒 || 月球领主 ||
                旧日支配者事件 || 海盗事件 || 南瓜月与霜月 || 火星暴乱事件;
            #endregion
            #region 难度模式判定
            if (DisorderUnderstar.Easy && !DisorderUnderstar.Hard && !DisorderUnderstar.Hell && !DisorderUnderstar.Nightmare)
            {
                if (Main.rand.Next(1, 10) <= 1) { npc.velocity *= 0.8f; }
            }
            if (DisorderUnderstar.Normal)
            {
                if (Main.rand.Next(1, 100) <= 1 && Boss) { npc.velocity *= 2.2f; }
                else if (Main.rand.Next(1, 100) <= 1) { npc.velocity *= 1.6f; }
                foreach (Tile tile in Main.tile)
                {
                    if (tile.type == TileID.Sunflower) { tile.active(false); }
                }
            }
            if (DisorderUnderstar.Hard)
            {
                if (Boss) { npc.value *= 2; }
                else { npc.value *= 1.5f; }
                if (type == NPCID.Golem)
                {
                    npc.lifeRegen += 100;
                    if (Main.rand.Next(1, 100) <= 1) { npc.immune[npc.type] = 60; }
                    else { npc.damage += 1; }
                }
            }
            #endregion
        }
        public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit)
        {
            if (DisorderUnderstar.Easy && !DisorderUnderstar.Hard && !DisorderUnderstar.Hell &&
                !DisorderUnderstar.Nightmare)
            {
                npc.damage = 0;
                target.statLife -= target.statLifeMax2 / 50;
                target.immuneTime -= 60;
            }
        }
        public override bool PreNPCLoot(NPC npc)
        {
            int type = npc.type;
            #region Boss判定
            bool 世界吞噬者 = type == NPCID.EaterofWorldsHead || type == NPCID.EaterofWorldsBody || type == NPCID.EaterofWorldsTail;
            bool 克鲁苏之脑 = type == NPCID.BrainofCthulhu || type == NPCID.Creeper;
            bool 骷髅王 = type == NPCID.SkeletronHead || type == NPCID.SkeletronHand;
            bool 血肉之墙 = type == NPCID.WallofFlesh || type == NPCID.WallofFleshEye;
            bool 双子魔眼 = type == NPCID.Retinazer || type == NPCID.Spazmatism;
            bool 毁灭者 = type == NPCID.TheDestroyer || type == NPCID.TheDestroyerBody || type == NPCID.TheDestroyerTail || type == NPCID.Probe;
            bool 骷髅队长 = type == NPCID.SkeletronPrime || type == NPCID.PrimeCannon || type == NPCID.PrimeSaw || type == NPCID.PrimeVice ||
                type == NPCID.PrimeLaser;
            bool 石巨人 = type == NPCID.Golem || type == NPCID.GolemFistLeft || type == NPCID.GolemFistRight || type == NPCID.GolemHead;
            bool 猪鲨龙公爵 = type == NPCID.DukeFishron || type == NPCID.Sharkron || type == NPCID.Sharkron2;
            bool 月神教徒 = type == NPCID.CultistBoss || type == NPCID.CultistBossClone || type == NPCID.CultistDevote;
            bool 月球领主 = type == NPCID.MoonLordCore || type == NPCID.MoonLordHead || type == NPCID.MoonLordHand ||
                type == NPCID.MoonLordLeechBlob;
            bool 旧日支配者事件 = type == NPCID.DD2OgreT2 || type == NPCID.DD2OgreT3 || type == NPCID.DD2DarkMageT1 ||
                type == NPCID.DD2DarkMageT3 || type == NPCID.DD2Betsy;
            bool 海盗事件 = type == NPCID.PirateShip || type == NPCID.PirateShipCannon;
            bool 南瓜月与霜月 = type == NPCID.MourningWood || type == NPCID.Pumpking || type == NPCID.Everscream || type == NPCID.SantaNK1 ||
                type == NPCID.IceQueen;
            bool 火星暴乱事件 = type == NPCID.MartianSaucer || type == NPCID.MartianSaucerCore || type == NPCID.MartianSaucerTurret ||
                type == NPCID.MartianSaucerCannon;
            bool Boss = type == NPCID.KingSlime || type == NPCID.EyeofCthulhu || 世界吞噬者 || 克鲁苏之脑 || type == NPCID.QueenBee || 骷髅王 ||
                血肉之墙 || 双子魔眼 || 毁灭者 || 骷髅队长 || type == NPCID.Plantera || 石巨人 || 猪鲨龙公爵 || 月神教徒 || 月球领主 ||
                旧日支配者事件 || 海盗事件 || 南瓜月与霜月 || 火星暴乱事件;
            #endregion
            #region 月蚀事件判定
            /*
            if (npc.type == NPCID.Plantera) { LunarEclipse.打败世纪之花 = true; }
            if (LunarEclipse.打败世纪之花 && 月球领主)
            {
                Main.NewText("月球无主，生物狂欢！", Color.DarkBlue);
                LunarEclipse.打败月球领主 = true;
            }
            if (LunarEclipse.打败月球领主 && npc.type == NPCID.EyeofCthulhu)
            {
                Main.NewText("似神之眼已被释放……", Color.DarkBlue);
                LunarEclipse.打败月球领主后克鲁苏之眼 = true;
            }
            if (LunarEclipse.打败月球领主后克鲁苏之眼 && 血肉之墙)
            {
                Main.NewText("远古之神再次醒来……", Color.DarkBlue);
                LunarEclipse.打败月球领主后血肉之墙 = true;
            }
            if (LunarEclipse.打败月球领主后血肉之墙 && npc.type == NPCID.Plantera)
            {
                Main.NewText("月亮逐渐靠近这片大地……", Color.DarkBlue);
                LunarEclipse.打败月球领主后世纪之花 = true;
            }
            */
            #endregion
            if (DisorderUnderstar.Easy && !DisorderUnderstar.Hard && !DisorderUnderstar.Hell && !DisorderUnderstar.Nightmare)
            {
                if (Boss) { npc.value /= 4; }
                else { npc.value /= 2; }
            }
            if (DisorderUnderstar.Hard)
            {
                if (Boss) { npc.value *= 2; }
                else { npc.value *= 1.5f; }
            }
            return true;
        }
    }
}
