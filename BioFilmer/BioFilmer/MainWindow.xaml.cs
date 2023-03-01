using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using BioFilmer.Models;

namespace BioFilmer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        ICollectionView listSrc;
        public List<Movie> Movies { get; set; } = new List<Movie> {
            //new Movie { Title = "Avatar: The Way of Water", Synopsis = "Jake Sully och Ney'tiri har bildat familj och gör allt för att hålla ihop. De måste dock lämna sitt hem och utforska Pandoras regioner. När ett gammalt hot återuppstår tvingas Jake utkämpa ett svårt krig mot människorna.", Genres = new[] {"Action","Adventure", "Fantasy" } },
            //new Movie { Title = "Tron: Legacy", Synopsis = "När Flynn, världens störste spelskapare, skickar ut en hemlig signal från en dold digital värld, fångas den upp av hans son, som bestämmer sig för att rädda fadern som är försvunnen sedan länge.", Genres = new[] {"Action","Adventure", "Sci-Fi" } },
            //new Movie { Title = "Matrix", Synopsis = "Datahackern Neo möter mystiska rebeller som berättar sanningen om världen han bor i - och om hans roll i kriget mot dem som kontrollerar det som till synes verkar vara verkligheten.", Genres = new[] {"Action", "Sci-Fi" } },
            //new Movie { Title = "They Live", Synopsis = "När huvudpersonen John Nada hittar ett par solglasögon upptäcker han att världen är fylld av dolda budskap och att de styrande i samhället är utomjordingar. Han ger sig ut på jakt efter det högkvarter som utomjordingarna använder samtidigt som de blir medvetna om hans möjlighet att se deras rätta jag.", Genres = new[] {"Action","Horror", "Sci-Fi" } },
            //new Movie { Title = "Soylent Green", Synopsis = "New York år 2022. Miljön är förstörd, världen är överbefolkad och människor lever på konstgjord föda, framför allt från storföretaget Soylent. En polis vid namn Thorn undersöker ett mord, som snart visar sig ha kopplingar till företaget.", Genres = new[] {"Crime","Mystery", "Sci-Fi" } },
            //new Movie { Title = "The Book of Eli", Synopsis = "I en inte alltför avlägsen framtid, cirka 30 år efter det slutliga kriget, vandrar en ensam man genom det ödelandskap som en gång var Amerika. Det finns ingen civilisation här, ingen lag. Vägarna tillhör gäng som skulle mörda en man för hans skor, en droppe vatten - eller för ingenting alls. Driven av sitt åtagande och vägledd av sin tro på något större än sig själv gör Eli vad han måste för att överleva.", Genres = new[] {"Action","Adventure", "Drama" } }
        };


        public List<MovieShowtime> MovieShowtimes { get; set; } = new List<MovieShowtime>
        {
            //new MovieShowtime { CinemaName = "Royal", MovieTitle = "Avatar: The Way of Water", Showtime = new DateTime(2023,03,17,19,00,00) },
            //new MovieShowtime { CinemaName = "Royal", MovieTitle = "Avatar: The Way of Water", Showtime = new DateTime(2023,03,17,21,00,00) },
            //new MovieShowtime { CinemaName = "Bergakungen", MovieTitle = "Avatar: The Way of Water", Showtime = new DateTime(2023,03,17,19,15,00) },
            //new MovieShowtime { CinemaName = "Bergakungen", MovieTitle = "Avatar: The Way of Water", Showtime = new DateTime(2023,03,17,21,15,00) },
            //new MovieShowtime { CinemaName = "Bergakungen", MovieTitle = "Tron: Legacy", Showtime = new DateTime(2023,03,16,19,00,00) },
            //new MovieShowtime { CinemaName = "Bergakungen", MovieTitle = "Tron: Legacy", Showtime = new DateTime(2023,03,16,21,00,00) },
            //new MovieShowtime { CinemaName = "Royal", MovieTitle = "Tron: Legacy", Showtime = new DateTime(2023,03,16,19,15,00) },
            //new MovieShowtime { CinemaName = "Royal", MovieTitle = "Tron: Legacy", Showtime = new DateTime(2023,03,16,21,15,00) },
            //new MovieShowtime { CinemaName = "Royal", MovieTitle = "Matrix", Showtime = new DateTime(2023,03,16,19,00,00) },
            //new MovieShowtime { CinemaName = "Royal", MovieTitle = "Matrix", Showtime = new DateTime(2023,03,16,21,00,00) },
            //new MovieShowtime { CinemaName = "Bergakungen", MovieTitle = "Matrix", Showtime = new DateTime(2023,03,16,19,15,00) },
            //new MovieShowtime { CinemaName = "Bergakungen", MovieTitle = "Matrix", Showtime = new DateTime(2023,03,16,21,15,00) },
            //new MovieShowtime { CinemaName = "Bergakungen", MovieTitle = "They Live", Showtime = new DateTime(2023,03,16,19,00,00) },
            //new MovieShowtime { CinemaName = "Bergakungen", MovieTitle = "They Live", Showtime = new DateTime(2023,03,16,21,00,00) },
            //new MovieShowtime { CinemaName = "Royal", MovieTitle = "They Live", Showtime = new DateTime(2023,03,16,19,15,00) },
            //new MovieShowtime { CinemaName = "Royal", MovieTitle = "They Live", Showtime = new DateTime(2023,03,16,21,15,00) },
            //new MovieShowtime { CinemaName = "Royal", MovieTitle = "The Book of Eli", Showtime = new DateTime(2023,03,16,19,00,00) },
            //new MovieShowtime { CinemaName = "Royal", MovieTitle = "The Book of Eli", Showtime = new DateTime(2023,03,16,21,00,00) },
            //new MovieShowtime { CinemaName = "Bergakungen", MovieTitle = "The Book of Eli", Showtime = new DateTime(2023,03,16,19,15,00) },
            //new MovieShowtime { CinemaName = "Bergakungen", MovieTitle = "The Book of Eli", Showtime = new DateTime(2023,03,16,21,15,00) },
            //new MovieShowtime { CinemaName = "Bergakungen", MovieTitle = "Soylent Green", Showtime = new DateTime(2023,03,17,19,00,00) },
            //new MovieShowtime { CinemaName = "Bergakungen", MovieTitle = "Soylent Green", Showtime = new DateTime(2023,03,17,21,00,00) },
            //new MovieShowtime { CinemaName = "Royal", MovieTitle = "Soylent Green", Showtime = new DateTime(2023,03,17,19,15,00) },
            //new MovieShowtime { CinemaName = "Royal", MovieTitle = "Soylent Green", Showtime = new DateTime(2023,03,17,21,15,00) },
        };

        public MainWindow()
        {
            InitializeComponent();
            AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(HeaderClick));

            
            
            using (var db = new BioFilmerContext(_connectionString))
            {
                if(!db.Database.CanConnect())
                {
                    try
                    {
                        db.Database.EnsureCreated();
                        db.Movies.AddRange(Movies);
                        db.MovieShowtimes.AddRange(MovieShowtimes);
                        db.SaveChanges();
                    }
                    catch (Exception ex) 
                    { 
                        Debug.WriteLine( "There was an exception: " + ex.GetBaseException().ToString()); 
                    }
                }
                else
                {
                    Movies = db.Movies.ToList();
                    MovieShowtimes = db.MovieShowtimes.ToList();
                }
            }

            List<string> cinemaNames = MovieShowtimes.Select(m => m.CinemaName).Distinct().ToList();
            List<string> movieTitles = MovieShowtimes.Select(m => m.MovieTitle).Distinct().ToList();
            cinemaNames.Sort();
            movieTitles.Sort();
            bioCmb.ItemsSource = cinemaNames;
            titleCmb.ItemsSource = movieTitles;

            ListViewMovieShowtimes.ItemsSource = MovieShowtimes;
            listSrc = CollectionViewSource.GetDefaultView(ListViewMovieShowtimes.ItemsSource);
        }

        private void ListViewMovieShowtimes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MovieShowtime selectedShowtime = ListViewMovieShowtimes.SelectedItem as MovieShowtime;

            if (selectedShowtime == null)
                return;

            Movie selectedMovie = Movies.Where(x => x.Title == selectedShowtime.MovieTitle).First();

            if (selectedMovie != null)
            {
                TextBlockMovieTitle.Text = selectedMovie.Title;
                TextBlockMovieGenres.Text = String.Join(", ", selectedMovie.Genres);
                TextBlockMovieSynopsis.Text = selectedMovie.Synopsis;
                ShowtimeInfo.Visibility = Visibility.Hidden;
                EditShowtime.Visibility = Visibility.Visible;
                MovieInfo.Visibility = Visibility.Visible;

            }
        }

        string _lastHeader = null;

        // Sorts columns
        private void HeaderClick(object sender, RoutedEventArgs e)
        {
            var columnHeader = e.OriginalSource as GridViewColumnHeader;
            if (columnHeader == null) 
                return; 

            string header = (string)(columnHeader.Column.DisplayMemberBinding as Binding).Path.Path;
            
            listSrc.SortDescriptions.Clear();

            if (header != _lastHeader)
            {
                listSrc.SortDescriptions.Add(new SortDescription(header, ListSortDirection.Ascending));
                _lastHeader = header;
            }
            else
            {
                listSrc.SortDescriptions.Add(new SortDescription(header, ListSortDirection.Descending));
                _lastHeader = null;
            }
            
            // Functionality for a little more nuanced sorting by adding a secondary field
            if (header == "CinemaName")
            {
                listSrc.SortDescriptions.Add(new SortDescription("MovieTitle", ListSortDirection.Ascending));
            } 
            else if (header == "MovieTitle")
            {
                listSrc.SortDescriptions.Add(new SortDescription("CinemaName", ListSortDirection.Ascending));
            }

            listSrc.Refresh();
            e.Handled = true;
        }

        private void AddMovieShowtime(object sender, RoutedEventArgs e)
        {
            bioCmb.SelectedIndex = -1;
            titleCmb.SelectedIndex = -1;
            dateTimePicker.Value = DateTime.Now;
            ShowtimePrompt.Text = "";

            MovieInfo.Visibility = Visibility.Hidden;
            ShowtimeInfo.Visibility = Visibility.Visible;
            ShowtimeInfo.Header = "Lägg till Filmvisning";
        }
        private void EditMovieShowtime(object sender, RoutedEventArgs e)
        {
            MovieShowtime selectedShowtime = ListViewMovieShowtimes.SelectedItem as MovieShowtime;

            var cinemaNames = bioCmb.ItemsSource as List<string>;
            var movieTitles = titleCmb.ItemsSource as List<string>;

            bioCmb.SelectedIndex = cinemaNames.IndexOf(selectedShowtime.CinemaName);
            titleCmb.SelectedIndex = movieTitles.IndexOf(selectedShowtime.MovieTitle);
            dateTimePicker.Value = selectedShowtime.Showtime;
            ShowtimePrompt.Text = "";

            MovieInfo.Visibility = Visibility.Hidden;
            ShowtimeInfo.Visibility = Visibility.Visible;
            ShowtimeInfo.Header = "Redigera Filmvisning";
        }
        private void SaveMovieShowtime(object sender, RoutedEventArgs e)
        {
            string cinema = (string)bioCmb.SelectedItem;
            string movie = (string)titleCmb.SelectedItem;

            if (cinema == null)
                ShowtimePrompt.Text = "Välj en biograf!";
            else if (movie == null)
                ShowtimePrompt.Text = "Välj en film!";
            else
            {
                MovieShowtime showtime = new MovieShowtime()
                {
                    CinemaName = cinema,
                    MovieTitle = movie,
                    Showtime = (DateTime)dateTimePicker.Value
                };

                using (var db = new BioFilmerContext(_connectionString))
                {
                    if ((string)ShowtimeInfo.Header == "Redigera Filmvisning")
                    {
                        MovieShowtime selectedShowtime = ListViewMovieShowtimes.SelectedItem as MovieShowtime;
                        db.MovieShowtimes.Remove(selectedShowtime);
                        int idx = MovieShowtimes.IndexOf(selectedShowtime);
                        MovieShowtimes[idx] = showtime;
                    }
                    else
                    {
                        MovieShowtimes.Add(showtime);
                    }
                    db.MovieShowtimes.Add(showtime);
                    db.SaveChanges();
                }
                listSrc.Refresh();
                ShowtimePrompt.Text = "Filmvisning sparad!";
            }
        }

    }
}
