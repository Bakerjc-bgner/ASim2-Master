using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ASim2
{
    public class ExecuteOpenFst
    { 
        public ExecuteOpenFst()
        {
            this.Copyexe();
            this.WriteBATFile();
            this.Call_OpenFst();
        }
        public string workDir1 = @".\Resources\IEA-15-240-RWT-Monopile\runMe.bat";
        public void WriteBATFile()
        {
           
            if (!File.Exists(workDir1))
            {
                FileStream fs1 = new FileStream(workDir1, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine(".\\openfast_x64.exe IEA-15-240-RWT-Monopile.fst");
                sw.Close();
                fs1.Close();
            }
            else
            {
                FileStream fs = new FileStream(workDir1, FileMode.Open, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(".\\openfast_x64.exe IEA-15-240-RWT-Monopile.fst");
                sr.Close();
                fs.Close();
            }

        } 
        public void Copyexe()
        {
            Byte[] array = Properties.Resources.openfast_x64.ToArray<Byte>();
            FileStream fs = new FileStream(@".\Resources\IEA-15-240-RWT-Monopile\openfast_x64.exe",FileMode.Create);
            fs.Write(array, 0, array.Length);
            fs.Close();
        }
        public void Call_OpenFst()
        {
            /*File.Copy(, @".\Resources\IEA-15-240-RWT-Monopile");*/
            Process proc;
            try
            {
                string targetDir = string.Format(@".\Resources\IEA-15-240-RWT-Monopile");
                proc = new Process();
                proc.StartInfo.WorkingDirectory = targetDir;
                proc.StartInfo.FileName = "runMe.bat";
                //隐藏Shell
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.Start();
                /* proc.WaitForExit();*/
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
