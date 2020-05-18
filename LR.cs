using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp134
{
    class Program
    {
        static void Main(string[] args)
        {

            LR prob = new LR("input.txt");
            prob.Read();
            prob.Right();
            prob.Left();
            prob.Print();

            Console.ReadKey();
        }
    }
    public class LR
    {
        private int[] sir;
        private int[] L;
        private int[] R;
        private string numeFisier;

        public LR(string fisier)
        {
            numeFisier = fisier;
        }

        public void Right()
        {
            R = new int[sir.Length];
            int min = sir[sir.Length - 1];
            for (int i = sir.Length - 1; i >= 0; i--)
            {
                if (sir[i] < min)
                {
                    min = sir[i];
                }
                R[i] = min;
            }
        }

        public void Left()
        {
            L = new int[sir.Length];
            int max = sir[0];
            for (int i = 0; i < sir.Length; i++)
            {
                if (sir[i] > max)
                {
                    max = sir[i];
                }
                L[i] = max;
            }
        }

        public void Read()
        {

            using (StreamReader sr = new StreamReader(numeFisier))
            {
                string line;
                line = sr.ReadLine();
                line = sr.ReadLine();
                string[] tok;
                char[] separatori = { ' ', ',', '/', ';', ':', '.' };
                tok = line.Split(separatori, StringSplitOptions.RemoveEmptyEntries);

                sir = new int[tok.Length];
                int i = 0;
                foreach (var item in tok)
                {
                    sir[i++] = int.Parse(item);
                }

            }
        }

        public void Print()
        {
            int nr = 0;
            Console.Write("Elementele LR sunt: ");
            for (int i = 1; i < sir.Length - 1; i++)
            {
                if (sir[i] == L[i] && sir[i] == R[i])
                {
                    Console.Write(sir[i] + " ");
                    nr++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Sunt {0} elemente LR in sir.", nr);
        }
    }
}
