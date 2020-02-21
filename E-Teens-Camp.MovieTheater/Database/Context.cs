using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_Teens_Camp.MovieTheater.Database
{
    class Context : DbContext
    {
        public Context() : base("DbConnection") { }

        public DbSet<MovieEntity> Movies { get; set; }
    }
}