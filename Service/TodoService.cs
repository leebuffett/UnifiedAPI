using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Interface;
using TodoAPI.Model;


namespace TodoAPI.Service
{
    public class TodoService : ITodoService
    {
        string path = "WriteFile.txt";
        public async Task<bool> addTodo(Todo todo)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                await sw.WriteLineAsync(todo.id + "," + todo.Task.ToString() + "," + todo.dueDate + "," + todo.status);
            }

            return true;
        }

        public async Task<List<Todo>> getTodoList()
        {
            List<Todo> todolist = new List<Todo>();
            // if (!File.Exists(path))
            // {
            //     File.Create(path).Close();

            // }
            // else
            // {
            try
            {
                string[] lines = File.ReadAllLines(path);
                if (lines.Length >= 1)
                {
                    foreach (var line in lines)
                    {
                        string[] col = line.Split(',');
                        var newTodo = new Todo();
                        newTodo.id = col[0].ToString();
                        newTodo.Task = col[1].ToString();
                        newTodo.dueDate = DateTime.Parse(col[2].ToString());
                        newTodo.status = bool.Parse(col[3].ToString());
                        todolist.Add(newTodo);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                File.Create(path).Close();
            }






            return todolist;
        }
    }
}