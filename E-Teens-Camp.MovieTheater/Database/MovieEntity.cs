using System;
using System.ComponentModel.DataAnnotations;

namespace E_Teens_Camp.MovieTheater.Database
{
    public class MovieEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public string YoutubeUrl { get; set; }
        public int Age { get; set; }
        public TimeSpan Duration { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}