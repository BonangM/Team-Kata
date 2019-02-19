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
      var detail = new[] { 
        address.type.name,":",
        address.addressLineDetail.line1,"-",
        address.addressLineDetail.line2,"-",
        address.cityOrTown, "-",
        address.provinceOrState.name, "-",
        address.postalCode, "-",
        address.country.name
      };
      string addressDetails = string.Join(",", detail.Where(s => !string.IsNullOrEmpty(s)));

      return addressDetails;
    }

  }
}
