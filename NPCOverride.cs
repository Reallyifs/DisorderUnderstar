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
        public override bool CloneNewInstances => true;
        public override bool InstancePerEntity => true;
        public override void AI(NPC npc)
        {
            #region 难度模式判定
            if (DisorderUnderstar.Easy)
            {
                if (Main.rand.Next(1, 10) <= 1) { npc.velocity *= 0.8f; }
            }
            if (DisorderUnderstar.Normal)
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
            if (DisorderUnderstar.Easy)
            {
                npc.damage = 0;
                target.statLife -= target.statLifeMax2 / 50;
                target.immuneTime -= 60;
            }
        }
        public override bool PreNPCLoot(NPC npc)
        {
            if (DisorderUnderstar.Easy)
            {
                if (npc.boss) { npc.value /= 4; }
                else { npc.value /= 2; }
            }
            if (DisorderUnderstar.Hard)
            {
                if (npc.boss) { npc.value *= 2; }
                else { npc.value *= 1.5f; }
            }
            return true;
        }
    }
}