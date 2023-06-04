using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TaskOrganiser.Model;

namespace TaskOrganiser.Views
{
    public partial class EditTDLWindow : Window
    {
        private TDL toDoList;
        private List<string> images;

        public EditTDLWindow(TDL toDoList)
        {
            InitializeComponent();
            this.toDoList = toDoList;
            InitializeImageList();
            InitializeTDLFields();
        }

        private void InitializeImageList()
        {
            images = new List<string>
            {
                "Nature.png",
                "Home.png",
                "Shopping.png"
            };
            ImageComboBox.ItemsSource = images;
        }

        private void InitializeTDLFields()
        {
            NameTextBox.Text = toDoList.Name;
            if (!string.IsNullOrEmpty(toDoList.ImagePath))
            {
                TDLImage.Source = new BitmapImage(new Uri(toDoList.ImagePath, UriKind.Relative));
            }
        }


        private void ImageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedImagePath = (string)ImageComboBox.SelectedItem;
            TDLImage.Source = new BitmapImage(new Uri(selectedImagePath, UriKind.Relative));
        }

        private void SaveButtonClicked(object sender, RoutedEventArgs e)
        {
            toDoList.Name = NameTextBox.Text;
            toDoList.ImagePath = (string)ImageComboBox.SelectedItem;
            toDoList.OnPropertyChanged(nameof(toDoList.ImagePath));

            this.Close();
        }
    }
}
