using RestWithAspNet02_UsingDiferentsVerbs.Model;
using System.Collections.Generic;

namespace RestWithAspNet02_UsingDiferentsVerbs.Repository {
    public interface IPersonRepository {
        Person Create(Person person);
        Person FindById(long person);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);

        bool Exists(long? id);
    }
}
