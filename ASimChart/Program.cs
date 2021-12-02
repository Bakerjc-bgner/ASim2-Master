using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using OutputModel;
using OutputModel.FileRead;

namespace ASimChart
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form3());
            //Application.Run(new Form2());
            ////Application.Run(new RealChart());

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //OutputReader outputReader = new OutputReader(@"D:\Users\DELL\Desktop\文件\2 项目\南航项目ASim\IEA-15-240-RWT-Monopile.out", true);

            //outputReader.fileRead();



            //string s = "WindMotions.windVel[0].V2";

            //VisiableOutput res = outputReader.GetOutput(s);
            //if(res != null)
            //{
            //    foreach(string t in res.data)
            //    {
            //        Console.WriteLine(t);
            //        Console.WriteLine(Convert.ToDouble(t));
            //    }
            //}


            //打印测试
            //for (int i = 0; i < num; i++)
            //{
            //    if (p[i].unit == "INVALID")
            //        continue;
            //    Console.WriteLine(p[i].title + "    " + p[i].unit);
            //    foreach (double j in p[i].data)
            //        Console.Write(j + "  ");
            //    Console.WriteLine();
            //    Console.WriteLine();
            //    
            //}


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Outputs_oneTimeStep output = new Outputs_oneTimeStep();
            //Assembly assembly = Assembly.Load("OutputModel");
            //Type t = assembly.GetType("OutputModel.Outputs_oneTimeStep");

            //foreach (FieldInfo item in t.GetFields())
            //{
            //    string valName = item.Name;
            //    object tmp = item.GetValue(output);
            //    Type t2 = assembly.GetType(item.FieldType.ToString());
            //    Console.WriteLine(t2.GetProperty("showName").GetValue(tmp).ToString());
            //    //foreach (FieldInfo item2 in t2.GetFields())
            //    //{
            //    //    Console.WriteLine(item2);
            //    //}
            //}

            //OutputModel.BladeOutputs output = new OutputModel.BladeOutputs();

            //Assembly assembly = Assembly.Load("OutputModel");
            ////获取一级类
            //Type t = assembly.GetType("OutputModel.BladeOutputs");

            ////字段列表
            //FieldInfo[] items = t.GetFields();
            //FieldInfo item = items[2];
            ////PropertyInfo[] items = t.GetProperties();

            //Type t2 = (item.FieldType.GetElementType() == null) ? item.FieldType : item.FieldType.GetElementType();

            ////获取实例化对象的某字段对象
            //object[] temp = new object[1];
            //if(item.FieldType.GetElementType() == null)
            //{
            //    temp[0] = item.GetValue(output);
            //}
            //else
            //{
            //    temp[0] = ((object[])item.GetValue(output))[0];
            //}

            ////获取二级类


            ////一级类中某字段对象 对应的 二级类中某一属性值
            //Console.WriteLine(t2.GetProperty("showName").GetValue(temp[0]).ToString());


            ////FieldInfo[] items2 = t2.GetFields();
            ////Console.WriteLine(items2[0].Name);

            ////foreach (FieldInfo item in t.GetFields())
            ////{
            ////    Console.WriteLine(item.Name);
            ////    Type t2 = assembly.GetType("OutputModel."+ item.Name);
            ////    foreach (FieldInfo item2 in t2.GetFields())
            ////    {
            ////        Console.WriteLine(item2);
            ////    }
            ////}

            ////Console.WriteLine(GetType().GetField(str).GetValue(this).ToString());



            ////string str = "spp";
            ////public string spp = "very good";

            ////Console.WriteLine("*************************");
            ////Console.WriteLine("*************************");

            ////string str = "spp";
            ////test test = new test();
            ////Type t = typeof(test);
            ////FieldInfo item = t.GetField(str);
            ////Console.WriteLine(item.GetValue(test).ToString());


        }
    }

}
