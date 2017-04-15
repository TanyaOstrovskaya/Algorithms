using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Huffman
{
    public class HuffmanTest
    {
        public static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            Tree tree = new Huffman.Tree();

            tree.BuildTree(inputString);

            BitArray encodedBits = tree.EncodeString(inputString);
            Console.WriteLine("NUFFMAN encoded:");
            foreach (bool bit in encodedBits)
            {
                Console.Write((bit ? 1 : 0) + "");
            }
            Console.WriteLine();

            string decodedString = tree.DecodeString(encodedBits);
            Console.WriteLine("NUFFMAN decoded:\n" + decodedString);

            Console.ReadKey();
        }
    }

    public class Node
    {
        public char symbol { get; set; }
        public int frequency { get; set; }
        public Node rightChild { get; set; }
        public Node leftChild { get; set; }

        public Node() { }

        public Node (char symbol, int frequency, Node left, Node rigth)
        {
            this.symbol = symbol;
            this.frequency = frequency;
            this.leftChild = left;
            this.rightChild = rigth;
        }

        public List<bool> Traverse (char symbol, List<bool> currPath)
        {
            //  if node is a leaf
            if (this.leftChild == null && this.rightChild == null)
            {
                if (symbol.Equals(this.symbol))              
                    return currPath;               
                else                
                    return null;                
            }
            else
            //  if node is not a leaf - invoke recursivelly till achievement leafs 
            {
                List<bool> left = null;
                List<bool> right = null;

                if (this.leftChild != null)
                {
                    List<bool> leftPath = new List<bool>();
                    leftPath.AddRange(currPath);
                    leftPath.Add(false);
                    left = this.leftChild.Traverse(symbol, leftPath);
                }
                if (this.rightChild != null)
                {
                    List<bool> rightPath = new List<bool>();
                    rightPath.AddRange(currPath);
                    rightPath.Add(true);
                    right = this.rightChild.Traverse(symbol, rightPath);
                }

                if (left != null)
                    return left;
                else
                    return right;
            }
        }
    }

    public class Tree
    {

        public Node root;
        private List<Node> nodes = new List<Node>();
        private List<Node> orderedNodes;


        public void BuildTree (string sourceString)
        {
            BuildNodesFromSymbols(sourceString);
           
            while (nodes.Count > 1)
            {
                orderedNodes = new List<Node>(nodes);
                orderedNodes.Sort((node1, node2) => node1.frequency - node2.frequency);

                if (orderedNodes.Count >=2 )
                {
                    // take two nodes
                    Node takenNode1 = orderedNodes[0];
                    Node takenNode2 = orderedNodes[1];
                    Node parentNode = new Node('*', takenNode1.frequency + takenNode2.frequency, takenNode1, takenNode2);

                    nodes.Remove(takenNode1);
                    nodes.Remove(takenNode2);
                    nodes.Add(parentNode);
                }

                this.root = nodes[0];
            }   
        }

        public BitArray EncodeString (string sourceString)
        {
            List<bool> encodedBitsList = new List<bool>();
            for (int i = 0; i < sourceString.Length; i++)
            {
                List<bool> encodedSymbol = this.root.Traverse(sourceString[i], new List<bool>());
                encodedBitsList.AddRange(encodedSymbol);
            }

            return new BitArray(encodedBitsList.ToArray());
        }

        public string DecodeString (BitArray bits)
        {
            Node currNode = this.root;
            string decodedString = null;

            foreach (bool bit in bits)
            {
                if (bit)
                {
                    if (currNode.rightChild != null)
                        currNode = currNode.rightChild;
                }
                else
                {
                    if (currNode.leftChild != null)
                        currNode = currNode.leftChild;
                }

                if (currNode.leftChild == null && currNode.rightChild == null) //if node is a leaf => add symbol to decoded
                {
                    decodedString += currNode.symbol;
                    currNode = this.root;
                }              
            }
            return decodedString;
        }

        private void BuildNodesFromSymbols (string sourceString)
        {
            // builds nodes list from source string considering their frequency

            Dictionary<char, int> symbolFrequencies = new Dictionary<char, int>();

            for (int i = 0; i < sourceString.Length; i++)
            {
                if (!symbolFrequencies.ContainsKey(sourceString[i]))
                    symbolFrequencies.Add(sourceString[i], 0);

                symbolFrequencies[sourceString[i]]++;
            }

            foreach (KeyValuePair<char, int> symbol in symbolFrequencies)
                nodes.Add(new Node(symbol.Key, symbol.Value, null, null));
        }
    }
}