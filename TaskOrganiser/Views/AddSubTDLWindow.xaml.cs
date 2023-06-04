using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media.Imaging;
using TaskOrganiser.Model;
using TaskOrganiser.ViewModel;
using System.Windows.Controls;
using System;

namespace TaskOrganiser.Views
{
    public partial class AddSubTDLWindow : Window
    {
        private TDL parentTDL;
        private TreeViewViewModel viewModel;

        public AddSubTDLWindow(TDL parentTDL, TreeViewViewModel viewModel)
        {
            InitializeComponent();
            this.parentTDL = parentTDL;
            this.viewModel = viewModel;
        }

        public string SubTDLName
        {
            get
            {
                return SubTDLNameTextBox.Text;
            }
        }

        public Image SelectedImage
        {
            get
            {
                return (Image)ImageComboBox.SelectedItem;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SubTDLNameTextBox.Text))
            {
                TDL newSubTDL = new TDL { Name = SubTDLNameTextBox.Text, Tasks = new ObservableCollection<Model.Task>(), ToDoLists = new ObservableCollection<TDL>(), Image = new BitmapImage(new Uri((ImageComboBox.SelectedItem as ComboBoxItem).Tag.ToString(), UriKind.Relative)) };
                viewModel.AddSubTDL(parentTDL, newSubTDL);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a name for the Sub-TDL.", "Error", MessageBoxButton.OK);
            }
        }

    }
}
