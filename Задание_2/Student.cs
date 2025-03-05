using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_2
{
    class Student
    {
        private string name;
        private string surname;
        private string recordBookNumber;
        private string group;
        private string status;
        public Student(string name, string surname, string recordBookNumber, string group, string status)
        {
            this.name = name;
            this.surname = surname;
            this.recordBookNumber = recordBookNumber;
            this.group = group;
            this.status = status;
        }
        public string GetName()
        {
            return this.name;
        }
        public string GetSurname()
        {
            return this.surname;
        }
        public string GetRecordBookNumber()
        {
            return this.recordBookNumber;
        }
        public string GetGroup()
        {
            return this.group;
        }
        public string GetStatus()
        {
            return this.status;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetSurname(string surname)
        {
            this.surname = surname;
        }
        public void SetRecordBookNumber(string recordBookNumber)
        {
            this.recordBookNumber = recordBookNumber;
        }
        public void SetGroup(string group)
        {
            this.group = group;
        }
        public void SetStatus(string status)
        {
            this.status = status;
        }
    }
}
