using System.Net.Http.Json;
using Models;

namespace Client.Services
{
    public class PersonService(HttpClient httpClient)
    {
        public async Task<IEnumerable<Person>> GetAllPersons()
        {
            return await httpClient.GetFromJsonAsync<List<Person>>("api/Person");
        }
        public async Task SaveNewPerson(Person person)
        {
            await httpClient.PostAsJsonAsync("api/Person", person);
        }
    }
}
