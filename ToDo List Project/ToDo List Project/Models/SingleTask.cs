using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo_List_Project.Models
{
    public class SingleTask
    {
        public string TaskDescription { get; set; }
        public bool IsCompleted { get; set; }

        public SingleTask(string taskDescription, bool isCompleted)
        {
            this.TaskDescription = taskDescription;
            this.IsCompleted = isCompleted;
        }
    }
}
