using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DisorderUnderstar
{
    public class AllType
    {
        public static byte 随机数(int 最小值 = 100, int 最大值 = 200) => (byte)Main.rand.Next(最小值, 最大值);
        public static int[] 月蚀_杀怪分数 = new int[]
        {
            0, // 0
            30, // 1
            90, // 2
            180, // 3
            360, // 4
            720, // 5
            1440, // 6
            2880, // 7
            5760, // 8
            11520, // 9
            23040, // 10
            0, // 休息波
            20, // 11
            40, // 12
            80, // 13
            160, // 14
            320, // 15
            640, // 16
            1280, // 17
            2560, // 18
            5120, // 19
            10240, // 20
            0, // 休息波
            500000000 // 最终波
        };
    }
}