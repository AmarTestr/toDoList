
using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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
        public string Title { get; set; }
        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; }

        public TaskItem(string title, TaskPriority priority)
        {
            Title = title;
            Priority = priority;
            Status = TaskStatus.Pending;
        }

        public virtual void Display()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Priority: {Priority}");
            Console.WriteLine($"Status: {Status}");
        }
    }


    public class WorkTask : TaskItem
    {
        public string ProjectName { get; set; }

        public WorkTask(string title, TaskPriority priority, string projectName)
            : base(title, priority)
        {
            ProjectName = projectName;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Project: {ProjectName}");
            Console.WriteLine("----------------------");
        }
    }


    public class PersonalTask : TaskItem
    {
        public string Location { get; set; }

        public PersonalTask(string title, TaskPriority priority, string location)
            : base(title, priority)
        {
            Location = location;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Location: {Location}");
            Console.WriteLine("----------------------");
        }
    }


    public class TaskManager
    {
        private List<TaskItem> tasks = new List<TaskItem>();
        private string filePath = "C:\\Users\\amar0\\Documents\\jsonresponse.json";


        public void AddTask(TaskItem task)
        {
            bool exists = tasks.Any(t =>
                t.Title.Equals(task.Title, StringComparison.OrdinalIgnoreCase));

            if (exists)
            {
                Console.WriteLine("\n-----Task already exists-----.");
                return;
            }


            tasks.Add(task);
            Console.WriteLine("\n----Task added successfully----.");
        }


        public void ViewTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("\n----No tasks found----.");
                return;
            }

            foreach (var task in tasks)
            {
                task.Display();
            }
        }


        public void CompleteTask(string title)
        {
            var task = tasks.FirstOrDefault(t =>
                t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            task.Status = TaskStatus.Completed;
            Console.WriteLine("Task marked as completed.");
        }


        public void DeleteTask(string title)
        {
            var task = tasks.FirstOrDefault(t =>
                t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            tasks.Remove(task);
            Console.WriteLine("Task deleted.");
        }


        public void FilterByPriority(TaskPriority priority)
        {
            var filtered = tasks.Where(t => t.Priority == priority);

            foreach (var task in filtered)
            {
                task.Display();
            }
        }

        public void SaveFiles()
        {
            string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true
            });
            File.WriteAllText(filePath, json);

            Console.WriteLine("Tasks saved to JSON file.");
        }
    }
}