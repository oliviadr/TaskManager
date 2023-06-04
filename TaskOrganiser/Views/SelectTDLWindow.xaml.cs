using System;
using System.Collections.Generic;
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
    /// Interaction logic for SelectTDLWindow.xaml
    /// </summary>
    public partial class SelectTDLWindow : Window
    {
        public TDL SelectedTDL { get; private set; }

        public SelectTDLWindow(TreeViewViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedTDL = TDLListBox.SelectedItem as TDL;

            if (SelectedTDL != null)
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Please select a TDL to proceed.", "No TDL Selected", MessageBoxButton.OK);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }

}
