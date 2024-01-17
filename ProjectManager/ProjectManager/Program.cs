using Microsoft.EntityFrameworkCore;
using ProjectManager;
using System;
using System.Linq;

//seedTasks();
//seedWorkers();

using (ProjectManagerContext context = new())
{
    var tasks = context.Task.Include(task => task.Todos);
    foreach (var task in tasks)
    {
        Console.WriteLine($"Task: {task.Name}");
        foreach(var todo in task.Todos)
        {
            Console.WriteLine($"-{todo.Name}");
        }
    }
}

printIncompleteTasksAndTodos();


    //static void Blogging() 
    //{ 
    //    using var db = new BloggingContext();

//    // Note: This sample requires the database to be created before running.
//    Console.WriteLine($"Database path: {db.DbPath}.");

//    // Create
//    Console.WriteLine("Inserting a new blog");
//    db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
//    db.SaveChanges();

//    // Read
//    Console.WriteLine("Querying for a blog");
//    var blog = db.Blogs
//        .OrderBy(b => b.BlogId)
//        .First();

//    // Update
//    Console.WriteLine("Updating the blog and adding a post");
//    blog.Url = "https://devblogs.microsoft.com/dotnet";
//    blog.Posts.Add(
//        new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
//    db.SaveChanges();

//    // Delete
//    Console.WriteLine("Delete the blog");
//    db.Remove(blog);
//    db.SaveChanges();
//}

    static void seedTasks()
    {
        using var db = new ProjectManagerContext();
        Console.WriteLine($"Database path: {db.DbPath}.");

        List<Todo> produceSoftwareTodoList = new List<Todo>();
        produceSoftwareTodoList.Add(new Todo("Write code", false));
        produceSoftwareTodoList.Add(new Todo("Compile source", false));
        produceSoftwareTodoList.Add(new Todo("Test program", false));
        ProjectManager.Task produceSoftware = new("Produce software", produceSoftwareTodoList);

        List<Todo> brewCoffeeTodoList = new List<Todo>();
        brewCoffeeTodoList.Add(new Todo("Pour water", false));
        brewCoffeeTodoList.Add(new Todo("Pour coffee", false));
        brewCoffeeTodoList.Add(new Todo("Turn on", false));
        ProjectManager.Task brewCoffee = new("Brew coffee", brewCoffeeTodoList);

        db.Add(produceSoftware);
        db.Add(brewCoffee);
        db.SaveChanges();
    }

static void printIncompleteTasksAndTodos()
{
    Console.WriteLine("\n\nTasks not done yet");
    using (var context = new ProjectManagerContext())
    {
        var tasks = context.Task.Include(task => task.Todos);
        foreach (var task in tasks)
        {
            Console.WriteLine($"Task: {task.Name}");
            var result = task.Todos.Where(todo => todo.IsComplete == false);
            foreach (var todo in result)
            {
                Console.WriteLine($"-{todo.Name}");
            }
        }
    }
}

static void seedWorkers()
{
    using (var context = new ProjectManagerContext())
    {
        Console.WriteLine("Seeding Workers");
        Team Frontend = new() { Name = "Frontend" };
        Team Backend = new() { Name = "Backend" };
        Team Testere = new() { Name = "Testere" };
        Worker SteenSecher = new() { Name = "Steen Secher" };
        Worker EjvindMøller = new() { Name = "Ejvind Møller" };
        Worker KonradSommer = new() { Name = "Konrad Sommer" };
        Worker SofusLotus = new() { Name = "Sofus Lotus" };
        Worker RemoLademann = new() { Name = "Remo Lademann" };
        Worker EllaFanth = new() { Name = "Ella Fanth" };
        Worker AnneDam = new() { Name = "Anne Dam" };

        //Frontend
        context.TeamWorker.Add(new TeamWorker { team = Frontend, Worker = SteenSecher });
        context.TeamWorker.Add(new TeamWorker { team = Frontend, Worker = EjvindMøller });
        context.TeamWorker.Add(new TeamWorker { team = Frontend, Worker = KonradSommer });
        //Backend
        context.TeamWorker.Add(new TeamWorker { team = Backend, Worker = KonradSommer });
        context.TeamWorker.Add(new TeamWorker { team = Backend, Worker = SofusLotus });
        context.TeamWorker.Add(new TeamWorker { team = Backend, Worker = RemoLademann });
        //Testere
        context.TeamWorker.Add(new TeamWorker { team = Testere, Worker = EllaFanth });
        context.TeamWorker.Add(new TeamWorker { team = Testere, Worker = AnneDam });
        context.TeamWorker.Add(new TeamWorker { team = Testere, Worker = SteenSecher });
        context.SaveChanges();
    }
}