using System;
using NUnit.Framework;


namespace ChildGrowthTest
{
    [TestFixture]
    public class TestsSample
    {

        [SetUp]
        public void Setup() { }


        [TearDown]
        public void Tear() { }

        [Test]
        public void AssertAddChild()
        {
            Console.WriteLine("test1");
            Assert.True(true);
        }

        [Test]
        public void AssertRemoveChild()
        {
            Console.WriteLine("test1");
            Assert.True(true);
        }

        [Test]
        public void AssertReadChild()
        {
            Console.WriteLine("test1");
            Assert.True(true);
        }

        [Test]
        public void AssertWriteChild()
        {
            Console.WriteLine("test1");
            Assert.True(true);
        }

        [Test]
        public void AssertGraphUpdate()
        {
            Console.WriteLine("test1");
            Assert.True(true);
        }

        [Test]
        public void AssertMeasurementUpdate()
        {
            Console.WriteLine("test1");
            Assert.True(true);
        }

        [Test]
        public void AssertMilestonesUpdate()
        {
            Console.WriteLine("test1");
            Assert.True(true);
        }

        [Test]
        public void AssertMeasurementsUpdate()
        {
            Console.WriteLine("test1");
            Assert.True(true);
        }
        [Test]
        public void AssertVaccinationsUpdate()
        {
            Console.WriteLine("test1");
            Assert.True(true);
        }

        [Test]
        public void AssertInsightsUpdate()
        {
            Console.WriteLine("test1");
            Assert.True(true);
        }

        [Test]
        [Ignore("another time")]
        public void Ignore()
        {
            Assert.True(false);
        }

        [Test]
        public void Inconclusive()
        {
            Assert.Inconclusive("Inconclusive");
        }
    }
}