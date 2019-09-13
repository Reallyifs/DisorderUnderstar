using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Items.Star
{
    [AutoloadEquip(EquipType.Shield)]
    public class ShiningShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shining Shield");
            DisplayName.AddTranslation(GameCulture.Chinese, "闪耀星盾");
            Tooltip.SetDefault("[Star]\n" +
                "Although it's not very bright\n" +
                "It can also be used as a self-contained luminescent potion???");
            Tooltip.AddTranslation(GameCulture.Chinese, "【星星】\n" +
                "虽然也没有很亮\n" +
                "但是也可以拿来做个自行携带的发光药水？？？");
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.EoCShield);
            item.crit = 25;
            item.magic = true;
            item.damage = 40;
            item.accessory = true;
            item.expertOnly = true;
            if (item.crit > 50) { item.crit = 50; }
            if (item.damage > item.crit * 5) { item.damage = item.crit * 5; }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            for(int _0 = 0; _0 < 2; _0++)
            {
                Dust _1 = Dust.NewDustDirect(player.Center, hitbox.Width, hitbox.Height, MyDustId.YellowHallowFx, player.velocity.X / 2,
                    player.velocity.Y / 2);
                _1.alpha = Main.rand.Next(0, 128);
                _1.color = Color.White;
                _1.scale = Main.rand.NextFloat(0.5f, 1.5f);
                _1.noLight = false;
                _1.noGravity = true;
            }
        }
    }
}