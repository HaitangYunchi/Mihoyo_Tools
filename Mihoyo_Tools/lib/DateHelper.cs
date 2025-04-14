/*----------------------------------------------------------------
 * 版权所有 (c) 2025 HaiTangYunchi  保留所有权利
 * CLR版本：4.0.30319.42000
 * 公司名称：
 * 命名空间：Mihoyo_Tools
 * 唯一标识：689b8be5-b409-4901-b076-f508c96cbf0f
 * 文件名：Date
 * 
 * 创建者：海棠云螭
 * 电子邮箱：haitangyunchi@126.com
 * 创建时间：2025/3/31 16:49:52
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 修改人：
 * 时间：
 * 修改说明：
 *
 * 版本：V1.0.1
 *----------------------------------------------------------------*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mihoyo_Tools.lib
{
    class DateHelper
    {
        public static class ChinaDate
        {
            private static ChineseLunisolarCalendar china = new ChineseLunisolarCalendar();
            private static Hashtable gHoliday = new Hashtable();
            private static Hashtable nHoliday = new Hashtable();
            private static string[] JQ = { "小寒", "大寒", "立春", "雨水", "惊蛰", "春分", "清明", "谷雨", "立夏", "小满", "芒种", "夏至", "小暑", "大暑", "立秋", "处暑", "白露", "秋分", "寒露", "霜降", "立冬", "小雪", "大雪", "冬至" };
            private static int[] JQData = { 0, 21208, 42467, 63836, 85337, 107014, 128867, 150921, 173149, 195551, 218072, 240693, 263343, 285989, 308563, 331033, 353350, 375494, 397447, 419210, 440795, 462224, 483532, 504758 };
            static ChinaDate()
            {
                //公历节日
                gHoliday.Add("0101", "元旦");
                gHoliday.Add("0214", "情人节");
                gHoliday.Add("0305", "雷锋日");
                gHoliday.Add("0308", "妇女节");
                gHoliday.Add("0312", "植树节");
                gHoliday.Add("0315", "消权日");
                gHoliday.Add("0401", "愚人节");
                gHoliday.Add("0501", "劳动节");
                gHoliday.Add("0504", "青年节");
                gHoliday.Add("0601", "儿童节");
                gHoliday.Add("0701", "建党节");
                gHoliday.Add("0707", "七七事变");
                gHoliday.Add("0801", "建军节");
                gHoliday.Add("0910", "教师节");
                gHoliday.Add("0918", "九一八事变");
                gHoliday.Add("1001", "国庆节");
                gHoliday.Add("1224", "平安夜");
                gHoliday.Add("1225", "圣诞节");

                //农历节日
                nHoliday.Add("0101", "春节");
                nHoliday.Add("0115", "元宵节");
                nHoliday.Add("0202", "龙抬头");
                nHoliday.Add("0505", "端午节");
                nHoliday.Add("0707", "七夕");
                nHoliday.Add("0715", "中元节");
                nHoliday.Add("0815", "中秋节");
                nHoliday.Add("0909", "重阳节");
                nHoliday.Add("1208", "腊八节");
                nHoliday.Add("1223", "北方小年");
                nHoliday.Add("1224", "南方小年");
            }

            /// <summary>
            /// 获取农历
            /// </summary>
            /// <param name="dt"></param>
            /// <returns></returns>
            public static string GetChinaDate(DateTime dt)
            {
                if (dt > china.MaxSupportedDateTime || dt < china.MinSupportedDateTime)
                {
                    //日期范围：1901 年 2 月 19 日 - 2101 年 1 月 28 日
                    throw new Exception(string.Format("日期超出范围！必须在{0}到{1}之间！", china.MinSupportedDateTime.ToString("yyyy-MM-dd"), china.MaxSupportedDateTime.ToString("yyyy-MM-dd")));
                }
                string str = string.Format("{0} {1}{2}", GetYear(dt), GetMonth(dt), GetDay(dt));
                string strJQ = GetSolarTerm(dt);
                if (strJQ != "")
                {
                    str += " (" + strJQ + ")";
                }
                string strHoliday = GetHoliday(dt);
                if (strHoliday != "")
                {
                    str += " " + strHoliday;
                }
                string strChinaHoliday = GetChinaHoliday(dt);
                if (strChinaHoliday != "")
                {
                    str += " " + strChinaHoliday;
                }

                return str;
            }

            /// <summary>
            /// 获取农历年份
            /// </summary>
            /// <param name="dt"></param>
            /// <returns></returns>
            public static string GetYear(DateTime dt)
            {
                int yearIndex = china.GetSexagenaryYear(dt);
                string year_HeavenlyStems = " 甲乙丙丁戊己庚辛壬癸";
                string year_EarthlyBranches = " 子丑寅卯辰巳午未申酉戌亥";
                string year_Zodiac = " 鼠牛虎兔龙蛇马羊猴鸡狗猪";
                int year = china.GetYear(dt);
                int HeavenlyStems = china.GetCelestialStem(yearIndex);
                int EarthlyBranches = china.GetTerrestrialBranch(yearIndex);

                string str = string.Format("{2}{3}({1}){0}", '年', year_Zodiac[EarthlyBranches], year_HeavenlyStems[HeavenlyStems], year_EarthlyBranches[EarthlyBranches]);
                return str;
            }

            /// <summary>
            /// 获取农历月份
            /// </summary>
            /// <param name="dt"></param>
            /// <returns></returns>
            public static string GetMonth(DateTime dt)
            {
                int year = china.GetYear(dt);
                int iMonth = china.GetMonth(dt);
                int leapMonth = china.GetLeapMonth(year);
                bool isLeapMonth = iMonth == leapMonth;
                if (leapMonth != 0 && iMonth >= leapMonth)
                {
                    iMonth--;
                }

                string szText = "正二三四五六七八九十";
                string strMonth = isLeapMonth ? "闰" : "";
                if (iMonth <= 10)
                {
                    strMonth += szText.Substring(iMonth - 1, 1);
                }
                else if (iMonth == 11)
                {
                    strMonth += "冬";
                }
                else
                {
                    strMonth += "腊";
                }
                return strMonth + "月";
            }

            /// <summary>
            /// 获取农历日期
            /// </summary>
            /// <param name="dt"></param>
            /// <returns></returns>
            public static string GetDay(DateTime dt)
            {
                int iDay = china.GetDayOfMonth(dt);
                string szText1 = "初十廿三";
                string szText2 = "一二三四五六七八九十";
                string strDay;
                if (iDay == 20)
                {
                    strDay = "二十";
                }
                else if (iDay == 30)
                {
                    strDay = "三十";
                }
                else
                {
                    strDay = szText1.Substring((iDay - 1) / 10, 1);
                    strDay = strDay + szText2.Substring((iDay - 1) % 10, 1);
                }
                return strDay;
            }

            /// <summary>
            /// 获取节气
            /// </summary>
            /// <param name="dt"></param>
            /// <returns></returns>
            public static string GetSolarTerm(DateTime dt)
            {
                DateTime dtBase = new DateTime(1900, 1, 6, 2, 5, 0);
                DateTime dtNew;
                double num;
                int y;
                string strReturn = "";

                y = dt.Year;
                for (int i = 1; i <= 24; i++)
                {
                    num = 525948.76 * (y - 1900) + JQData[i - 1];
                    dtNew = dtBase.AddMinutes(num);
                    if (dtNew.DayOfYear == dt.DayOfYear)
                    {
                        strReturn = JQ[i - 1];
                    }
                }

                return strReturn;
            }

            /// <summary>
            /// 获取公历节日
            /// </summary>
            /// <param name="dt"></param>
            /// <returns></returns>
            public static string GetHoliday(DateTime dt)
            {
                string strReturn = "";
                object g = gHoliday[dt.Month.ToString("00") + dt.Day.ToString("00")];
                if (g != null)
                {
                    strReturn = g.ToString();
                }

                return strReturn;
            }

            /// <summary>
            /// 获取农历节日
            /// </summary>
            /// <param name="dt"></param>
            /// <returns></returns>
            public static string GetChinaHoliday(DateTime dt)
            {
                string strReturn = "";
                int year = china.GetYear(dt);
                int iMonth = china.GetMonth(dt);
                int leapMonth = china.GetLeapMonth(year);
                int iDay = china.GetDayOfMonth(dt);
                if (china.GetDayOfYear(dt) == china.GetDaysInYear(year))
                {
                    strReturn = "除夕";
                }
                else if (leapMonth != iMonth)
                {
                    if (leapMonth != 0 && iMonth >= leapMonth)
                    {
                        iMonth--;
                    }
                    object n = nHoliday[iMonth.ToString("00") + iDay.ToString("00")];
                    if (n != null)
                    {
                        if (strReturn == "")
                        {
                            strReturn = n.ToString();
                        }
                        else
                        {
                            strReturn += " " + n.ToString();
                        }
                    }
                }

                return strReturn;
            }
        }
    }
}
