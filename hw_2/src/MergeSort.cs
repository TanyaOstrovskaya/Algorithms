using System;
using System.Diagnostics;

namespace CASort
{
    public static class Sort       
    {
		static public void MainMergeSort(int[] items)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            MergeSort(items, 0, items.Length - 1);
            sw.Stop();
            for (int i = 0; i < items.Length; i++)
            {
                Console.Write(items[i] + " ");
            }
            Console.WriteLine(sw.Elapsed);
        }

        static void MergeSort(int[] items, int left, int right)
        {
            if (right > left)
            {
                int mid = (left + right) / 2;
                MergeSort(items, left, mid);
                MergeSort(items, mid + 1, right);
                Merge(items, left, mid, right);
            }
        }

        static void Merge(int[] items, int l, int mid, int r)
        {
            int[] temp = new int[(r - l) + 1];

            int i = l;
            int j = mid + 1;
            int k = 0;

            while (i < mid + 1 && j < r + 1)
            {
                if (items[i] < items[j])
                {
                    temp[k++] = items[i++];                   
                }
                else
                {
                    temp[k++] = items[j++];                   
                }
            }
            
            while (i <= mid)
            {
                temp[k++] = items[i++];
            }
            while (j <= r)
            {
                temp[k++] = items[j++];                
            }
            
            i = l;
            k = 0;
            while (k < temp.Length && i <= r)
            {
                items[i++] = temp[k++];                
            }
        }
    }
}