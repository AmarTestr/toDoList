using System;
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
    public class AddTask

    { 
        public static List<TaskItem> tasks= new List<TaskItem>();
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

    public class ViewTask
    {
        public void ShowTasks()
        {
            if (AddTask.tasks.Count == 0)
            {
                Console.WriteLine("No tasks found.");
                return;
            }

            foreach (var task in AddTask.tasks)
            {
                Console.WriteLine($"Title: {task.Title}");
                Console.WriteLine($"Priority: {task.Priority}");
                Console.WriteLine($"Status: {task.Status}");
                Console.WriteLine("----------------------");
            }
        }
    }

    public class CompleteTask
    {

    }

    public class FilterTask
    {

    }


}