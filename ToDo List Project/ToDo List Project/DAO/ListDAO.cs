using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ToDo_List_Project.Models;

namespace ToDo_List_Project.DAO
{
    public class ListDAO : IListDAO
    {
        private string FullPath 
        {
            get
            {
                string directory = Environment.CurrentDirectory;
                string filename = "Lists.txt";
                string fullPath = Path.Combine(directory, filename);
                return fullPath;
            }
            
        }
        public ToDoList CreateList(List<SingleTask> list, string name)
        {
            int count = 1;
            using(StreamReader sr = new StreamReader(FullPath))
            {
                while (!sr.EndOfStream)
                {
                    count++;
                    sr.ReadLine();
                }
            }
            ToDoList newList = new ToDoList(count, name, DateTime.Now.Ticks, list);
            using (StreamWriter sw = new StreamWriter(this.FullPath, true))
            {
                sw.WriteLine(ListToString(newList));
            }
            return newList;
        }

        public bool DeleteList(int id)
        {
            throw new NotImplementedException();
        }

        public bool FileExists()
        {
            return File.Exists(this.FullPath);
        }

        public ToDoList GetAllList()
        {
            throw new NotImplementedException();
        }

        public ToDoList GetListById(int id)
        {
            throw new NotImplementedException();
        }

        public ToDoList UpdateList(ToDoList list)
        {
            throw new NotImplementedException();
        }

        private string ListToString(ToDoList list)
        {
            string taskString = "";
            foreach(Models.SingleTask task in list.Tasks)
            {
                taskString += $"{task.TaskDescription}={task.IsCompleted},";
            }
            return $"{list.Id}|{list.Name}|{list.UnixTime}|" + taskString;
        }
    }
}
