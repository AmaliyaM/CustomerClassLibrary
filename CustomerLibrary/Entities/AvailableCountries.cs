using System.Runtime.Serialization;
namespace CustomerInformation
{
    public enum AvailableCountries
    {

        [EnumMember(Value = "Canada")]
        Canada,

        [EnumMember(Value = "United States")]
        US
    }
}

