using System;
using System.Linq;
using practice1.Entities;

namespace practice1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserCommand();

        }
        static void UserCommand()
        {
            CompanyControl companyControl = new CompanyControl();
            M: Console.WriteLine("Choose an action: " +
                "\n1. Receive company facilities" +
                "\n2. Change company information" +
                "\n3. Delete company " +
                "\n4. Copy information about the direction of development from one company to another");
            int actionid = int.Parse(Console.ReadLine());
            switch (actionid)
            {
                case 1:
                    Console.WriteLine(companyControl.GetCompanyInformation());
                    goto M;
                case 2:
                    Console.WriteLine("Enter company id");
                    companyControl.ChangeCompanyInfo(Console.ReadLine());
                    goto M;
                case 3:
                    Console.WriteLine("Enter company id");
                    companyControl.DeleteCompany(Console.ReadLine());
                    goto M;
                case 4:
                    Console.WriteLine("Enter companies id");
                    companyControl.CopyCompanyInformation(Console.ReadLine(), Console.ReadLine());
                    goto M;



            }
        }
    }
    public class CompanyControl
    {
        private string CompanyDescription;
        private Company[] Companies;
        public CompanyControl()
        {
            CompanyDescription = "";
            Companies = new Company[3];
            Companies[0] = new Company()
            {
                Id = Guid.NewGuid(),
                Name = "Latex Enjoyers",
                MainActivity = "Latex Products",
                DateOfCreation = new DateTime(2020, 11, 8, 13, 13, 0),
                directionOfDevelopment = Enumerables.DirectionOfDevelopment.LatexCostumes
            };
            Companies[1] = new Company()
            {
                Id = Guid.NewGuid(),
                Name = "Bondage Professionals",
                MainActivity = "Bondage Testing",
                DateOfCreation = new DateTime(2021, 4, 11, 12, 3, 0),
                directionOfDevelopment = Enumerables.DirectionOfDevelopment.VioletBondages
            };
            Companies[2] = new Company()
            {
                Id = Guid.NewGuid(),
                Name = "Lube Monsters",
                MainActivity = "Lube Manufacture",
                DateOfCreation = new DateTime(2021, 5, 13, 10, 1, 0),
                directionOfDevelopment = Enumerables.DirectionOfDevelopment.Lube
            };
        }
        public string GetCompanyInformation()
        {
            CompanyDescription = "";
            for (int i = 0; i < Companies.Length; i++)
            {
                CompanyDescription = CompanyDescription + $"id: {Companies[i].Id} \nName: {Companies[i].Name}" +
                    $" \nMain activity: {Companies[i].MainActivity}" +
                    $" \nDate of creation: {Companies[i].DateOfCreation}" +
                    $" \nDirection of Development: {Companies[i].directionOfDevelopment}\n";

            }
            return CompanyDescription;

        }
        public void ChangeCompanyInfo(string CompanyId)
        {
            CompanyId = CompanyId.Trim();
            Console.WriteLine("Enter new company name");
            string newName = Console.ReadLine();
            Console.WriteLine("Enter a new main activity");
            string newActivity = Console.ReadLine();
            foreach (Company company in Companies)
            {
                if (company.Id.ToString() == CompanyId)
                {
                    company.Name = newName;
                    company.MainActivity = newActivity;

                }
            }
        }
        public void DeleteCompany(string CompanyId)
        {
            for (int i = 0; i < Companies.Length; i++)
            {
                if (Companies[i].Id.ToString() == CompanyId)
                {
                    Companies = Companies.Where((source, index) => index != i).ToArray();
                }
            }
        }
        public void CopyCompanyInformation(string CompanyId, string CompanyIdTwo)
        {
            int tempid = 0;
            for (int i = 0; i < Companies.Length; i++)
            {
                if (Companies[i].Id.ToString()==CompanyId)
                {
                    tempid = i; 
                }
            }
            for (int i = 0; i < Companies.Length; i++)
            {
                if (Companies[i].Id.ToString() == CompanyIdTwo)
                {
                    Companies[tempid].directionOfDevelopment = Companies[i].directionOfDevelopment;
                }
            } 
        }
    }
}
