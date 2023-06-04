using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskOrganiser.Model;
using TaskOrganiser.ViewModel;
using TaskOrganiser.Views;

namespace TaskOrganiser
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void AboutButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Drobot Olivia \n10LF211 ","Info student", MessageBoxButton.OK);
        }

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {   TDL tdl = TDLTreeView.SelectedItem as TDL;
            if (tdl != null)
            {
                AddTaskWindow newWindow = new AddTaskWindow(tdl);
                newWindow.Show();
            }
            else
            {
                MessageBox.Show("Task incomplet!", "Could not add task", MessageBoxButton.OK);
            }
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is TDL SelectedTDL)
            {
                UpdateTaskListView(_showOnlyDoneTasks);
            }
        }

        private void EditButtonClicked(object sender, RoutedEventArgs e)
        {
            TDL desiredItem = TDLTreeView.SelectedItem as TDL;
            Model.Task desiredTask = TaskListView.SelectedItem as Model.Task;
            int index = desiredItem.Tasks.IndexOf(desiredTask);
            EditTaskWindow newWindow = new EditTaskWindow(desiredItem, desiredTask, index);
            newWindow.Show();
        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            TDL desiredItem = TDLTreeView.SelectedItem as TDL;
            Model.Task desiredTask = TaskListView.SelectedItem as Model.Task;
            desiredItem.Tasks.Remove(desiredTask);
        }

        private void SetDoneButtonClicked(object sender, RoutedEventArgs e)
        {
            Model.Task desiredTask = TaskListView.SelectedItem as Model.Task;
            desiredTask.Status = true;
            SolidColorBrush paint = new SolidColorBrush(Colors.Green);
            ListViewItem desiredItem = TaskListView.ItemContainerGenerator.ContainerFromItem(desiredTask) as ListViewItem;
            desiredItem.Background = paint;
        }

        private void MoveUpButtonClicked(object sender, RoutedEventArgs e)
        {
            TDL selectedItem = TDLTreeView.SelectedItem as TDL;
            Model.Task desiredTask = TaskListView.SelectedItem as Model.Task; 
            int index = selectedItem.Tasks.IndexOf(desiredTask);
            if(index > 0)
            {
                Model.Task auxTask = selectedItem.Tasks[index - 1];
                ListViewItem listViewItem1 = TaskListView.ItemContainerGenerator.ContainerFromItem(selectedItem.Tasks[index]) as ListViewItem; 
                ListViewItem listViewItem2 = TaskListView.ItemContainerGenerator.ContainerFromItem(selectedItem.Tasks[index - 1]) as ListViewItem;
                selectedItem.Tasks[index - 1] = desiredTask;
                Brush paint = listViewItem1.Background;
                listViewItem1.Background = listViewItem2.Background;
                listViewItem2.Background = paint;
                selectedItem.Tasks[index] = auxTask;
            }
            else
            {
                MessageBox.Show("Can't move up!", "Error", MessageBoxButton.OK);
            }
        }

        private void MoveDownButtonClicked(object sender, RoutedEventArgs e)
        {
            TDL selectedItem = TDLTreeView.SelectedItem as TDL;
            Model.Task desiredTask = TaskListView.SelectedItem as Model.Task;
            int index = selectedItem.Tasks.IndexOf(desiredTask);
            if(index < selectedItem.Tasks.Count - 1)
            {
                Model.Task auxTask = selectedItem.Tasks[index + 1];
                ListViewItem listViewItem1 = TaskListView.ItemContainerGenerator.ContainerFromItem(selectedItem.Tasks[index]) as ListViewItem;
                ListViewItem listViewItem2 = TaskListView.ItemContainerGenerator.ContainerFromItem(selectedItem.Tasks[index + 1]) as ListViewItem;
                selectedItem.Tasks[index + 1] = desiredTask;
                Brush paint = listViewItem1.Background;
                listViewItem1.Background = listViewItem2.Background;
                listViewItem2.Background = paint;
                selectedItem.Tasks[index] = auxTask;
            }
            else
            {
                MessageBox.Show("Can't move down!", "Error", MessageBoxButton.OK);
            }
        }

        private void FindTaskButtonClicked(object sender, RoutedEventArgs e)
        {
            ViewModel.TreeViewViewModel view = this.DataContext as ViewModel.TreeViewViewModel;
            ObservableCollection<TDL> ToDoLists = view.TDLs;
            TDL selectedRoot = TDLTreeView.SelectedItem as TDL;
            if (selectedRoot != null)
            {
                ObservableCollection<Tuple<string, TDL>> tuples = view.tuples;
                FindTaskWindow newWindow = new FindTaskWindow(ToDoLists, selectedRoot, tuples);
                newWindow.Show();
            }
            else
            {
                MessageBox.Show("You didn't select a view!", "Error", MessageBoxButton.OK);
            }
        }

        private void SortByDeadline(object sender, RoutedEventArgs e)
        {
            TreeViewViewModel treeViewViewModel = this.DataContext as TreeViewViewModel;
            ObservableCollection<TDL> ToDoLists = treeViewViewModel.TDLs;
            foreach (TDL tdl in ToDoLists)
            {
                tdl.Tasks = new ObservableCollection<Model.Task>(tdl.Tasks.OrderBy(t => t.Deadline));
            }
            treeViewViewModel.TDLs = ToDoLists;
        }

        private void SortByPriority(object sender, RoutedEventArgs e)
        {
            TreeViewViewModel treeViewViewModel = this.DataContext as TreeViewViewModel;
            foreach (TDL tdl in treeViewViewModel.TDLs)
            {
                List<Model.Task> lowPriorityTask = new List<Model.Task>();
                List<Model.Task> mediumPriorityTask = new List<Model.Task>();
                List<Model.Task> highPriorityTask = new List<Model.Task>();

                foreach (Model.Task task in tdl.Tasks)
                {
                    if (task.Priority == Priority.Low)
                    {
                        lowPriorityTask.Add(task);
                    }
                    else if (task.Priority == Priority.Medium)
                    {
                        mediumPriorityTask.Add(task);
                    }
                    else if (task.Priority == Priority.High)
                    {
                        highPriorityTask.Add(task);
                    }
                }

                tdl.Tasks.Clear();
                foreach (Model.Task task in lowPriorityTask)
                {
                    tdl.Tasks.Add(task);
                }
                foreach (Model.Task task in mediumPriorityTask)
                {
                    tdl.Tasks.Add(task);
                }
                foreach (Model.Task task in highPriorityTask)
                {
                    tdl.Tasks.Add(task);
                }
            }

            TaskListView.ItemsSource = treeViewViewModel.TDLs;
        }

        private void StatisticsButtonClicked(object sender, RoutedEventArgs e)
        {
            int tasksDueToday = 0;
            int tasksDueTomorrow = 0;
            int tasksOverdue = 0;
            int tasksDone = 0;
            int tasksToBeDone = 0;

            TreeViewViewModel treeView = this.DataContext as TreeViewViewModel;

            foreach (TDL tdl in treeView.TDLs)
            {
                foreach (Model.Task task in tdl.Tasks)
                {
                    if (task.Status)
                    {
                        tasksDone++;
                    }
                    else
                    {
                        if (task.Deadline.Date < DateTime.Now.Date)
                        {
                            tasksOverdue++;
                            tasksToBeDone++;
                        }
                        else if (task.Deadline.Date == DateTime.Now.Date)
                        {
                            tasksDueToday++;
                            tasksToBeDone++;
                        }
                        else if (task.Deadline.Date == DateTime.Now.Date.AddDays(1))
                        {
                            tasksDueTomorrow++;
                            tasksToBeDone++;
                        }
                        else
                        {
                            tasksToBeDone++;
                        }
                    }
                }
            }

            TasksDueTodayBlock.Text = tasksDueToday.ToString();
            TasksDueTomorrowBlock.Text = tasksDueTomorrow.ToString();
            TasksOverdueBlock.Text = tasksOverdue.ToString();
            TasksDoneBlock.Text = tasksDone.ToString();
            TasksToBeDoneBlock.Text = tasksToBeDone.ToString();
        }

        private void TaskListViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TreeViewViewModel treeView = this.DataContext as TreeViewViewModel;
            if(treeView != null)
            {
                Model.Task selectedTask = TaskListView.SelectedItem as Model.Task;
                treeView.selectedTask = selectedTask;
                TDL selectedList = TDLTreeView.SelectedItem as TDL;
                treeView.selectedTDL = selectedList;
            }
        }
        private void AddRootTDLButtonClicked(object sender, RoutedEventArgs e)
        {
            TreeViewViewModel viewModel = this.DataContext as TreeViewViewModel;
            AddTDLWindow addTDLWindow = new AddTDLWindow(viewModel);
            addTDLWindow.ShowDialog();
        }
        private void AddSubTDLButtonClicked(object sender, RoutedEventArgs e)
        {
            TreeViewViewModel viewModel = this.DataContext as TreeViewViewModel;
            TDL selectedTDL = TDLTreeView.SelectedItem as TDL;
            if (selectedTDL != null)
            {
                AddSubTDLWindow addSubTDLWindow = new AddSubTDLWindow(selectedTDL, viewModel);
                addSubTDLWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a TDL to add a Sub-TDL.", "Error", MessageBoxButton.OK);
            }
        }


        private bool _showOnlyDoneTasks = false;
        private void ToggleDoneTasksButton_Click(object sender, RoutedEventArgs e)
        {
            _showOnlyDoneTasks = !_showOnlyDoneTasks;
            UpdateTaskListView(_showOnlyDoneTasks);
        }
        private void UpdateTaskListView(bool showOnlyDoneTasks)
        {
            TDL selectedTDL = TDLTreeView.SelectedItem as TDL;
            if (selectedTDL != null)
            {
                if (showOnlyDoneTasks)
                {
                    TaskListView.ItemsSource = selectedTDL.Tasks.Where(task => task.Status);
                }
                else
                {
                    TaskListView.ItemsSource = selectedTDL.Tasks;
                }
            }
        }
        private bool _showOnlyLateTasks = false;
        private void ToggleLateTasksButton_Click(object sender, RoutedEventArgs e)
        {
            _showOnlyLateTasks = !_showOnlyLateTasks;
            UpdateTaskListView1(_showOnlyLateTasks);
        }
        private void UpdateTaskListView1(bool showOnlyLateTasks)
        {
            TDL selectedTDL = TDLTreeView.SelectedItem as TDL;
            if (selectedTDL != null)
            {
                if (showOnlyLateTasks)
                {
                    TaskListView.ItemsSource = selectedTDL.Tasks.Where((task => task.Status == false && task.DateOfFinish.Date > task.Deadline.Date));
                }
                else
                {
                    TaskListView.ItemsSource = selectedTDL.Tasks;

                }
            }
        }
        private bool _showOnlyUnfTasks = false;
        private void ToggleUnfTasksButton_Click(object sender, RoutedEventArgs e)
        {
            _showOnlyLateTasks = !_showOnlyLateTasks;
            UpdateTaskListView2(_showOnlyLateTasks);
        }
        private void UpdateTaskListView2(bool showOnlyUnfTasks)
        {
            TDL selectedTDL = TDLTreeView.SelectedItem as TDL;
            if (selectedTDL != null)
            {
                if (showOnlyUnfTasks)
                {
                    TaskListView.ItemsSource = selectedTDL.Tasks.Where((task => task.Status == false));
                }
                else
                {
                    TaskListView.ItemsSource = selectedTDL.Tasks;

                }
            }
        }

        private void MoveUpTDLButtonClicked(object sender, RoutedEventArgs e)
        {
            TreeViewViewModel viewModel = this.DataContext as TreeViewViewModel;
            TDL selectedItem = TDLTreeView.SelectedItem as TDL;

            if (selectedItem != null)
            {
                TDL parentTDL = null;
                foreach (var tdl in viewModel.TDLs)
                {
                    parentTDL = FindParentTDL(viewModel.TDLs, tdl, selectedItem);
                    if (parentTDL != null) break;
                }

                if (parentTDL == null) // Selected TDL is a root TDL
                {
                    int index = viewModel.TDLs.IndexOf(selectedItem);

                    if (index > 0)
                    {
                        viewModel.TDLs.Move(index, index - 1);
                        viewModel.OnPropertyChanged("TDLs"); // Notify the UI about the change
                    }
                    else
                    {
                        MessageBox.Show("Can't move up!", "Error", MessageBoxButton.OK);
                    }
                }
                else // Selected TDL is a sub-TDL
                {
                    int index = parentTDL.ToDoLists.IndexOf(selectedItem);

                    if (index > 0)
                    {
                        var updatedToDoLists = new ObservableCollection<TDL>(parentTDL.ToDoLists);
                        updatedToDoLists.RemoveAt(index);
                        updatedToDoLists.Insert(index - 1, selectedItem);
                        parentTDL.ToDoLists = updatedToDoLists; // Directly update the property
                    }
                    else
                    {
                        MessageBox.Show("Can't move up!", "Error", MessageBoxButton.OK);
                    }
                }
            }
            else
            {
                MessageBox.Show("No TDL is selected!", "Error", MessageBoxButton.OK);
            }
        }


        private void MoveDownTDLButtonClicked(object sender, RoutedEventArgs e)
        {
            TreeViewViewModel viewModel = this.DataContext as TreeViewViewModel;
            TDL selectedItem = TDLTreeView.SelectedItem as TDL;

            if (selectedItem != null)
            {
                TDL parentTDL = null;
                foreach (var tdl in viewModel.TDLs)
                {
                    parentTDL = FindParentTDL(viewModel.TDLs, tdl, selectedItem);
                    if (parentTDL != null) break;
                }

                if (parentTDL == null) // Selected TDL is a root TDL
                {
                    int index = viewModel.TDLs.IndexOf(selectedItem);

                    if (index < viewModel.TDLs.Count - 1)
                    {
                        viewModel.TDLs.Move(index, index + 1);
                        viewModel.OnPropertyChanged("TDLs"); // Notify the UI about the change
                    }
                    else
                    {
                        MessageBox.Show("Can't move down!", "Error", MessageBoxButton.OK);
                    }
                }
                else // Selected TDL is a sub-TDL
                {
                    int index = parentTDL.ToDoLists.IndexOf(selectedItem);

                    if (index < parentTDL.ToDoLists.Count - 1)
                    {
                        var updatedToDoLists = new ObservableCollection<TDL>(parentTDL.ToDoLists);
                        updatedToDoLists.RemoveAt(index);
                        updatedToDoLists.Insert(index + 1, selectedItem);
                        parentTDL.ToDoLists = updatedToDoLists; // Directly update the property
                    }
                    else
                    {
                        MessageBox.Show("Can't move down!", "Error", MessageBoxButton.OK);
                    }
                }
            }
            else
            {
                MessageBox.Show("No TDL is selected!", "Error", MessageBoxButton.OK);
            }
        }


        private void DeleteTDLButtonClicked(object sender, RoutedEventArgs e)
        {
            TreeViewViewModel viewModel = this.DataContext as TreeViewViewModel;
            TDL selectedItem = TDLTreeView.SelectedItem as TDL;

            if (selectedItem != null)
            {
                TDL parentTDL = null;
                foreach (var tdl in viewModel.TDLs)
                {
                    parentTDL = FindParentTDL(viewModel.TDLs, tdl, selectedItem);
                    if (parentTDL != null) break;
                }

                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete the selected TDL?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    if (parentTDL == null) // Selected TDL is a root TDL
                    {
                        viewModel.TDLs.Remove(selectedItem);
                        viewModel.OnPropertyChanged("TDLs"); // Notify the UI about the change
                    }
                    else // Selected TDL is a sub-TDL
                    {
                        parentTDL.ToDoLists.Remove(selectedItem);
                        viewModel.OnPropertyChanged("TDLs"); // Notify the UI about the change
                    }
                }
            }
            else
            {
                MessageBox.Show("No TDL is selected!", "Error", MessageBoxButton.OK);
            }
        }



        private void EditTDLButtonClicked(object sender, RoutedEventArgs e)
        {
            TDL selectedTDL = TDLTreeView.SelectedItem as TDL;
            if (selectedTDL != null)
            {
                EditTDLWindow editTDLWindow = new EditTDLWindow(selectedTDL);
                editTDLWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("No TDL is selected!", "Error", MessageBoxButton.OK);
            }
        }
        public TDL FindParentTDL(ObservableCollection<TDL> rootTDLs, TDL root, TDL targetTDL)
        {
            if (root.ToDoLists.Contains(targetTDL))
                return root;

            foreach (var child in root.ToDoLists)
            {
                var parentTDL = FindParentTDL(rootTDLs, child, targetTDL);
                if (parentTDL != null)
                    return parentTDL;
            }

            return null;
        }

        private void ChangeTDLPathButton_Clicked(object sender, RoutedEventArgs e)
        {
            TDL selectedItem = TDLTreeView.SelectedItem as TDL;

            if (selectedItem != null)
            {
                TreeViewViewModel viewModel = this.DataContext as TreeViewViewModel;
                SelectTDLWindow selectTDLWindow = new SelectTDLWindow(viewModel);

                if (selectTDLWindow.ShowDialog() == true)
                {
                    TDL newParentTDL = selectTDLWindow.SelectedTDL;

                    // Remove the TDL from the old parent
                    TDL oldParentTDL = null;
                    foreach (var tdl in viewModel.TDLs)
                    {
                        oldParentTDL = FindParentTDL(viewModel.TDLs, tdl, selectedItem);
                        if (oldParentTDL != null) break;
                    }

                    if (oldParentTDL != null)
                    {
                        oldParentTDL.ToDoLists.Remove(selectedItem);
                        oldParentTDL.OnPropertyChanged("ToDoLists"); // Notify the UI about the change in the old parent
                    }
                    else
                    {
                        viewModel.TDLs.Remove(selectedItem);
                        viewModel.OnPropertyChanged("TDLs"); // Notify the UI about the change in the root TDLs
                    }

                    // Add the TDL to the new parent
                    newParentTDL.ToDoLists.Add(selectedItem);
                    newParentTDL.OnPropertyChanged("ToDoLists"); // Notify the UI about the change in the new parent
                }
            }
            else
            {
                MessageBox.Show("No TDL is selected!", "Error", MessageBoxButton.OK);
            }
        }


    }
}
