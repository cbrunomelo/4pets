using Application.Dtos.Contracts;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Api.Conf
{
    public class IDtoJsonConverter<T> : JsonConverter<T> where T : IDto
    {
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            var type = value.GetType();

            JsonSerializer.Serialize(writer, value, type, options);
        }
    }
}
