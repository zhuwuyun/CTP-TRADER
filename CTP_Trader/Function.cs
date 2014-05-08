using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTP_FUNCTION
{
    public static class Function
    {
        /// <summary>
        /// 四舍五入
        /// </summary>
        /// <param name="d">输入字符</param>
        /// <param name="pointBits">保留小数位</param>
        /// <returns>四舍五入的结果</returns>
        public static double GetRoundNum(object d, int pointBits)
        {
            return Math.Round((double)d, pointBits, MidpointRounding.AwayFromZero);
        }

    }
}
