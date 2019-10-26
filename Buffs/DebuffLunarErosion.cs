using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Buffs
{
    public class DebuffLunarErosion : ModBuff
    {
        public override void SetDefaults()
        {
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = false;
            this.longerExpertDebuff = true;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            base.Update(npc, ref buffIndex);
        }
    }
}
