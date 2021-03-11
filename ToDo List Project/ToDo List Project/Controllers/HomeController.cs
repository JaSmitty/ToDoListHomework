using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDo_List_Project.DAO;
using ToDo_List_Project.Models;

namespace ToDo_List_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IListDAO ListDAO;
        public ToDoController(ListDAO listDAO)
        {
            this.ListDAO = listDAO;
        }

        [HttpGet]
        public ActionResult<bool> PathIsWorking()
        {
            return this.ListDAO.FileExists();
        }

        [HttpPost]
        [Route("create/{listName}")]
        public ActionResult<bool> TestFileWrite(List<SingleTask> newList, string listName)
        {
            ListDAO.CreateList(newList, listName);
            return true;
        }
    }
}
