using System.Data.Entity;

namespace E_Teens_Camp.MovieTheater.Database
{
    class Context : DbContext
    {
        public Context() : base("DbConnection") { }

        public DbSet<MovieEntity> Movies { get; set; }
    }
}