using System;
using System.Collections.Generic;
using System.Threading;
using RestWithAspNet02_UsingDiferentsVerbs.Model;
using RestWithAspNet02_UsingDiferentsVerbs.Model.Context;

namespace RestWithAspNet02_UsingDiferentsVerbs.Services.Implematattions
{
    public class PersonServiceImpl : IPersonService
    {
        private MySQLContext _context;

        private volatile int count;

        public PersonServiceImpl(MySQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {
            // nothing
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for(int i = 0; i < 8; i++){
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        public Person FindById(long person)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Nelson",
                LastName = "Junior",
                Address = "Juiz de Fora/MG",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person; 
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person" + i,
                LastName = "Person Last Name" + i,
                Address = "Juiz de Fora/MG",
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
