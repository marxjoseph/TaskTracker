using Microsoft.AspNetCore.Mvc;
using Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        [HttpGet]
        public IEnumerable<Person> GetAllPersonsAsync([FromServices] PersonRepository personRepository)
        {
            return personRepository.GetAllPersons();
        }

        [HttpPost]
        public void Post([FromBody] Person person, [FromServices] PersonRepository personRepository)
        {
            personRepository.AddPerson(person);
        }
    }
}
