using System;
using System.Collections.Generic;
using System.Linq;

namespace Modul11
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 5, 11, 89, 3, 10, 4 };

            //StarifyList(list);
            Console.WriteLine(string.Join(",", StarifyList(list)));

            //Console.WriteLine(string.Join(",", NumberHigherThanFive(list)));

            //foreach (int x in result)
            //{
            //    Console.WriteLine(x);
            //}


            //int sum = Sum(list);
            //Console.WriteLine(sum);
            //double avg = Average(list);
            //Console.WriteLine(avg);
        }

        private static List<string> StarifyList(List<int> list)
        {
            //List<string> stars = new List<string>();          //Utan Linq

            //foreach (var item in list)
            //{
            //    stars.Add("* " + item.ToString());
            //}

            //return stars;

            List<string> stars = list.Select(x => "*" + x + "*").ToList();          //Linq
            return stars;
        }

        //private static List<int> NumberHigherThanFive(List<int> list)
        //{
        //    List<int> numbersHigherThanFive = list.Where(x => x > 5).ToList();
        //    return numbersHigherThanFive;


        //List<int> numbersHigherThanFive = new List<int>();            //Utan Linq

        //foreach (var item in list)
        //{
        //    if (item > 5)
        //    {
        //        numbersHigherThanFive.Add(item);
        //    }
        //}

        //foreach (var item in numbersHigherThanFive)
        //{
        //    Console.WriteLine(item);
        //}

        //return numbersHigherThanFive;
        //}

        //private static int Sum(List<int> list)
        //{

        //    int total = 0;                //Utan Linq

        //    foreach (var item in list)
        //    {
        //        int summa = item + total;
        //        total = summa;
        //    }

        //    return total;

        //    int summa = list.Sum();       //Linq
        //    return summa;
        //}

        //private static double Average(List<int> list)
        //{
        //    int total = 0;                //utan Linq

        //    foreach (var item in list)
        //    {
        //        int summa = item + total;
        //        total = summa;
        //    }

        //    double medeltal = total / list.Count;
        //    return medeltal;


        //    double medeltal = list.Average();             //Linq
        //    return medeltal;
        //}
    }
}
