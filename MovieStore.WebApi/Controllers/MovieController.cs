using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using MovieStore.WebApi.Models;
using AutoMapper;

namespace MovieStore.WebApi.Controllers
{
    public class MovieController : ApiController
    {

        private readonly IMappingEngine _mapper;

        public MovieController(IMappingEngine mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public List<vwMovies> GetMovies()
        {
            using (MovieStoreContext db = new MovieStoreContext())
            {
                List<vwMovies> records = new List<vwMovies>();
                records = db.vwMovies.ToList();
                return records;
            }
        }

        [HttpGet]
        public MovieDTO GetMovieById(long id) {
            using (MovieStoreContext db = new MovieStoreContext())
            {
                var record = new Movies();
                record = db.Movies.Where(x => x.MovieID == id).FirstOrDefault();
                return _mapper.Map<MovieDTO>(record);
            }
        }

        [HttpPost]
        public long Create(MovieDTO obj)
        {
            using (MovieStoreContext ent = new MovieStoreContext())
            {
                Movies record = _mapper.Map<Movies>(obj);

                try
                {
                    var tempObj = ent.Movies.Add(record);
                    ent.SaveChanges();
                    return tempObj.MovieID;
                }
                catch
                {
                    return 0;
                }
            }
        }

        [HttpPost]
        public long Update(MovieDTO obj)
        {
            using (MovieStoreContext ent = new MovieStoreContext())
            {
                var records = ent.Movies.Where(x => x.MovieID == obj.MovieID);

                foreach (var o in records)
                {
                    o.Title = obj.Title;
                    o.Genre = obj.Genre;
                    o.Director = obj.Director;
                    o.ReviewRating = obj.ReviewRating;
                    o.MPAARating = obj.MPAARating;
                    o.YearReleased = obj.YearReleased;
                    o.Price = obj.Price;
                    o.Stock = obj.Stock;
                    o.Enable = obj.Enable;
                }
                ent.SaveChanges();
                return obj.MovieID;
            }
        }

    }
}
