using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;

namespace KataFunctions
{
  public abstract class Helper : IAddress
  {
    public List<Address> addresses = new List<Address>();

    public void getAdresses()
    {
      using (StreamReader reader = new StreamReader("addresses.json"))
      {
        string json = reader.ReadToEnd();
        addresses = JsonConvert.DeserializeObject<List<Address>>(json);
        reader.Dispose();
      }
    }

    public string printAddressFromFile()
    {
      StringBuilder sb = new StringBuilder();
      addresses.ForEach(a => sb.Append(a.prettyPrint(a)));
      return sb.ToString();
      }
     

    public string printAddress(int addressCode)
    {
      StringBuilder sb = new StringBuilder();
      switch (addressCode)
      {
        case 1:
          addresses.Where(a => a.type.name.Equals(""));
        
          break;
      }
      return sb.ToString();
    }

    //public bool validateAddress(Address address)
    //{

    //}
  }


}

