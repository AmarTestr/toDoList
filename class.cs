using System;
using System.Linq;
using System.Threading.Tasks;
namespace TaskManagementSystem
{

    public enum TaskPriority
    {
        Low, Medium, High
    }

    public enum TaskStatus
    {
        Pending,
        Completed
    }

    public class TaskItem
    {
        public  string Title { get; set; }
        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; }

        public TaskItem(string title, TaskPriority priority)
        {
            Title= title;
            Priority = priority;
            Status = TaskStatus.Pending;

        }
    }
    
    public class TaskManager
    {
        public static List<TaskItem> tasks = new List<TaskItem>();
    }
    
    public class AddTask:TaskManager
    {       
        public void CreateTask()
        {
            Console.WriteLine("Enter the Task Title");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the task priority Low , Medium , High");
            TaskPriority priority = Enum.Parse<TaskPriority> (Console.ReadLine(), true);
           
            TaskItem task = new TaskItem(title, priority);
            tasks.Add(task);
            Console.WriteLine("Task created");

        }
    }

    public class ViewTask:TaskManager
    {
        public void ShowTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found.");
                return;
            }

            foreach (var task in tasks)
            {
                Console.WriteLine($"Title: {task.Title}");
                Console.WriteLine($"Priority: {task.Priority}");
                Console.WriteLine($"Status: {task.Status}");
                Console.WriteLine("----------------------");
            }
        }
    }

    public class CompleteTask: TaskManager
    { public void Completed()
        {
            Console.WriteLine("Enter the Task Title");
            string title = Console.ReadLine();
            TaskItem task=tasks.FirstOrDefault(t=>t.Title.Equals( title, StringComparison.OrdinalIgnoreCase));
            if(task != null)
            {
                    task.Status = TaskStatus.Completed;
            }
            else
            {
                Console.WriteLine("Cant find the Task status ");
               
            }
        }
       
    }

    public class FilterTask: TaskManager
    {
        public void Filter() {
            Console.WriteLine("Enetre the priority type you want to see ");
            string type = Console.ReadLine();
             if(Enum.TryParse<TaskPriority>(type, true, out TaskPriority priority))
            {
                foreach (var task in tasks)
                {
                    if (task.Priority == priority)
                    {
                        Console.WriteLine($"Title: {task.Title}");
                        Console.WriteLine($"Priority: {task.Priority}");
                        Console.WriteLine($"Status: {task.Status}");
                        Console.WriteLine("----------------------");
                    }
                }
            }
            else
            {
                Console.WriteLine("no such priority exist");
            }
           
            }
    }


}
