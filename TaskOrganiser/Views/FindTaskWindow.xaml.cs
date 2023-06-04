using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TaskOrganiser.Model;

namespace TaskOrganiser.Views
{
    public partial class FindTaskWindow : Window
    {
        private ObservableCollection<TDL> ToDoLists;
        private TDL selectedRoot;
        private ObservableCollection<Tuple<string, TDL>> tuples;
        public FindTaskWindow(ObservableCollection<TDL> ToDoLists, TDL selectedRoot, ObservableCollection<Tuple<string, TDL>> tuples)
        {
            InitializeComponent();
            this.ToDoLists = ToDoLists;
            this.selectedRoot = selectedRoot;
            this.tuples = tuples;
        }

        private void CloseButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FindButtonClicked(object sender, RoutedEventArgs e)
        {
            int count = 0;
            string desiredTaskName = SearchByNameTextBox.Text;
            bool viewOnlySelectedRoot = viewCheckBox.IsChecked == true;

            foreach (TDL tdl in ToDoLists)
            {
                if (viewOnlySelectedRoot && tdl != selectedRoot)
                    continue;

                count += FindTasksInTDL(tdl, desiredTaskName);
            }

            FoundItemsTextBlock.Text = $"{count} task/(s) found";
            FoundTasksListView.ItemsSource = tuples;
        }

        private int FindTasksInTDL(TDL tdl, string desiredTaskName)
        {
            int count = 0;
            if (tdl.Tasks != null)
            {
                foreach (Model.Task task in tdl.Tasks)
                {
                    if (task.Name == desiredTaskName)
                    {
                        tuples.Add(new Tuple<string, TDL>(desiredTaskName, tdl));
                        count++;
                    }
                }
            }
            if (tdl.ToDoLists != null)
            {
                foreach (TDL tdl2 in tdl.ToDoLists)
                {
                    count += FindTasksInTDL(tdl2, desiredTaskName);
                }
            }
            return count;
        }
    }
}
