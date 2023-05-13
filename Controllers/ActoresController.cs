using AutoMapper;
using AutoMapper.QueryableExtensions;
using IntroEFCore.DTOs;
using IntroEFCore.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroEFCore.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class ActoresController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ActoresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(ActorCreacionDTO actorCreacion)
        {
            var actor = mapper.Map<Actor>(actorCreacion);
            context.Add(actor);
            await context.SaveChangesAsync();
            return Ok(actor);
        }

        // Consulta de datos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> Get()
        {
            return await context.Actores.OrderBy(a => a.FechaNacimiento).ToListAsync();
        }

        // Consulta de datos
        [HttpGet("nombre")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get(string nombre)
        {
            //return await context.Actores
            //    .Where(a => a.Nombre.Contains(nombre))
            //    .OrderBy(a => a.Nombre)
            //    .ThenBy(a => a.FechaNacimiento)
            //    .ToListAsync();
            return await context.Actores.Where(a => a.Nombre.Contains(nombre)).ToListAsync();
        }

        [HttpGet("fechaNacimiento/rango")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get(DateTime fechaInicio, DateTime fechaFin)
        {
            return await context.Actores
                .Where(a => a.FechaNacimiento >= fechaInicio && a.FechaNacimiento <= fechaFin)
                .ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Actor>> Get(int id)
        {
            var actor = await context.Actores.FirstOrDefaultAsync(a => a.Id == id);

            if (actor == null) return NotFound();

            return actor;
        }

        [HttpGet("id-nombre")]
        public async Task<ActionResult<IEnumerable<ActorDTO>>> GetIdYNombre()
        {
            // Manual
            //var actores = await context.Actores
            //.Select(a => new ActorDTO { Id = a.Id, Nombre = a.Nombre })
            //.ToListAsync();

            // Con AutoMapper
            var actores = await context.Actores
                .ProjectTo<ActorDTO>(mapper.ConfigurationProvider)
                .ToListAsync();

            return actores;

        }

    }
}


