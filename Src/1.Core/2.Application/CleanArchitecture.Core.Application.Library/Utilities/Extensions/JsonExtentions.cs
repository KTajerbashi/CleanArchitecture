using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CleanArchitecture.Core.Application.Library.Utilities.Extensions;

public static class JsonExtentions
{
    public static string ToJson(this object obj)
    {
        return JsonConvert.SerializeObject(obj, new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        });
    }

    public static T To<T>(this string str)
    {
        return JsonConvert.DeserializeObject<T>(str);
    }
}
