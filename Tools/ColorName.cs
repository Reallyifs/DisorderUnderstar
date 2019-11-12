using System;
using Terraria.ModLoader;
using System.Collections.Generic;
namespace DisorderUnderstar.Tools
{
    public class ColorName
    {
        #region 主类替换
        public static string 魔法替换(string 名称, bool 武器)
        {
            if (武器) { return "[c/FF00FF:" + 名称 + "]"; }
            else { return "[c/0000FF:" + 名称 + "]"; }
        }
        public static string 近战替换(string 名称)
        {
            return "[c/FF8000:" + 名称 + "]";
        }
        public static string 远程替换(string 名称)
        {
            return "[c/00007F:" + 名称 + "]";
        }
        public static string 召唤替换(string 名称)
        {
            return "[c/00FFFF:" + 名称 + "]";
        }
        public static string 投掷替换(string 名称)
        {
            return "[c/7F7F7F:" + 名称 + "]";
        }
        public static string 生命替换(string 名称)
        {
            return "[c/FF0000:" + 名称 + "]";
        }
        #endregion
        public static string Buff替换(string 名称, bool Buff)
        {
            if (Buff) { return "[c/BFBFBF:" + 名称 + "]"; }
            else { return "[c/3F3F3F:" + 名称 + "]"; }
        }
        public static string 所有类替换(string 名称)
        {
            return "[c/000000:" + 名称 + "]";
        }
        public static string 叶绿替换(string 名称)
        {
            return "[c/00FF00:" + 名称 + "]";
        }
        public static string 耐力()
        {
            return "[c/5E5E5E:耐力]";
        }
    }
}