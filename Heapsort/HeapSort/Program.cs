using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp146
{
    class Program
    {
        public static void Print(int[] v)
        {
            int n = v.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(v[i] + " ");
            
        }
        static void Main(string[] args)
        {
            int[] v = { 2, 11, 1, 19, 6, 7,43,21 };
            int n = v.Length;
            Print(v);
            HeapSort h = new HeapSort();
            h.sort(v);
            Console.WriteLine();
            Print(v);
            Console.ReadKey();

        }
    }
}
