using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStore.WebApi.Models
{
    public partial class GenreDTO
    {

        public long GenreID { get; set; }
        public string Description { get; set; }
        public bool Enable { get; set; }

    }
}