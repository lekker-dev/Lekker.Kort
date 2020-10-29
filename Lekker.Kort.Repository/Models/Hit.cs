using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lekker.Kort.Repository.Models
{

    public class Hit
    {
        [Required, Key]
        public string Key { get; set; }

        [Required]
        public string Name { get; set; }

        public Hit()
        {

        }

        public Hit(string key, string name)
        {
            Key = key;
            Name = name;
        }
    }
}