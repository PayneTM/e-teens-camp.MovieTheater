using Newtonsoft.Json;

namespace E_Teens_Camp.MovieTheater.Models
{
    public class MovieModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("release_year")]
        public string ReleaseYear { get; set; }

        [JsonProperty("youtybe_url")]
        public string YoutubeUrl { get; set; }

        [JsonProperty("age")]
        public string Age { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("genre")]
        public string Genre { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }
}