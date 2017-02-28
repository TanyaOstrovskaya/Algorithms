using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sorts
{    
    public class Node
    {
        public int key { get; set; }
        public int run { get; private set; }

        public Node(int Key, int run)
        {
            this.key = Key;
            this.run = run;
        }
    }

    public class MultywayMerge
    {
        public int ways { get; private set; }

        int[] items;

        public MultywayMerge(int ways)
        {
            this.ways = ways;
        }

        public void MainSort(int[] array)
        {
            this.items = array;
            Sort(0, array.Length - 1);
        }

        private void Sort(int start, int end)
        {
            if (start < end)
            {
                int length = (int)Math.Ceiling((double)(end - start + 1) / ways);

                int l, r;
                for (int i = 0; i < ways - 1; i++)
                {
                    l = start + length * i;
                    r = l + length - 1;
                    Sort(l, r);
                }
                Sort(start + length * (ways - 1), end);

                Merge(start, end, length);
            }
        }

        private void Merge(int start, int end, int length)
        {
            List<List<int>> mergingLists = new List<List<int>>(ways);
            List<int> tempList;
            int[] tempArray = new int[end - start + 1];
            int left, right, k;

            for (int i = 0; (i < ways - 1) & (i < tempArray.Length); i++)
            {
                tempList = new List<int>(length);
                left = start + length * i;
                right = left + length - 1;
                for (k = left; k <= right; k++)
                    tempList.Add(items[k]);
                mergingLists.Add(tempList);
            }

            right = start + length * (ways - 1);
            if (right <= end)
            {
                tempList = new List<int>(end - right + 1);
                for (k = right; k <= end; k++)
                    tempList.Add(items[k]);
                mergingLists.Add(tempList);
            }

            k = 0;
            SelectionTree tree;
            int count = mergingLists.Count;
            int[] treeArr = new int[count];
            for (int i = 0; i < count ; i++)
            {
                treeArr[i] = mergingLists[i][0];
            }
            tree = new SelectionTree(treeArr);

            k = 0;
            while (count > 0)
            {
                Node min = tree.ExtractMin();
                tempArray[k] = mergingLists[min.run][0];
                mergingLists[min.run].RemoveAt(0);         

                if (mergingLists[min.run].Count == 0)
                {
                    tree.Add(int.MaxValue, min.run);
                    --count;
                }
                else
                {
                    tree.Add(mergingLists[min.run][0], min.run);
                }
                k++;
            }

            k = 0;
            for (int i = start; i <= end; i++, k++)
            {
                items[i] = tempArray[k];
            }
        }
    }

    public class SelectionTree
    {
        public Node[] items;
        int arrSize;
        int treeSize;

        public SelectionTree(int[] items)
        {
            arrSize = items.Length;
            BuildTree(items);
        }        

        public  Node ExtractMin()
        {
            return items[0];
        }

        void BuildTree(int[] items)
        {
            treeSize = GetTreeLength(arrSize);
            this.items = new Node[2 * treeSize - 1];

            for (int i = 0; i < arrSize; i++)
            {
                this.items[treeSize - 1 + i] = new Node(items[i], i);
            }
            for (int i = 0; i < treeSize - arrSize; i++)
            {
                this.items[treeSize - 1 + arrSize + i] = new Node(int.MaxValue, arrSize + i);
            }

            EnterTreeItems();
        }

        int GetTreeLength(int l)
        {
            int resultLength = 1;
            while (true)
            {
                if ((l <= resultLength) && (l >= resultLength / 2))
                    return resultLength;
                else
                    resultLength *= 2;
            }
        }

        public void Add(int key, int i)
        {
            int index = items.Length - treeSize + i;
            items[index] = new Node(key, i);
            if (GetParent(index) != 0)
                SiftUp(GetParent(index));   
        }

        void SiftUp(int i)
        {
            int largest = i;
            int left = GetLeftChild(i);
            int right = GetRightChild(i);

            if (items[right].key < items[left].key)
                items[i] = items[right];
            else
                items[i] = items[left];
            if (i != 0)
                SiftUp(GetParent(i));
        }

        void EnterTreeItems()
        {
            int childsPointer = items.Length - 2;
            int k = 0;
            while (childsPointer > 0)
            {
                k = childsPointer;
                if (items[k + 1].key < (items[k]).key)
                    k++;
                items[GetParent(k)] = items[k];
                childsPointer = childsPointer - 2;
            }
        }

        int GetParent(int i)
        {
            return (i - 1) / 2;
        }

        int GetRightChild(int i)
        {
            return 2 * i + 2;
        }

        int GetLeftChild(int i)
        {
            return 2 * i + 1;
        }
    }
}
