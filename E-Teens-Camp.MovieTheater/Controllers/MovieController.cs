using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
                    result.Add(new MovieModel {
                        Age = movie.Age.ToString(),
                        Date = movie.Date.Date.ToString("yyyy-MM-dd"),
                        Description = movie.Description,
                        Duration = $"{movie.Duration.Hours}:{movie.Duration.Minutes}",
                        Genre = movie.Genre.ToString(),
                        Id = movie.Id,
                        Name = movie.Name,
                        ReleaseYear = movie.ReleaseYear.ToString(),
                        Time = movie.Date.TimeOfDay.ToString(@"hh\:mm"),
                        YoutubeUrl = movie.YoutubeUrl
                    });
                }
            }
            return result;
        }

        // GET: api/Movie/5
        public MovieEntity Get(int id)
        {
            using (var db = new Context())
            {
                return db.Movies.FirstOrDefault(x=>x.Id == id);
            }
        }

        // POST: api/Movie
        public void Post([FromBody]MovieModel model)
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
                Genre = model.Genre
            };
            using (var db = new Context())
            {
                db.Movies.Add(entity);
                db.SaveChanges();
            }
        }

        // PUT: api/Movie/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Movie/5
        public void Delete(int id)
        {
        }
    }
}
