using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NetCoreLiteDB
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object obj)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));

            return JsonSerializer.Serialize(obj, options);
        }
    }
}