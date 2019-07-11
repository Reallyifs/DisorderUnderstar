using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
namespace DisorderUnderstar.Items.Disorder
{
    public class DisorderEschatologyBossBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("宝藏袋");
            Tooltip.SetDefault("右键单击以打开");
        }
        public override void SetDefaults()
        {
            item.width = 48;
            item.expert = true;
            item.height = 48;
            item.maxStack = 9999999;
            item.expertOnly = true;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse != 1)
            {
                item.shoot = Item.NewItem((int)player.position.X, (int)player.position.Y,
                    player.width, player.height, mod.ItemType("DisorderEschatologyBossBag"), 2);
                item.maxStack -= 1;
            }
            else
            {
                player.dead = true;
                player.KillMe(PlayerDeathReason.ByCustomReason
                    (player.name + "说：“啥?”"), 9999, 0);
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe z2333 = new ModRecipe(mod);
            z2333.AddIngredient(mod, "DisorderEschatologyBossBag", 2);
            z2333.SetResult(this);
            z2333.AddRecipe();
            ModRecipe z3222 = new ModRecipe(mod);
            {
                z3222.anyWood = true;
            }
            z3222.AddIngredient(ItemID.Wood, 233);
            z3222.AddIngredient(ItemID.StoneBlock, 233);
            z3222.SetResult(this, 100);
            z3222.AddRecipe();
        }
    }
}