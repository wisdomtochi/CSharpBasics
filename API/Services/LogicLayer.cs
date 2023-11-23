using API.Data;
using API.Models;

namespace API.Services
{
    public class LogicLayer
    {
        private readonly ApplicationDbContext context;

        public LogicLayer(ApplicationDbContext context)
        {
            this.context = context;

            new List<Person>()
            {
                new Person { Id = 1, Name = "Mary" },
                new Person { Id = 2, Name = "John" },
                new Person { Id = 3, Name = "Okon" }
            };
        }

        public async Task<List<Person>> ReadAll()
        {
            return new List<Person> { new Person { Id = 1, Name = "Mary" },
                new Person { Id = 2, Name = "John" },
                new Person { Id = 3, Name = "Okon" }
            };
            //return await context.People.ToListAsync();
        }
    }
}
