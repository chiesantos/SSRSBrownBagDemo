using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStore.WebApi.Models
{
    public partial class MpaaDTO
    {    
        public long MpaaID { get; set; }
        public string Rating { get; set; }
        public string Description { get; set; }
        public bool Enable { get; set; }

    }
}