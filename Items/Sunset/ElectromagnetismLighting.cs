using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar.Items.Sunset
{
    public class ElectromagnetismLighting : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("电磁光亮");
            Tooltip.SetDefault("【阳夕-Sunset】\n" +
                "围绕在旁边的电子开始聚集在一起……？\n" +
                "-\n" +
                "左键蓄力射出跟踪的电磁炮\n" +
                "如果碰到了墙壁或敌人，会产生一次爆炸并在原位置持续伤害\n" +
                "右键发射一道低伤害的激光\n" +
                "如果激光旁有敌人的话，则放出另一道跟踪的激光来攻击它\n" +
                "-");
        }
        public override void SetDefaults()
        {
            item.mana = 10;
            item.rare = ItemRarityID.Cyan;
            item.magic = true;
            item.scale = 0.8f;
            item.value = Item.buyPrice(0, 10, 50, 0);
            item.value = Item.sellPrice(0, 0, 1, 0);
            item.width = 54;
            item.damage = 136;
            item.height = 26;
            item.noMelee = true;
            item.useTime = 60;
            item.maxStack = 1;
            item.useStyle = 5;
            item.knockBack = 0f;
            item.useAnimation = 60;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse != 2)
            {
                item.crit = 70;
                item.mana = 10;
                item.shoot = mod.ProjectileType("PESUDOProSunsetElectromagneticProjectile");
                item.damage = 136;
                item.channel = true;
                item.useTime = 20;
                item.autoReuse = false;
                item.knockBack = 0f;
                item.shootSpeed = 50f;
                item.useAnimation = 20;
            }
            else
            {
                item.crit = 35;
                item.mana = 3;
                item.shoot = mod.ProjectileType("ProSunsetLaser1");
                item.damage = 74;
                item.channel = false;
                item.useTime = 8;
                item.autoReuse = true;
                item.knockBack = 1f;
                item.shootSpeed = 100f;
                item.useAnimation = 16;
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe modde = new ModRecipe(mod);
            modde.AddIngredient(ItemID.ChargedBlasterCannon, 1);
            modde.AddIngredient(ItemID.ElectrosphereLauncher, 1);
            modde.AddIngredient(ItemID.ShadowbeamStaff, 1);
            modde.AddIngredient(mod.ItemType("StarManaGun"), 1);
            modde.AddTile(TileID.HeavyWorkBench);
            modde.SetResult(this);
            modde.AddRecipe();
        }
    }
}
