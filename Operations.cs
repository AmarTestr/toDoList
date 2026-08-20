using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TaskManagementSystem;
using JsonFetchSpace;
namespace toDoListLatest
{

    public class TaskManager
    {
        JsonFetch Fetch = new JsonFetch();
        private List<TaskItem> tasks = new List<TaskItem>(); 
        public string filePath { get; private set; }

        public TaskManager()
        {
            tasks = Fetch.FetchTasks();
            filePath = @"C:\Users\amraj0\learnings\C#\projects\taskamangementsystem\toDoListLatest\jsonresponse.json.txt";

        }


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
            SaveFiles(tasks);
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
                Console.WriteLine("\nTask not found.");
                return;
            }

            task.Status = TaskStatuses.Completed;
            Console.WriteLine("\nTask marked as completed.");
            SaveFiles(tasks);
        }


        public void DeleteTask(string title)
        {
            var task = tasks.FirstOrDefault(t =>
                t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (task == null)
            {
                Console.WriteLine("\nTask not found.");
                return;
            }

            tasks.Remove(task);
            Console.WriteLine("\nTask deleted.");
            SaveFiles(tasks);
        }


        public void FilterByPriority(TaskPriority priority)
        {
            var filtered = tasks.Where(t => t.Priority == priority);

            foreach (var task in filtered)
            {
                task.Display();
            }
        }

        public void SaveFiles(List<TaskItem> tasks)
        {
            string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true
            });
            File.WriteAllText(filePath, json);
            Console.WriteLine("\nTasks saved to JSON file.");
        }
    }

    //the helper functions with the methods to read the input from the user and create the appropriate task objects based on the input.
    public class TaskInputHelper
    {
        public void Details(TaskManager manager, string taskType)
        {
            Console.WriteLine("Title: ");
            string title = Console.ReadLine();

            TaskPriority priority = ReadPriority();
            if (taskType == "Work")
            {
                Console.WriteLine("Work Project Name: ");
                string project = Console.ReadLine();

                manager.AddTask(
                    new WorkTask(title, priority, project));

            }
            else if (taskType == "Personal")
            {
                Console.WriteLine("Personal Project Location: ");
                string location = Console.ReadLine();
                manager.AddTask(
                    new PersonalTask(title, priority, location));
            }

        }

        private TaskPriority ReadPriority()
        {
            while (true)
            {
                Console.Write("Priority (Low/Medium/High): ");
                string input = Console.ReadLine();

                if (Enum.TryParse<TaskPriority>(input, true, out TaskPriority priority)
                    && Enum.IsDefined(typeof(TaskPriority), priority))
                {
                    return priority;
                }

                Console.WriteLine("Outside the provided values");
            }
        }
    }
}

