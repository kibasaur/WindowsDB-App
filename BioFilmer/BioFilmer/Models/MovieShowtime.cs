using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioFilmer.Models
{
    public class MovieShowtime
    {
        public string CinemaName { get; set; }
        public string MovieTitle { get; set; }
        public DateTime Showtime { get; set; }
    }
}
