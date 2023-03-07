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
            public Firm() 
            {
                Name = null;
                FoundingDate = 0;
                Profile = Profile.IT;
                FullNameDirector = null;
                NumberEmployees = 0;
                Address = null;
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
        }

        static void Main(string[] args)
        {
            Firm firm1 = new Firm("ABC Company", 1990, "John Smith", Profile.IT, 100, "123 Main St");
            Firm firm2 = new Firm("XYZ Inc", 2005, "Jane Doe", Profile.Marketing, 50, "456 Broadway");
            Firm firm3 = new Firm("Food Corporation", 1980, "Bob Johnson", Profile.Restaurant, 200, "789 Oak Ave");
            Firm firm4 = new Firm("Big Co", 2023, "Samantha Lee", Profile.Construction, 75, "321 Elm St");
            Firm firm5 = new Firm("White Enterprises", 1995, "Mike Black", Profile.Trading, 150, "555 Pine St");
            Firm firm6 = new Firm("Superior Industries", 1975, "Karen Jones", Profile.IT, 300, "222 Maple Ave");
            Firm firm7 = new Firm("Elite Solutions", 2000, "David Brown", Profile.Marketing, 25, "777 Main St");
            Firm firm8 = new Firm("Pinnacle Group", 2022, "Anna Kim", Profile.Construction, 50, "444 Market St");
            Firm firm9 = new Firm("Innovative Ventures", 1998, "Chris White", Profile.Trading, 125, "999 Broadway");
            Firm firm10 = new Firm("Advanced Technologies", 1985, "Emily Chen", Profile.IT, 175, "333 Oak Ave");
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

        }
    }
}
