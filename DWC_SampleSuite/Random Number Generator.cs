using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DWC_SampleSuite
{
    [TestClass]
   public class RandomNumberGen
    {
        private readonly Random _random = new Random();

        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

    //    [TestMethod]
        public void PrintRand()
        {
            Console.WriteLine(RandomNumber(1,10));

        }
            
    }
}
