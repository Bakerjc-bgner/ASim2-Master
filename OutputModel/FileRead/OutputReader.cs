using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputModel.FileRead
{
    public class OutputReader
    {
        public string path;
        public int curLine = 0;
        public bool isLinear = true;
        public Hashtable outputTable = new Hashtable();
        public Hashtable fullNameTable = new Hashtable();


        public OutputReader(string _path, bool _isLinear)
        {
            this.path = _path;
            this.isLinear = _isLinear;
            this.fullNameHash(this.isLinear);
        }

        public void fullNameHash(bool isLinear)
        {
            string[] contents;
            //outputVar1是线性输出，outputVar2是非线性输出
            if (isLinear)
                contents = Properties.Resources.outputVar1.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            else
                contents = Properties.Resources.outputVar2.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            for (int i = 0; i < contents.Length; i++)
            {
                try
                {
                    string[] tmp = contents[i].Split('\t');
                    this.fullNameTable.Add(tmp[1], tmp[0]);
                }
                catch (Exception e) { }
            }
        }
        
        public bool fileRead()
        {
            //string path = @"D:\Users\DELL\Desktop\文件\2 项目\南航项目ASim\IEA-15-240-RWT-Monopile.out";

            if (!File.Exists(this.path)) return false;

            string[] contents = File.ReadAllLines(this.path);

            string[] name = contents[6].Split('	');

            int num = name.Length; //获取文件中变量个数

            //获取变量名和单位
            if (this.curLine < 8)
            {
                for (int i = 0; i < num; i++)
                {
                    VisiableOutput output = new VisiableOutput(contents[6].Split('	')[i], contents[7].Split('	')[i]);
                    output.data = new ArrayList();
                    if (output.units == "INVALID" || this.outputTable.ContainsKey(output.name)) continue;
                    this.outputTable.Add(output.name, output);
                }
            }

            //获取data
            for (int j = (this.curLine > 8 ? this.curLine : 8); j < contents.Length; j++)
            {
                string[] temp = contents[j].Split('	');

                try
                {
                    for (int i = 0; i < num; i++)
                    {
                        if (this.outputTable.ContainsKey(name[i]))
                            ((VisiableOutput)this.outputTable[name[i]]).data.Add(Convert.ToDouble(temp[i]));
                    }
                }
                catch (Exception e) { }
            }

            this.curLine = contents.Length;
            
            return true;
        }

        public VisiableOutput GetOutput(string fullname)
        {
            string name = null;
            VisiableOutput res = null;
            if (fullNameTable.ContainsKey(fullname))
                name = (string)fullNameTable[fullname];

            if(name != null && outputTable.ContainsKey(name))
                res = (VisiableOutput)outputTable[name];

            return res;
        }
    }
}