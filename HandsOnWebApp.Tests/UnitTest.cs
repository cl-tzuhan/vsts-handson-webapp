using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HandsOnWebApp.Test {

    [TestClass]
    public class UnitTest {

        [TestMethod]
        public void TestMethod1() {
            var pvObj = new PrivateObject(new Default());
            var result = pvObj.Invoke("Calculate", "1", "2");
            Assert.AreEqual(3f, result);
        }

        [TestMethod]
        public void TestMethod2() {
            var pvObj = new PrivateObject(new Default());
            try {
                pvObj.Invoke("Calculate", "A", "2");
            } catch (FormatException) {
                return;
            }
            Assert.Fail();
        }
    }
}
