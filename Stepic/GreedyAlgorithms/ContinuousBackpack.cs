using System;

namespace StepicAlgorithms
{
    public class ContinuousBackpack
    {
        /* "Непрерывный рюкзак"
            Первая строка содержит количество предметов и вместимость рюкзака. Каждая
            из следующих nn строк задаёт стоимость и объём предмета (целые числа). Вывести
            максимальную стоимость частей предметов (от каждого предмета можно отделить любую часть, 
            стоимость и объём при этом пропорционально уменьшатся), помещающихся в данный рюкзак.
        */

        public static void Main()
        {
            var arr = Console.ReadLine().Split(new[] { ' ' });
            int number = int.Parse(arr[0]);
            int volume = int.Parse(arr[1]);

            Subject[] subjects = InputSubjects(number);

            double maxCost = Solve(volume, number, subjects);

            Console.WriteLine("{0:0.000}", maxCost);
            Console.ReadKey();
        }

        private static double Solve (int volume, int number, Subject[] subjects)
        {   
            Array.Sort(subjects);
            Array.Reverse(subjects);
            int remainder = volume;

            double sum = 0;
            int i = 0;
            while ((i < number) && (remainder > 0))
            {
                if (remainder > subjects[i].volume)
                {
                    sum += (subjects[i].cost);
                    remainder -= subjects[i].volume;
                }
                else
                {
                    sum += remainder * subjects[i].pricePerKg;
                    remainder = 0;
                }
                i++;
            }
            return sum;
        }
            
        private static Subject[] InputSubjects(int number)
        {
            Subject[] subjects = new Subject[number];
            string subjectString;
            for (int i = 0; i < number; i++)
            {
                subjectString = Console.ReadLine();
                var arr = subjectString.Split(new[] { ' ' });
                var nextSubject = new Subject(float.Parse(arr[0]), int.Parse(arr[1]));
                subjects[i] = nextSubject;
            }
            return subjects;
        }

        private class Subject : IComparable<Subject>
        {
            public float cost;
            public int volume;
            public double pricePerKg;

            public Subject(float c, int w)
            {
                this.cost = c;
                this.volume = w;
                this.pricePerKg = c / w;
            }
            public int CompareTo(Subject newSmth)
            {
                return this.pricePerKg.CompareTo(newSmth.pricePerKg);
            }
        }

    }

}
