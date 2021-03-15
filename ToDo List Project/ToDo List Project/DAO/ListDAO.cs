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
        private string FullPathToFile2
        {
            get
            {
                string directory = Environment.CurrentDirectory;
                string filename = "Lists2.txt";
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
            DuplicateFile();
            bool hasDeleted = false;
            using(StreamReader sr = new StreamReader(this.FullPathToFile2))
            {
                using(StreamWriter sw = new StreamWriter(this.FullPath, false))
                {
                    while (!sr.EndOfStream)
                    {
                        string currentLine = sr.ReadLine();
                        if (currentLine.Length > 1 )
                        {
                            ToDoList currentList = StringToList(currentLine);
                            if (currentList.Id == id)
                            {
                                sw.WriteLine("D");
                                hasDeleted = true;
                            }
                            else
                            {
                                sw.WriteLine(currentLine);
                            }
                        }
                        else if(currentLine.Contains("D"))
                        {
                            sw.WriteLine("D");
                        }
                    }
                }
            }
            return hasDeleted;
        }

        public bool FileExists()
        {
            return File.Exists(this.FullPath);
        }

        public List<ToDoList> GetAllList()
        {
            List<ToDoList> returnedList = new List<ToDoList>();
            using (StreamReader sr = new StreamReader(FullPath))
            {
                while (!sr.EndOfStream)
                {
                    string currentLine = sr.ReadLine();
                    if (currentLine.Length > 1)
                    {
                        returnedList.Add(StringToList(currentLine));
                    }
                }
            }
            return returnedList;
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

        public bool UpdateList(ToDoList list)
        {
            DuplicateFile();
            bool hasUpdated = false;
            using (StreamReader sr = new StreamReader(this.FullPathToFile2))
            {
                using (StreamWriter sw = new StreamWriter(this.FullPath, false))
                {
                    while (!sr.EndOfStream)
                    {
                        string currentLine = sr.ReadLine();
                        if (currentLine.Length > 1)
                        {
                            ToDoList currentList = StringToList(currentLine);
                            if (currentList.Id == list.Id)
                            {
                                sw.WriteLine(ListToString(list));
                                hasUpdated = true;
                            }
                            else
                            {
                                sw.WriteLine(currentLine);
                            }
                        }
                        else if (currentLine.Contains("D"))
                        {
                            sw.WriteLine("D");
                        }
                    }
                }
            }
            return hasUpdated;
        }




        //Helper methods
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

            newList.Tasks = new List<SingleTask>();
            string[] splitString = listString.Split('|');
            newList.Id = Int32.Parse(splitString[0]);
            newList.Name = splitString[1];
            newList.TimeTicks = long.Parse(splitString[2]);
            string[] taskArray = splitString[3].Split(',');
            foreach (string singleString in taskArray)
            {
                if (singleString.Length > 1)
                {
                    string[] tasks = singleString.Split('=');
                    SingleTask newTask = new SingleTask(tasks[0], bool.Parse(tasks[1]));
                    newList.Tasks.Add(newTask);
                }
            }
            return newList;
        }

        private void DuplicateFile()
        {
            using (StreamReader sr = new StreamReader(FullPath))
            {
                using (StreamWriter sw = new StreamWriter(this.FullPathToFile2, false))
                {
                    while (!sr.EndOfStream)
                    {
                        sw.WriteLine(sr.ReadLine());
                    }
                }
            }
        }
    }
}
