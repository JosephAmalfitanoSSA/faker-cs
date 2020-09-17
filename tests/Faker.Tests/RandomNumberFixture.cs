﻿using System;
using System.Linq;
using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    public class RandomNumberFixture
    {
        [TestCase(1, "Coin flip")] // 0 ... 1 Coin flip
        [TestCase(6, "6 sided die")] // 0 .. 6
        [TestCase(9, "Random single digit")] // 0 ... 9
        [TestCase(20, "D20")] // 0 ... 20  The signature dice of the dungeons and dragons
        public void Should_Yield_All_ValuesWithinRange(int maxValue, string testName)
        {
            var maxExclusiveLimit = maxValue + 1;
            Console.WriteLine($@"RandomNumber.Next [{testName}]");
            var results = Enumerable.Range(0, maxExclusiveLimit).ToDictionary(k => k, k => false);
            do
            {
                var coinFlip = RandomNumber.Next(0, maxExclusiveLimit);
                results[coinFlip] = true;
                Console.WriteLine($@"RandomNumber.Next(0,maxValueExclusive)=[{coinFlip}]");
            } while (!results.All(j => j.Value));
            Assert.IsTrue(results.Select(z => z.Value).All(y => y));
        }

        [Test]
        public void Should_Create_Zero()
        {
            var zero = RandomNumber.Next(0, 0);
            Console.WriteLine($@"RandomNumber.Next(0,0)=[{zero}]");
            Assert.IsTrue(zero == 0);
        }
    }
}