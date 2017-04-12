using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiDataProvider.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create a new Person Object");
            Person newPerson = new Person()
            {
                FirstName = "Ronald",
                LastName = "McDonald",
                MiddleInitial = "H"
            };
            Console.WriteLine("{0}: {1}, {2} {3}", newPerson.Id, newPerson.LastName, newPerson.FirstName, newPerson.MiddleInitial);
            Console.WriteLine("Insert the newly created Person object");
            int id = PersonService.Insert(newPerson);
            Console.WriteLine("");

            Console.WriteLine("Get the newly inserted row");
            Person existingPerson = PersonService.SelectById(id);
            Console.WriteLine("{0}: {1}, {2} {3}", existingPerson.Id, existingPerson.LastName, existingPerson.FirstName, existingPerson.MiddleInitial);
            Console.WriteLine("");

            Console.WriteLine("Get all the rows in the Person Table");
            List<Person> personList = PersonService.SelectAll();
            foreach (Person p in personList)
            {
                Console.WriteLine("{0}: {1}, {2} {3}", p.Id, p.LastName, p.FirstName, p.MiddleInitial);
            }
            Console.WriteLine("");

            Console.WriteLine("Modify the person object");
            existingPerson.FirstName = "Donald";
            existingPerson.LastName = "Duck";
            PersonService.Update(existingPerson);
            Console.WriteLine("{0}: {1}, {2} {3}", existingPerson.Id, existingPerson.LastName, existingPerson.FirstName, existingPerson.MiddleInitial);
            Console.WriteLine("");

            Console.WriteLine("Get all the rows in the Person Table, again");
            personList = PersonService.SelectAll();
            foreach(Person p in personList)
            {
                Console.WriteLine("{0}: {1}, {2} {3}", p.Id,p.LastName,p.FirstName,p.MiddleInitial);
            }
            Console.WriteLine("");

            Console.WriteLine("Delete the record you created...");
            PersonService.Delete(existingPerson.Id);

            Console.WriteLine("Get all the rows in the Person Table, a final time.");
            personList = PersonService.SelectAll();
            foreach (Person p in personList)
            {
                Console.WriteLine("{0}: {1}, {2} {3}", p.Id, p.LastName, p.FirstName, p.MiddleInitial);
            }
            Console.Read();
        }
    }
}
