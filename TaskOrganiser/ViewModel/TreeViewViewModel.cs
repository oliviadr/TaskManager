using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using TaskOrganiser.Commands;
using TaskOrganiser.Model;
using TaskOrganiser.Views;

namespace TaskOrganiser.ViewModel
{
    public class TreeViewViewModel : Model.BaseVM
    {
        private DeleteTaskCommand deleteTask;
        public ICommand DeleteTaskCommand
        {
            get { return deleteTask; }
        }
       
        public ObservableCollection<Tuple<string, TDL>> tuples { get; set; }
        private TDL tdl;
        public TDL Tdl
        {
            get { return tdl; }
            set
            {
                tdl = value;
                OnPropertyChanged("Tdl");
            }

        }

        public ObservableCollection<TDL> TDLs { get; set; }
        public TreeViewViewModel()
        {
            selectedTDL = new TDL();
            selectedTask = new Model.Task();
            deleteTask = new DeleteTaskCommand(this);
            tuples = new ObservableCollection<Tuple<string,TDL>>();
            TDLs = new ObservableCollection<TDL>();
           
            TDLs.Add(new TDL
            {
                Name = "Home",
                Image = new BitmapImage(new Uri(@"/Views/Home.png", UriKind.Relative)),
                ToDoLists = new ObservableCollection<TDL>
        {
            new TDL()
            {
                Name = "Gradina",
                 Image = new BitmapImage(new Uri(@"/Views/Nature.png", UriKind.Relative)),
                Tasks = new ObservableCollection<Model.Task>(),
                ToDoLists = new ObservableCollection<TDL>() // Initialize ToDoLists property
            }
        },

                Tasks = new ObservableCollection<Model.Task>()
                {
                    new Model.Task(){
                    Name = "Water the Flowers",
                    Description = "You need to water the flowers",
                    Category = Category.Home,
                    Deadline = new DateTime(2023, 5, 1),
                    DateOfFinish = new DateTime(2023, 4, 29),
                    Priority = Priority.High,
                    Status = true,
                    Type = Model.Type.Minor
                    }
                }
            });
        }
        public TDL selectedTDL;
        public Model.Task selectedTask;
        public void AddSubTDL(TDL parentTDL, TDL newSubTDL)
        {
            parentTDL.ToDoLists.Add(newSubTDL);
        }

       


    }

}
