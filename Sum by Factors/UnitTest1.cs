using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Sum_by_Factors
{
    [TestFixture]
    public class SumOfDividedTests
    {
        [Test]
        public void Test1()
        {
            int[] lst = new int[] { 12, 15 };
            Assert.AreEqual("(2 12)(3 27)(5 15)", SumOfDivided.sumOfDivided(lst));
        }
        [Test]
        public void Test2()
        {
            int[] lst = new int[] { 15, 21, 24, 30, 45 };
            Assert.AreEqual("(2 54)(3 135)(5 90)(7 21)", SumOfDivided.sumOfDivided(lst));
        }
        [Test]
        public void Test3()
        {
            int[] lst = new int[] { 114, 237, 421 };
            Assert.AreEqual("(2 114)(3 351)(19 114)(79 237)(421 421)", SumOfDivided.sumOfDivided(lst));
        }
        [Test]
        public void Test4()
        {
            int[] lst = new int[] { -10, -5, 12 };
            Assert.AreEqual("(2 2)(3 12)(5 -15)", SumOfDivided.sumOfDivided(lst));
        }
        public class SumOfDivided
        {
            public static List<List<int>> lst_Factor = new List<List<int>> { };
            public static string sumOfDivided(int[] lst)
            {
                int sum = 0;
                string ans = "";
                var CF = Common_Factorization(lst);
                List<int> result = new List<int> { };
                foreach (var factor in CF)
                {
                    for (int i = 0; i < lst_Factor.Count(); i++)
                        if (lst_Factor[i].Contains(factor))
                            sum += lst[i];
                    result.Add(sum);
                    sum = 0;
                }
                for (int i = 0; i < result.Count(); i++)
                {
                    ans += "(" + CF[i].ToString() + " " + result[i].ToString() + ")";
                }
                lst_Factor.Clear();
                return ans;
            }
            public static List<int> Common_Factorization(int[] lst)
            {
                List<int> result = new List<int> { };
                for (int i = 0; i < lst.Length; i++)
                {
                    result = result.Union(Factorization(lst[i])).OrderBy(n => n).ToList();
                }
                return result;
            }
            public static List<int> Factorization(int num)
            {
                List<int> result = new List<int> { };
                while (num > 1 || num < -1)
                {
                    for (int i = 2; i <= Math.Abs(num); i++)
                    {
                        if (num % i == 0)
                        {
                            result.Add(i);
                            num /= i;
                            break;
                        }
                    }
                }
                lst_Factor.Add(result.Distinct().ToList());
                return result.Distinct().ToList();
            }
        }
    }
}
