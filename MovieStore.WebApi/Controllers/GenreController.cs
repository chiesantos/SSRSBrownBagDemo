using AutoMapper;
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

namespace MovieStore.WebApi.Controllers
{
    public class GenreController : ApiController
    {
        private readonly IMappingEngine _mapper;
        
        public GenreController(IMappingEngine mapper)
        {
            _mapper = mapper;
        }
         

        [HttpGet]
        public List<GenreDTO> GetGenres()
        {
            using (MovieStoreContext ent = new MovieStoreContext())
            {
                List<Genres> records = new List<Genres>();
                records = ent.Genres.Where(x => x.Enable == true).ToList();
                return _mapper.Map<List<GenreDTO>>(records);
            }
        }

        [HttpGet]
        public GenreDTO GetGenreById(long id) 
        {
            using (MovieStoreContext db = new MovieStoreContext())
            {
                var record = new Genres();
                record = db.Genres.Where(x => x.GenreID == id).FirstOrDefault();
                return _mapper.Map<GenreDTO>(record);
            }
        }

        [HttpPost]
        public long Create(GenreDTO obj)
        {
            using (MovieStoreContext ent = new MovieStoreContext()) {
                Genres record = _mapper.Map<Genres>(obj);

                try
                {
                    var tempObj = ent.Genres.Add(record);
                    ent.SaveChanges();
                    return tempObj.GenreID;
                }
                catch 
                {
                    return 0;
                }
            }
        }

        [HttpPost]
        public long Update(GenreDTO obj)
        {
            using (MovieStoreContext ent = new MovieStoreContext())
            {
                var record = ent.Genres.Where(x => x.GenreID.Equals(obj.GenreID)).ToList();

                foreach (var o in record)
                {
                    o.Description = obj.Description;
                    o.Enable = obj.Enable;
                }
                
                ent.SaveChanges();
                return obj.GenreID;
            }

        }
    }
}
