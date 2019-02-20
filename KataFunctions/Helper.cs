using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;

namespace KataFunctions
{
  public abstract class Helper : IAddress
  {
    public static List<Address> addresses = new List<Address>();

    public static List<Address> getAdresses()
    {
      using (StreamReader reader = new StreamReader("addresses.json"))
      {
        string json = reader.ReadToEnd();
        var settings = new JsonSerializerSettings{NullValueHandling = NullValueHandling.Ignore};

        addresses = JsonConvert.DeserializeObject<List<Address>>(json, settings);
        reader.Dispose();
      }
      return addresses;
    }

    public string printAddressFromFile()
    {
      StringBuilder sb = new StringBuilder();
      addresses.ForEach(a => sb.Append(a.prettyPrint(a)));
      return sb.ToString();
      }

    public enum AddressTypeCode {
      Physical = 1,
      Postal = 2,
      Business = 3,
     
    }

    public static string printAddress(AddressTypeCode addressCode)
    {
      StringBuilder sb = new StringBuilder();
      switch (addressCode)
      {
        case AddressTypeCode.Physical:
          addresses.Where(a => a.type.name.Equals("Physical Address")).ToList()
            .ForEach(a => sb.Append(a.prettyPrint(a)));
          break;
        case AddressTypeCode.Postal:
          addresses.Where(a => a.type.name.Equals("Postal Address")).ToList()
            .ForEach(a => sb.Append(a.prettyPrint(a)));
          break;
        case AddressTypeCode.Business:
          addresses.Where(a => a.type.name.Equals("Business Address")).ToList()
            .ForEach(a => sb.Append(a.prettyPrint(a)));
          break;
      }
      return sb.ToString();
    }

    public bool isNumeric(string s)
    {
      int output;
      return int.TryParse(s, out output);
    }
    public bool validateAddress(Address address)
    {
      if (!isNumeric(address.postalCode) && !string.IsNullOrEmpty(address.country.name))
      {
        if (!string.IsNullOrEmpty(address.addressLineDetail.line1) || !string.IsNullOrEmpty(address.addressLineDetail.line2))
        {
          if(address.country.code.Equals("ZA") && !string.IsNullOrEmpty(address.provinceOrState.name))
          {
            return true;
          }
        }
      }
      return false;
    }

    public string isValid(Address address)
    {
      bool result;
      string message = "";
      addresses.Where(a => validateAddress(a) == true);
      return message = "Good job";
    }
  }


}

