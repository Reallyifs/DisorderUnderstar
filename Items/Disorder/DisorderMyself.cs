﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Items.Disorder
{
    [AutoloadEquip(EquipType.Wings)]
    public class DisorderMyself : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("无序·我于万物之中");
            Tooltip.SetDefault("【无序-Disorder】\n" +
                "“万物于我，我于万物之中。”\n" +
                "“万物即我，我于我之中。”\n" +
                "“可恨的自己，可爱的自己。”\n" +
                "          ——scp-3999\n" +
                "-\n" +
                "你会获得一堆实际上我写了但是没有作用的Buff\n" +
                "（我真的写了护盾）\n" +
                "-\n" +
                "当生命低于2888时，最大魔法增加388，临时魔法增加88\n" +
                "当魔法低于288时，最大生命值增加888，临时生命值增加388\n" +
                "当生命低于200、魔法低于20时，临时生命增加666，临时魔法增加66\n" +
                "如果以上条件都不满足，移动速度乘以8\n" +
                "-\n" +
                "当生命低于生命上限的三分之一时，给予你持续30秒的“冰障”Buff\n" +
                "如果以上条件不满足，给予你“祝福时刻”Buff\n" +
                "同时给予你“混乱理论”Debuff\n" +
                "-\n" +
                "无论你在何种状态，给予你“偏转磁极”Debuff\n" +
                "-\n" +
                "（不全）\n" +
                "-");
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
            // 免疫效果
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
                /*
                player.buffImmune[mod.BuffType("DebuffGreenLight")] = true;
                player.buffImmune[mod.BuffType("DebuffSunsetBlackFire")] = true;
                player.buffImmune[mod.BuffType("DebuffFourHeavyBlocking")]= true;
                */
            }
            // 伤害暴击
            {
                player.attackCD -= 1;
                player.manaCost -= 0.9f;
                player.minionKB += 0.5f;
                player.magicCrit += 88;
                player.meleeCrit += 88;
                player.maxMinions += 40;
                player.meleeSpeed += 0.5f;
                player.rangedCrit += 88;
                player.thrownCrit += 88;
                player.crystalLeaf = true;
                player.magicDamage *= 23.87f;
                player.meleeDamage *= 23.87f;
                player.minionDamage *= 23.87f;
                player.rangedDamage *= 23.87f;
                player.thrownDamage *= 23.87f;
                player.stardustMinion = true;
                player.shroomiteStealth = true;
                player.vortexStealthActive = true;
            }
            // 生命魔法
            {
                player.lifeForce = true;
                player.lifeRegen += player.dpsDamage;
                player.manaRegen = player.dpsDamage;
                player.manaFlower = true;
                player.shinyStone = true;
                player.crimsonRegen = true;
                player.statLifeMax2 += 1500;
                player.statManaMax2 += 750;
            }
            // 各种免疫
            {
                player.noFallDmg = true;
                player.lavaImmune = true;
                player.noKnockback = true;
            }
            // 如果语句
            {
                {
                    if (player.statLife < 200)
                    {
                        if (player.statMana < 20)
                        {
                            player.statLife += 666;
                            player.statMana += 66;
                        }
                    }
                    else if (player.statMana < 288)
                    {
                        player.statLife += 388;
                        player.statLifeMax += 888;
                    }
                    else if (player.statLife < 2888)
                    {
                        player.statMana += 88;
                        player.statManaMax += 388;
                    }
                    else
                    {
                    /*
                        player.moveSpeed += 1f;
                        player.moveSpeed += 1f;
                        player.moveSpeed += 1f;
                        player.moveSpeed += 1f;
                        player.moveSpeed += 1f;
                        player.moveSpeed += 1f;
                        player.moveSpeed += 1f;
                        player.moveSpeed += 1f;
                    */
                    }
                }
                {
                    if (player.statLife < player.statLifeMax2 / 3)
                    {
                        player.AddBuff(BuffID.IceBarrier, 30);
                    }
                    else
                    {
                        player.AddBuff(mod.BuffType("BuffBlessingMoment"), 10);
                        player.AddBuff(mod.BuffType("DebuffChaosTheory"), 10);
                    }
                }
                {
                    player.AddBuff(mod.BuffType("DebuffBendingMagnets"), 10);
                }
                if (hideVisual == true)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        Dust.NewDustDirect
                            (player.position, player.width, player.height,
                            MyDustId.WhiteLingering,
                            -player.velocity.X * 0.5f, -player.velocity.Y * 0.5f, 100,
                            Color.White, 1.0f);
                    }
                }
            }
            // 懵逼加成
            {
                // 叶绿水晶？
                {
                    //player.AddBuff(mod.BuffType("MODCrystalLeaf"), 1);
                }
                // 星辰守卫？
                {
                    //player.AddBuff(mod.BuffType("MODStardustGuardianMinion"), 1);
                }
                // 其他加成
                {
                    player.swimTime = 10;
                    player.wingTime = 10;
                    player.jumpBoost = true;
                    player.moveSpeed *= 23.87f;
                    player.waterWalk2 = true;
                    player.CollectTaxes();
                    player.fishingSkill += 100;
                    player.maxFallSpeed -= 1f;
                    player.jumpSpeedBoost += 8.5f;
                }
            }
        }
        public override void VerticalWingSpeeds
            (Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier,
            ref float constantAscend)
        {
            ascentWhenFalling = 1.5f;
            ascentWhenRising = 0.75f;
            maxAscentMultiplier = 5f;
            maxCanAscendMultiplier = 10f;
            constantAscend = 0.5f;
        }
        public override void HorizontalWingSpeeds
            (Player player, ref float speed, ref float acceleration)
        {
            speed = 50f;
            acceleration *= 5f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(mod, "DisorderFourtype", 1);
            recipe1.AddIngredient(mod, "DisorderOmnipotence", 1);
            recipe1.AddIngredient(mod, "DisorderCross", 1);
            recipe1.AddIngredient(mod, "GlitchSIO", 1);
            recipe1.AddIngredient(mod, "DisorderBar", 33);
            recipe1.AddIngredient(mod, "LikeLifeLine", 10);
            recipe1.AddIngredient(mod, "StartStarsStory", 10);
            recipe1.AddIngredient(ItemID.LifeCrystal, 50);
            recipe1.AddIngredient(ItemID.ManaCrystal, 50);
            recipe1.AddTile(TileID.LunarCraftingStation);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}