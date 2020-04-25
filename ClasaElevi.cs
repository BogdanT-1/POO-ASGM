using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp112
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Bogdi.DESKTOP-SHEFDBL\source\repos\ConsoleApp112\ConsoleApp112\TextFile1.txt");
            List<Student> Clasa = new List<Student>();

            foreach (string line in lines)
            {

                int i = 0;
                float media = 0;
                string[] str = line.Split(' ');
                var tempEl = new Student();
                foreach (string s in str)
                {
                    
                    if(i==0)
                    {
                        tempEl.nume = s;
                    }
                    if(i==1)
                    {
                        tempEl.prenume = s;
                    }
                    if(i>2)
                    {
                        media += int.Parse(s);
                    }
                    i++;
                }
                tempEl.media_aritmetica = media / (i - 3);
                Clasa.Add(tempEl);                          
            }
           
            IComparer<Student> comparer = new Order();
            Clasa.Sort(comparer);
            Clasa.ForEach(Console.WriteLine);
            using (TextWriter tw = new StreamWriter(@"C:\Users\Bogdi.DESKTOP-SHEFDBL\AppData\Local\Temp\~vs5573.txt"))
            {
                foreach (var s in Clasa)
                    tw.WriteLine(s);
            }
            Console.ReadKey();
        }
    }

    public class Student
    {
        public string nume { get; set; }
        public string prenume { get; set; }
        public float media_aritmetica { get; set; }

        public override string ToString()
        {
            return string.Format("{0}|{1} are media {2} ", nume,prenume,media_aritmetica);
        }

    }
    public class Order : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            int comparaStudentiMedie = y.media_aritmetica.CompareTo(x.media_aritmetica);
            if (comparaStudentiMedie == 0)
            {
                int comparaStundetiNume= x.nume.CompareTo(y.nume);
                if(comparaStundetiNume==0)
                {
                    return  x.prenume.CompareTo(y.prenume);
                }
                return comparaStundetiNume;
            }
            return comparaStudentiMedie;
        }
    }
}
