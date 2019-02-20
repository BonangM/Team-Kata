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
      //Arr
      
      var address = new Address();
     var result = address.prettyPrint( new Address { cityOrTown = "Johannesburg", postalCode = "100"});
      Assert.IsNotNull(result);
    }
  }
}
