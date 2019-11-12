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
            for (int _0 = 0; _0 < npc.buffImmune.Length; _0++) { npc.buffImmune[_0] = true; }
        }
        public override void AI()
        {
            NPCOverride.读图设置(npc, 12, true);
            int _1 = 0;
            _1++;
            Player _2 = Main.player[npc.target];
            if (npc.life <= npc.lifeMax / 4)
            {
                if (_1 == 1)
                {
                    Vector2 tVEC = Vector2.Normalize(_2.Center - npc.Center) * 50;
                    npc.velocity = tVEC * 0.9f;
                }
                else if (_1 < 60 && _1 > 30) { npc.velocity *= 0.8f; }
                else if (_1 >= 60) { _1 = 0; }
            }
            else
            {
                if (_1 == 1)
                {
                    Vector2 tVEC = Vector2.Normalize(_2.Center - npc.Center) * 25;
                    npc.velocity = tVEC * 0.8f;
                }
                else if (_1 < 120 && _1 > 60) { npc.velocity *= 0.9f; }
                else if (_1 >= 120) { _1 = 0; }
            }
            if (npc.life == npc.lifeMax / 4 && _1 != 0) { _1 = 0; }
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