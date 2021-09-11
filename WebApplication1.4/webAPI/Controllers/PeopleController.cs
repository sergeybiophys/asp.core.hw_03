using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using Services.Abstract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models.People;

namespace webAPI.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        IServiceManager serviceManager;
        IMapper mapper;

        public PeopleController(IServiceManager serviceManager,
                                IMapper mapper)
        {
            
            this.mapper = mapper;
            this.serviceManager = serviceManager;
        }

        [HttpGet]
        public IEnumerable<PersonDto> GetAllPeople()
        {
            return serviceManager.PeopleService.GetAllPeople();
        }

        [HttpPost]
        public PersonDto Create(CreatePersonModel model)
        {
            var tmp = mapper.Map<PersonDto>(model);

            return serviceManager.PeopleService.CreateNewPerson(tmp);
            //var tmp = serviceManager.PeopleService.CreateNewPerson(new PersonDto
            //{
            //    FirstName = model.FirstName,
            //    LastName = model.LastName,
            //    Birth = model.Birth
            //});
            //;
            //return tmp;
        }

        [HttpPut]

        public PersonDto Update(UpdatePersonModel model)
        {
            var tmp = mapper.Map<PersonDto>(model);

            return serviceManager.PeopleService.UpdatePerson(tmp);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            serviceManager.PeopleService.RemovePersonById(id);
            return new JsonResult("Ok");
        }
    }
}
