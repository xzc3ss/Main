using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Story.Entities;
using System.Web.Mvc;

namespace Story.Entities
{

    [MetadataType(typeof(MovieMetadata))]
    public partial class Movie
    {
        
    }


    public class MovieMetadata
    {

        [Required]
        public string Name { get; set; }

        [Range(0, 10)]
        public int Rating { get; set; }

        [Required]
        public string Description { get; set; }

       
        public DateTime Date { get; set; }

        [Required]
        public string Director { get; set; }

      //  public int GenreID { get; set; }
        
                              
    }
}