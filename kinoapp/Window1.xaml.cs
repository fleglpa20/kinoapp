using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace kinoapp
{
    public partial class Window1 : Window
    {
        Grid myGrid;

        public movie selectedMovie { get; set; }

        public Window1(movie selected_movie)
        {
            selectedMovie = selected_movie;
            InitializeComponent();
            myGrid = new Grid();
            CreateGrid();
            CreateSeats();
            Content = myGrid;
        }

        private void CreateGrid()
        {
            int numRows = selectedMovie.cinema.rows;
            int numCols = selectedMovie.cinema.columns;
            double buttonSize = 50;
            double marginSize = 5;

            // Create the Grid
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;

            // Define the Columns
            for (int i = 0; i < numCols; i++)
            {
                ColumnDefinition colDef = new ColumnDefinition
                {
                    Width = new GridLength(buttonSize + marginSize * 2)
                };
                myGrid.ColumnDefinitions.Add(colDef);
            }

            // Define the Rows
            for (int i = 0; i < numRows + 1; i++)
            {
                RowDefinition rowDef = new RowDefinition
                {
                    Height = new GridLength(buttonSize + marginSize * 2)
                };
                myGrid.RowDefinitions.Add(rowDef);
            }

            // Add the Label to the Grid
            Label label = new Label
            {
                Content = "PLÁTNO",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetRow(label, 0);
            Grid.SetColumn(label, 0);
            Grid.SetColumnSpan(label, numCols);
            myGrid.Children.Add(label);
        }

        private void CreateSeats()
        {
            int numRows = selectedMovie.cinema.rows;
            int numCols = selectedMovie.cinema.columns;
            double buttonSize = 50;
            double marginSize = 5;
            for (int row = 1; row <= numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    Button button = new Button
                    {
                        Content = row.ToString() + "-" + (col + 1).ToString(),
                        Width = buttonSize,
                        Height = buttonSize,
                        Margin = new Thickness(marginSize),
                        Background = Brushes.White
                    };
                    button.Click += (sender, e) => {
                        data Data = new data(selectedMovie.uuid, row, col);
                        Window2 okenice = new Window2(Data);
                    };
                    myGrid.Children.Add(button);
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                }
            }
        }

        /*       private void Button_Click(object sender, RoutedEventArgs e, Movie selected_movie)
               {



                   Button button = (Button)sender;
                   if (button.Background == Brushes.White)
                   {
                       button.Background = Brushes.Red;
                   }
                   else if (button.Background == Brushes.Red)
                   {
                       button.Background = Brushes.White;
                   }
    }*/
    }
}