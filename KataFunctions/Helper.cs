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

    public static string printAddressFromFile()
    {
      StringBuilder sb = new StringBuilder();
      addresses.ForEach(a => sb.Append(a.prettyPrint(a)));
      return sb.ToString();
      }

    public static string printAddress(int addressCode)
    {
      StringBuilder sb = new StringBuilder();
      switch (addressCode)
      {
        case 1:
          addresses.Where(a => a.type.name.Equals("Physical Address")).ToList()
            .ForEach(a => sb.Append(a.prettyPrint(a)));
          break;
        case 2:
          addresses.Where(a => a.type.name.Equals("Postal Address")).ToList()
            .ForEach(a => sb.Append(a.prettyPrint(a)));
          break;
        case 3:
          addresses.Where(a => a.type.name.Equals("Business Address")).ToList()
            .ForEach(a => sb.Append(a.prettyPrint(a)));
          break;
      }
      return sb.ToString();
    }

    public static bool isNumeric(string s)
    {
      int output;
      return int.TryParse(s, out output);
    }

    public static bool validateAddress(Address address)
    {
      if (isNumeric(address.postalCode) && !string.IsNullOrEmpty(address.country.name))
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

    public static string isValid()
    {
      StringBuilder sb = new StringBuilder();
      foreach(var address in addresses) {
      sb.Append(address.prettyPrint(address));
     if(validateAddress(address) == false)
      {
        if (!isNumeric(address.postalCode)) sb.Append( "Postal Code must be numbers");
        if (string.IsNullOrEmpty(address.country.name)) sb.Append("Country is required");
        if (string.IsNullOrEmpty(address.addressLineDetail.line1) && string.IsNullOrEmpty(address.addressLineDetail.line2)) sb.Append( "Atleast one address line detail is required");
        if (address.country.code.Equals("ZA") && string.IsNullOrEmpty(address.provinceOrState.name)) sb.Append( "Province required when Country is South Africa") ;
      }
      }
      return sb.ToString();
    }
  }


}

