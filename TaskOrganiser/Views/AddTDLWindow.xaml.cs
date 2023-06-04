using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TaskOrganiser.Model;
using TaskOrganiser.ViewModel;

namespace TaskOrganiser.Views
{
    /// <summary>
    /// Interaction logic for AddTDLWindow.xaml
    /// </summary>
    public partial class AddTDLWindow : Window
    {
        private TreeViewViewModel viewModel;

        public AddTDLWindow(TreeViewViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TDLNameTextBox.Text))
            {
                var selectedImage = (ImageComboBox.SelectedItem as ComboBoxItem).Tag as string;
                viewModel.TDLs.Insert(0, new TDL { Name = TDLNameTextBox.Text, Image = new BitmapImage(new Uri(selectedImage, UriKind.Relative)), Tasks = new ObservableCollection<Model.Task>(), ToDoLists = new ObservableCollection<TDL>() });
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a name for the TDL.", "Error", MessageBoxButton.OK);
            }
        }


    }
}