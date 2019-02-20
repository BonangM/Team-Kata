using System;
using System.Linq;
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
      public string line1 = "";
      public string line2 = "";
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

      sb.Append(!string.IsNullOrEmpty(address.type.name) + ":");
      sb.Append(!string.IsNullOrEmpty(address.addressLineDetail.line1)+"-");
      sb.Append(!string.IsNullOrEmpty(address.addressLineDetail.line2)+"-");
      sb.Append(!string.IsNullOrEmpty(address.cityOrTown) + "-");
      sb.Append(!string.IsNullOrEmpty(address.provinceOrState.name)+ "-");
      sb.Append(!string.IsNullOrEmpty(address.postalCode) + "-");
      sb.Append(!string.IsNullOrEmpty(address.country.name));
      
      return sb.ToString();
    }

  }
}
