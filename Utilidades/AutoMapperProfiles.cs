using AutoMapper;
using IntroEFCore.DTOs;
using IntroEFCore.Entidades;

namespace IntroEFCore.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GeneroCreacionDTO, Genero>();
            CreateMap<ActorCreacionDTO, Actor>();

            CreateMap<PeliculaCreacionDTO, Pelicula>()
                .ForMember(ent => ent.Generos,
                    dto => dto.MapFrom(             // Aqui se esta usando una proyeccion
                        campo => campo.Generos.Select(id => new Genero { Id = id })
                    )
                );

            CreateMap<PeliculaActorCreacionDTO, PeliculaActor>();

            CreateMap<ComentarioCreacionDTO, Comentario>();
        }
    }
}
