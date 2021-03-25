using System;
using System.ComponentModel.DataAnnotations;

namespace JoelsDatabaseSequel.Models
{
    public class Film
    {
        //Model for the form on the AddFilm Page
        [Key]
        public int FilmId { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Range(1900, 2021)]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        //? Makes this field nullable
        public bool? Edited { get; set; }

        public string LentTo { get; set; }

        //Sets the max length for this field
        [StringLength(25)]
        public string Notes { get; set; }

        
    }
}

