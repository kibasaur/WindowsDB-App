using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BioFilmer.Models
{
    public class Movie
    {
        [Key]
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string[] Genres { get; set; }
    }
}
