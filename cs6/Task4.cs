using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs6
{
    class Employee
    {
        static Random rnd = new Random();
        static int contractCounter;
        static Employee() { contractCounter = rnd.Next(); }
        public Employee(string name_, string surname_, int salary_, string position_)
        {
            name = name_;
            surname = surname_;
            salary = salary_;
            contractNumber = ++contractCounter;
            position = position_;
        }
        public Employee(string position_)
        {
            contractNumber = ++contractCounter;
            position = position_;
        }
        //o ім'я,
        string name;
        //o прізвище,
        string surname;
        //o посаду,
        string position;
        //o заробітну плату
        int salary;
        //o номер договору про прийом на роботу
        int contractNumber;
        //o властивості доступу до полів
        public string Name { get => name; }
        public string Surname { get => surname; }
        public string Positioin { get => position; }
        public int Salary { get => salary; }
        public int Contract { get => contractNumber; }
        //Визначити у класі методи
        //o вводу імені та прізвища,
        public void SetNameSurname()
        {
            try
            {
                string name_, surname_;
                Console.Write("Enter name: ");
                name_ = Console.ReadLine();
                Console.Write("Enter surname: ");
                surname_ = Console.ReadLine();
                if (name_.Any(x => char.IsDigit(x)) || surname_.Any(x => char.IsDigit(x)))
                    throw new FormatException("Error. Nodigits allow in name/surname.");
                name = name_;
                surname = surname_;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SetNameSurname();
            }
        }
        //o вводу заробітної плати.
        public void SetSalary()
        {
            try
            {
                int salary_;
                Console.Write("Enter salary: ");
                if (!int.TryParse(Console.ReadLine(), out salary_))
                    throw new SalaryInputException();
                if (salary_ < 0)
                {
                    Console.WriteLine("Error. Salary is too small.");
                    SetSalary();
                }
                else
                    salary = salary_;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SetSalary();
            }
        }
        public void Info()
        {
            Console.WriteLine($"Full name: {Name} {Surname}\t Position: {Positioin}\t " +
                $"Salary: {Salary}\t Contract number: {Contract}");
        }
        public override string ToString()
        {
            return $"Full name: {Name} {Surname}\t Position: {Positioin}\t " +
                $"Salary: {Salary}\t Contract number: {Contract}";
        }
    }
    class Department : IEnumerable
    {
        List<Employee> department = new List<Employee>();
        public IEnumerator GetEnumerator()
        {
            //foreach (var el in department)
            //    yield return el;
            return department.GetEnumerator();
        }
        public IEnumerable Reverse()
        {
            for (int i = department.Count - 1; i >= 0; i--)
            {
                yield return department[i];
            }
        }
        const uint MAX_DEP_SIZE = 10;
        //o додавання працівників,
        public void Add(Employee employee)
        {
            if (department.Count >= MAX_DEP_SIZE)
                throw new FullDerartmentException();
            else
                department.Add(employee);
        }
        public void Add()
        {
            if (department.Count >= MAX_DEP_SIZE)
                throw new FullDerartmentException();
            else
            {
                string tmpPos;
                do
                {
                    Console.Write("Enter position: ");
                    tmpPos = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(tmpPos))
                        Console.WriteLine("Invalid input.");
                    else
                        break;
                } while (true);
                Employee tmp = new Employee(tmpPos);
                tmp.SetNameSurname();
                tmp.SetSalary();
                department.Add(tmp);
            }
        }
        //o видалення працівника(за номером договору чи прізвищем та іменем)
        public void Remove(int contract)
        {
            try
            {
                if (department == null || department.Count == 0)
                    throw new EmptyDepartmentException();
                if (contract >= 0)
                {
                    int index = department.FindIndex(x => x.Contract == contract);
                    if (index != -1)
                        department.RemoveAt(index);
                    else
                        throw new EmployeeRemoveException();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Remove(string name, string surname)
        {
            try
            {
                if (department == null || department.Count == 0)
                    throw new EmptyDepartmentException();
                if (!String.IsNullOrWhiteSpace(name) && !String.IsNullOrWhiteSpace(surname)
                    && !name.Any(x => char.IsDigit(x)) && !surname.Any(x => char.IsDigit(x)))
                {
                    int index = department.FindIndex(x => x.Name == name && x.Surname == surname);
                    if (index != -1)
                        department.RemoveAt(index);
                    else
                        throw new EmployeeRemoveException();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //o перегляд відділу
        public void Show()
        {
            if (department.Count > 0)
                foreach (var el in department)
                    el.Info();
        }
    }
    class FullDerartmentException : ApplicationException
    {
        public FullDerartmentException(string message = "Department is full") : base(message)
        { }
    }
    class SalaryInputException : ApplicationException
    {
        public SalaryInputException(string message = "Invalid salary input") : base(message)
        { }
    }
    class EmptyDepartmentException : ApplicationException
    {
        public EmptyDepartmentException(string message = "Department is empty") : base(message)
        { }
    }
    class EmployeeRemoveException : ApplicationException
    {
        public EmployeeRemoveException(string message = "Employee not found") : base(message)
        { }
    }
}
