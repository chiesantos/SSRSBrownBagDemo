﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MovieStore.WebApi
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MovieStoreContext : DbContext
    {
        public MovieStoreContext()
            : base("name=MovieStoreContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Mpaa> Mpaa { get; set; }
        public DbSet<vwMovies> vwMovies { get; set; }
    }
}
