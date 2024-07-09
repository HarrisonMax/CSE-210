using System;
using System.Runtime.CompilerServices;


class Program
{
    static void Main(string[] args)
    {
        Console. WriteLine("Bonjour Tout Le Monde");
        Employee employee = new Employee("Bob", 40, 23.77);
    //    Console.WriteLine($"{employee.GetName()} Is due: {employee.GetPay()}");

        ConstructionWorker constructionWorker = new ConstructionWorker("Betty", 40, 35.88);
      //  Console.WriteLine($"{constructionWorker.GetName()} is due: {constructionWorker.GetPay()}");

        Doctor doctor = new Doctor("Belinda", 240000.99);
        // Console.WriteLine($"{doctor.GetName()} is due {doctor.GetPay()}");

        List<Employee> employees = new List<Employee>();
        employees.Add(employee);
        employees.Add(constructionWorker);
        employees.Add(doctor);

        foreach (Employee e in employees)
        {
            Console.WriteLine($"{e.GetName()} is due {e.GetPay()} Insurance Cost: {e.InsuranceCost()}");
        }
    }
}