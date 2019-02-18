using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace KataFunctions
{
  public class Address
  {
    public string id { get; set; }
    public Type type { get; set; }
    public AddressLineDetail addressLineDetail { get; set; }
    public ProvinceOrState provinceOrState { get; set; }
    public string cityOrTown { get; set; }
    public Country country { get; set; }
    public string postalCode { get; set; }
    public DateTime lastUpdated { get; set; }
    public string suburbOrDistrict { get; set; }

    public class Type
    {
      public string code { get; set; }
      public string name { get; set; }
    }

    public class AddressLineDetail
    {
      public string line1 { get; set; }
      public string line2 { get; set; }
    }

    public class ProvinceOrState
    {
      public string code { get; set; }
      public string name { get; set; }
    }

    public class Country
    {
      public string code { get; set; }
      public string name { get; set; }
    }

    public string prettyPrint(Address address)
    {
      string result = null;

      StringBuilder sb = new StringBuilder();
      sb.Append("Type: " + address.type.name);
      sb.Append("Line Details:" + address.addressLineDetail.line1 + address.addressLineDetail.line2);
      sb.Append(address.cityOrTown);
      sb.Append(address.provinceOrState.name);
      sb.Append(address.postalCode.ToString());
      sb.Append(address.country.name);
     
      return result = sb.ToString();
    }
   
    public string prettyPrintJson()
    {
      string result = null;
      using (StreamReader reader = new StreamReader("addresses.json"))
      {
        string json = reader.ReadToEnd();
        var addresses = JsonConvert.DeserializeObject<List<Address>>(json);
        foreach (var obj in addresses)
        {
          result = prettyPrint(obj);
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
