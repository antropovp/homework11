using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Homework_11.Repository.Implementation;
using Newtonsoft.Json;

namespace Homework_11.Service.Implementation
{
    public class FileService : IFileService
    {
        public Department readOrganizationFromXMLFile(string filePath)
        {
            Department organization = new Department();

            // Если файл существует, десериализуем содержимое в виде экземпляра организации
            if (File.Exists(filePath))
            {
                try
                {
                    using FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Department));
                    organization = (Department)xmlSerializer.Deserialize(fileStream);
                }
                catch (Exception e)
                {
                    using FileStream fileStream = new FileStream(filePath + ".log", FileMode.Create, FileAccess.Write);
                    byte[] logInfo = new UTF8Encoding(true).GetBytes(e.ToString());
                    fileStream.Write(logInfo, 0, logInfo.Length);
                }
            }

            return organization;
        }

        public Department readOrganizationFromJSONFile(string filePath)
        {
            Department organization = new Department();

            // Если файл существует, десериализуем содержимое в виде экземпляра организации
            try
            {
                organization = JsonConvert.DeserializeObject<Department>(File.ReadAllText(filePath), new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
            }
            catch (Exception e)
            {
                using FileStream fileStream = new FileStream(filePath + ".log", FileMode.Create, FileAccess.Write);
                byte[] logInfo = new UTF8Encoding(true).GetBytes(e.ToString());
                fileStream.Write(logInfo, 0, logInfo.Length);
            }

            return organization;
        }

        public void saveOrganizationToXMLFile(string filePath, Department headDepartment)
        {
            // Создаём файл и помещаем в него сериализованный экземпляр организации
            try
            {
                using FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Department));
                xmlSerializer.Serialize(fileStream, headDepartment);
            }
            catch (Exception e)
            {
                using FileStream fileStream = new FileStream(filePath + ".log", FileMode.Create, FileAccess.Write);
                byte[] logInfo = new UTF8Encoding(true).GetBytes(e.ToString());
                fileStream.Write(logInfo, 0, logInfo.Length);
            }
        }

        public void saveOrganizationToJSONFile(string filePath, Department headDepartment)
        {
            // Создаём файл и помещаем в него сериализованный экземпляр организации
            try
            {
                File.WriteAllText(filePath,JsonConvert.SerializeObject(headDepartment, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    TypeNameHandling = TypeNameHandling.All
                }));
            }
            catch (Exception e)
            {
                using FileStream fileStream = new FileStream(filePath + ".log", FileMode.Create, FileAccess.Write);
                byte[] logInfo = new UTF8Encoding(true).GetBytes(e.ToString());
                fileStream.Write(logInfo, 0, logInfo.Length);
            }
        }
    }
}