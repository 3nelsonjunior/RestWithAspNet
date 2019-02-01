using RestWithAspNet02_UsingDiferentsVerbs.Model;
using System.Collections.Generic;

namespace RestWithAspNet02_UsingDiferentsVerbs.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long person);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);

    }
}
