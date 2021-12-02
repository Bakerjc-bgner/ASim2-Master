using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TableLibrary
{
    public class Search
    {
        /// <summary>
        /// 通过PPD查找下一级子类的信息
        /// </summary>
        /// <param name="dtInfo">数据表</param>
        /// <param name="PPD">PPD</param>
        /// <returns>该ID的下一级子类对应的数据行组成的数组, 数组长度为 0 即没有子类</returns>
        public static DataRow[] GetChildrenByPPD(DataTable dtInfo, String PPD)
        {
            DataRow[] dts = dtInfo.Select("PPD = '" + PPD + "'");
            return dts;
        }
        /// <summary>
        /// 通过ID查找下一级子类的信息
        /// </summary>
        /// <param name="dtInfo">数据表</param>
        /// <param name="id">ID</param>
        /// <returns>该ID的下一级子类对应的数据行组成的数组, 数组长度为 0 即没有子类</returns>
        public static DataRow[] GetChildrenByID(DataTable dtInfo, int id)
        {
            DataRow[] current = dtInfo.Select("ID = " + id);
            String PPD = current[0].ItemArray[1] as String;
            return GetChildrenByPPD(dtInfo, PPD);
        }
        /// <summary>
        /// 从类名获取ID
        /// </summary>
        /// <param name="name">类名</param>
        /// <returns>ID, 若为null表示无法解析类名</returns>
        public static int? GetIDFromTypeName(String name)
        {
            name += '\n';
            Regex reg = new Regex("_(\\d+)\n");
            Match match = reg.Match(name);
            if (match.Success)
            {
                String id = match.Groups[1].Value;
                return int.Parse(id);
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// 从类名获取CodeName
        /// </summary>
        /// <param name="name">类名</param>
        /// <returns>去除ID后缀的类名, 若输入null, 返回空字符串; 若无ID后缀, 返回原字符串</returns>
        public static String GetCodeNameFromTypeName(String name)
        {
            name += '\n';
            Regex reg = new Regex("_\\d+\n");
            Match match = reg.Match(name);
            if (match.Success)
            {
                return name.Remove(match.Index, match.Value.Length);
            }
            else
            {
                return name.Remove(name.Length - 1, 1);
            }
        }
        public static int GetIDByPD(DataTable dtInfo, String PD)
        {
            DataRow[] current = dtInfo.Select("PD = '" + PD + "'");
            int id = (int)(current[0].ItemArray[0]);
            return id;
        }
        public static String GetTypeByID(DataTable dtInfo, int id)
        {
            DataRow[] current = dtInfo.Select("ID = " + id);
            String type = current[0].ItemArray[3] as String;
            return type;
        }
        public static String[] GetTypesByDataRows(DataRow[] rows)
        {
            String[] types = new String[rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                types[i] = rows[i].ItemArray[3] as String;
            }
            return types;
        }
        public static String GetShowNameByID(DataTable dtInfo, int id)
        {
            DataRow[] current = dtInfo.Select("ID = " + id);
            String showName = current[0].ItemArray[7] as String;
            return showName;
        }
        public static String GetShowUnitByID(DataTable dtInfo, int id)
        {
            DataRow[] current = dtInfo.Select("ID = " + id);
            String unit = current[0].ItemArray[8] as String;
            return unit;
        }
        public static String GetDescriptionByID(DataTable dtInfo, int id)
        {
            DataRow[] current = dtInfo.Select("ID = " + id);
            String description = current[0].ItemArray[10] as String;
            return description.Replace(@"\n", "\n");
        }
        /// <summary>
        /// 从ID获取决定数组长度的关联变量
        /// </summary>
        /// <param name="dtInfo">数据表</param>
        /// <param name="id">ID</param>
        /// <returns>空表示ID对应变量非数组; 负数表示无关联变量; 正数表示长度为定值; 否则为关联变量对应的CodeName</returns>
        public static String GetLengthByID(DataTable dtInfo, int id)
        {
            DataRow[] current = dtInfo.Select("ID = " + id);
            String length = current[0].ItemArray[11] as String;
            return length;
        }
    }
}
