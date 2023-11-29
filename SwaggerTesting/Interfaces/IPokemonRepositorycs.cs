using SwaggerTesting.Models;

namespace SwaggerTesting.Interfaces
{
    public interface IPokemonRepositorycs
    {
        public List<Pokemon> GetPokemons();
        public Pokemon GetPokemon(int id);

    }
}
