using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp96
{
    class Program
    {
        public static float GetDirectory(DirectoryInfo c)
        {
            
           
            FileSystemInfo[] v = c.GetDirectories();
      
            float sum = 0;
            FileInfo[] d = c.GetFiles();
            foreach (FileInfo di in d)
            {
                sum += di.Length;
            }

            foreach(DirectoryInfo f in v)
            {
                sum += GetDirectory(f);
            }
            return sum;
        }
  

        public static void FileSize(string c)
        {
           
            FileInfo info = new FileInfo(c);
            long size = info.Length;
          
            Console.WriteLine("Size in bytes: {0}", size);

        }

        static void Main(string[] args)
        {
            try
            {
                const string file = @"E:\Test\Test.txt";
                FileSize(file);
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Size: {0}", GetDirectory(new DirectoryInfo(@"E:\Test\")));
            }

            Console.ReadKey();
        }
    }
}
