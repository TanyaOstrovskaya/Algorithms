using System;
using System.Diagnostics;

namespace CASort
{
    public static class Sort        
    {
        public class Heap
        {
            private int heapSize;

            public void HeapSort(int[] items)
            {
                heapSize = items.Length - 1;

                BuildHeap(items);

                for (int i = items.Length - 1; i >= 1; i--)
                {
                    int temp = items[0];
                    items[0] = items[i];
                    items[i] = temp;

                    heapSize--;
                    Heapify(items, 0);
                }

                for (int i = 0; i < items.Length; i++)
                {
                    Console.Write(items[i] + " ");
                }
            }

            void BuildHeap(int[] items)
            {
                for (int i = items.Length / 2; i >= 0; i--)
                {
                    Heapify(items, i);
                }
            }

            void Heapify(int[] items, int i)
            {
                int largest = FindLargest(items, i);

                if (largest != i)
                {
                    int temp = items[i];
                    items[i] = items[largest];
                    items[largest] = temp;

                    Heapify(items, largest);
                }
            }

            private int FindLargest(int[] items, int i)
            {
                int largest;
                int l = GetLeftIndex(i);
                int r = GetRightIndex(i);
                
                if ((l <= heapSize) && (items[l]>(items[i])))
                {                    
                    largest = l;
                }
                else
                {                   
                    largest = i;
                }

                if ((r <= heapSize) && (items[r] > (items[largest])))
                {                    
                    largest = r;
                }

                return largest;
            }

            private int GetParentIndex(int i)
            {
                return (int)Math.Floor((double)i);         
            }

            private int GetLeftIndex(int i)
            {
                return (i*2);
            }

            private int GetRightIndex(int i)
            {
                return (i*2) + 1;
            }
        }
    }
}