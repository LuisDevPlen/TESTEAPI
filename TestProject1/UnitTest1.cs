using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            [TestInitialize]
            public void iniciarTestes()
            {

            }

            [TestMethod]
            public void TestMethod1()
            {
            }
            [TestCleanup]
            public void finalizar()
            {

            }

        }
    }
}