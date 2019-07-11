/*using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DisorderUnderstar.NPCs.Bosses.Disorder
{
    public class DisorderEschatology : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("无序·恐惧症");
            Main.npcFrameCount[npc.type] = 120;
        }
        public override void SetDefaults()
        {
            npc.lifeMax=60170;
            npc.life=60170;
            npc.damage=123;
            npc.defense=89;
            npc.knockBackResist=0.0f;
            npc.lavaImmune=true;
            npc.buffImmune[BuffID.OnFire]=true;
            npc.buffImmune[BuffID.Venom]=true;
            npc.buffImmune[BuffID.Poisoned]=true;
            npc.noGravity=true;
            npc.noTileCollide = true;
        }
        public override void NPCLoot()
        {
            Item.NewItem((int)npc.velocity.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Star, 20);
            Item.NewItem((int)npc.velocity.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Heart, 200);
        }
        public override void AI()
        {
        }
    }
}
*/