using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Model
{
    public enum status{
        Completed,
        Pending
    }
    public class Todo
    {
        public string id{get;set;}
        public string Task{get;set;}
        public DateTime dueDate{get;set;}
        public bool status{get;set;}
    }
}