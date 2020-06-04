using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp146
{
    class Program
    {
        public static List<Angajat> angajati = new List<Angajat>();
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Bogdi.DESKTOP-SHEFDBL\source\repos\ConsoleApp146\ConsoleApp146\text.txt");
            
            Angajat Flaviu = new Angajat("Flaviu", "Catalin", DateTime.Now);
            Angajat toRemove = new Angajat();

           

           
            
            foreach (string line in lines)
            {
                angajati.Add(new Angajat(line));
                
            }

            Flaviu.Add(Flaviu);

            int i = rnd.Next(0, angajati.Count - 1);
            var AngajatR = angajati[i];
            toRemove.Remove(angajati[i]);

            IComparer<Angajat> comparer = new Angajat();
            angajati.Sort(comparer);
            using (TextWriter tw = new StreamWriter(@"C:\Users\Bogdi.DESKTOP-SHEFDBL\source\repos\ConsoleApp146\ConsoleApp146\TextFile1.txt"))
            {
                foreach (var s in angajati)
                    tw.WriteLine(s);
                tw.WriteLine($"Angajatu scos din lista a fost {AngajatR.nume} {AngajatR.prenume}");
            }
            
            angajati.Sort(delegate (Angajat a, Angajat b) { return a.data.CompareTo(b.data); });
            using (TextWriter tw = new StreamWriter(@"C:\Users\Bogdi.DESKTOP-SHEFDBL\source\repos\ConsoleApp146\ConsoleApp146\TextFile2.txt"))
            {
                foreach (var s in angajati)
                    tw.WriteLine(s+" "+"timp lucrat: "+s.ani+" ani "+s.luni+" zile");
            }

        }
    }
    //yymmddminsec
    public class Angajat: IComparer<Angajat>
    {
        public string nume;
        public string prenume;
        public DateTime data;
        public TimeSpan t;
        public int luni;
        public int ani;
        public Angajat()
        {
        }
        
        public  void Add(Angajat a)
        {
            Program.angajati.Add(a);
        }
        public  void Remove(Angajat a)
        {
            Program.angajati.Remove(a);
        }
        public static int Luni_Ani(DateTime ti,DateTime tf)
        {
            return (ti.Month - tf.Month) + 12 * (ti.Year - tf.Year);
        }
        public  Angajat(string line)
        {
            {
                string[] tokens = line.Split(' ', '.');
                nume = tokens[0];
                prenume = tokens[1];
                data = new DateTime(int.Parse(tokens[2]), int.Parse(tokens[3]), int.Parse(tokens[4]));
                t = DateTime.Now - data;
                luni = Luni_Ani(DateTime.Now, data) % 12;
                ani = Luni_Ani(DateTime.Now, data) / 12;
            }
        }

        public Angajat(string nume, string prenume, DateTime data) 
        {
            this.nume = nume;
            this.prenume = prenume;
            this.data = data;
            
            
        }

        public int Compare(Angajat x, Angajat y)
        {

            int comparaNume = x.nume.CompareTo(y.nume);
            if (comparaNume == 0)
            {
                return x.prenume.CompareTo(y.prenume);
            }
            return comparaNume;

        }


        public override string ToString()
        {
            return nume+" "+prenume+" "+data.ToShortDateString();
        }

    }
   
}
