using SwaggerTesting.Context;
using SwaggerTesting.Interfaces;
using SwaggerTesting.Models;

namespace SwaggerTesting.Repository
{
    public class PokemonRepository : IPokemonRepositorycs
    {
        private readonly PokemonAppDbContext _context;
        public PokemonRepository(PokemonAppDbContext context) 
        {
            _context = context;
        }

        public Pokemon GetPokemon(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pokemon> GetPokemons()
        {
            return _context.Pokemon.ToList();
        }
    }
}
