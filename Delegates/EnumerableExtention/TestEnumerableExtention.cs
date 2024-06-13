using Delegates.EnumerableExtention;
using System;
using System.Collections.Generic;


namespace Delegates.EnumerableExtention
{
    public class TestEnumerableExtention
    {
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public override string ToString()
            {
                return $"Name: {Name}, Age: {Age}";
            }
        }

        public void TestRun()
        {
            List<Person> listPersons = new List<Person>();
            listPersons.Add(new Person() { Name = "Tom", Age = 30 });
            listPersons.Add(new Person() { Name = "Joane", Age = 35 });
            listPersons.Add(new Person() { Name = "Alexander", Age = 25 });

            Func<Person, float> GetAge = Person => Person.Age;
            Console.WriteLine($"Человек с максимальным возрастом: {listPersons.GetMax(GetAge)}");

            Func<Person, float> GetNameLength = Person => Person.Name.Length;
            Console.WriteLine($"Человек с самым длинным именем: {listPersons.GetMax(GetNameLength)}");
        }

    }
}
