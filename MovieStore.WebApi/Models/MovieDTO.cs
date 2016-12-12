using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStore.WebApi.Models
{
    public partial class MovieDTO
    {
        public long MovieID { get; set; }
        public string Title { get; set; }
        public Nullable<long> Genre { get; set; }
        public string Director { get; set; }
        public Nullable<int> ReviewRating { get; set; }
        public Nullable<long> MPAARating { get; set; }
        public Nullable<int> YearReleased { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> Stock { get; set; }
        public Nullable<bool> Enable { get; set; }
    
        public virtual GenreDTO Genres { get; set; }
        public virtual MpaaDTO MPAA { get; set; }
    }
}