using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TaskOrganiser.Model
{
    public class TDL : BaseVM
    {
        private string name;
        private BitmapImage image;
        private ObservableCollection<Task> tasks;
        private string _imagePath;

        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                if (_imagePath != value)
                {
                    _imagePath = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public string Name 
        {   
            get { return name; }
            set 
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private ObservableCollection<TDL> _toDoLists;
        public ObservableCollection<TDL> ToDoLists
        {
            get { return _toDoLists; }
            set
            {
                _toDoLists = value;
                OnPropertyChanged("ToDoLists");
            }
        }

        public BitmapImage Image
        {
            get { return image; }
            set 
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }

        public ObservableCollection<Task> Tasks
        {
            get { return tasks; }
            set 
            { 
                tasks = value;
                OnPropertyChanged("Tasks");
            }
        }
    }
}
