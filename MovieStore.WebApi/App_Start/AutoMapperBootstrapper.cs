using AutoMapper;
using MovieStore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStore.WebApi.App_Start
{
    public class AutoMapperBootstrapper
    {

        public static void Run()
        {
            RunAutoMapper();
        }

        private static void RunAutoMapper()
        {
            Mapper.CreateMap<Genres, GenreDTO>();
            Mapper.CreateMap<GenreDTO, Genres>();

            Mapper.CreateMap<MpaaDTO, Mpaa>();
            Mapper.CreateMap<Mpaa, MpaaDTO>();

            Mapper.CreateMap<MovieDTO, Movies>();
            Mapper.CreateMap<Movies, MovieDTO>();
        }
    }
}