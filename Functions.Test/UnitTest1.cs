using System;
using KataFunctions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static KataFunctions.Address;

namespace Functions.Test
{
  [TestClass]
  public class AddressTestClass
  {
    [TestMethod]
    public void TestAddress_PrettyPrint_ReturnsTrue()
    {
      //Arrange
      var address = new Address();
      Helper.getAdresses();
    }
  }
}
