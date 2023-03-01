using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using BioFilmer.Models;

namespace Classes
{
    public class Serializer
    {
        Movie serializeMovie(MovieDBO movieDbo)
        {
            Movie movie = new Movie();
            movie.Title = movieDbo.Title;
            movie.Synopsis = movieDbo.Synopsis;
            string[] genres = movieDbo.Genres.Split(new char[] { ',' }).ToArray();
            movie.Genres = genres;
            return movie;
        }
        MovieDBO serializeMovieDBO(Movie movie)
        {
            MovieDBO movieDbo = new MovieDBO();
            movieDbo.Title = movie.Title;
            movieDbo.Synopsis = movie.Synopsis;
            string genres = string.Join(',', movie.Genres);
            movieDbo.Genres = genres;
            return movieDbo;
        }

    }
}