using System;
using System.Diagnostics;

namespace Sorts
{
    public class DHeap
    {
        public int d { get; private set; }
        int heapSize;

        public DHeap(int d)
        {
            this.d = d;
        }

        public void DHeapSort(ref int[] items)
        {
            this.heapSize = items.Length - 1;
            BuildDHeap(items);

            for (int i = items.Length - 1; i >= 1; i--)
            {
                Swap(ref items[0], ref items[i]);
                this.heapSize--;
                Heapify(items, 0);
            }
        }

        public void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        void BuildDHeap(int[] items)
        {
            for (int i = GetFirstWithChild(items); i >= 0; i--)
            {
                Heapify(items, i);
            }
        }

        int GetParentIndex(int i)
        {
            return (i - 1) / this.d;
        }

        int GetChildIndex(int i, int j)
        {
            return i * this.d + j;
        }

        int GetFirstWithChild(int[] items)
        {
            return (heapSize - 1) / this.d;
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

        int FindLargest(int[] items, int i)
        {
            int largest = i;
            int сurrentChild = GetChildIndex(i, 1);

            if (сurrentChild > this.heapSize)
            {
                return i;
            }

            int j = 1;
            while (j <= this.d & сurrentChild <= this.heapSize)
            {
                if (items[сurrentChild] > items[largest])
                {
                    largest = сurrentChild;
                }

                j++;
                сurrentChild = GetChildIndex(i, j);
            }
            return largest;
        }
    }
}
