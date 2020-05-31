using System;
namespace ConsoleApp146
{
    public class HeapSort
    {
        public void sort(int[] v)
        {
            int n = v.Length;
            int j = n-1;
           
            for (int i = n / 2 - 1; i >= 0; i--)
                heap(v, n, i);

            while (j > 0)
            {             
                swap(ref v[0],ref v[j]);
                heap(v, j, 0);
                j--;
            }
            
        }
        public static void swap(ref int a,ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        public void heap(int[] v, int n, int i)
        {
            int max = i; 
            int l = 2 * i + 1;
            int r = 2 * i + 2;

           
            if (l < n && v[l] > v[max])
                max = l;

          
            if (r < n && v[r] > v[max])
                max = r;

           
            if (max != i)
            {
                swap(ref v[i],ref v[max]);
               
                heap(v, n, max);
            }
        }
    }
}