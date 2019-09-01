using Terraria.ModLoader;
namespace DisorderUnderstar.NPCs.Bosses.Star
{
    public class MeteorTidal : Terraria.ModLoader.ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("流星潮汐");
        }
        public override void SetDefaults()
        {
            npc.boss = true;
            npc.width = 28;
            npc.height = 28;
            npc.lifeMax = 23000;
            npc.friendly = false;
        }
    }
}
