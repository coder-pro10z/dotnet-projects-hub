using System;
using System.Collections.Generic;
public class Program
{
    // public static object TaskManagerApp { get; private set; }

    /// <summary>
    /// The main entry point for the Task Manager application.  
    /// </summary>

    public static void Initialize()
    {
        // Initialization logic for the Task Manager application can go here.
        // This could include setting up services, loading configurations, etc.
    }

    public static void Run()
    {
        // Logic to run the Task Manager application can go here.
        // This could include starting the main loop, handling user input, etc.
    }

    /// <summary>
    /// 1.create a class UserTask to represent a task in the Task Manager Application.
    /// The class will have propeties such  as taskID, taskName, taskDescription, isCompleted, dueDate, and priority.
    /// /// The class will also have a constructor to initialize these properties.
    /// 2.create a class to store the collection of tasks as List<UserTask>.
    /// </summary>
    public class UserTask
    {
        public int taskID { get; set; }
        public string taskName { get; set; }
        public Boolean isCompleted { get; set; }
        public DateTime dueDate { get; set; }
        public string? priority { get; set; }
        public string? taskDescription { get; set; }

        public UserTask(int id, string name, bool completed, DateTime due, string description = "", string _priority = "Normal")
        {
            taskID = id;
            taskName = name;
            taskDescription = description;
            isCompleted = completed;
            dueDate = due;
            priority = _priority;
        }
    }

    public class TaskManager
    {
        public List<UserTask> userTasks { get; set; }

        // Constructor to initialize the TaskManager with a list of UserTask objects.
        public TaskManager()
        {
            userTasks = new List<UserTask>();
        }
        public TaskManager(List<UserTask> tasks)
        {
            userTasks = tasks;
        }


    }

    public static void Main(string[] args)
    {

        System.Console.WriteLine("Welcome to the Task Manager Application!");

        //initialize an variable with data typr Task
        UserTask task1 = new UserTask(1, "Create a console application", false, DateTime.Now.AddDays(1), "Create a dotnet console application for managing tasks", "High");

        Console.WriteLine($"TaskID:\t\t{task1.taskID}\n" +
                            $"Task:\t\t{task1.taskName}\n" +
                            $"Description:\t{task1.taskDescription}\n" +
                            $"Priority:\t{task1.priority}\n" +
                            $"Status:\t\t{task1.isCompleted}\n" +
                            $"Due Date:\t{task1.dueDate}\n");
        // Console.WriteLine($"TaskID :{task1.taskID} {} {} {} {} {}");

        ///
        /// <summary>
        /// 1.Create a method to create a new task.
        /// This method should take parameters for task details such as ID, name, description, completion
        /// /// status, due date, and priority.
        /// The method should return a new instance of the UserTask class.
        /// 2. Create a method to display task details.
        /// This method should take a UserTask object as a parameter and print its details to the console.
        /// 3. Create a method to mark a task as completed.
        /// This method should take a UserTask object as a parameter and update its completion status.
        /// 4. Create a method to list all tasks.
        /// /// This method should take a list of UserTask objects and print the details of each task to the console.
        /// 5. Create a method to filter tasks by priority.
        /// This method should take a list of UserTask objects and a priority level as parameters,
        /// /// and return a list of tasks that match the specified priority.
        /// /// 6. Create a method to sort tasks by due date.
        /// This method should take a list of UserTask objects and return a sorted list based on 
        /// due date.
        /// /// 7. Create a method to save tasks to a file.
        /// This method should take a list of UserTask objects and save their details to a text file.
        /// 8.Create a method to delete task from the list.
        /// This method should take a list of UserTask objects and a task ID as parameters,
        /// /// and remove the task with the specified ID from the list.
        ///  
        /// </summary>
        /// 

        // Initialize the TaskManager with an empty list of tasks.
        TaskManager taskManager = new TaskManager();

        // Add the created task to the TaskManager's list of tasks.
        taskManager.userTasks.Add(task1);
        foreach (UserTask task in taskManager.userTasks)
        {
            Console.WriteLine($"TaskID: {task.taskID}, Task: {task.taskName}, Status: {task.isCompleted}, Due Date: {task.dueDate}");

        }
        Console.WriteLine("Press any key to exit...");
    }


    // Additional methods for task management can be added here.
    //private methods for creating, displaying, updating, deleting tasks, etc.

    // Create a method to create a new task.
    public static UserTask CreateTask(int id, string name, bool completed, DateTime due, string priority = "Normal", string description = "")
    {
        return new UserTask(id, name, completed, due, priority, description);
    }

    // Create a method to display task details.
    public static void DisplayTask(UserTask task)
    {
        Console.WriteLine($"TaskID: {task.taskID}, Task: {task.taskName}, Description: {task.taskDescription}, " +
                          $"Priority: {task.priority}, Status: {task.isCompleted}, Due Date: {task.dueDate}");
    }

    // Create a method to mark a task as completed.
    public static void markedAsCompleted(UserTask task, bool isCompleted)
    {
        // Logic to mark a task as completed can be implemented here.
        // This could involve updating the isCompleted property of a UserTask object.
        task.isCompleted = isCompleted;
        Console.WriteLine($"Task {task.taskName} marked as completed: {task.isCompleted}");
    }

    // Create a method to list all tasks.
    public static void ListAllTasks(List<UserTask> tasks)
    {
        Console.WriteLine("Listing all tasks:");
        foreach (var task in tasks)
        {
            DisplayTask(task);
        }
    }

    // Create a method to filter tasks by priority.
    public static List<UserTask> FilterTasksByPriority(List<UserTask> tasks, string priority)
    {
        List<UserTask> filteredTasks = new List<UserTask>();
        foreach (var task in tasks)
        {
            if (task.priority != null && task.priority.ToLower() == priority.ToLower())
            {
                filteredTasks.Add(task);
            }
        }
        return filteredTasks;
    }
    
    // Create a method to sort tasks by due date.
}