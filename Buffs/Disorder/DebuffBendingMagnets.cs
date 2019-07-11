using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Buffs.Disorder
{
    public class DebuffBendingMagnets : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("偏转磁极");
            Description.SetDefault("你觉得你的方向感有点偏差……");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            this.longerExpertDebuff = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (Main.rand.Next(100) < 1)
            {
                player.buffImmune[BuffID.Confused] = false;
                player.AddBuff(BuffID.Confused, 60);
            }
            else
            {
                player.buffImmune[BuffID.Confused] = true;
            }
        }
    }
}
