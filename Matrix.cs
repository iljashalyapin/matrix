using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Матрицы
{
    class Matrix
    {
        private List <List<double>> list;
        public Matrix(List <List<double>> l) 
        {
            list = l;
        }
        public void Show()
        {
            for (int i = 0; i < list.Count; i++) 
            {
                for (int j = 0; j < list[i].Count; j++) 
                {
                    Console.Write(Math.Round(list[i][j], 3));
                    Console.Write("\t");
                }
                Console.Write("\n");
            }
        }
        public void Add_Str(List<double> l, int pos) 
        {
            list.Insert(pos, l);
        }
        public int Size()
        {
            return list.Count();
        }
        public int Size(int i)
        {
            return list[i].Count();
        }
        public double Get_El(int index1, int index2)
        {
            return list[index1][index2];
        }
        public void Set_El(int index1, int index2, double count)
        {
            list[index1][index2] = count;
        }
        public void Add_Col(List<double> l, int pos)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Insert(pos, l[i]);
            }
        }
        
    }
}
