using System;
using System.Collections.Generic;
using System.Text;

namespace ASimInterfaces
{
    public class VisibleMatrix : VisibleObject
    {
        public VisibleMatrix() : base() { }
        public VisibleMatrix(string name,int n) : base(name,n) { }
        public double[,] Matrix = new double[6, 6];
        public bool setValue(double[,] VM)//给矩阵赋值
        {

            if (VM.GetLength(0) != 6 || VM.GetLength(1) != 6)
            {
                return false;
            }
            this.Matrix = VM;
            return true;
        }
        public IEnumerable<double[,]> Children//返回矩阵的枚举变量
        {
            get {
                yield return this.Matrix;
            }
        }
        public double[,] getValue()//直接返回矩阵
        {
            return this.Matrix;
        }
    }
}
