using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp105
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "23153126326236";
            string s2 = " 312527783473";
            Console.WriteLine($"{s1} +{s2}={BigNUMB.Adunare(s1, s2)}");
            Console.WriteLine($"{s1} *{s2}={BigNUMB.Inmultire(s1, s2)}");
            BigNUMB.Fibonacci(100);
            BigNUMB.Factorial(1000);
            Console.ReadKey();
        }
    }
}
internal class BigNUMB
{
    public static string Adunare(string nr1, string nr2)
    {
        if (nr1.Length > nr2.Length)
        {
            string t = nr1;
            nr1 = nr2;
            nr2 = t;
        }

        string adunare = "";
        int n1 = nr1.Length, n2 = nr2.Length;

        char[] ch = nr1.ToCharArray();
        Array.Reverse(ch);
        nr1 = new string(ch);
        char[] ch1 = nr2.ToCharArray();
        Array.Reverse(ch1);
        nr2 = new string(ch1);

        int carry = 0;
        for (int i = 0; i < n1; i++)
        {
            int sum = ((int)(nr1[i] - '0') +
                    (int)(nr2[i] - '0') + carry);
            adunare += (char)(sum % 10 + '0');
            carry = sum / 10;
        }

        for (int i = n1; i < n2; i++)
        {
            int sum = ((int)(nr2[i] - '0') + carry);
            adunare += (char)(sum % 10 + '0');
            carry = sum / 10;
        }

        if (carry > 0)
            adunare += (char)(carry + '0');

        char[] ch2 = adunare.ToCharArray();
        Array.Reverse(ch2);
        adunare = new string(ch2);

        return adunare;
    }

    public static string Inmultire(string nr1, string nr2)
    {
        int n = nr1.Length;
        int m = nr2.Length;

        int[] inmultire = new int[n + m];
        int i_n1 = 0;
        int i_n2 = 0;
        int i;

        for (i = n - 1; i >= 0; i--)
        {
            int carry = 0;
            int n1 = nr1[i] - '0';
            i_n2 = 0;
            for (int j = m - 1; j >= 0; j--)
            {
                int n2 = nr2[j] - '0';
                int sum = n1 * n2 + inmultire[i_n1 + i_n2] + carry;
                carry = sum / 10;
                inmultire[i_n1 + i_n2] = sum % 10;
                i_n2++;
            }

            if (carry > 0)
                inmultire[i_n1 + i_n2] += carry;
            i_n1++;
        }

        i = inmultire.Length - 1;
        while (i >= 0 && inmultire[i] == 0)
            i--;

        if (i == -1)
            return "0";

        string inm = "";

        while (i >= 0)
            inm += (inmultire[i--]);

        return inm;
    }

    public static void Factorial(int n)
    {
        string nr = "1";
        string fact = "1";

        for (int i = 0; i < n; i++)
        {
            fact = Inmultire(fact, nr);
            nr = Adunare(nr, 1.ToString());
        }

        Console.WriteLine("{0} factorial:", n);
        Console.WriteLine(fact);
        Console.WriteLine();
    }

    public static void Fibonacci(int nr)
    {
        string nr1 = "1";
        string nr2 = "1";
        string fibonacci = "";

        for (int i = 2; i < nr; i++)
        {
            fibonacci = Adunare(nr1, nr2);
            nr1 = nr2;
            nr2 = fibonacci;
        }

        Console.WriteLine("Al {0}-lea element din sirul lui Fibonacci este:{1}", nr, fibonacci);
        Console.WriteLine();
    }
}