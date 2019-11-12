using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using DisorderUnderstar.Buffs;
using DisorderUnderstar.Tools;
using Microsoft.Xna.Framework;
using DisorderUnderstar.Buffs.Sunset;
using DisorderUnderstar.Buffs.Disorder;
namespace DisorderUnderstar.Items.Disorder
{
    [AutoloadEquip(EquipType.Wings)]
    public class DisorderMyself : ModItem
    {
        public override void SetStaticDefaults()
        {
            int 共冷却时间 = Main.expertMode ? (NPC.downedPlantBoss ? 20 : 40) : (NPC.downedPlantBoss ? 15 : 30);
            int 生命冷却时间 = Main.expertMode ? 20 : 10;
            int 魔法冷却时间 = Main.expertMode ? 15 : 10;
            #region 英文
            DisplayName.SetDefault("Disorder ` Myself");
            Tooltip.SetDefault("[Disorder]\n" +
                "\"Everything is in me, I am in everything.\"\n" +
                "\"Everything is me, I am everything.\"\n" +
                "\"I hate myself, I love myself.\"\n" +
                "          -- scp-3999\n" +
                "-\n" +
                "You'll get a bunch of [c/BFBFBF:Buffs] that I actually wrote but didn't work.\n" +
                "-\n" +
                "When [c/FF0000:Life] is below 2888, [c/0000FF:Maximum mana] increases 388, [c/0000FF:Temporary Magic] increases 88\n" +
                "When [c/0000FF:Mana] is below 288, [c/FF0000:Life Max] increases 888, [c/FF0000:Temporary Life] increases 388.\n" +
                "When [c/FF0000:Life] is below 200 and [c/0000FF:Mana] is below 20, [c/FF0000:Temporary Life] increases 666 and [c/0000FF:Temporary Magic] increases 66.\n" +
                "If none of the above conditions are met, multiply the moving speed by 8\n" +
                "-\n" +
                "When [c/FF0000:Life] is below a third of [c/FF0000:Life Max], give you [c/BFBFBF:Ice Barrier Buff] for 30 seconds.\n" +
                "If the above conditions are not satisfied, give you [c/BFBFBF:Blessing Moment Buff], and give you [c/3F3F3F:Chaos Theory Debuff]\n" +
                "-\n" +
                "Give you [c/3F3F3F:Bending Magnets Debuff] no matter what state you are in.\n" +
                "-\n" +
                "(Incomplete)\n" +
                "-");
            #endregion
            #region 中文
            DisplayName.AddTranslation(GameCulture.Chinese, "无序·我于万物之中");
            Tooltip.AddTranslation(GameCulture.Chinese, "【无序】\n" +
                "“万物于我，我于万物之中。”\n" +
                "“万物即我，我于我之中。”\n" +
                "“可恨的自己，可爱的自己。”\n" +
                "          ——scp-3999\n" +
                "-\n" +
                "你会获得一堆实际上我写了但是没有作用的[c/BFBFBF:Buff]\n" +
                "-\n" +
                "当[c/FF0000:生命]低于2888时，[c/0000FF:最大魔法]增加388，[c/0000FF:临时魔法]增加88，" + 生命冷却时间 + "秒冷却\n" +
                "当[c/0000FF:魔法]低于288时，[c/FF0000:最大生命]增加888，[c/FF0000:临时生命]增加388，" + 魔法冷却时间 + "秒冷却\n" +
                "当[c/FF0000:生命]低于200、[c/0000FF:魔法]低于20时，[c/FF0000:临时生命]增加666，[c/0000FF:临时魔法]增加66，以上皆冷却" + 共冷却时间 + "秒\n" +
                "如果以上条件都不满足，移动速度提升90%\n" +
                "-\n" +
                "当[c/FF0000:生命]低于[c/FF0000:生命上限]的三分之一时，给予你持续30秒的[c/BFBFBF:冰障Buff]\n" +
                "如果以上条件不满足，给予你[c/BFBFBF:祝福时刻Buff]，同时给予你[c/3F3F3F:混乱理论Debuff]\n" +
                "-\n" +
                "无论你在何种状态，给予你[c/3F3F3F:偏转磁极Debuff]\n" +
                "-\n" +
                "（不全）\n" +
                "-");
            #endregion
        }
        public override void SetDefaults()
        {
            item.rare = 12;
            item.value = Item.sellPrice(10, 20, 30, 40);
            item.width = 48;
            item.expert = true;
            item.height = 48;
            item.defense = 407;
            item.accessory = true;
            item.expertOnly = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            #region 伤害暴击
            player.attackCD -= 1;
            player.manaCost -= 0.9f;
            player.minionKB += 0.5f;
            player.allDamage *= 23.87f;
            player.magicCrit += 88;
            player.meleeCrit += 88;
            player.maxMinions += 40;
            player.meleeSpeed += 0.5f;
            player.rangedCrit += 88;
            player.thrownCrit += 88;
            player.crystalLeaf = true;
            player.stardustMinion = true;
            player.shroomiteStealth = true;
            player.vortexStealthActive = true;
            #endregion
            #region 生命魔法
            player.lifeForce = true;
            player.lifeRegen += player.dpsDamage;
            player.manaRegen += player.dpsDamage;
            player.manaFlower = true;
            player.shinyStone = true;
            player.crimsonRegen = true;
            player.statLifeMax2 += 1500;
            player.statManaMax2 += 750;
            #endregion
            #region 各种免疫
            player.noFallDmg = true;
            player.lavaImmune = true;
            player.noKnockback = true;
            #endregion
            加成(player, hideVisual);
            免疫Debuff(player);
        }
        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            constantAscend = 0.5f;
            ascentWhenRising = 0.75f;
            ascentWhenFalling = 1.5f;
            maxAscentMultiplier = 5f;
            maxCanAscendMultiplier = 10f;
        }
        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 50f;
            acceleration *= 5f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ModContent.ItemType<DisorderFourtype>(), 1);
            recipe1.AddIngredient(ModContent.ItemType<DisorderOmnipotence>(), 1);
            recipe1.AddIngredient(ModContent.ItemType<DisorderCross>(), 1);
            recipe1.AddIngredient(ModContent.ItemType<DisorderBar>(), 33);
            recipe1.AddIngredient(ModContent.ItemType<LikeLifeLine>(), 10);
            recipe1.AddIngredient(ModContent.ItemType<StartStarsStory>(), 10);
            recipe1.AddIngredient(ItemID.LifeCrystal, 25);
            recipe1.AddIngredient(ItemID.ManaCrystal, 25);
            recipe1.AddTile(TileID.LunarCraftingStation);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
        private int 冷却时间开始(bool 生命, bool 魔法, bool 重置 = false)
        {
            int 共冷却时间 = Main.expertMode ? (NPC.downedPlantBoss ? 20 : 40) : (NPC.downedPlantBoss ? 15 : 30);
            int 生命冷却时间 = Main.expertMode ? 20 : 10;
            int 魔法冷却时间 = Main.expertMode ? 15 : 10;
            if (生命)
            {
                int 秒数 = 60;
                秒数--;
                if (重置) { 生命冷却时间 = Main.expertMode ? 20 : 10; }
                if (秒数 <= 0 && 生命冷却时间 > 0)
                {
                    秒数 = 60;
                    生命冷却时间 -= 秒数 / 60;
                }
                return 生命冷却时间;
            }
            else if (魔法)
            {
                int 秒数 = 60;
                秒数--;
                if (重置) { 魔法冷却时间 = Main.expertMode ? 15 : 10; }
                if (秒数 <= 0 && 魔法冷却时间 > 0)
                {
                    秒数 = 60;
                    魔法冷却时间 -= 秒数 / 60;
                }
                return 魔法冷却时间;
            }
            else if (!生命 && !魔法)
            {
                int 秒数 = 60;
                秒数--;
                if (重置) { 共冷却时间 = Main.expertMode ? (NPC.downedPlantBoss ? 20 : 40) : (NPC.downedPlantBoss ? 15 : 30); }
                if (秒数 <= 0 && 共冷却时间 > 0)
                {
                    秒数 = 60;
                    共冷却时间 -= 秒数 / 60;
                }
                return 共冷却时间;
            }
            return int.MaxValue;
        }
        private bool 冷却时间结束(bool 生命, bool 魔法)
        {
            if (生命) { return 冷却时间开始(true, false) == 0; }
            else if (魔法) { return 冷却时间开始(false, true) == 0; }
            else if (!生命 && !魔法) { return 冷却时间开始(false, false) == 0; }
            return false;
        }
        private void 免疫Debuff(Player player)
        {
            player.buffImmune[BuffID.Wet] = true;
            player.buffImmune[BuffID.Slow] = true;
            player.buffImmune[BuffID.Weak] = true;
            player.buffImmune[BuffID.Dazed] = true;
            player.buffImmune[BuffID.Venom] = true;
            player.buffImmune[BuffID.Ichor] = true;
            player.buffImmune[BuffID.Cursed] = true;
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.Slimed] = true;
            player.buffImmune[BuffID.Stinky] = true;
            player.buffImmune[BuffID.Stoned] = true;
            player.buffImmune[BuffID.Webbed] = true;
            player.buffImmune[BuffID.Burning] = true;
            player.buffImmune[BuffID.Chilled] = true;
            player.buffImmune[BuffID.Blackout] = true;
            player.buffImmune[BuffID.Bleeding] = true;
            player.buffImmune[BuffID.Confused] = true;
            player.buffImmune[BuffID.Darkness] = true;
            player.buffImmune[BuffID.OgreSpit] = true;
            player.buffImmune[BuffID.Poisoned] = true;
            player.buffImmune[BuffID.Silenced] = true;
            player.buffImmune[BuffID.Horrified] = true;
            player.buffImmune[BuffID.MoonLeech] = true;
            player.buffImmune[BuffID.SugarRush] = true;
            player.buffImmune[BuffID.TheTongue] = true;
            player.buffImmune[BuffID.IceBarrier] = true;
            player.buffImmune[BuffID.NoBuilding] = true;
            player.buffImmune[BuffID.Obstructed] = true;
            player.buffImmune[BuffID.WindPushed] = true;
            player.buffImmune[BuffID.BoneJavelin] = true;
            player.buffImmune[BuffID.BrokenArmor] = true;
            player.buffImmune[BuffID.Electrified] = true;
            player.buffImmune[BuffID.ShadowFlame] = true;
            player.buffImmune[BuffID.Suffocation] = true;
            player.buffImmune[BuffID.ManaSickness] = true;
            player.buffImmune[BuffID.VortexDebuff] = true;
            player.buffImmune[BuffID.CursedInferno] = true;
            player.buffImmune[BuffID.WitheredArmor] = true;
            player.buffImmune[BuffID.PotionSickness] = true;
            player.buffImmune[BuffID.WitheredWeapon] = true;
            player.buffImmune[BuffID.DryadsWardDebuff] = true;
            player.buffImmune[ModContent.BuffType<DebuffGreenLight>()] = true;
            player.buffImmune[ModContent.BuffType<DebuffSunsetBlackFire>()] = true;
            player.buffImmune[ModContent.BuffType<DebuffFourHeavyBlocking>()] = true;
        }
        private void 加成(Player player, bool hideVisual)
        {
            player.swimTime = 10;
            player.wingTime = 10;
            player.jumpBoost = true;
            player.moveSpeed += 0.9f;
            player.waterWalk2 = true;
            player.maxRunSpeed *= 23.87f;
            player.fishingSkill += 100;
            player.maxFallSpeed -= 1f;
            player.jumpSpeedBoost += 5f;
            player.AddBuff(BuffID.LeafCrystal, 1);
            player.AddBuff(BuffID.StardustGuardianMinion, 1);
            player.AddBuff(ModContent.BuffType<DebuffBendingMagnets>(), 10);
            player.GetModPlayer<DisorderUnderstarPlayer>().装备_无序我于万物之中 = true;
            if (player.statLife < 200 && player.statMana < 20 && 冷却时间结束(false, false))
            {
                player.statLife += 666;
                player.statMana += 66;
                player.HealEffect(666);
                冷却时间开始(false, false, true);
            }
            else if (player.statMana < 288 && 冷却时间结束(false, true))
            {
                player.statLife += 388;
                player.statLifeMax += 888;
                player.HealEffect(388);
                冷却时间开始(false, true, true);
            }
            else if (player.statLife < 2888 && 冷却时间结束(true, false))
            {
                player.statMana += 88;
                player.statManaMax += 388;
                冷却时间开始(true, false, true);
            }
            else { player.moveSpeed += 0.9f; }
            if (player.statLife < player.statLifeMax2 / 3) { player.AddBuff(BuffID.IceBarrier, 30); }
            else
            {
                player.AddBuff(ModContent.BuffType<DebuffChaosTheory>(), 10);
                player.AddBuff(ModContent.BuffType<BuffBlessingMoment>(), 10);
            }
            if (hideVisual)
            {
                for (int i = 0; i < 1; i++)
                {
                    Dust.NewDustDirect(player.position, player.width, player.height, MyDustId.WhiteLingering, -player.velocity.X * 0.5f,
                        -player.velocity.Y * 0.5f, 100, Color.White, 1.0f);
                }
            }
        }
    }
}