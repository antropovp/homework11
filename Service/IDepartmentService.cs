using System.Collections.Generic;
using Homework_11.Repository;
using Homework_11.Repository.Implementation;

namespace Homework_11.Service
{
    /// <summary>
    /// Сервис для работы с департаментами
    /// </summary>
    public interface IDepartmentService
    {
        /// <summary>
        /// Создание департамента
        /// </summary>
        /// <returns></returns>
        Department createDepartment(Department parentDepartment);

        /// <summary>
        /// Изменение департамента
        /// </summary>
        /// <param name="department">Департамент</param>
        Department changeDepartment(Department department);

        /// <summary>
        /// Удаление всех сотрудников из департамента
        /// </summary>
        /// <param name="department">Департамент</param>
        void clearWorkers(Department department);

        /// <summary>
        /// Удаление всех вложенных департаментов
        /// </summary>
        /// <param name="department">Департамент</param>
        void clearDepartments(Department department);

        /// <summary>
        /// Удаление департамента
        /// </summary>
        /// <param name="department">Департамент</param>
        void deleteDepartment(Department department);

        /// <summary>
        /// Удаление нескольких департаментов
        /// </summary>
        /// <param name="parentDepartment">Родительский департамент</param>
        /// <param name="departments">Список департаментов</param>
        void deleteDepartments(Department parentDepartment, List<Department> departments);

        /// <summary>
        /// Удаление департаментов по дате создания
        /// </summary>
        /// <param name="parentDepartment">Родительский департамент</param>
        void deleteDepartmentsByDateOfCreation(Department parentDepartment);

        /// <summary>
        /// Удаление департаментов по названию
        /// </summary>
        /// <param name="parentDepartment">Родительский департамент</param>
        void deleteDepartmentsByName(Department parentDepartment);

        /// <summary>
        /// Удаление департаментов по количеству сотрудников
        /// </summary>
        /// <param name="parentDepartment">Родительский департамент</param>
        void deleteDepartmentsByWorkersCount(Department parentDepartment);
    }
}