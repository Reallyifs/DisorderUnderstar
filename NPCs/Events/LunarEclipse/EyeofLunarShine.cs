using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using DisorderUnderstar.Buffs;
using Microsoft.Xna.Framework;
using static DisorderUnderstar.Events.LunarEclipse;
namespace DisorderUnderstar.NPCs.Events.LunarEclipse
{
    public class EyeofLunarShine : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eye of Lunar Shine");
            DisplayName.AddTranslation(GameCulture.Chinese, "月耀之眼");
            Main.npcFrameCount[npc.type] = 2;
        }
        public override void SetDefaults()
        {
            npc.color = Color.LimeGreen;
            npc.value = Item.buyPrice(0, Main.rand.Next(0, 10), Main.rand.Next(20, 50), Main.rand.Next(60, 99));
            npc.width = 24;
            npc.damage = 214;
            npc.height = 22;
            npc.aiStyle = -1;
            npc.defense = 46;
            npc.friendly = false;
            npc.HitSound = SoundID.NPCHit1;
            npc.noGravity = true;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
        }
        public override void FindFrame(int frameHeight) => npc.frame.Y = 24 * frameHeight;
        public override void AI()
        {
            npc.ai[0]++;
            if (npc.ai[0] == 12) { FindFrame(0); }
            else if (npc.ai[0] == 24)
            {
                FindFrame(1);
                npc.ai[0] = 0;
            }
            for (int i = 0; i < Main.maxBuffTypes; i++) { npc.buffImmune[i] = true; }
            int _0 = 0, _1 = 0;
            Player _3 = Main.player[npc.target];
            if (_0 == 0)
            {
                Vector2 _4 = Vector2.Normalize(_3.Center - npc.Center) * 30;
                npc.velocity = (npc.velocity + _4) * 0.9f;
                _0 = 1;
            }
            if (npc.life < npc.lifeMax / 4)
            {
                if (_1 < 60)
                {
                    _1++;
                    if (_1 > 40) { npc.velocity *= 0.9f; }
                }
                else { _0 = _1 = 0; }
            }
            else
            {
                if (_1 < 120)
                {
                    _1++;
                    if (_1 > 60) { npc.velocity *= 0.8f; }
                }
                else { _0 = _1 = 0; }
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.velocity += npc.velocity / 2;
            target.AddBuff(ModContent.BuffType<DebuffLunarErosion>(), damage);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo) => 0;
        public override void NPCLoot() => 杀怪分数 += 10;
    }
}