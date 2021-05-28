using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Homework_11.Repository;
using Homework_11.Repository.Implementation;
using Newtonsoft.Json;

namespace Homework_11.Service.Implementation
{
    public class FileService : IFileService
    {
        public Department readOrganizationFromXMLFile(string filePath)
        {
            Console.WriteLine("Reading organization from the XML file...");

            Department organization = new Department();

            // Если файл существует, десериализуем содержимое в виде экземпляра организации
            if (File.Exists(filePath))
            {
                try
                {
                    // Не работало
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Department));
                        organization = (Department)xmlSerializer.Deserialize(fileStream);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                Console.WriteLine("Done.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("File doesn't exist.");
            }

            return organization;
        }

        public Department readOrganizationFromJSONFile(string filePath)
        {
            Console.WriteLine("Reading organization from the JSON file...");

            Department organization = new Department();

            // Если файл существует, десериализуем содержимое в виде экземпляра организации
            try
            {
                organization = JsonConvert.DeserializeObject<Department>(File.ReadAllText(filePath));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Done.");
            Console.WriteLine();

            return organization;
        }

        public void saveOrganizationToXMLFile(string filePath, Department headDepartment)
        {
            Console.WriteLine("Saving organization to an XML file...");

            // Создаём файл и помещаем в него сериализованный экземпляр организации
            try
            {
                // Не работало
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Department));
                    xmlSerializer.Serialize(fileStream, headDepartment);
                }

                // Работало только так
                //
                // // Сериализуем в JSON формат
                // string json = JsonConvert.SerializeObject(headDepartment, new JsonSerializerSettings
                // {
                //     ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                // });
                //
                // // Конвертируем в XML и записываем в файл
                // XDocument xml = JsonConvert.DeserializeXNode(json, "Department");
                // using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                // {
                //     xml.Save(fileStream);
                // }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Done.");
            Console.WriteLine();
        }

        public void saveOrganizationToJSONFile(string filePath, Department headDepartment)
        {
            Console.WriteLine("Saving organization to a JSON file...");

            // Создаём файл и помещаем в него сериализованный экземпляр организации
            try
            {
                File.WriteAllText(filePath,JsonConvert.SerializeObject(headDepartment, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Done.");
            Console.WriteLine();
        }
    }
}