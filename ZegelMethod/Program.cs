using System;
using static System.Console;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckNormaltipe m = new CheckNormaltipe();
            m.Nv();
            m.Result();
            ReadKey();
        }
    }
    class Advertisement
    {
        static double S = 0.2, b = 0.6;
        public int i, j, n = 4; 
        public double Anew1 = 0, N = 1, pohybka = 0.0001, max;
        public double[] x0 = new double[4];
        public double[] x1 = new double[4];
        public double[,] A = new double[4, 4];
        public double[] B = new double[4];
        public double[,] massA = new double[,] { { 3.3, 12.62 + S, 4.1, 1.9 }, { 3.92, 8.45, 1.78 - S, 1.4 }, { 3.77, 1.21 + S, 8.04, 0.28 }, { 2.21, 3.65 - S, 1.69, 9.99 } }; // your matrix
        public double[] massB = new double[] { -10.55 + b, 12.21, 15.45 - b, -8.35 }; // [0,4] [1,4] and e.t.c
        public double[,] mass1 = new double[4, 4];
    }
    class CheckNormaltipe : Advertisement
    {
        public void Nv()
        {
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    max = massA[i, i];
                    if (max < massA[i, j])
                    {
                        massA[i, i] = massA[i, j];
                        massA[i, j] = max;
                    }
                }
            }
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Write(massA[i, j] + " ");
                }
                WriteLine(massB[i]);
            }
            WriteLine("Нормальний");
            for (i = 0; i < n; i++)
            {
                B[i] = massB[i] / massA[i, i];
                x0[i] = B[i];
                for (j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        A[i, j] = -(massA[i, j] / massA[i, i]);
                        Write(A[i, j] + " ");
                    }
                }
                WriteLine(B[i]);
            }
            WriteLine("N=1");
            for (i = 0; i < n; i++)
            {
                Write("x{0}=", i);
                WriteLine(x0[i]);
            }
        }
        public void Result()
        {
            while (true)
            {
                N++;
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        if (i != j)
                        {
                            A[i, j] = -(massA[i, j] / massA[i, i]) * x0[j];
                        }
                        Anew1 += A[i, j];
                    }
                    x1[i] = B[i] + Anew1;
                    Anew1 = 0;
                }
                if (Math.Abs(x1[0] - x0[0]) > pohybka)
                {
                    for (i = 0; i < n; i++)
                    {
                        x0[i] = x1[i];
                    }
                }
                else
                {
                    break;
                }
            }
            WriteLine("N=" + N);
            for (i = 0; i < n; i++)
            {
                Write("x{0}=", i);
                WriteLine(x1[i]);
            }
        }
    }
}
