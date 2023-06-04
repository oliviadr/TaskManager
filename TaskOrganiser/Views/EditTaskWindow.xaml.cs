using System;
using System.Windows;
using System.Windows.Controls;
using TaskOrganiser.Model;

namespace TaskOrganiser.Views
{
    public partial class EditTaskWindow : Window
    {
        private TDL toDoList;
        private Task task;
        private int index;
        public EditTaskWindow(TDL toDoList, Task task, int index)
        {
            InitializeComponent();
            this.toDoList = toDoList;
            this.task = task;
            this.index = index;
            InitializeTaskFields();
        }

        private void InitializeTaskFields()
        {
            NameTextBox.Text = task.Name;
            DescriptionTextBox.Text = task.Description;
            StatusCheckBox.IsChecked = task.Status;
            PriorityComboBox.Text = task.Priority.ToString();
            TypeComboBox.Text = task.Type.ToString();
            DeadlineDatePicker.Text = task.Deadline.ToString();
            DateOfFinishDatePicker.Text = task.DateOfFinish.ToString();
            CategoryComboBox.Text = task.Category.ToString();
        }
        private void EditTaskButtonClicked(object sender, RoutedEventArgs e)
        {
            Task actualTask = new Task
            {
                Name = NameTextBox.Text,
                Description = DescriptionTextBox.Text,
                Type = (Model.Type)Enum.Parse(typeof(Model.Type), TypeComboBox.Text),
                Category = (Category)Enum.Parse(typeof(Category), CategoryComboBox.Text),
                Priority = (Priority)Enum.Parse(typeof(Priority), PriorityComboBox.Text),
                Status = StatusCheckBox.IsChecked == true,
                Deadline = DeadlineDatePicker.SelectedDate ?? DateTime.MinValue,
                DateOfFinish = DateOfFinishDatePicker.SelectedDate ?? DateTime.MinValue
            };

            toDoList.Tasks[index] = actualTask;
            this.Close();
        }
    }
}
