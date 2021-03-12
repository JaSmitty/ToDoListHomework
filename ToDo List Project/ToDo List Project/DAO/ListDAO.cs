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
        public ToDoList CreateList(ToDoList newList)
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
            newList.Id = count;
            newList.TimeTicks = DateTime.Now.Ticks;
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

        public List<ToDoList> GetAllList()
        {
            throw new NotImplementedException();
        }

        public ToDoList GetListById(int id)
        {
            using (StreamReader sr = new StreamReader(FullPath))
            {
                ToDoList newList = null;
                while (!sr.EndOfStream)
                {
                    newList = StringToList(sr.ReadLine());
                    if ( newList.Id == id)
                    {
                        return newList;
                    }
                }
                return newList;
            }
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
            return $"{list.Id}|{list.Name}|{list.TimeTicks}|" + taskString;
        }

        private ToDoList StringToList(string listString)
        {
            ToDoList newList = new ToDoList();
            string[] splitString = listString.Split('|');
            newList.Id = Int32.Parse(splitString[0]);
            newList.Name = splitString[1];
            newList.TimeTicks = long.Parse(splitString[2]);
            string[] taskArray = splitString[3].Split(',');
            foreach(string singleString in taskArray)
            {
                if (singleString.Length > 0)
                {
                    string[] tasks = singleString.Split('=');
                    SingleTask newTask = new SingleTask(tasks[0], bool.Parse(tasks[1]));
                    newList.Tasks = new List<SingleTask>();
                    newList.Tasks.Add(newTask);
                }
            }
            return newList;
        }
    }
}
