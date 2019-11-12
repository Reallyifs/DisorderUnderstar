using System;
using Terraria;
using Terraria.ID;
using Terraria.UI;
using Terraria.ModLoader;
using DisorderUnderstar.Tools;
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
            #region 展示物品价格
            if (DisorderUndetstarClientConfig.ShowItemValue)
            {
                int 铂 = 0, 金 = 0, 银 = 0, 铜 = 0;
                int value = item.value;
                string 现文本 = "物品的价格为：";
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
                else { 现文本 += "无价"; }
                tooltips.Add(new TooltipLine(mod, "ItemValue", 现文本));
            }
            #endregion
        }
        /// <summary>
        /// 利用这个生成伪原版叶绿水晶
        /// </summary>
        /// <param name="player">在这个玩家头上漂浮叶绿水晶</param>
        public static void 漂浮叶绿水晶(Player player)
        {
            Vector2 uVEC = new Vector2(player.Center.X, player.position.Y - player.height);
            if (player.whoAmI == Main.myPlayer)
            {
                Projectile 叶绿水晶 = Projectile.NewProjectileDirect(uVEC, player.velocity, ProjectileID.CrystalLeaf, Player.crystalLeafDamage,
                    Player.crystalLeafKB, player.whoAmI);
                叶绿水晶.position.X = player.Center.X;
                叶绿水晶.position.Y = player.position.Y - player.height;
            }
        }
    }
}