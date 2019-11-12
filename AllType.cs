using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar
{
    public class AllType
    {
        public static byte 随机数(int 最小值 = 100, int 最大值 = 200) => (byte)Main.rand.Next(最小值, 最大值);
    }
}