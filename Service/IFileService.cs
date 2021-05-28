using Homework_11.Repository;
using Homework_11.Repository.Implementation;

namespace Homework_11.Service
{
    public interface IFileService
    {
        /// <summary>
        /// Чтение организации из XML файла
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns></returns>
        Department readOrganizationFromXMLFile(string filePath);

        /// <summary>
        /// Чтение организации из JSON файла
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns></returns>
        Department readOrganizationFromJSONFile(string filePath);

        /// <summary>
        /// Сохранение организации в XML файл
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <param name="headDepartment">Организация</param>
        void saveOrganizationToXMLFile(string filePath, Department headDepartment);

        /// <summary>
        /// Сохранение организации в JSON файл
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <param name="headDepartment">Организация</param>
        void saveOrganizationToJSONFile(string filePath, Department headDepartment);
    }
}