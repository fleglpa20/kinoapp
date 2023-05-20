using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Newtonsoft.Json;
using System.IO;
using System.ComponentModel;
using System.Windows.Data;
using kinoapp;

namespace kinoapp
{
    public partial class MainWindow : Window
    {
        private ListView movieList;

        public static List<movie> LoadJson(string path)
        {
            string json = File.ReadAllText(path);

            List<movie> movies = JsonConvert.DeserializeObject<List<movie>>(json);

            return movies;
        }

        public MainWindow()
        {
            InitializeComponent();
            Createlist();
        }

        public void Createlist()
        {
            List<movie> movies = LoadJson("C:/Users/patri/source/repos/kinoapp/kinoapp/filmy.json");
            // Vytvoření nového ListView
            movieList = new ListView();

            // Nastavení vlastností ListView
            movieList.Name = "movieList";
            movieList.Width = 1920;
            movieList.Height = 1080;

            // Přidání sloupců ListView
            GridView gridView = new GridView();
            movieList.View = gridView;
            gridView.Columns.Add(new GridViewColumn { Header = "Název filmu", Width = 150, DisplayMemberBinding = new Binding("name") });
            gridView.Columns.Add(new GridViewColumn { Header = "Čas promítání", Width = 150, DisplayMemberBinding = new Binding("date") });
            gridView.Columns.Add(new GridViewColumn { Header = "Místo promítání", Width = 150, DisplayMemberBinding = new Binding("cinema.name") });

            foreach (movie movie in movies)
            {
                movieList.Items.Add(movie);
            }

            movieList.SelectionChanged += OnMovieListSelectionChanged;

            // Přidání ListView do rodičovského prvku
            this.Content = movieList;
        }
        private void OnMovieListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (movieList != null && movieList.SelectedItem != null)
            {
                movie selectedMovie = (movie)movieList.SelectedItem;

                Window1 okenice = new Window1(selectedMovie);
                okenice.Show();
            }
        }
    }
}
