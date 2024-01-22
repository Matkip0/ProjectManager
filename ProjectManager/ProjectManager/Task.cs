using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager
{
    public class ProjectManagerContext : DbContext
    {
        public DbSet<ProjectManager.Task> Task { get; set; }
        public DbSet<Todo> Todo { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Worker> Worker { get; set; }
        public DbSet<TeamWorker> TeamWorker { get; set; }

        public string DbPath { get; }

        public ProjectManagerContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "ProjectManager.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamWorker>()
                .HasKey(o => new { o.TeamID, o.WorkerID });
            modelBuilder.Entity<Worker>().HasOne<Todo>().WithMany().IsRequired(false);
        }
    }
    public class Task
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public List<Todo> Todos { get; set; }

        public Task(string name, List<Todo> todos)
        {

            Name = name;
            Todos = todos;
        }
        public Task()
        {

        }
    }


    public class Todo
    {
        public int TodoID { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        public Todo(string name, bool isComplete)
        {
            Name = name;
            IsComplete = isComplete;
        }
        public Todo()
        {

        }
    }

    public class Team
    {
        public int TeamID { get; set; }
        public string Name { get; set; }
        public List<TeamWorker> Workers { get; set; }
        public Task? CurrentTask { get; set; }
        public List<Task>? Tasks { get; set; }
    }

    public class Worker
    {
        public int WorkerID { get; set; }
        public string Name { get; set; }
        public List<TeamWorker> Teams {  get; set; }
        public Todo? CurrentTodo { get; set; }
        public List<Todo>? Todos { get; set; }
    }

    public class TeamWorker
    {
        public int TeamID { get; set; }
        public Team? team { get; set; }
        public int WorkerID { get; set; }
        public Worker Worker { get; set; }
    }

}