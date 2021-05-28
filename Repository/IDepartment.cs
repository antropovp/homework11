using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Homework_11.Entity;
using Homework_11.Repository.Implementation;

namespace Homework_11.Repository
{
    /// <summary>
    /// Департамент
    /// </summary>
    public interface IDepartment
    {
        /// <summary>
        /// Дата создания департамента
        /// </summary>
        DateTime DateOfCreation { get; set; }

        /// <summary>
        /// Название департамента
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Список работников
        /// </summary>
        List<Worker> Workers { get; set; }

        /// <summary>
        /// Список вложенных департаментов
        /// </summary>
        List<Department> Departments { get; set; }

        /*
         * Добавление сотрудников/вложенных департаментов
         */

        /// <summary>
        /// Добавление сотрудника
        /// </summary>
        /// <param name="worker">Сотрудник</param>
        void add(Worker worker);

        /// <summary>
        /// Добавление вложенного департамента
        /// </summary>
        /// <param name="department">Департамент</param>
        void add(Department department);

        /// <summary>
        /// Добавление списка сотрудников
        /// </summary>
        /// <param name="workers">Список сотрудников</param>
        void add(List<Worker> workers);

        /// <summary>
        /// Добавление списка вложенных департаментов
        /// </summary>
        /// <param name="departments">Список департаментов</param>
        void add(List<Department> departments);

        /*
         * Сортировка сотрудников
         */

        /// <summary>
        /// Сортировка по фамилии
        /// </summary>
        void sortWorkersByLastName();

        /// <summary>
        /// Сортировка по имени
        /// </summary>
        void sortWorkersByFirstName();

        /// <summary>
        /// Сортировка по возрасту
        /// </summary>
        void sortWorkersByAge();

        /// <summary>
        /// Сортировка по зарплате
        /// </summary>
        void sortWorkersBySalary();

        /// <summary>
        /// Сортировка по количеству проектов
        /// </summary>
        void sortWorkersByProjectsCount();

        /*
         * Сортировка вложенных департаментов
         */

        /// <summary>
        /// Сортировка по дате создания
        /// </summary>
        void sortDepartmentsByDateOfCreation();

        /// <summary>
        /// Сортировка по названию
        /// </summary>
        void sortDepartmentsByName();

        /// <summary>
        /// Сортировка по количеству сотрудников
        /// </summary>
        void sortDepartmentsByWorkersCount();

        /*
         * Нахождение сотрудников
         */

        /// <summary>
        /// Нахождение сотрудников по фамилии
        /// </summary>
        /// <param name="lastName">Фамилия</param>
        /// <returns></returns>
        List<Worker> findWorkersByLastName(string lastName);

        /// <summary>
        /// Нахождение сотрудников по имени
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <returns></returns>
        List<Worker> findWorkersByFirstName(string firstName);

        /// <summary>
        /// Нахождение сотрудников по возрасту
        /// </summary>
        /// <param name="age">Возраст</param>
        /// <returns></returns>
        List<Worker> findWorkersByAge(int age);

        /// <summary>
        /// Нахождение сотрудников по зарплате
        /// </summary>
        /// <param name="salary">Зарплата</param>
        /// <returns></returns>
        List<Worker> findWorkersBySalary(int salary);

        /// <summary>
        /// Нахождение сотрудников по количеству проектов
        /// </summary>
        /// <param name="projectsCount">Количество проектов</param>
        /// <returns></returns>
        List<Worker> findWorkersByProjectsCount(int projectsCount);

        /*
         * Нахождение вложенных департаментов
         */

        /// <summary>
        /// Нахождение по дате создания
        /// </summary>
        /// <param name="dateOfCreation">Дата создания</param>
        /// <returns></returns>
        List<Department> findDepartmentsByDateOfCreation(DateTime dateOfCreation);

        /// <summary>
        /// Нахождение по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns></returns>
        List<Department> findDepartmentsByName(string name);

        /// <summary>
        /// Нахождение по количеству сотрудников
        /// </summary>
        /// <param name="workersCount">Количество сотрудников</param>
        /// <returns></returns>
        List<Department> findDepartmentsByWorkersCount(int workersCount);

        /*
         * Удаление сотрудников/вложенных департаментов
         */

        /// <summary>
        /// Удаление сотрудника из департамента
        /// </summary>
        /// <param name="worker">Сотрудник</param>
        void remove(Worker worker);

        /// <summary>
        /// Удаление вложенного департамента из департамента
        /// </summary>
        /// <param name="department">Департамент</param>
        void remove(Department department);

        /// <summary>
        /// Удаление списка сотрудников из департамента
        /// </summary>
        /// <param name="workers">Список сотрудников</param>
        void remove(List<Worker> workers);

        /// <summary>
        /// Удаление списка вложенных департаментов из департамента
        /// </summary>
        /// <param name="departments">Список департаментов</param>
        void remove(List<Department> departments);
    }
}