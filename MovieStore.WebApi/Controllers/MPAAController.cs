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
    public class MPAAController : ApiController
    {

        private readonly IMappingEngine _mapper;

        public MPAAController(IMappingEngine mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public List<MpaaDTO> GetMPAA()
        {
            using (MovieStoreContext db = new MovieStoreContext())
            {
                List<Mpaa> records = new List<Mpaa>();
                records = db.Mpaa.Where(x => x.Enable == true).ToList();
                return _mapper.Map<List<MpaaDTO>>(records);
            }
        }

        [HttpGet]
        public MpaaDTO GetMpaaById(long id)
        {
            using (MovieStoreContext db = new MovieStoreContext())
            {
                var record = new Mpaa();
                record = db.Mpaa.Where(x => x.MpaaID == id).FirstOrDefault();
                return _mapper.Map<MpaaDTO>(record);
            }
        }

        [HttpPost]
        public long Create(MpaaDTO obj)
        {
            using (MovieStoreContext ent = new MovieStoreContext())
            {
                var record = _mapper.Map<Mpaa>(obj);

                try
                {
                    var tempObj = ent.Mpaa.Add(record);
                    ent.SaveChanges();
                    return tempObj.MpaaID;
                }
                catch
                {
                    return 0;
                }
            }
        }

        [HttpPost]
        public long Update(MpaaDTO obj)
        {
            using (MovieStoreContext ent = new MovieStoreContext())
            {
                var record = ent.Mpaa.Where(x => x.MpaaID.Equals(obj.MpaaID));

                foreach (var o in record)
                {
                    o.Rating = obj.Rating;
                    o.Description = obj.Description;
                    o.Enable = obj.Enable;
                }

                ent.SaveChanges();
                return obj.MpaaID;
            }

        }
    }
}
