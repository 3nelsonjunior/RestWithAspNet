﻿using System.Collections.Generic;
using RestWithAspNet02_UsingDiferentsVerbs.Model;
using RestWithAspNet02_UsingDiferentsVerbs.Repository;

namespace RestWithAspNet02_UsingDiferentsVerbs.Business.Implematattions {
    public class PersonBusinessImpl : IPersonBusiness
    {
        private IPersonRepository _repository;

        private volatile int count;

        public PersonBusinessImpl(IPersonRepository repository)
        {
            _repository = repository;
        }


        public List<Person> FindAll() {
            return _repository.FindAll();
        }

        public Person FindById(long id) {
            return _repository.FindById(id);
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public Person Update(Person person) {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}
