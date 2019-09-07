/*
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.DataStructures;
namespace DisorderUnderstar.NPCs.Bosses.Disorder
{
    public class DisorderEschatology : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("无序·恐惧症");
        }
        public override void SetDefaults()
        {
            npc.boss = true;
            npc.value = Item.buyPrice(10, 10, 10, 10);
            npc.damage = 123;
            npc.defense = 89;
            npc.lifeMax = 60170;
            npc.noGravity = true;
            npc.lavaImmune = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0.0f;
            npc.buffImmune[BuffID.Venom] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.Poisoned] = true;
        }
        public override void AI()
        {
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.SuperHealingPotion;
        }
        public override void NPCLoot()
        {
            Item.NewItem((int)npc.velocity.X, (int)npc.position.Y, npc.width, npc.height,
                ItemID.Star, 20);
            Item.NewItem((int)npc.velocity.X, (int)npc.position.Y, npc.width, npc.height,
                ItemID.Heart, 200);
        }
    }
}
*/