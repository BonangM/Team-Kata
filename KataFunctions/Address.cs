using System;
using System.Text;

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

      StringBuilder sb = new StringBuilder();
      //string addressDetails = string.Join("",)
      
      sb.Append("Type: " + !string.IsNullOrEmpty(address.type.name));
      sb.Append("Line Details:" + !string.IsNullOrEmpty(address.addressLineDetail.line1 + address.addressLineDetail.line2));
      sb.Append(address.cityOrTown);
      sb.Append(address.provinceOrState.name);
      sb.Append(address.postalCode.ToString());
      sb.Append(address.country.name);

      return sb.ToString();
    }

  }
}
