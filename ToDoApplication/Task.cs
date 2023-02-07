using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication
{

    public class Tasks
    {
        public string Name { get; set; }
        public string Description { get; set; }//властивість Description
        public bool isCompleted { get; set; }
        public string Id { get; set; }

        public DateTime dateTime { get; set; }
        Guid guid { get; set; }

        
        public Tasks(string Name, string Description)
        {
            this.Name = Name;
            this.isCompleted = false;
            this.Description = Description;
            dateTime = DateTime.Now;//Задаємо час створення

            Id = Guid.NewGuid().ToString();//Створюємо унікальний Id



        }
       

    }
}
