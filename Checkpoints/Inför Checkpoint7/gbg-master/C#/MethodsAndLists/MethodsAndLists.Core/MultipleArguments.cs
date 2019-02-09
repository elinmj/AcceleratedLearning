using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MethodsAndLists.Core.Enums;

namespace MethodsAndLists.Core
{
    public class MultipleArguments
    {
        public List<string> SomeToUpper(List<string> list, List<bool> toUpper)
        {
            var result = new List<string>();
            int index = 0;
            foreach (var word in list)
            {
                if (toUpper[index] == true)
                    result.Add(word.ToUpper());
                else
                    result.Add(word);
                index++;
            }

            return result;
        }

        public List<string> SomeToUpper_Linq(List<string> list, List<bool> toUpper)
        {
            return list.Select((x, index) => toUpper[index] ?

                    list[index].ToUpper() :
                    list[index]

            ).ToList();
        }

        public List<string> SomeToUpper_Zip(List<string> list, List<bool> toUpper)
        {
            return list.Zip(toUpper, (x, up) => up ? x.ToUpper() : x).ToList();
        }
        public List<double> MultiplyAllBy(int factor, List<double> numbers)
        {
            if (numbers == null)
                throw new ArgumentException();

            var result = new List<double>();
            foreach (var number in numbers)
            {
                result.Add(number * factor);
            }

            return result;
        }

        public List<double> MultiplyAllBy_Linq(int factor, List<double> numbers)
        {
            if (numbers == null)
                throw new ArgumentException();

            return numbers.Select(n => n * factor).ToList();
        }


        public List<string> NearbyElements(int position, List<string> list)
        {
            if (position < 0 || position > list.Count - 1)
                throw new ArgumentException();

            var result = new List<string>();

            if (position > 0)
                result.Add(list[position - 1]);

            result.Add(list[position]);

            if (position < list.Count - 1)
                result.Add(list[position + 1]);

            return result;
        }

        public List<List<int>> MultiplicationTable(int rowMax, int colMax)
        {
            if (rowMax <= 0 || colMax <= 0)
                throw new ArgumentException();

            var result = new List<List<int>>();
            for (int rowNumber = 1; rowNumber <= rowMax; rowNumber++)
            {
                var row = new List<int>();
                for (int colNumber = 1; colNumber <= colMax; colNumber++)
                {
                    row.Add(rowNumber * colNumber);
                }
                result.Add(row);
            }

            return result;
        }

        public List<List<int>> MultiplicationTable_Linq(int rowMax, int colMax)
        {
            if (rowMax <= 0 || colMax <= 0)
                throw new ArgumentException();

            return Enumerable.Range(1, rowMax).Select(r => Enumerable.Range(1, colMax).Select(c => c * r).ToList()).ToList();
        }

        public int ComputeSequenceSumOrProduct(int toNumber, bool sum)
        {
            if (sum)
                return ComputeSequence(toNumber, ComputeMethod.Sum);
            else
                return ComputeSequence(toNumber, ComputeMethod.Product);
        }

        public int ComputeSequence(int toNumber, ComputeMethod sum)
        {
            if (toNumber <= 0)
                throw new ArgumentException();

            var range = Enumerable.Range(1, toNumber).ToList();

            switch (sum)
            {
                case ComputeMethod.Sum:
                    return range.Sum();

                case ComputeMethod.Product:
                    return range.Aggregate((a, b) => a * b);

                default:
                    throw new NotImplementedException();
            }
        }

        public int[] CombineLists(int[] list1, int[] list2)
        {
            var result = new List<int>();

            for (int i = 0; i < Math.Max(list1.Length, list2.Length); i++)
            {
                if (i <= list1.Length - 1)
                    result.Add(list1[i]);

                if (i <= list2.Length - 1)
                    result.Add(list2[i]);
            }

            return result.ToArray();
        }


        public int[] RotateList_Queue(int[] list, int rotation)
        {
            if (list == null)
                throw new ArgumentException();

            if (list.Length == 0)
                return list;

            int movetoleft = (rotation < 0 ? -rotation : list.Length - rotation) % list.Length;

            var q = new Queue<int>(list);

            for (int i = 0; i < movetoleft; i++)
                q.Enqueue(q.Dequeue()); // ta bort det första elementet och lägg det sist

            return q.ToArray();
        }

        public int[] RotateList_KG_Special(int[] list, int rotation)
        {
            if (list == null)
                throw new ArgumentException();

            return list.Select((_, index) => list[(index - rotation + list.Length) % list.Length]).ToArray();
        }

        public int[] RotateList_Magnus_Recursion(int[] list, int rotation)
        {
            if (list == null) throw new ArgumentException();
            if (list.Length == 0) return list;

            //rotation = rotation % list.Length; // kan användas för att minska repetitionerna till mindre än två list.längder
            if (rotation < 0) // Stegar bakåt
                return RotateList_Magnus_Recursion(list.Select((x, i) => list[(i + 1) % list.Length]).ToArray(), rotation + 1);

            else if (rotation > 0) // Stegar framåt
                return RotateList_Magnus_Recursion(list.Select((x, i) => list[(i - 1 + list.Length) % list.Length]).ToArray(), rotation - 1);

            return list;
        }

        public int[] RotateList(int[] list, int rotation)
        {
            // list         0 1 2 3 4 5 6
            // rotation     2
            // result       5 6 0 1 2 3 4
            // startIndex   length - rotation = 7 - 2 = 5

            // list         0 1 2 3 4 5 6
            // rotation     -2
            // result       2 3 4 5 6 0 1
            // startIndex   -rotation = 2

            if (list == null)
                throw new ArgumentException();

            if (list.Length == 0)
                return list;

            // Beräkna startIndex

            int startIndex = rotation % list.Length; // rotation 8 är samma som rotation 1 (om längden på listan är 7)
            if (startIndex >= 0)
                startIndex = list.Length - rotation;
            else
                startIndex = -rotation;

            // Plocka ut första och sista delen i listan

            var firstPart = list.Skip(startIndex);
            var lastPart = list.Take(startIndex);

            // Foga ihop listorna

            return firstPart.Concat(lastPart).ToArray();
        }
    }
}
