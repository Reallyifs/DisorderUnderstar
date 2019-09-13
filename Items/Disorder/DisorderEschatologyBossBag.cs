﻿using Terraria;
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
        public override bool CanRightClick()
        {
            return true;
        }
        public override void RightClick(Player player)
        {
            if (player.altFunctionUse != 1)
            {
                item.maxStack -= 1;
                item.shoot = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, item.type, 2);
            }
            else
            {
                player.dead = true;
                player.KillMe(PlayerDeathReason.ByCustomReason(player.name + "说：“啥?”"), 9999, 0);
            }
        }
        public override void AddRecipes()
        {
            ModRecipe _0 = new ModRecipe(mod);
            _0.AddIngredient(mod, "DisorderEschatologyBossBag", 2);
            _0.SetResult(this);
            _0.AddRecipe();
            _0 = new ModRecipe(mod)
            {
                anyWood = true
            };
            _0.AddIngredient(ItemID.Wood, 233 * ItemID.Wood);
            _0.AddIngredient(ItemID.StoneBlock, 233 * ItemID.StoneBlock);
            _0.SetResult(this, 100);
            _0.AddRecipe();
        }
    }
}