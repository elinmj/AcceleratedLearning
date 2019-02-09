using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MyTestProject.YieldLab
{
    [TestClass]
    public class Yield1
    {
        [TestMethod]
        public void MyTestMethod()
        {
            int index = 0;
            double result = 0; 

            foreach (var number in GetAllNumbers())
            {
                if (index == 5)
                {
                    result = number;
                    break;
                }
                index++;
            }
            Assert.AreEqual(Math.Sin(5), result);
        }

        [TestMethod]
        public void MyTestMethod_Yield()
        {
            int index = 0;
            double result = 0;

            foreach (var number in GetAllNumbers_Yield())
            {
                if (index == 5)
                {
                    result = number;
                    break;
                }
                index++;
            }
            Assert.AreEqual(Math.Sin(5), result);
        }

        private IEnumerable<double> GetAllNumbers()
        {
            var list = new List<double>();
            for (long i = 0; i < 100000000; i++)
            {
                list.Add(Math.Sin(i));
            }
            return list;
        }



        private IEnumerable<double> GetAllNumbers_Yield()
        {
            for (double i = 0; i < 100000000; i++)
            {
                yield return Math.Sin(i);
            }
        }
    }
}
