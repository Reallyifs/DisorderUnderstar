using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using DisorderUnderstar.Dusts.Disorder;
namespace DisorderUnderstar.Buffs.Disorder
{
    public class DebuffChaosTheory : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Chaos Theory");
            DisplayName.AddTranslation(GameCulture.Chinese, "混沌理论");
            Description.SetDefault("Something was fall out of your body several time...?");
            Description.AddTranslation(GameCulture.Chinese, "时不时有什么从你的身体脱落……？");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            this.longerExpertDebuff = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (Main.rand.Next(25) < 1)
            {
                Vector2 pVEC = new Vector2(Main.rand.Next(0, 5), 0);
                player.statLife -= 6;
                Dust.NewDustDirect(player.position + pVEC, 1, 1, ModContent.DustType<DustBodyDebris>(), 0, 0, 128, Color.Red);
            }
        }
    }
}