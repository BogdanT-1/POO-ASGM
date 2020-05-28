using System;
using System.Collections.Generic;
using System.Text;

namespace SortareLocalizata
{
    class Persoana
    {
        private static string[] nume;

        public Persoana(string fullName)
        {
            if (fullName.Length > 2)
            {
                nume = fullName.Split(' ');
                for (int i = 0; i < nume.Length; i++)
                {
                    if (nume[i].Length > 1)
                    {
                        string var = nume[i];
                        var = var.ToLower();
                        var = char.ToUpper(var[0]) + var.Substring(1);
                        nume[i] = var;
                    }

                }
            }
        }

        public string getNume()
        {
            string rez = "";
            foreach(string aux in nume)
            {
                rez = rez + aux + " ";
            }
            return rez;
        }

        public void printNume()
        {
            foreach(string var in nume)
            {
                Console.Write(var + " ");
            }
            Console.WriteLine();
        }

        public void setNume(string fullName)
        {
            nume = fullName.Split(' ');
            for (int i = 0; i < nume.Length; i++)
            {
                string var = nume[i];
                var.ToLower();
                var = char.ToUpper(var[0]) + var.Substring(1);
                nume[i] = var;
            }
        }
    }
}
