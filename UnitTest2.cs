using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject2
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void Sum_CorrectSumwithMulitpleElements()
        {
            var collection = new List<int> { 1, 2, 3, 4, 5 };

            CollectionMethods target = new CollectionMethods();

            int resultsum = target.Sum(collection);

            Assert.AreEqual(15, resultsum);
        }

        [TestMethod]
        public void Sum_CorrectSumwithSingleElements()
        {
            var collection = new List<int> { 4};

            CollectionMethods target = new CollectionMethods();

            int resultsum = target.Sum(collection);

            Assert.AreEqual(4, resultsum);
        }

        [TestMethod]
        public void Sum_CorrectSumwithNoElements()
        {
            var collection = new List<int> {  };

            CollectionMethods target = new CollectionMethods();

            int resultsum = target.Sum(collection);

            Assert.AreEqual(0, resultsum);
        }

        [TestMethod]
        public void Max_findCorrectMax()
        {
            var collection = new List<int> {1, 3, 7, 44, 24 };

            CollectionMethods target = new CollectionMethods();

            int resultMax = target.Max(collection);

            Assert.AreEqual(44, resultMax);
        }

        [TestMethod]
        public void min_findCorrectMin()
        {
            var collection = new List<int> { 1, 3, 7, 44, 24 };

            CollectionMethods target = new CollectionMethods();

            int resultMin = target.Min(collection);

            Assert.AreEqual(1, resultMin);
        }



    }




    public class CollectionMethods
    {
        public int Sum(ICollection<int> collection)
        {
            int sum = 0;
            foreach (int currentInt in collection)
            {
                sum += currentInt;
            }
            return sum;
        }

        public int Max(ICollection<int> collection)
        {
            int max = 0;
            foreach (int currentInt in collection)
            {
                if (currentInt > max)
                {
                    max = currentInt;
                }
            }
            return max;
        }

        public int Min(ICollection<int> collection)
        {
            int min = int.MaxValue;
            foreach (int currentInt in collection)
            {
                if (currentInt < min)
                {
                    min = currentInt;
                }
            }
            return min;
        }


    }



}
