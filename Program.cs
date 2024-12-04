using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Матрицы
{
    class Program
    {
        static void Full_list(List<double> l) 
        {
            Random rand = new Random();
            double d = Math.Round(rand.NextDouble() * 10, 3);
            Thread.Sleep(10);
            l.Add(d);
        }

        static void Full_list(List<double> l, params double[] mas)
        {
            foreach (double d in mas)
            {
                l.Add(d);
            }      
        }

        static double Max(Matrix m, int _i) 
        {
            double d = m.Get_El(_i, 0);
            for (int j = 0; j < m.Size(_i); j++) 
            {
                if (m.Get_El(_i, j) > d) 
                {
                    d = m.Get_El(_i, j);
                }
            }
            return d;
        }

        static Matrix MUL(Matrix m1, Matrix m2)
        {
            List<List<double>> list1 = new List<List<double>>();
            for (int i = 0; i < m1.Size(); i++)
            {
                List<double> list2 = new List<double>();
                for (int j = 0; j < m2.Size(i); j++)
                {
                    Full_list(list2);
                }
                list1.Add(list2);
            }
            Matrix matrix = new Matrix(list1);
            for (int i = 0; i < m1.Size(); i++)
            {
                for (int j = 0; j < m2.Size(i); j++)
                {
                    double b = 0;
                    for (int r = 0; r < m2.Size(); r++)
                    {
                        double d = m1.Get_El(i, r) * m2.Get_El(r, j);
                        b += d;
                    }
                    matrix.Set_El(i, j, b);
                }
            } 
            return matrix;
        }

        static void Main(string[] args)
        {
            List<List<double>> list1 = new List<List<double>>();
            for (int i = 0; i < 10; i++) 
            {
                List<double> list2 = new List<double>();
                for (int j = 0; j < 10; j++) 
                {
                    Full_list(list2);
                }
                list1.Add(list2);
            }           
            Matrix matrix = new Matrix(list1);
            Console.WriteLine("Первая матрица:");
            matrix.Show();
            List<double> str1 = new List<double>();
            for (int j = 0; j < 10; j++)
            {
                Full_list(str1);
            }          
            matrix.Add_Str(str1, 5);
            matrix.Add_Col(str1, 5);
            Console.WriteLine("");
            Console.WriteLine("Матрица после вставки строки и столбца:");
            matrix.Show();
            List<double> str2 = new List<double>();
            Full_list(str2, 6.89, 7.23, 6, 78, 8.076, 3);
            for (int i = 0; i < matrix.Size(); i++)
            {
                for (int j = 0; j < matrix.Size(i); j++)
                {
                    if (i == j) 
                    {
                        for (int k = 0; k < str2.Count; k++) 
                        {
                            if (matrix.Get_El(i, j) < (str2[k] + 15) && matrix.Get_El(i, j) > (str2[k] - 15)) 
                            {
                                matrix.Set_El(i, j, 0);
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Матрица после замены элементов:");
            matrix.Show();
            for (int i = 0; i < matrix.Size(); i++)
            {
                for (int j = i+1; j < matrix.Size(i); j++)
                {
                    double d = matrix.Get_El(i, j);
                    matrix.Set_El(i, j, matrix.Get_El(j, i));
                    matrix.Set_El(j, i, d);
                }
            }
            Console.WriteLine("Матрица после транспонирования:");
            matrix.Show();
            List<List<double>> list3 = new List<List<double>>();
            for (int i = 0; i < matrix.Size(); i++)
            {
                List<double> list2 = new List<double>();
                for (int j = 0; j < matrix.Size(i); j++)
                {
                    Full_list(list2);
                }
                list3.Add(list2);
            }
            Matrix matrix2 = new Matrix(list3);
            Console.WriteLine("Вторая матрица:");
            matrix2.Show();
            Console.WriteLine("Первая матрица, умноженная на максимумы строк второй матрицы:");
            for (int i = 0; i < matrix.Size(); i++)
            {
                for (int j = 0; j < matrix.Size(i); j++)
                {
                    matrix.Set_El(i, j, matrix.Get_El(i, j)*Max(matrix2, i));
                }
            }
            matrix.Show();
            List<List<double>> list4 = new List<List<double>>(7);
            for (int i = 0; i < 7; i++)
            {
                List<double> list2 = new List<double>(7);
                for (int j = 0; j < 7; j++)
                {
                    Full_list(list2, 0);
                }
                list4.Add(list2);
            }
            Matrix matrix3 = new Matrix(list4);
            int a = 0;
            int b;
            int c = 0;
            int p = 1;
            while (a < 49)
            {
                c++;
                for (b = c-1; b < 7-c+1; b++)
                {
                    matrix3.Set_El(c-1, b, p);
                    p++;
                    a++;
                }
                for (b = c; b < 7-c+1; b++)
                {
                    matrix3.Set_El(b, 7-c, p);
                    p++;
                    a++;
                }
                for (b = 7-c-1; b >= c-1; b--)
                {
                    matrix3.Set_El(7-c, b, p);
                    a++;
                    p++;
                }
                for (b = 7-c-1; b >= c; b--)
                {
                    matrix3.Set_El(b, c-1, p);
                    a++;
                    p++;
                }
            }         
            Console.WriteLine("Спираль- матрица:");
            matrix3.Show();
            Matrix m = MUL(matrix, matrix2);
            Console.WriteLine("Произведение 1 и 2 матрицы:");
            m.Show();  
            Console.WriteLine("Нахождение обратной квадратной матрицы:");
            List<List<double>> list0 = new List<List<double>>();
            for (int i = 0; i < 5; i++)
            {
                List<double> list2 = new List<double>();
                for (int j = 0; j < 5; j++)
                {
                    Full_list(list2);
                }
                list0.Add(list2);
            }
            Matrix mat = new Matrix(list0);
            Console.WriteLine("Исходная матрица:");
            mat.Show();           
            double []arr = new double[5];
            for (int i = 0; i < 5; i++) 
            {
                arr[i] = 0;
            }
            arr[0] = 1;
            List<List<double>> list000 = new List<List<double>>();
            for (int i = 0; i < 5; i++)
            {
                List<double> list2 = new List<double>();             
                for (int j = 0; j < 5; j++)
                {
                    list2.Add(arr[j]);                    
                }
                if (i < 4)
                {
                    double bb = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = bb;
                }
                list000.Add(list2);
            }
            Matrix _mat = new Matrix(list000);
            Console.WriteLine("Единичная матрица:");
            _mat.Show();
            for (int k = 0; k < 5; k++)
            {
                double gg = mat.Get_El(k, k);
                for (int i = 0; i < 5; i++)
                {
                    double d = mat.Get_El(k, i);
                    d /= gg;
                    double _d = _mat.Get_El(k, i);
                    _d /= gg;
                    mat.Set_El(k, i, d);
                    _mat.Set_El(k, i, _d);
                }
                for (int i = k+1; i < 5; i++)
                {                   
                    double gg1 = mat.Get_El(i, k);
                    for (int j = 0; j < 5; j++)
                    {
                        double d = mat.Get_El(i, j);
                        d -= mat.Get_El(k, j) * gg1;
                        double _d = _mat.Get_El(i, j);
                        _d -= _mat.Get_El(k, j) * gg1;
                        mat.Set_El(i, j, d);
                        _mat.Set_El(i, j, _d);
                    }
                }
            }
            Console.WriteLine("Исходная матрица после преобр-ий:");
            mat.Show();
            Console.WriteLine("Единичная матрица после преобр-ий:");
            _mat.Show();
            for (int k = 4; k >= 0; k--)
            {
                for (int i = 0; i <= k - 1; i++)
                {
                    double gg = mat.Get_El(i, k);   
                    for (int j = 0; j < 5; j++)
                    {
                        double d = mat.Get_El(i, j);
                        double kk = mat.Get_El(k, j) *gg;
                        d -= kk;
                        double _d = _mat.Get_El(i, j);
                        kk = _mat.Get_El(k, j) *gg;
                        _d -= kk;
                        mat.Set_El(i, j, d);
                        _mat.Set_El(i, j, _d);
                    }
                }
            }
            Console.WriteLine("Новая единичная матрица:");
            mat.Show();
            Console.WriteLine("Обратная матрица:");
            _mat.Show();
            List<List<double>> list5 = new List<List<double>>(10);
            for (int i = 0; i < 10; i++)
            {
                List<double> list2 = new List<double>(10);
                for (int j = 0; j < 10; j++)
                {
                    Full_list(list2, 0);
                }
                list5.Add(list2);
            }
            Matrix matrix5 = new Matrix(list5);
            int xy;
            Console.WriteLine("Введите х:");
            xy = int.Parse(Console.ReadLine());
            for (int i = 0; i < 10; i++)
            {
                matrix5.Set_El(i, 0, Math.Pow(xy, i));
                matrix5.Set_El(0, i, Math.Pow(xy, i));
            }
            for (int i = 9; i >= 0; i--)
            {
                matrix5.Set_El(i, 9, Math.Pow(xy, 9-i));
                matrix5.Set_El(9, i, Math.Pow(xy, 9 - i));
            }
            Console.WriteLine("Вторая квадратная матрица:");
            matrix5.Show();
            Console.ReadKey();
        }
    }
}
