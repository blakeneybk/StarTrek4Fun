using OSA.Backend.StarshipApi.Models;

namespace OSA.Backend.StarshipApi.Repositories
{
    public class MockStarshipRepository : BaseMockRepository<StarTrekStarship>
    {
        private readonly int nextId = 1;

        public MockStarshipRepository()
        {
            entities.AddRange(new[]
            {
                new StarTrekStarship { Id = nextId++, Name = "USS Enterprise", Class = "Constitution", Registry = "NCC-1701", Captain = "James T. Kirk" },
                new StarTrekStarship { Id = nextId++, Name = "USS Voyager", Class = "Intrepid", Registry = "NCC-74656", Captain = "Kathryn Janeway" },
                new StarTrekStarship { Id = nextId++, Name = "USS Defiant", Class = "Defiant", Registry = "NX-74205", Captain = "Benjamin Sisko" },
                new StarTrekStarship { Id = nextId++, Name = "USS Discovery", Class = "Crossfield", Registry = "NCC-1031", Captain = "Gabriel Lorca" },
                new StarTrekStarship { Id = nextId++, Name = "USS Enterprise-D", Class = "Galaxy", Registry = "NCC-1701-D", Captain = "Jean-Luc Picard" }
            });
        }
    }
}