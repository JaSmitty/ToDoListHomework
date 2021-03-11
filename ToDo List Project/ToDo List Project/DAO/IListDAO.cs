using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo_List_Project.Models;

namespace ToDo_List_Project.DAO
{
    interface IListDAO
    {
        ToDoList GetAllList();

        ToDoList GetListById(int id);

        ToDoList CreateList(List<SingleTask> list, string name);

        ToDoList UpdateList(ToDoList list);

        bool DeleteList(int id);

        bool FileExists();
    }
}
