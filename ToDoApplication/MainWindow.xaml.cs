using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Tasks> tasks = new ObservableCollection<Tasks>();

       
        public MainWindow()
        {
            InitializeComponent();


            //for (int i = 0; i < 100; i++)
            //    tasks.Add(new Tasks($"Task_{i + 1}", $"Description_{i + 1} for task"));

            
            ToDoListBox.ItemsSource = tasks;
            ToDoListBox.DisplayMemberPath = "Name";
        }
        private void ToDoListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Tasks selected = ToDoListBox.SelectedItem as Tasks;
            if (selected != null)
            {
                MessageBox.Show($"{selected.Description}.\nДата створення: {selected.dateTime}.");
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NewWindow newWindow = new NewWindow();

            newWindow.Owner = this;
            newWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            if( newWindow.ShowDialog() == true)
            {
                Tasks task = newWindow.ReturnObj;
                tasks.Add (task);
              
            }
        }

        private void DeleteButton_Click_1(object sender, RoutedEventArgs e)
        {
            int index = ToDoListBox.SelectedIndex;
            Tasks deleted = ToDoListBox.SelectedItem as Tasks;
          
            if(index == -1)
            {
                MessageBox.Show("Виберіть завдання для видалення.","Warning",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
                for (int i = 0; i < tasks.Count; i++)

                    if (tasks[i].Id == deleted.Id)
                    {
                        tasks.RemoveAt(i);
                    }
                //for (int i = 0; i < notComplTasks.Count; i++)
                //    if (notComplTasks[i].Id == deleted.Id)
                //    {
                //        notComplTasks.RemoveAt(i);
                //    }
                //for (int i = 0; i < complTasks.Count; i++)

                //    if (complTasks[i].Id == deleted.Id)
                //    {
                //        complTasks.RemoveAt(i);
                //    }
            }
        }

        private void CompleteButton_Click_2(object sender, RoutedEventArgs e)
        {
            int index = ToDoListBox.SelectedIndex;
            Tasks selected = ToDoListBox.SelectedItem as Tasks;

            if (index != -1)
            {
                for (int i = 0; i < tasks.Count; i++)

                    if (tasks[i].Id == selected.Id)
                    {
                        tasks[i].isCompleted = true;
                    }
              //  tasks[index].isCompleted = true;
            }
            else
            {
                MessageBox.Show("Виберіть завдання для завершення.", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void AllRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            ToDoListBox.ItemsSource = tasks;
            CompleteBtn.IsEnabled = true;
        }

        private void CompleteRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Tasks> complTasks = new ObservableCollection<Tasks>();

            foreach (Tasks ftask in tasks) 
            {
               
                    if (ftask.isCompleted == true)
                    {
                        complTasks.Add(ftask);
                    } 
                
            }
            ToDoListBox.ItemsSource = complTasks;
            CompleteBtn.IsEnabled = false;
            
        }

        private void NotCompleteRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Tasks> notComplTasks = new ObservableCollection<Tasks>();

            foreach (Tasks ftask in tasks)
            {
               
                    if (ftask.isCompleted == false )
                    {
                        notComplTasks.Add(ftask);
                    }
                
            }
            ToDoListBox.ItemsSource = notComplTasks;
            CompleteBtn.IsEnabled = true;
        }

        public void SerializeJson(string fileName)
        {
            string json = JsonConvert.SerializeObject(tasks);
            File.WriteAllText(fileName, json);
        }
        public void DeserializeJson(string fileName)
        {
            string json = File.ReadAllText(fileName);
            tasks = JsonConvert.DeserializeObject<ObservableCollection<Tasks>>(json);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //Виконав за допомогою JSON
            SerializeJson("Data.json");

            //BinaryFormatter formatter = new BinaryFormatter();
            //using(Stream stream = File.OpenWrite("Data.json"))
            //{
            //    formatter.Serialize(stream, tasks);
            //}
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DeserializeJson("Data.json");

            //if (File.Exists("Data.json"))
            //{
            //    BinaryFormatter formatter = new BinaryFormatter();
            //    using (Stream stream = File.OpenRead("Data.json"))
            //    {
            //        tasks = formatter.Deserialize(stream) as ObservableCollection<Tasks >;
            //    }
            //}
        }
    }
}
