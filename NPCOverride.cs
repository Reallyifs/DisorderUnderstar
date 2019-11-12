using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using DisorderUnderstar.Events;
using DisorderUnderstar.NPCs.Bosses.Star;
namespace DisorderUnderstar
{
    public class NPCOverride : GlobalNPC
    {
        public override void AI(NPC npc)
        {
            #region 难度模式判定
            if (DisorderUnderstar.Difficulty == (int)DifficultyMode.Easy)
            {
                if (Main.rand.Next(1, 10) <= 1) { npc.velocity *= 0.8f; }
            }
            if (DisorderUnderstar.Difficulty == (int)DifficultyMode.Normal)
            {
                if (Main.rand.Next(1, 100) <= 1 && npc.boss) { npc.velocity *= 2.2f; }
                else if (Main.rand.Next(1, 100) <= 1) { npc.velocity *= 1.6f; }
                foreach (Tile tile in Main.tile)
                {
                    if (tile.type == TileID.Sunflower) { tile.ClearTile(); }
                }
            }
            #endregion
        }
        public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit)
        {
            if (DisorderUnderstar.Difficulty == (int)DifficultyMode.Easy)
            {
                npc.damage = 0;
                target.statLife -= target.statLifeMax2 / 20;
                target.immuneTime -= 60;
            }
        }
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit,
            ref int hitDirection)
        {
            if (LunarEclipse.事件发生中)
            {
                damage = npc.lifeMax / 8;
                projectile.Kill();
            }
        }
        public override bool PreNPCLoot(NPC npc)
        {
            if (DisorderUnderstar.Difficulty == (int)DifficultyMode.Easy)
            {
                if (npc.boss) { npc.value /= 4; }
                else { npc.value /= 2; }
            }
            if (DisorderUnderstar.Difficulty == (int)DifficultyMode.Hard)
            {
                if (npc.boss) { npc.value *= 2; }
                else { npc.value *= 1.5f; }
            }
            return true;
        }
        /// <summary>
        /// 利用这个来设置NPC的帧图
        /// </summary>
        /// <param name="npc">被指定的NPC</param>
        /// <param name="每隔几秒切换帧">每隔输入秒数/60切换一次</param>
        /// <param name="宽">NPC的宽</param>
        /// <param name="高">NPC的高</param>
        /// <param name="竖着读"></param>
        public static void 读图设置(NPC npc, int 每隔几秒切换帧, bool 竖着读)
        {
            int 竖帧数 = 0;
            int 横帧数 = 0;
            npc.frameCounter++;
            if (npc.frameCounter >= 每隔几秒切换帧)
            {
                npc.frameCounter = 0;
                if (竖着读)
                {
                    竖帧数++;
                    npc.frame.X = 竖帧数 * (npc.width + 4);
                }
                else
                {
                    横帧数++;
                    npc.frame.Y = 横帧数 * (npc.height + 4);
                }
            }
            npc.frame.Width = npc.width + 2;
            npc.frame.Height = npc.height + 2;
        }
    }
}