using Terraria;
using Terraria.ModLoader;
using DisorderUnderstar.Tools;
using Microsoft.Xna.Framework;
using DisorderUnderstar.Projectiles.LoadedMod;
namespace DisorderUnderstar
{
    public class LoadedMod
    {
        public class LoadedWtfway
        {
            public static void Wtfway弹幕发射(Player player, Entity victim, float x, float y)
            {
                if (player.GetModPlayer<DisorderUnderstarPlayer>().加载了Wtfway && victim.active && Main.rand.Next(0, 5) < 2)
                {
                    int _0 = Main.rand.Next(3, 7);
                    Vector2 _1 = new Vector2(x, y);
                    Vector2 _2 = Vector2.Normalize(victim.Center - player.Center) * 30;
                    _2.RotatedBy(Main.rand.NextDouble() * 0.3);
                    for (int _3 = 0; _3 < 5; _3++)
                    {
                        Dust.NewDust(_1, victim.width, victim.height, MyDustId.BlueTorch, victim.velocity.X / 3, victim.velocity.Y / 3,
                            Main.rand.Next(10, 50), Color.Blue, Main.rand.NextFloat(0.8f, 1.2f));
                        Dust.NewDust(_1, victim.width, victim.height, MyDustId.BlueParticle, victim.velocity.X / 3, victim.velocity.Y / 3,
                            Main.rand.Next(10, 50), Color.Blue, Main.rand.NextFloat(0.8f, 1.2f));
                    }
                    for (int _4 = 0; _4 < 2; _4++)
                    {
                        Dust.NewDust(player.Center, player.width, player.height, MyDustId.BlueWhiteBubble, player.velocity.X / 3, player.velocity.Y / 3,
                            Main.rand.Next(10, 100), Color.Blue, Main.rand.NextFloat(0.6f, 1.4f));
                    }
                    for (int _5 = 0; _5 < _0; _5++)
                    {
                        Projectile.NewProjectile(player.Center, _2, ModContent.ProjectileType<ProWtfway>(), 24, 2f, player.whoAmI, victim.whoAmI);
                    }
                }
            }
        }
    }
}