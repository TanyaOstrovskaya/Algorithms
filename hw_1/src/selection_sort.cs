using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileApp
{
    	static public void SelectionSort (int[] a)   
	{       
            int temp;
            for (int i = 0; i < a.Length; i++)
            {                
                int indexOfMin = i;              
                for (int j = i + 1; j < a.Length; j++)
                {                   
                    if (a[j] < a[indexOfMin])
                    {
                        indexOfMin = j;
                    }
                }               
                temp = a[i];
                a[i] = a[indexOfMin];
                a[indexOfMin] = temp;
            }             
        } 
}