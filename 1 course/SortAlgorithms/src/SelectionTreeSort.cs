﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sorts
{
    public class SelectionTree
    {
        public class treeNode
        {
            public int key { get; set; }
            public int index { get; private set; }

            public treeNode(int Key, int run)
            {
                this.key = Key;
                this.index = run;
            }
        }

        public treeNode[] items;        
        int arrSize;
        int treeSize;

        public SelectionTree(int[] items)
        {
            arrSize = items.Length;
            BuildTree(items);
        }

        public int[] SelectionTreeSort()
        {   
            int[] resultArray = new int[arrSize];
            for (int i = 0; i < arrSize; i++)
            {
                resultArray[i] = ExtractMin();
            }
            return resultArray;
        }

        public int ExtractMin()
        {
            int minKey = items[0].key;
            int minRun = items[0].index;
            items[treeSize - 1 + minRun] = new treeNode(int.MaxValue, minRun);
            SiftUp(GetParent(treeSize - 1 + minRun));
            return minKey;
        }

        void BuildTree(int[] items)
        {
            treeSize = GetTreeLength(arrSize);
            this.items = new treeNode[2 * treeSize - 1];

            for (int i = 0; i < arrSize; i++)
            {
                this.items[treeSize - 1 + i] = new treeNode(items[i], i);
            }
            for (int i = 0; i < treeSize - arrSize; i++)
            {
                this.items[treeSize - 1 + arrSize + i] = new treeNode(int.MaxValue, arrSize + i);
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

        void SiftUp(int i)
        {
            int largest = i;            
            int r = GetRightChild(i);
            int l = GetLeftChild(i);

            if (items[r].key < items[l].key)
                items[i] = items[r];
            else
                items[i] = items[l];
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
