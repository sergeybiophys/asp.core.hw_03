using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using Services.Abstract;
using Services.Abstract.Dto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PeopleService : IPeopleService
    {
        readonly IUnitOfWork unitOfWork;
        readonly IMapper mapper;

        public PeopleService(IUnitOfWork uow,
                             IMapper mapper)
        {
            unitOfWork = uow;
            this.mapper = mapper;
        }

        public PersonDto CreateNewPerson(PersonDto person)
        {
            var tmp = new Person
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Birth = person.Birth
            };
            unitOfWork.PeopleRepository.Create(tmp);
            unitOfWork.SaveChanges();
            
            return mapper.Map<PersonDto>(tmp);
            //;
            //return tmpDto;
            //return new PersonDto
            //{
            //    Id = tmp.Id,
            //    FirstName = tmp.FirstName,
            //    LastName = tmp.LastName,
            //    Birth = tmp.Birth,
            //    CreatedAt = tmp.CreatedAt
            //};
        }

        public IEnumerable<PersonDto> GetAllPeople()
        {
            var people = unitOfWork.PeopleRepository.GetAll();
            // TODO: AutoMapper
           // return people.Select((p) => new PersonDto
            //{
            //    Id = p.Id,
            //    Birth = p.Birth,
            //    FirstName = p.FirstName,
            //    LastName = p.LastName,
            //    CreatedAt = p.CreatedAt
            //}).ToList();
            return mapper.Map<IEnumerable<PersonDto>>(people);
        }

        public PersonDto GetPersonById(Guid id)
        {
            var person = unitOfWork.PeopleRepository.Get(id);
            return mapper.Map<PersonDto>(person);
            //return new PersonDto
            //{
            //    Id = person.Id,
            //    FirstName = person.FirstName,
            //    LastName = person.LastName,
            //    Birth = person.Birth,
            //    CreatedAt = person.CreatedAt
            //};
        }

        public void RemovePersonById(Guid id)
        {
            unitOfWork.PeopleRepository.Remove(id);
            unitOfWork.SaveChanges();
        }

        public PersonDto UpdatePerson(PersonDto person)
        {

            var tmp = new Person
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Birth = person.Birth,
                CreatedAt = person.CreatedAt
            };
            unitOfWork.PeopleRepository.Update(tmp);
            unitOfWork.SaveChanges();

            return mapper.Map<PersonDto>(tmp);
        }
    }
}
