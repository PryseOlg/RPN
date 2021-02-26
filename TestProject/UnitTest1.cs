using NUnit.Framework;
using RPNLogic;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPlus()
        {
            Assert.AreEqual(NotationConverter.ToPostFix("2+2"), "2 2 +");
            Assert.Pass();
        }
        
        [Test]
        public void TestIncorrect()
        {
            Assert.AreNotEqual(NotationConverter.ToPostFix("2+2"), "22+");
            Assert.Pass();
        }
    }
}