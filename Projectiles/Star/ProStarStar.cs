﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using DisorderUnderstar.Utils;
using Microsoft.Xna.Framework;
namespace DisorderUnderstar.Projectiles.Star
{
    public class ProStarStar : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star-星星");
        }
        public override void SetDefaults()
        {
            projectile.alpha = 0;
            projectile.light = 0.7f;
            projectile.magic = true;
            projectile.scale = 1f;
            projectile.width = 18;
            projectile.height = 18;
            projectile.aiStyle = 471;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.timeLeft = 300;
            projectile.knockBack = 1f;
            projectile.penetrate = -1;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            {
                if (projectile.timeLeft < 297)
                {
                    Dust dust = Dust.NewDustDirect
                        (projectile.position, projectile.width, projectile.height,
                        MyDustId.BlueCircle, 0f, 0f, 100,
                        Color.Blue, 1f);
                    dust.noGravity = true;
                    dust.noLight = false;
                }
                if (projectile.timeLeft < 200)
                {
                    Dust dust = Dust.NewDustDirect
                        (projectile.position, projectile.width, projectile.height,
                        MyDustId.GreenFXPowder, 0f, 0f, 100,
                        Color.Green, 1f);
                    dust.noGravity = true;
                    dust.noLight = false;
                }
                if (projectile.timeLeft < 100)
                {
                    Dust dust = Dust.NewDustDirect
                        (projectile.position, projectile.width, projectile.height,
                        MyDustId.YellowFx, 0f, 0f, 100,
                        Color.Yellow, 1f);
                    dust.noGravity = true;
                    dust.noLight = false;
                }
                if (projectile.timeLeft < 10)
                {
                    Dust dust = Dust.NewDustDirect
                        (projectile.position, projectile.width, projectile.height,
                        MyDustId.RedLight, 0f, 0f, 100,
                        Color.Red, 1f);
                    dust.noGravity = true;
                    dust.noLight = false;
                }
            }
            {
                Player player = Main.player[projectile.owner];
                if (projectile.timeLeft < 297)
                {
                    NPC tar = null;
                    float disMAX = 500f;
                    foreach (NPC npc in Main.npc)
                    {
                        // 如果npc活着且敌对
                        if (npc.active && !npc.friendly && npc.type != NPCID.TargetDummy)
                        {
                            // 计算与玩家的距离
                            float dis = Vector2.Distance(npc.Center, player.Center);
                            // 如果npc距离比当前最大距离小
                            if (dis <= disMAX)
                            {
                                // 就把最大距离设置为npc和玩家的距离
                                // 并且暂时选取这个npc为距离最近npc
                                disMAX = dis;
                                tar = npc;
                            }
                        }
                    }
                    // 如果找到符合条件的npc
                    if (tar != null)
                    {
                        // 计算朝向目标的向量
                        Vector2 tarVEC = tar.Center - projectile.Center;
                        tarVEC.Normalize();
                        // 目标向量是朝向目标的大小为20的向量
                        tarVEC *= 20f;
                        // 声明一个float变量，并随之减小
                        float nVEC = 30f;
                        if (nVEC <= 30f)
                            nVEC -= 0.1f;
                        // 朝向npc的单位向量 * nVEC + 3.33%偏移量
                        projectile.velocity =
                            (projectile.velocity * nVEC + tarVEC) / (nVEC + 1f);
                    }
                }
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                Dust dust = Dust.NewDustDirect
                    (projectile.position, projectile.width, projectile.height, 
                    MyDustId.YellowGoldenFire, 0f, 0f, 100,
                    Color.Yellow, 3f);
                dust.noGravity = true;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 600);
            target.AddBuff(BuffID.Confused, damage * 5);
            target.AddBuff(BuffID.Venom, 600);
            target.AddBuff(BuffID.Frozen, damage);
        }
    }
}
