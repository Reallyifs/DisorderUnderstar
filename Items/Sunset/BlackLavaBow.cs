using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items.Sunset
{
    public class BlackLavaBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("黑熔弓");
            Tooltip.SetDefault("【阳夕-Sunset】\n" +
                "-\n" +
                "左键发射黑炎箭\n" +
                "攻击到敌人会给敌人一个“黑色火焰”Debuff\n" +
                "右键蓄力发射能量箭\n" +
                "使用10魔力来让它保持悬浮\n" +
                "-\n" +
                "目前正在尝试着更好的发射方式！");
        }
        public override void SetDefaults()
        {
            item.mana = 5;
            item.rare = ItemRarityID.Cyan;
            item.scale = 1f;
            item.width = 25;
            item.damage = 121;
            item.height = 56;
            item.ranged = true;
            item.useTime = 5;
            item.useStyle = 5;
            item.knockBack = 5f;
            item.useAnimation = 10;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse != 2)
            {
                item.mana = 5;
                item.shoot = mod.ProjectileType("ProSunsetBlackFireArrow");
                item.damage = 133;
                item.channel = false;
                item.useTime = 5;
                item.autoReuse = true;
                item.knockBack = 5f;
                item.shootSpeed = 35f;
                item.useAnimation = 10;
            }
            else
            {
                item.mana = 10;
                item.shoot = mod.ProjectileType("PSEUDOProSunsetEnergyArrow");
                item.damage = 0;
                item.channel = true;
                item.useTime = 40;
                item.autoReuse = false;
                item.knockBack = 0f;
                item.shootSpeed = 0f;
                item.useAnimation = 40;
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe when = new ModRecipe(mod);
            {
                when.anyIronBar = true;
            }
            when.AddIngredient(ItemID.MoltenFury, 1);
            when.AddIngredient(ItemID.IronBar, 25);
            when.AddIngredient(ItemID.Hellstone, 30);
            when.AddIngredient(ItemID.Obsidian, 30);
            when.AddIngredient(ItemID.Amber, 5);
            when.AddIngredient(ItemID.Topaz, 10);
            when.AddIngredient(ItemID.Sapphire, 20);
            when.AddTile(TileID.HeavyWorkBench);
            when.SetResult(this);
            when.AddRecipe();
        }
    }
}
