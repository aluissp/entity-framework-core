using AutoMapper;
using IntroEFCore.DTOs;
using IntroEFCore.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroEFCore.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenerosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(GeneroCreacionDTO generoCreacion)
        {
            var genero = mapper.Map<Genero>(generoCreacion);

            context.Add(genero);
            await context.SaveChangesAsync();
            return Ok(genero);
        }

        [HttpPost("varios")]
        public async Task<ActionResult> Post(GeneroCreacionDTO[] generosCreacionDTO)
        {
            var generos = mapper.Map<Genero[]>(generosCreacionDTO);
            context.AddRange(generos);
            await context.SaveChangesAsync();

            return Ok(generos);
        }


        // Consulta de datos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genero>>> Get()
        {
            return await context.Generos.ToListAsync();
        }

        // Actualizar datos mediante el campo conectado
        [HttpPut("{id:int}/nombre2")]
        public async Task<ActionResult> Put(int id)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(x => x.Id == id);

            if (genero == null) return NotFound();

            genero.Nombre = "Cambiado";
            await context.SaveChangesAsync();

            return Ok();
        }

        // Actualizar datos mediante el campo desconectado
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, GeneroCreacionDTO generoCreacionDTO)
        {
            var genero = mapper.Map<Genero>(generoCreacionDTO);

            if (genero == null) return NotFound();

            genero.Id = id;

            context.Update(genero);

            await context.SaveChangesAsync();

            return Ok();
        }


        // Eliminar datos mediante el campo conectado
        [HttpDelete("{id:int}/moderna")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasAlteradas = await context.Generos.Where(g => g.Id == id).ExecuteDeleteAsync();
            
            if (filasAlteradas == 0) return NotFound();

            return NoContent();
        }

        // Eliminar datos mediante el campo conectado
        [HttpDelete("{id:int}/anterior")]
        public async Task<ActionResult> DeleteAnterior(int id)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(g => g.Id == id);
          
            if (genero == null) return NotFound();

            context.Remove(genero);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
