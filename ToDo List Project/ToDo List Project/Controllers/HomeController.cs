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
        [Route("create")]
        public ActionResult<ToDoList> TestFileWrite(ToDoList tasks)
        {
            return ListDAO.CreateList(tasks);
            
        }

        [HttpGet]
        [Route("list")]
        public ActionResult<List<ToDoList>> GetAllList()
        {
            return this.ListDAO.GetAllList();
        }


            [HttpGet]
        [Route("list/{id}")]
        public ActionResult<ToDoList> GetListById(int id)
        {
            return this.ListDAO.GetListById(id);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult<bool> DeleteList(int id)
        {
            return this.ListDAO.DeleteList(id);
        }
    }
}
