using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo_List_Project.Models;

namespace ToDo_List_Project.DAO
{
    interface IListDAO
    {
        List<ToDoList> GetAllList();

        ToDoList GetListById(int id);

        ToDoList CreateList(ToDoList newList);

        ToDoList UpdateList(ToDoList list);

        bool DeleteList(int id);

        bool FileExists();
    }
}
