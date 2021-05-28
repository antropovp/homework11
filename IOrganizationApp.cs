using Homework_11.Entity;
using Homework_11.Repository;
using Homework_11.Repository.Implementation;

namespace Homework_11
{
    public interface IOrganizationApp
    {
        /// <summary>
        /// Запуск приложения
        /// </summary>
        void start();

        /// <summary>
        /// Главное меню
        /// </summary>
        void organizationMenu();

        /// <summary>
        /// Вывод департамента в консоль
        /// </summary>
        /// <param name="department">Департамент</param>
        void printDepartment(Department department);

        /// <summary>
        /// Вывод сотрудника в консоль
        /// </summary>
        /// <param name="worker">Сотрудник</param>
        void printWorker(Worker worker);

        /// <summary>
        /// Вывод вложенных департаментов в консоль
        /// </summary>
        /// <param name="parentDepartment">Родительский департамент</param>
        void printDepartments(Department parentDepartment);

        /// <summary>
        /// Вывод сотрудников департамента в консоль
        /// </summary>
        /// <param name="department">Департамент</param>
        void printWorkers(Department department);

        /// <summary>
        /// Меню департамента
        /// </summary>
        /// <param name="department">Департамент</param>
        void departmentMenu(Department department);

        /// <summary>
        /// Меню сотрудника
        /// </summary>
        /// <param name="worker">Сотрудник</param>
        void workerMenu(Worker worker);

        /// <summary>
        /// Меню сортировки департаментов
        /// </summary>
        /// <param name="parentDepartment">Родительский департамент</param>
        void sortDepartmentsMenu(Department parentDepartment);

        /// <summary>
        /// Меню сортировки сотрудников
        /// </summary>
        /// <param name="department">Департамент</param>
        void sortWorkersMenu(Department department);

        /// <summary>
        /// Меню удаления департаментов
        /// </summary>
        /// <param name="parentDepartment">Родительский департамент</param>
        void deleteDepartmentsMenu(Department parentDepartment);

        /// <summary>
        /// Меню удаления сотрудников
        /// </summary>
        /// <param name="department">Департамент</param>
        void deleteWorkersMenu(Department department);

        /// <summary>
        /// Получение пути файла для данных организации
        /// </summary>
        string getFilePath();

        /// <summary>
        /// Загрузка данных организации из файла
        /// </summary>
        void loadOrganization();

        /// <summary>
        /// Сохранение данных организации в файл
        /// </summary>
        void saveOrganization();

        /// <summary>
        /// Выход из приложения
        /// </summary>
        void exit();
    }
}