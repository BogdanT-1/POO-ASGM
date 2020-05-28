using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp139
{
    class Program
    {
        static void Main(string[] args)
        {
            Cerc c = new Cerc(5, "Cerc");
            Console.WriteLine($"Aria ceruclui c este {c.Aria()}");
            Console.WriteLine($"Lungimea ceruclui c este {c.LungimeF()}");

            Patrat p = new Patrat(15, "Patrat");
            Console.WriteLine($"Aria ceruclui p este {p.Aria()}");
            Console.WriteLine($"Lungimea ceruclui p este {p.LungimeF()}");

            Console.ReadKey();
        }
    }
    interface IForma2D
    {
        double Aria();
        double LungimeF();
        string Denumire
        {
            get;
        }

    }
    class Cerc : IForma2D
    {
        private double r;
        public string Denumire { get; }

        public double Radius
        {
            get { return r; }
        }

        public Cerc(double r, string Denumire)
        {
            this.r = r;
            this.Denumire = Denumire;
        }

        public double Aria()
        {
            return r * r * Math.PI;
        }      

        public double LungimeF()
        {
            return 2 * r * Math.PI;
        }
    }

    class Patrat : IForma2D
    {
        private double latura;

        public string Denumire { get; }

       
        public Patrat(double latura, string Denumire)
        {
            this.latura = latura;
            this.Denumire = Denumire;
        }
       

        public double Aria()
        {
            return latura * latura;
        }

        public double LungimeF()
        {
            return 4 * latura;
        }
    }
}

