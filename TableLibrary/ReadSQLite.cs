using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace TableLibrary
{
    public class ReadSQLite
    {
        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="queryString">查询语句</param>
        /// <param name="dbConnection">数据表连接</param>
        /// <returns>查询结果</returns>
        public static SQLiteDataReader ExecuteQuery(string queryString, SQLiteConnection dbConnection)
        {
            SQLiteCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = queryString;
            SQLiteDataReader dataReader = dbCommand.ExecuteReader();
            return dataReader;
        }
        /// <summary>
        /// 获取整张数据表
        /// </summary>
        /// <param name="fullPath">连接数据库文件的语句</param>
        /// <param name="linkString">连接数据表的语句</param>
        /// <returns>数据表中所有数据</returns>
        public static DataTable GetAll(string fullPath, string linkString = "SELECT * FROM MYDATA")
        {
            SQLiteConnection sqlconn = new SQLiteConnection(@fullPath);
            sqlconn.Open();
            SQLiteDataAdapter all = new SQLiteDataAdapter(linkString, sqlconn);
            DataTable data = new DataTable();
            all.Fill(data);
            return data;
        }
    }
}
