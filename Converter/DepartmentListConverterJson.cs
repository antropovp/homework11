using System;
using System.Collections.Generic;
using Homework_11.Repository;
using Newtonsoft.Json;

namespace Homework_11.Converter
{
    /// <summary>
    /// JSON конвертер списка департаментов
    /// </summary>
    /// <typeparam name="TImplementation">Реализация интерфейса IDepartment</typeparam>
    public class DepartmentListConverterJson<TImplementation> : JsonConverter where TImplementation : IDepartment
    {
        public override bool CanConvert(Type objectType)
        {
            // Даём понять, что это можно конвертировать
            return objectType == typeof(IDepartment);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Конвертируем
            var res = serializer.Deserialize<List<TImplementation>>(reader);
            return res.ConvertAll(x => (IDepartment)x);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}