using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MethodsAndLists.Core.Enums;

namespace MethodsAndLists.Core
{
    public class MultipleArguments
    {
        public int ComputeSequenceSumOrProduct(int toNumber, bool sum)
        {
            if (toNumber <= 0)
            {
                throw new ArgumentException();
            }
                
            if (sum == true)
            {
                int total = 1;

                for (int i = 2; i <= toNumber; i++)
                {
                    int summa = total + i;
                    total = summa;
                }

                return total;
            }
            else
            {
                int total = 1;

                for (int i = 2; i <= toNumber; i++)
                {
                    int summa = total * i;
                    total = summa;
                }

                return total;
            }
        }

        public int ComputeSequence(int toNumber, ComputeMethod sum)
        {
            if (toNumber <= 0)
            {
                throw new ArgumentException();
            }

            if (sum == ComputeMethod.Sum)
            {
                int total = 1;

                for (int i = 2; i <= toNumber; i++)
                {
                    int summa = total + i;
                    total = summa;
                }

                return total;
            }
            else
            {
                int total = 1;

                for (int i = 2; i <= toNumber; i++)
                {
                    int summa = total * i;
                    total = summa;
                }

                return total;
            }
        }

        public List<string> NearbyElements(int position, List<string> list)
        {
            if (position > list.Count -1 || position < 0)
            {
                throw new ArgumentException();
            }
           
            //List<string> newList = new List<string>();

            //if (position > 0)
            //{
            //    newList.Add(list[position-1]);
            //}

            //newList.Add(list[position]);

            //if (position < list.Count-1)
            //{
            //    newList.Add(list[position+1]);
            //}

            //return newList;

            return list.Where((a, x) => x == position - 1 || x == position || x == position + 1).ToList();
        }

        public List<double> MultiplyAllBy(int factor, List<double> numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentException();
            }

            List<double> list = new List<double>();

            foreach (var item in numbers)
            {
                double newNumbers = item * factor;
                list.Add(newNumbers);
            }

            return list;
        }

        public List<double> MultiplyAllBy_Linq(int factor, List<double> numbers)
        {

            if (numbers == null)
            {
                throw new ArgumentException();
            }

            return numbers.Select(x => x * factor).ToList();
        }

        public List<string> SomeToUpper(List<string> list, List<bool> toUpper)
        {
            List<string> newList = new List<string>();

            //int counter = 0;

            //foreach (var item in list)
            //{
            //    
            //  if (toUpper[counter] == true)
            //    {
            //        newList.Add(item.ToUpper());
            //    }
            //    else
            //    {
            //        newList.Add(item);
            //    }

            //    counter++;
            //}

            //return newList;

            return list.Select((a,x) => toUpper[x] == true ? a.ToUpper() : a).ToList();

        }

        public List<List<int>> MultiplicationTable(int rowMax, int colMax)
        {
            if (rowMax <= 0 || colMax <= 0)
            {
                throw new ArgumentException();
            }

            List<List<int>> list = new List<List<int>>();

            for (int i = 1; i <= rowMax; i++)
            {
                List<int> x = new List<int>();

                for (int j = 1; j <= colMax; j++)
                {
                    x.Add(i * j);
                }

                list.Add(x);
            }

            return list;
        }

        public List<List<int>> MultiplicationTable_Linq(int rowMax, int colMax)
        {
            throw new NotImplementedException();
        }
         
        public int[] CombineLists(int[] list1, int[] list2)
        {
            List<int> newList = new List<int>();

            for (int i = 0; i < list1.Length + list2.Length; i++)
            {
                if (i < list1.Length)
                {
                    newList.Add(list1[i]);
                }

                if (i < list2.Length)
                {
                    newList.Add(list2[i]);
                }
            }

            return newList.ToArray();

            //return list1.Concat(list2).ToArray();

        }

        public int[] RotateList(int[] list, int rotation)
        {
            if (list == null)
            {
                throw new ArgumentException();
            }
            
            List<int> newList = list.ToList();
            //newList.AddRange(list);

            if (rotation == 0 || list.Length <= 0)
            {
                return list;
            }

            else if (rotation > 0)
            {
                for (int i = 0; i < rotation; i++)
                {
                    int last = newList[newList.Count-1];
                    newList.RemoveAt(newList.Count - 1);
                    newList.Insert(0,last);
                }
            }

            else
            {
                for (int i = 0; i > rotation; i--)
                {
                    int first = newList[0];
                    newList.RemoveAt(0);
                    newList.Add(first);
                }
            }

            return newList.ToArray();
        }
    }
}
