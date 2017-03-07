using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileApp
{
	static public void BubbleSort (int[] a)
	{
            for (int i = 0; i < a.Length; i++)
            {              
                for (int j = a.Length - 1; j > i; j--)
                {                    
                    if (a[j] < a[j - 1])
                    {
                        int temp = a[j];
                        a[j] = a[j - 1];
                        a[j - 1] = temp;
                    }
                }
            }         
        }        
    }
}