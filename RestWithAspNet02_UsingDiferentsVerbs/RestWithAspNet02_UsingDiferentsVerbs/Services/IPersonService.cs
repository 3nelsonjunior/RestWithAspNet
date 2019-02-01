using RestWithAspNet02_UsingDiferentsVerbs.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNet02_UsingDiferentsVerbs.Services
{
    interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long person);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);

    }
}
