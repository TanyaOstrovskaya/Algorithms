using System;
using System.Collections.Generic;

namespace StepicAlgorithms
{
    public class CoverSegmentsWithPoints
    {
        /*  По данным n отрезкам необходимо найти множество точек минимального размера, 
            для которого каждый из отрезков содержит хотя бы одну из точек.
            В первой строке дано число n отрезков. Каждая из последующих nn строк содержит 
            по два числа r l, задающих начало и конец отрезка. Вывести оптимальное число m точек
            и сами m точек. Если таких множеств точек несколько, вывести любое из них. */

        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            List<int> pointsList;
            Segment[] segments = InputSegments(number);
            int count = Solve(number, segments, out pointsList);

            Console.WriteLine(count);
            pointsList.ForEach(x => Console.Write("{0} ", x));
        }


        private static int Solve(int number, Segment[] segments, out List<int> resultPoints)
        {
            int i = 0;
            int curPoint = 0;
            int count = 0;
            resultPoints = new List<int>();

            Array.Sort(segments);
            while (i < number)
            {
                count++;
                curPoint = segments[i].r;
                resultPoints.Add(curPoint);
                ++i;
                while ((i < number) && (segments[i].l <= curPoint))
                {
                    ++i;
                }
            }
            return count;
        }

        private static Segment[] InputSegments(int number)
        {
            Segment[] result = new Segment[number];
            string segmentString;
            for (int i = 0; i < number; i++)
            {
                segmentString = Console.ReadLine();
                var arr = segmentString.Split(new[] { ' ' });
                var nextSegment = new Segment();
                nextSegment.l = int.Parse(arr[0]);
                nextSegment.r = int.Parse(arr[1]);
                result[i] = nextSegment;
            }
            return result;
        }

        private class Segment : IComparable<Segment>
        {
            public int l;
            public int r;
            public int CompareTo(Segment segment)
            {
                return this.r.CompareTo(segment.r);
            }
        }

    }
}

