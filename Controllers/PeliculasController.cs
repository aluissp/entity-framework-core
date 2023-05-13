﻿using AutoMapper;
using IntroEFCore.DTOs;
using IntroEFCore.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroEFCore.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PeliculasController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(PeliculaCreacionDTO peliculaCreacion)
        {
            var pelicula = mapper.Map<Pelicula>(peliculaCreacion);

            if (pelicula.Generos is not null)
            {
                foreach (var genero in pelicula.Generos)
                {
                    context.Entry(genero).State = EntityState.Unchanged;
                }
            }

            if (pelicula.PeliculasActores is not null)
            {
                for (int i = 0; i < pelicula.PeliculasActores.Count; i++)
                {
                    pelicula.PeliculasActores[i].Orden = i + 1;
                }
            }

            context.Add(pelicula);
            await context.SaveChangesAsync();
            return Ok(pelicula);
        }
    }
}