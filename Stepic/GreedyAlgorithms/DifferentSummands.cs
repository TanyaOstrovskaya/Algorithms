using System;
using System.Linq;
using System.Collections.Generic;

namespace StepicAlgorithms
{
    class DifferentAddends
    {

        /*  По данному числу n найдите максимальное число k, для которого n
            можно представить как сумму k различных натуральных слагаемых. 
            Выведите в первой строке число k, во второй — k слагаемых. */


        static void Main (string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());

            List<int> addends = new List<int>();
            int k = Solve(n, out addends);

            Console.WriteLine(k);
            addends.ToList().ForEach(x => Console.Write("{0} ", x));
        }

        private static int Solve (int n, out List<int> addends)
        {
            int currRemainder = n;
            int i = 1;
            int result = 0;
            addends = new List<int>();

            while (currRemainder > 0)
            {
                if (i <= currRemainder)
                {
                    if (i+1 > currRemainder - i)
                    {
                        i = currRemainder; 
                    }
                    addends.Add(i);
                    currRemainder -= i;
                    i++;
                    result++;
                }
            }
            return result;
        }  
    }
}
