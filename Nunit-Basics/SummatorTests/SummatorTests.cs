using ConsoleAppSummator;
using NUnit.Framework;

namespace SummatorTests
{
    public class SummatorTests
    {

        [Test]
        public void Test_PossitiveNumber()
        {
            double actual = Summator.Sum(new double[] {5});

            Assert.Positive(actual);
        }

        [Test]
        public void Test_NegativeNumber()
        {
            double actual = Summator.Sum(new double[] { -5 });

            Assert.Negative(actual);
        }

        [Test]
        public void Test_Sum_PossitiveNumbers()
        {
            double actual = Summator.Sum(new double[] { 3,5,7 });

            double expected = 15;

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Test_Sum_NegativeNumbers()
        {
            double actual = Summator.Sum(new double[] { -3, -5, -7 });

            double expected = -15;

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Test_Sum_EmptyArray()
        {
            double actual = Summator.Sum(new double[] { });

            Assert.That(actual == 0);
        }

        [Test]
        public void Test_Average_TwoPossitiveNumbers()
        {
            double actual = Summator.Average(new double[] { 5,6,7,8,9,10,11 });

            double expected = 8;

            Assert.That(expected == actual);
        }

        [Test]
        public void Test_Average_NegativeNumbers()
        {
            double actual = Summator.Average(new double[] { -5, -10 , -15 , -20, - 25 });

            double expected = -15;

            Assert.That(expected == actual);
        }
    }
}