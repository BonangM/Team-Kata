using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace KataFunctions
{
  //The purpose of this class is to provide some re-usabilty and avoid giving too much methods to the address class
  public class Helper
  {
    
    public string prettyPrintJson()
    {
      string result = null;
      Address address = new Address();
      using (StreamReader reader = new StreamReader("addresses.json"))
      {
        string json = reader.ReadToEnd();
        var addresses = JsonConvert.DeserializeObject<List<Address>>(json);
        foreach (var obj in addresses)
        {
          result = address.prettyPrint(obj);
        }
      }

      return result;
    }

    public string printAddress(string addressType)
    {
      return "print all addresses of type";
    }

    //public bool validateAddress(Address address)
    //{

    //}
  }


}

