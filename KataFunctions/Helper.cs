using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System;

namespace KataFunctions
{
  public abstract class Helper 
  {
    public static List<Address> addresses = new List<Address>();

    public static List<Address> getAdresses()
    {
      using (StreamReader reader = new StreamReader("addresses.json"))
      {
        string json = reader.ReadToEnd();
        var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

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
      string a = address.prettyPrint(address);
      if (isNumeric(address.postalCode) && !string.IsNullOrEmpty(address.country.name))
      {
        if (address.addressLineDetail != null) {
          if (!string.IsNullOrEmpty(address.addressLineDetail.line1) || !string.IsNullOrEmpty(address.addressLineDetail.line2))
            return true;
        }
        if (address.country.code.Equals("ZA") && (address.provinceOrState != null))
        {
          if (!string.IsNullOrEmpty(address.provinceOrState.name))
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
      foreach (var address in addresses) {

        string a = address.prettyPrint(address);
        sb.Append(a);
        string[] array = a.Split( '-',':');
        //0:type 1:line1 2:line2 3.city 4:province 5:postalcode 6:country
        if (validateAddress(address) == false)
        {
          if (!isNumeric(array[5])) sb.Append("Postal Code must be numbers|");
          if (string.IsNullOrEmpty(array[5])) sb.Append("Country is required|");
          if (address.addressLineDetail == null) sb.Append("Line Detail not in file|");
          if (address.addressLineDetail != null)
          {
            if (string.IsNullOrEmpty(array[1]) && string.IsNullOrEmpty(array[2])) sb.Append("Atleast one address line detail is required|");
          }
          if (address.country.code.Equals("ZA"))
          {
            if (address.provinceOrState != null)
            {
              if (string.IsNullOrEmpty(address.provinceOrState.name)) sb.Append("Province required when Country is South Africa");
            }
            sb.Append("Province not in file|");
          }
        }
        sb.Append("ValidAddress|");
      }
      return sb.ToString();
    }


  }
}

