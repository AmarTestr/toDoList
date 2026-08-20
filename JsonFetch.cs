using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TaskManagementSystem;
using toDoListLatest;

namespace JsonFetchSpace
{
    public class JsonFetch
    {
        public string filePath { get; private set; }
        public JsonFetch()
        {
            filePath = @"C:\Users\amraj0\learnings\C#\projects\taskamangementsystem\toDoListLatest\jsonresponse.json.txt";
        }

        public List<TaskItem> FetchTasks()
        {
           
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            }
            else
            {
                return new List<TaskItem>();
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

   



}






