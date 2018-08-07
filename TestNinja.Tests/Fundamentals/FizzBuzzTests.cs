using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.Tests.Fundamentals
{
    [TestFixture]
    public class FizzBuzzTests
    {
        private FizzBuzz fixxBuzz;

        [SetUp]
        public void SetUp()
        {
            fixxBuzz = new FizzBuzz();
        }

        [Test]
        public void GetOutput_NumDivisbleBy35_ReturnsFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);

            Assert.That(result, Is.EqualTo("fizzbuzz").IgnoreCase);
        }

        [Test]
        public void GetOutput_NumDivisbleBy3_ReturnsFizz()
        {
            var result = FizzBuzz.GetOutput(9);

            Assert.That(result, Is.EqualTo("fizz").IgnoreCase);

        }

        [Test]
        public void GetOutput_NumDivisbleBy5_ReturnsBuzz()
        {
            var result = FizzBuzz.GetOutput(10);

            Assert.That(result, Is.EqualTo("Buzz").IgnoreCase);
        }

        [Test]
        public void GetOutput_NumNotDivisbleBy35_ReturnsInput()
        {
            var result = FizzBuzz.GetOutput(1);

            Assert.That(result, Is.EqualTo("1"));
        }
    }
}
