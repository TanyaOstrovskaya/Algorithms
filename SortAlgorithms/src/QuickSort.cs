using System;
using System.Diagnostics;

namespace CASort
{
    public static class Sort       
    {     

        public static void MainQuickSort(int[] items)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            QuickSort(items, 0, items.Length - 1);
            sw.Stop();

            for (int i = 0; i < items.Length; i++)
            {
                Console.Write(items[i] + " ");
            }

            Console.WriteLine(sw.Elapsed);
        }

        public static void QuickSort(int[] items, int l, int r)
        {
            if (l >= r)
                return;
            int m = Partition(items, l, r);
            QuickSort(items, l, m - 1);
            QuickSort(items, m + 1, r);
        }

        static int Partition(int[] items, int l, int r)
        {
            Random rnd = new Random();
            int k = rnd.Next(l, r);
            int temp = items[l];
            items[l] = items[k];
            items[k] = temp;
            int x = items[l];

            int j = l;
            for (int i = l + 1; i <= r; i++)
            {
                if (items[i] <= x)
                {
                    j = j + 1;
                    int tmp = items[i];
                    items[i] = items[j];
                    items[j] = tmp;
                }
            }
            temp = items[l];
            items[l] = items[j];
            items[j] = temp;

            return j;
        }
    }
}