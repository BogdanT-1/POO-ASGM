using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp145
{
    class Program
    {
        public static void Main(string[] args)
        {
            Publisher pub = new Publisher();
            SubscriberA subA = new SubscriberA();
            SubscriberB subB = new SubscriberB();
            pub.eveniment += new Iteratie(subA.Iteratie);
            pub.eveniment += new Iteratie(subB.Iteratie);
            pub.DeclansareEveniment();
            Console.ReadKey();
        }
    }

    public delegate void Iteratie(int a);

    public class Publisher
    {
        public event Iteratie eveniment;

        public void DeclansareEveniment()
        {
            for (int i = 0; i < 10; i++)
            {
                if (eveniment != null)
                    eveniment(i);
            }
        }
    }
    public class SubscriberA
    {
        public void Iteratie(int a)
        {
            Console.WriteLine("Eveniment in SubA");
        }
    }

    public class SubscriberB
    {
        public void Iteratie(int a)
        {
            Console.WriteLine("Eveniment in SubB");
        }
    }
}
