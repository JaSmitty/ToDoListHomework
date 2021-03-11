using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo_List_Project.Models
{
    public class ToDoList
    {
        public ToDoList(int id, string name, long unixTime, List<SingleTask> list)
        {
            this.Id = id;
            this.Name = name;
            this.UnixTime = unixTime;
            this.Tasks = list;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Time
        {
            get
            {
                return UnixTimeStampToDateTime(this.UnixTime).AddHours((double)-4);

            }
        }

        public long UnixTime { get; set; }

        public List<SingleTask> Tasks { get; set; }

        private DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            System.DateTime dtDateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp);
            return dtDateTime;
        }
    }
}
