using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SwaggerTesting.Dto;
using SwaggerTesting.Interfaces;
using SwaggerTesting.Models;

namespace SwaggerTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepositorycs _pokemonRepositorycs;
        private readonly IMapper _mapper;
        public PokemonController(IPokemonRepositorycs pokemonRepositorycs, IMapper mapper) 
        {
            _pokemonRepositorycs = pokemonRepositorycs;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type=typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepositorycs.GetPokemons());

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(pokemons);
        }
    }
}
