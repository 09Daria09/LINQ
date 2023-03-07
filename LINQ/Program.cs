using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQ
{
    internal class Program
    {
        enum Profile
        {
            IT,
            Marketing,
            Restaurant,
            Construction,
            Trading
        }
        class Firm
        {
            public string Name { get; set; }
            public int FoundingDate { get; set; }
            public Profile Profile { get; set; }
            public string FullNameDirector { get; set; }
            public int NumberEmployees { get; set; }
            public string Address { get; set; } 
            public List<Employee> Employees { get; set; }
            public Firm() 
            {
                Name = null;
                FoundingDate = 0;
                Profile = Profile.IT;
                FullNameDirector = null;
                NumberEmployees = 0;
                Address = null;
                Employees = new List<Employee>();
            }
            public Firm(string name, int foundingDate, string fullNameDirector, Profile profile, int numberEmployees, string address) 
            {
                Name = name;
                FoundingDate = foundingDate;
                Profile = profile;
                FullNameDirector = fullNameDirector;
                NumberEmployees = numberEmployees;
                Address = address;
            }
            public Firm(string name, int foundingDate, string fullNameDirector, Profile profile, int numberEmployees, string address, List<Employee> employees): this(name, foundingDate, fullNameDirector, profile, numberEmployees, address)
            {
                employees = new List<Employee>();
            }
            public override string ToString()
            {
                return string.Format($"\t***\nName: {Name}\nProfile: {Profile}\nFounded: {FoundingDate}\nDirector: {FullNameDirector}\nEmployees: {NumberEmployees}\nAddress: {Address}");
            }
        }
        class Employee
        {
            public string FullName { get; set; }
            public string Post { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public double Wage { get; set; }

            public Employee(string fullName, string post, string phone, string email, double wage)
            {
                FullName = fullName;
                Post = post;
                Phone = phone;
                Email = email;
                Wage = wage;
            }

            public Employee() { }
            public override string ToString()
            {
                return $"Name: {FullName}, Post: {Post}, Phone: {Phone}, Email: {Email}, Wage: {Wage}";
            }
        }

        static void Main(string[] args)
        {
            Employee employee1 = new Employee("Lionel Smith", "Manager", "555-1234", "kris@email.com", 15000);
            Employee employee2 = new Employee("Joy Gofri", "Assistant Manager", "555-5678", "joy@email.com", 29000);
            Employee employee3 = new Employee("Bob Johnson", "Sales Representative", "555-9012", "diohnson@email.com", 35000);
            Employee employee4 = new Employee("Samantha Lee", "Marketing Specialist", "555-3456", "slee@email.com", 30000);
            Employee employee5 = new Employee("Mike Davis", "IT Technician", "555-7890", "mdavis@email.com", 31000);
            Employee employee6 = new Employee("Karen Jones", "Human Resources Manager", "555-2345", "kjones@email.com", 55000);
            Employee employee7 = new Employee("David Brown", "Accountant", "555-6789", "dbrown@email.com", 50000);
            Employee employee8 = new Employee("Anna Kim", "Office Assistant", "555-0123", "akim@email.com", 30000);
            Employee employee9 = new Employee("Chris Lee", "Programmer", "555-4567", "clee@email.com", 55000);
            Employee employee10 = new Employee("Emily Chen", "Graphic Designer", "555-8901", "echen@email.com", 45000);
            List<Employee> employee = new List<Employee> { employee1, employee2, employee3, employee4, employee5, employee6, employee7, employee8, employee9, employee10 };

            Firm firm1 = new Firm("ABC Company", 1990, "John Smith", Profile.IT, 100, "123 Main St", employee);
            Firm firm2 = new Firm("XYZ Inc", 2005, "Jane Doe", Profile.Marketing, 50, "456 Broadway", employee);
            Firm firm3 = new Firm("Food Corporation", 1980, "Bob Johnson", Profile.Restaurant, 200, "789 Oak Ave", employee);
            Firm firm4 = new Firm("Big Co", 2023, "Samantha Lee", Profile.Construction, 75, "321 Elm St", employee);
            Firm firm5 = new Firm("White Enterprises", 1995, "Mike Black", Profile.Trading, 150, "555 Pine St", employee);
            Firm firm6 = new Firm("Superior Industries", 1975, "Karen Jones", Profile.IT, 300, "222 Maple Ave", employee);
            Firm firm7 = new Firm("Elite Solutions", 2000, "David Brown", Profile.Marketing, 25, "777 Main St", employee);
            Firm firm8 = new Firm("Pinnacle Group", 2022, "Anna Kim", Profile.Construction, 50, "444 Market St", employee);
            Firm firm9 = new Firm("Innovative Ventures", 1998, "Chris White", Profile.Trading, 125, "999 Broadway", employee);
            Firm firm10 = new Firm("Advanced Technologies", 1985, "Emily Chen", Profile.IT, 175, "333 Oak Ave", employee);
            List<Firm> firms = new List<Firm> { firm1, firm2, firm3, firm4, firm5, firm6, firm7, firm8, firm9, firm10 };

            #region 1
            ///Получить информацию обо всех фирмах
            var firmInfo = from firm in firms
                           select firm.ToString();

            //foreach (string info in firmInfo)
            //{
            //    Console.WriteLine(info);
            //}

            ///Получить фирмы, у которых в названии есть слово Food
            var firmsWithFood = firms.Where(f => f.Name.Contains("Food"));
            //foreach (Firm info in firmsWithFood)
            //{
            //    Console.WriteLine(info);
            //}

            ///Получить фирмы, которые работают в области маркетинга
            var firmsMarketing = firms.Where(f => f.Profile == Profile.Marketing);
            //foreach (Firm info in firmsMarketing)
            //{
            //    Console.WriteLine(info);
            //}

            ///Получить фирмы, которые работают в области маркетинга или IT
            var firmsMarketingOrIT = firms.Where(f => f.Profile == Profile.Marketing || f.Profile == Profile.IT);
            //foreach (Firm info in firmsMarketingOrIT)
            //{
            //    Console.WriteLine(info);
            //}

            ///Получить фирмы с количеством сотрудников, большем 100
            var NumberEmployeesMore100 = firms.Where(f => f.NumberEmployees > 100);
            //foreach (Firm info in NumberEmployeesMore100)
            //{
            //    Console.WriteLine(info);
            //}

            ///Получить фирмы с количеством сотрудников в диапазоне от 100 до 300
            var NumberEmployees100_300 = firms.Where(f => f.NumberEmployees > 100&& f.NumberEmployees < 300);
            //foreach (Firm info in NumberEmployees100_300)
            //{
            //    Console.WriteLine(info);
            //}

            ///Получить фирмы, у которых фамилия директора White
            var DirectorWhite = firms.Where(f => f.FullNameDirector.Contains("White"));
            //foreach (Firm info in DirectorWhite)
            //{
            //    Console.WriteLine(info);
            //}

            ///Получить фирмы, которые основаны больше двух лет назад
            var TowYear = firms.Where(f => f.FoundingDate < DateTime.Now.Year-2);
            //foreach (Firm info in TowYear)
            //{
            //    Console.WriteLine(info);
            //}

            ///Получить фирмы, у которых фамилия директора Black и название фирмы содержит слово White
            var BlackAndWhite = firms.Where(f => f.FullNameDirector.Contains("Black") && f.Name.Contains("White"));
            //foreach (Firm info in BlackAndWhite)
            //{
            //    Console.WriteLine(info);
            //}
            #endregion

            #region 2
            //Получить всех сотрудников конкретной фирмы
            var employeesInFirm = from e in employee
                                  from f in firms
                                  where f.Name == "ABC Company"
                                       select e;

            //foreach (Employee info in employeesInFirm)
            //{
            //    Console.WriteLine(info);
            //}

            //Получить всех сотрудников конкретной фирмы, у которых заработные платы больше заданной
            var employeesWage = from e in employee
                                  from f in firms
                                  where f.Name == "ABC Company"
                                  where e.Wage > 30000 
                                  select e;

            //foreach (Employee info in employeesWage)
            //{
            //    Console.WriteLine(info);
            //}

            //Получить сотрудников всех фирм, у которых должность менеджер
            var employeesManager = from e in employee
                                from f in firms
                                where e.Post == "Manager"
                                select e;
            //foreach (Employee info in employeesManager)
            //{
            //    Console.WriteLine(info);
            //}

            //Получить сотрудников, у которых телефон начинается с 23
            var employeesPhone = from e in employee
                                from f in firms
                                where f.Name == "ABC Company"
                                where e.Phone.StartsWith("23")
                                select e;

            //foreach (Employee info in employeesPhone)
            //{
            //    Console.WriteLine(info);
            //}

            //Получить сотрудников, у которых Email начинается с di
            var employeesEmail = from e in employee
                                 from f in firms
                                 where f.Name == "ABC Company"
                                 where e.Email.StartsWith("di")
                                 select e;

            //foreach (Employee info in employeesEmail)
            //{
            //    Console.WriteLine(info);
            //}

            //Получить сотрудников, у которых имя Lione
            var employeesName = from e in employee
                                 from f in firms
                                 where f.Name == "ABC Company"
                                 where e.FullName.Contains("Lionel")
                                select e;

            foreach (Employee info in employeesName)
            {
                Console.WriteLine(info);
            }
            #endregion
        }
    }
}
