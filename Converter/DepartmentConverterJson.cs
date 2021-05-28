using System;
using Homework_11.Repository;
using Newtonsoft.Json;

namespace Homework_11.Converter
{
    /// <summary>
    /// JSON конвертер департаментов
    /// </summary>
    /// <typeparam name="TImplementation">Реализация интерфейса IDepartment</typeparam>
    public class DepartmentConverterJson<TImplementation> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            // Даём понять, что это можно конвертировать
            return objectType == typeof(IDepartment);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Конвертируем
            return serializer.Deserialize<TImplementation>(reader);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

    }
}