

using System;
using TaskManagementSystem;
using toDoListLatest;
using JsonFetchSpace;


class Program
{
	public static void Main(string[] args)
	{
		TaskManager manager = new TaskManager();
		TaskInputHelper helper = new TaskInputHelper();
        JsonFetch Fetch=new JsonFetch();
		Fetch.FetchTasks();


        while (true)
		{
			Console.WriteLine("\nTask System");
			Console.WriteLine("1. Add Work Task");
			Console.WriteLine("2. Add Personal Task");
			Console.WriteLine("3. View Tasks");
			Console.WriteLine("4. Complete Task");
			Console.WriteLine("5. Delete Task");
			Console.WriteLine("6. Filter Tasks");
			Console.WriteLine("7. Exit");
			Console.Write("Enter choice: ");

			string choice = Console.ReadLine();

			switch (choice)
			{
				case "1":

                    helper.Details(manager,"Work");	
                    break;

				case "2":
                    helper.Details(manager, "Personal");
					break;

				case "3":
					manager.ViewTasks();
					break;

				case "4":
					Console.WriteLine("Enter title: ");
					manager.CompleteTask(Console.ReadLine());
					break;

				case "5":
					Console.WriteLine("Enter title: ");
					manager.DeleteTask(Console.ReadLine());
					break;

				case "6":
					Console.WriteLine("Priority (Low/Medium/High): ");
					TaskPriority fp =
						Enum.Parse<TaskPriority>(Console.ReadLine(), true);

					manager.FilterByPriority(fp);
					break;
				
				case "7":
					return;
			}
		}
	}
}
