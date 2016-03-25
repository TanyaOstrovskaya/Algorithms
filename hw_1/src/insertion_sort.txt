using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileApp
{
   	static public void InsertionSort (int[] a)
	{
            for (int i = 0; i < a.Length; i++)
            {
                int temp = a[i]; 
                int j = i - 1;
                while (j >= 0 && a[j] > temp)               
                {
                    a[j + 1] = a[j];                   
                    j--;
                }
                a[j + 1] = temp;               
            }           
        }	
}