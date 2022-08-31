using System.Runtime.Serialization;
namespace CustomerLibrary.Entities
{
    public enum AvailableCountries
    {

        [EnumMember(Value = "Canada")]
        Canada,

        [EnumMember(Value = "United States")]
        US
    }
}

