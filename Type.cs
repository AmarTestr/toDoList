
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

	public enum TaskStatuses
	{
		Pending,
		Completed
	}

	public class TaskItem
	{
		public string Title { get; set; }
		public TaskPriority Priority { get; set; }
		public TaskStatuses Status { get; set; }

		public TaskItem(string title, TaskPriority priority)
		{
			Title = title;
			Priority = priority;
			Status = TaskStatuses.Pending;
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
}

