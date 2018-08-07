using System;
using NUnit.Framework;
using TestNinja.Fundamentals;
using Assert = NUnit.Framework.Assert;

namespace TestNinja.Tests.Fundamentals
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _demeritPointsCalculator;

        [SetUp]
        public void InitializeClass()
        {
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(-5)]
        [TestCase(302)]
        public void CalculateDemeritPoints_WhenSpeedIsNegative_ThrowArgOutOfRangeException(int speed)
        {
            Assert.That(() => _demeritPointsCalculator.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        //[Test]
        //[TestCase(65, ExpectedResult = 0)]
        //[TestCase(50, ExpectedResult = 0)]
        //[TestCase(0, ExpectedResult = 0)]
        //[TestCase(67, ExpectedResult = 0)]
        //public int CalculateDemeritPoints_ForSpeedLessThanOrEqualToLimitAndLessThan5MOverLmt_Return0(int speed)
        //{
        //    return _demeritPointsCalculator.CalculateDemeritPoints(speed);
        //}

        [Test]
        [TestCase(65)]
        [TestCase(50)]
        [TestCase(0)]
        [TestCase(67)]
        public void CalculateDemeritPoints_ForSpeedLessThanOrEqualToLimitAndLessThan5MOverLmt_Return0(int speed)
        {
            Assert.That(_demeritPointsCalculator.CalculateDemeritPoints(speed), Is.EqualTo(0));
        }

        [Test]
        public void CalculateDemeritPoints_ForSpeed75Miles_Return2Points()
        {
            var res = _demeritPointsCalculator.CalculateDemeritPoints(75);
            Assert.That(res, Is.EqualTo(2));
        }
    }
}
