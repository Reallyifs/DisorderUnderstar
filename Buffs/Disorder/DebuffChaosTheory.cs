using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Buffs.Disorder
{
    public class DebuffChaosTheory : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("混沌理论");
            Description.SetDefault("时不时有什么从你的身体脱落……？");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            this.longerExpertDebuff = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (Main.rand.Next(25) < 1)
            {
                player.statLife -= 6;
                Dust.NewDustDirect
                    (player.position, player.width, player.height,
                    mod.DustType("DustBodyDebris"), 0, 0, 128,
                    Color.Red, -0.5f);
            }
        }
    }
}