using System;
using System.Diagnostics;

namespace Sorts
{   
    public class LeftistHeap
    {
        public class Node
        {
            public int value { get; private set; }
            public int npl;

            public static int GetNpl(Node item)
            {
                if (item == null)
                    return -1;
                else
                    return item.npl;
            }

            public Node left, right;

            public Node(int value)
            {
                this.value = value;
                npl = 0;
                left = null;
                right = null;
            }
        }

        static void Swap (ref Node H1, ref Node H2)
        {
            Node temp = H2;
            H2 = H1;
            H1 = temp;
        }
        public static Node Merge(Node H1, Node H2)
        {
            if (H1 == null)
                return H2;
            if (H2 == null)
                return H1;

            if (H2.value < H1.value)
                Swap(ref H1, ref H2);   

            H1.right = Merge(H1.right, H2);

            if (Node.GetNpl(H1.left) < Node.GetNpl(H1.right))
                Swap(ref H1.left, ref H1.right);

            H1.npl = Node.GetNpl(H1.right) + 1;

            return H1;
        }

        public static int ExtractMin(ref Node H)
        {
            int result = H.value;
            H = Merge(H.left, H.right);
            return result;
        }

        public static void LeftistHeapSort (ref int[] array)
        {
            Node leftistHeap = null ;

            for (int i = 0; i < array.Length; i++)
            {
                leftistHeap = Merge(leftistHeap, new Node(array[i]));
            }

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = ExtractMin(ref leftistHeap);
            }
        }
    }
}
