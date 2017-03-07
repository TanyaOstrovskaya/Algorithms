using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sorts
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 6; i <= 20; i++)
            {
                string name = @"D:\ITMO\CombAlgorithms\file" + i.ToString() + ".txt";
                CreateFile(name, i);
            }

        }

        static void CreateFile(string name, int power)      
        {
            Random rnd = new Random();
            
            using (StreamWriter sw = new StreamWriter(name))
            {
                for (int i = 0; i < Math.Pow(2,power); i++)
                {
                    sw.Write(rnd.Next(10000) + " ");
                }
            }          
        }
    }
}