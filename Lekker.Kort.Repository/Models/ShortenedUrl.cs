using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lekker.Kort.Repository.Models
{
    public class ShortenedUrl
    {
        public ShortenedUrl()
        {
        }

        public ShortenedUrl(string key, string value)
        {
            Key = key;
            Url = value;
        }

        [Required, Key]
        public string Key { get; set; }

        [Required]
        public string Url { get; set; }

        public List<Hit> Hits { get; set; }
    }
}