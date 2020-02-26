using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using E_Teens_Camp.MovieTheater.Database;
using E_Teens_Camp.MovieTheater.Models;

namespace E_Teens_Camp.MovieTheater.Controllers
{
    public class MovieController : ApiController
    {
        // GET: api/Movie
        public IEnumerable<MovieModel> Get()
        {
            var result = new List<MovieModel>();
            using (var db = new Context())
            {
                foreach (var movie in db.Movies)
                {
                    result.Add(CreateMovieModelFromDbEntity(movie));
                }
            }
            return result;
        }

        // GET: api/Movie/5
        public async Task<MovieModel> Get(int id)
        {
            using (var db = new Context())
            {
                var movie = await db.Movies.FindAsync(id);
                if (movie == null) return null;
                return CreateMovieModelFromDbEntity(movie);
            }
        }

        // POST: api/Movie
        public async Task Post([FromBody]MovieModel model)
        {
            var entity = new MovieEntity
            {
                Name = model.Name,
                ReleaseYear = int.Parse(model.ReleaseYear),
                YoutubeUrl = model.YoutubeUrl,
                Age = int.Parse(model.Age),
                Date = DateTime.Parse(model.Date) + TimeSpan.Parse(model.Time),
                Description = model.Description,
                Duration = TimeSpan.Parse(model.Duration),
                Genre = model.Genre ?? string.Empty
            };
            using (var db = new Context())
            {
                db.Movies.Add(entity);
                await db.SaveChangesAsync();
            }
        }

        // PUT: api/Movie/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Movie/5
        public async Task DeleteAsync(int id)
        {
            using (var db = new Context())
            {
                var toDelete = await db.Movies.FindAsync(id);
                if (toDelete == null) return;
                db.Movies.Remove(toDelete);
                await db.SaveChangesAsync();
            }
        }

        // DELETE: api/Movie/
        public async Task DeleteAll()
        {
            using (var db = new Context())
            {
                db.Movies.RemoveRange(db.Movies);
                await db.SaveChangesAsync();
            }
        }

        private MovieModel CreateMovieModelFromDbEntity(MovieEntity entity)
        {
            if (entity == null) return null;
            return new MovieModel
            {
                Age = entity.Age.ToString(),
                Date = entity.Date.Date.ToString("yyyy-MM-dd"),
                Description = entity.Description,
                Duration = $"{entity.Duration.Hours}:{entity.Duration.Minutes}",
                Genre = entity.Genre.ToString(),
                Id = entity.Id,
                Name = entity.Name,
                ReleaseYear = entity.ReleaseYear.ToString(),
                Time = entity.Date.TimeOfDay.ToString(@"hh\:mm"),
                YoutubeUrl = entity.YoutubeUrl
            };
        }
    }
}
