using System;
using System.Collections;
using System.Collections.Generic;
using Homework_11.Repository.Implementation;

namespace Homework_11.Enumerator
{
    public class DepartmentEnumerator : IEnumerator
    {
        private readonly List<Department> departments;

        private int position = -1;

        public DepartmentEnumerator(List<Department> departments)
        {
            this.departments = departments;
        }

        public bool MoveNext()
        {
            position++;
            return position < departments.Count;
        }

        public void Reset()
        {
            position--;
        }

        object IEnumerator.Current => Current;

        public Department Current
        {
            get
            {
                try
                {
                    return departments[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}