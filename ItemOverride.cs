using System;
using Terraria;
using Terraria.ID;
using Terraria.UI;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using DisorderUnderstar.Events;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace DisorderUnderstar
{
    public class ItemOverride : GlobalItem
    {
        public DisorderUndetstarClientConfig DisorderUndetstarClientConfig;
        public override bool CloneNewInstances => true;
        public override bool InstancePerEntity => true;
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.StarWrath)
            {
                item.rare = ItemRarityID.Red;
                item.scale = 1.5f;
                item.damage = 150;
                item.channel = true;
                item.useTime = 10;
                item.useStyle = 5;
                item.knockBack = 7f;
                item.shootSpeed = 10f;
                item.useAnimation = 10;
                return;
            }
        }
        public override bool CanUseItem(Item item, Player player)
        {
            if (item.type == ItemID.DD2ElderCrystal && LunarEclipse.事件发生中) { return false; }
            return true;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            /*
            #region 展示物品价格
            if (DisorderUndetstarClientConfig.ShowItemValue)
            {
                ItemTooltip tooltip = item.ToolTip;
                int 铂 = 0, 金 = 0, 银 = 0, 铜 = 0;
                int value = item.value;
                string 原文本 = tooltip.GetLine(item.ToolTip.Lines);
                string 现文本 = 原文本 + "\n物品的价格为：";
                while (value > 0)
                {
                    if (value >= Item.sellPrice(platinum: 1))
                    {
                        value -= Item.sellPrice(platinum: 1);
                        铂++;
                    }
                    else if (value >= Item.sellPrice(gold: 1))
                    {
                        value -= Item.sellPrice(gold: 1);
                        金++;
                    }
                    else if (value >= Item.sellPrice(silver: 1))
                    {
                        value -= Item.sellPrice(silver: 1);
                        银++;
                    }
                    else if (value >= Item.sellPrice(copper: 1))
                    {
                        value -= Item.sellPrice(copper: 1);
                        铜++;
                    }
                }
                if (铂 + 金 + 银 + 铜 > 0)
                {
                    if (铂 > 0)
                    {
                        现文本 += 铂 + "铂金";
                        if (金 != 0 || 银 != 0 || 铜 != 0) { 现文本 += "，"; }
                    }
                    if (金 > 0)
                    {
                        现文本 += 金 + "金";
                        if (银 != 0 || 铜 != 0) { 现文本 += "，"; }
                    }
                    if (银 > 0)
                    {
                        现文本 += 银 + "银";
                        if (铜 != 0) { 现文本 += "，"; }
                    }
                    if (铜 > 0) { 现文本 += 铜 + "铜"; }
                }
                else
                {
                    现文本 += "无价";
                }
            }
            #endregion
            */
        }
    }
}