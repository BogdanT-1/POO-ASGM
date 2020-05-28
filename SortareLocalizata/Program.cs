using System;
using System.IO;
using System.Collections.Generic;

namespace SortareLocalizata
{
    class Program
    {
        private static List<string> lista = new List<string>();
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"C:\Users\gaido\source\repos\SortareLocalizata\input.txt");
           
            foreach (string line in lines)
            {
                if(line.Length > 2)
                {
                    string[] aux = line.Split(' ');
                    string nume = "";
                    for(int i = 0; i < aux.Length; i++ )
                    {
                        if(aux[i].Length > 1)
                        {
                            aux[i] = aux[i].ToLower();
                            aux[i] = char.ToUpper(aux[i][0]) + aux[i].Substring(1);
                            nume = nume + aux[i] + " ";
                        }
                    }
                    lista.Add(nume);
                }

            }
            sort();
            StreamWriter file = new StreamWriter(@"C:\Users\gaido\source\repos\SortareLocalizata\output.txt");
            for (int i = 0; i < lista.Count; i++)
            {
                file.WriteLine(lista[i]);
            }
            file.Close();
        }

        public static void sort()
        {
            for(int i = 0; i < lista.Count; i++)
            {
                for(int j = 0; j < lista.Count; j++)
                {
                    if(String.Compare(lista[i], lista[j]) == -1)
                    {
                        string aux = lista[i];
                        lista[i] = lista[j];
                        lista[j] = aux;
                    }
                }
            }
        }
    }
}
