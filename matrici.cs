using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp104
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrice A = new Matrice(3, 3);
            Matrice B = new Matrice(3, 3);
            A.Afisare(); 
            B.Afisare();
            Matrice C = new Matrice(3, 3);
            C = A.Adunare(B); 
            C.Afisare();
            C = A.Scadere(B); 
            C.Afisare();
            C = A.Inmultire(B);
            C.Afisare();
            C = A.Putere(2); 
            C.Afisare();
            C = B.Inversa();
            C.Afisare();
            Console.ReadKey();
             
           
        }
    }

    internal class Matrice
    {
        private float[,] a;
        private float determinant;
        static Random rnd = new Random();
        public Matrice(int n,int m)
        {
            a = new float[n, m];
            for (int i = 0; i < n; i++)
            {
                
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = rnd.Next(10);
                }
            }
        }
        public Matrice Adunare(Matrice B)
        {
            int n = a.GetLength(0), m = a.GetLength(1);
            Matrice C = new Matrice(n, m);
            if (n != B.a.GetLength(0) || m != B.a.GetLength(1))
                Console.WriteLine("Nu se pot aduna ");
            else
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        C.a[i, j] = a[i, j] + B.a[i, j];
                    }
                }
            }
            return C;
        }
        public Matrice Scadere(Matrice B)
        {
            int n = a.GetLength(0), m = a.GetLength(1);
            Matrice C = new Matrice(n, m);
            if (n != B.a.GetLength(0) || m != B.a.GetLength(1))
                Console.WriteLine("Nu se pot scadea");
            else
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        C.a[i, j] = a[i, j] - B.a[i, j];
                    }
                }
            }
            return C;
        }
        public Matrice Inmultire(Matrice B)
        {
            int n = a.GetLength(0), m = a.GetLength(1);
            Matrice C = new Matrice(n, n);
            if (n != B.a.GetLength(1))
                Console.WriteLine("Nu se pot inmulti");
            else
            {
                for (int k = 0; k < n; k++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            C.a[k, i] += a[i, j] * B.a[j, i];
                        }
                    }
                }
            }
            return C;
        }

            public Matrice Putere(int x)
        {
            int n = a.GetLength(0);
            Matrice C = new Matrice(n, n);
            if (n != a.GetLength(1))
            {
                Console.WriteLine("Nu se poate ridica la putere");
                return C; 
            }
            if (x == 0)
                for (int i = 0; i < n; i++)
                {
                    C.a[i, i] = 1;
                }
            else if (x == 1)
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        C.a[i, j] = a[i, j];
                    }
                }
            else
                C = C.Inmultire(C.Putere(x - 1));
            return C;
        }
        public Matrice Inversa()
        {
            int n = a.GetLength(0);
            Matrice C = new Matrice(n, n);
            if (n != a.GetLength(1))
            { 
                Console.WriteLine("Doar matricile patratice pot avea inversa"); 
                return C; 
            }
            CalculDeterminant();
            if (determinant != 0)
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        Matrice A = new Matrice(n - 1, n - 1);
                        for (int k = 0; k < n - 1; k++)
                            for (int l = 0; l < n - 1; l++)
                            {
                                if (k >= i && l >= j) A.a[l, k] = a[k + 1, l + 1];
                                else if (k >= i && l < j) A.a[l, k] = a[k + 1, l];
                                else if (k < 1 && l >= j) A.a[l, k] = a[k, l + 1];
                                else A.a[l, k] = a[k, l];
                            }
                        A.Afisare();
                        A.CalculDeterminant();
                        C.a[i, j] = (int)Math.Pow(-1, i + j) * A.determinant;
                        Console.WriteLine(C.a[i, j]);
                    }
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        C.a[i, j] *= 1f / determinant;
            }
            return C;
        }
        public void CalculDeterminant()
        {
            int n = a.GetLength(0);
            if (n != a.GetLength(1))
                Console.WriteLine("Doar matricile patratice au determinant");
            else
            {
                int[] sol = new int[n];
                bool[] b = new bool[n];
                Permutari(0, n, sol, b);
            }
        }
        private void Permutari(int k, int n, int[] sol, bool[] b)
        {
            int[] v = new int[n];
            if (k >= n)
            {
                for (int i = 0; i < n; i++)
                    v[i] = sol[i];
                Prelucrare(v);
            }
            else
                for (int i = 0; i < n; i++)
                    if (b[i] == false)
                    {
                        b[i] = true;
                        sol[k] = i;
                        Permutari(k + 1, n, sol, b);
                        b[i] = false;
                    }
        }
        private void Prelucrare(int[] v)
        {
            int n = a.GetLength(0);
            int grad = 0;
            float produs = 1;
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    if (v[i] > v[j]) grad++;
            for (int i = 0; i < n; i++)
            {
                produs *= a[i, v[i]];
            }
            if (grad % 2 == 0) determinant += produs;
            else determinant -= produs;
        }


        public void Afisare()
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i,j]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}
