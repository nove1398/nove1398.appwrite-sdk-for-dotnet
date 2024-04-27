using System;
using Appwrite.Enums;
using Newtonsoft.Json;

namespace Appwrite.Converters
{
    public class ValueClassConverter : JsonConverter {

        public override bool CanConvert(System.Type objectType)
        {
            return typeof(IEnum).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = (string)reader.Value;
            var constructor = objectType.GetConstructor(new[] { typeof(string) });
            var obj = constructor.Invoke(new object[] { value });

            return Convert.ChangeType(obj, objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var type = value.GetType();
            var property = type.GetProperty(nameof(IEnum.Value));
            var propertyValue = property.GetValue(value);

            if (propertyValue == null)
            {
                writer.WriteNull();
                return;
            }

            writer.WriteValue(propertyValue);
        }
    }
}
