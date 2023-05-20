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
    /// <summary>
    /// Interakční logika pro Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private data Data;
        public Window2(data data)
        {
            InitializeComponent();
            this.Data = data;
            CreateUI(); // Call the CreateUI method
        }

        private void CreateUI()
        {
            Window win;
            win = new Window();

            win.Width = 200;
            win.Height = 300;
            win.MinHeight = 300;
            win.MinWidth = 200;
            double buttonSize = 50;
            double marginSize = 5;

            Grid MainGrid = new Grid();
            MainGrid.ShowGridLines = true;

            for (int x = 0; x < 2; x++)
            {
                RowDefinition row = new RowDefinition();
                row.Name = "row" + x.ToString();
                if (x == 0)
                {
                    row.Height = new GridLength(1, GridUnitType.Star);
                }
                else
                {
                    row.Height = new GridLength(4, GridUnitType.Star);
                }

                MainGrid.RowDefinitions.Add(row);
            }

            Label label = new Label();
            label.Content = "Row: " + Data.row.ToString() + " Seat: " + Data.col.ToString();
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Center;
            label.FontSize = 26;
            Grid.SetRow(label, 0);
            MainGrid.Children.Add(label);

            List<String> options = new List<string>() { "Rezervováno", "Out of order", "Zakoupeno na místě" };
            ComboBox comboBox = new ComboBox();
            comboBox.Width = 100;
            comboBox.Height = 30;

            foreach (String option in options)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = option;

                comboBox.Items.Add(textBlock);
                //comboBox.SelectedValuePath = "ID";
                //comboBox.DisplayMemberPath = option;
            }
            Grid.SetRow(comboBox, 1);
            MainGrid.Children.Add(comboBox);

            win.Content = MainGrid;
            win.Show();

            Button button = new Button
            {
                Content = "OK",
                Width = buttonSize,
                Height = buttonSize,
                Margin = new Thickness(marginSize),
                Background = Brushes.White
            };
            button.SetValue(Grid.RowProperty, 5);
            button.SetValue(Grid.ColumnProperty, 3);
            button.Click += (sender, e) =>
            {
                win.Close();
            };
            MainGrid.Children.Add(button);

        }
    }
}