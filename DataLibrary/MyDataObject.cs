using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableLibrary;

namespace DataLibrary
{
    public class MyDataObject
    {
        /// <summary>
        /// 被操作的数据对象
        /// </summary>
        public readonly DataTable dtInfo;
        public String filePath;
        //JSON文件的路径
        public bool hasSaved = true;
        //标记是否存在未保存的更改, true => 无, false => 有
        public Simulation_0 Simulation = new Simulation_0();
        //数据类

        public MyDataObject()
        {
            dtInfo = ReadSQLite.GetAll("Data Source =" + Environment.CurrentDirectory + "/MYDATA.db");
        }
        /// <summary>
        /// </summary>
        /// <param name="fullPath">连接数据库文件的语句</param>
        /// <param name="linkString">连接数据表的语句</param>
        /// <param name="filePath">JSON文件路径</param>
        public MyDataObject(String fullPath, String linkString, String filePath = null)
        {
            dtInfo = ReadSQLite.GetAll(fullPath, linkString);
            this.filePath = filePath;
        }
        /// <summary>
        /// 将数据类保存到JSON字符串中
        /// </summary>
        /// <returns>JSON字符串</returns>
        public String SaveToJson()
        {
            String json = JsonConvert.SerializeObject(Simulation);
            return json;
        }
        /// <summary>
        /// 从JSON字符串中恢复数据类对象
        /// </summary>
        /// <param name="json">JSON字符串</param>
        /// <returns>是否成功恢复</returns>
        public bool JsonToSimulation(String json)
        {
            Simulation = JsonConvert.DeserializeObject<Simulation_0>(json);
            return Simulation != null;
        }
    }
}
