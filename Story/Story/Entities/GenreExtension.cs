using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Story.Entities
{
    [MetadataType(typeof(GenreMetadata))]
    public partial class Genre
    {

    }


    public class GenreMetadata
    {

        [Required]
        public string Name { get; set; }
    
    }
}