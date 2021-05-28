using System.Collections.Generic;
using Homework_11.Entity;
using Homework_11.Repository;
using Homework_11.Repository.Implementation;

namespace Homework_11.Service
{
    /// <summary>
    /// Сервис для работы с сотрудниками
    /// </summary>
    public interface IWorkerService
    {
        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <returns></returns>
        Worker createWorker(Department department);

        /// <summary>
        /// Изменение сотрудника
        /// </summary>
        /// <param name="worker">Сотрудник</param>
        Worker changeWorker(Worker worker);

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <param name="worker">Сотрудник</param>
        void deleteWorker(Worker worker);

        /// <summary>
        /// Удаление нескольких сотрудников
        /// </summary>
        /// <param name="department">Департамент</param>
        /// <param name="workers">Список сотрудников</param>
        void deleteWorkers(Department department, List<Worker> workers);

        /// <summary>
        /// Удаление сотрудников по фамилии
        /// </summary>
        /// <param name="department">Департамент</param>
        void deleteWorkersByLastName(Department department);

        /// <summary>
        /// Удаление сотрудников по имени
        /// </summary>
        /// <param name="department">Департамент</param>
        void deleteWorkersByFirstName(Department department);

        /// <summary>
        /// Удаление сотрудников по возрасту
        /// </summary>
        /// <param name="department">Департамент</param>
        void deleteWorkersByAge(Department department);

        /// <summary>
        /// Удаление сотрудников по зарплате
        /// </summary>
        /// <param name="department">Департамент</param>
        void deleteWorkersBySalary(Department department);

        /// <summary>
        /// Удаление сотрудников по количеству проектов
        /// </summary>
        /// <param name="department">Департамент</param>
        void deleteWorkersByProjectsCount(Department department);
    }
}