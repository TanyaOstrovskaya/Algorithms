using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileApp
{   
       	static public void BinaryInsertion (int[] a)
        {                   
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i-1]>a[i])
                {
                    int temp = a[i];
                    int left = 0;
                    int right = i - 1;
                    do
                    {
                        int middle = (right + left) / 2;
                        if (a[middle] > temp)
                        {
                            right = middle-1;
                        }
                        else left = middle+1;
                    } while (right >= left);
                    for (int j = i-1; j >=left; j--)
                    {
                        a[j + 1] = a[j];
                    }
                    a[left] = temp;
                }
            }         
        } 
}