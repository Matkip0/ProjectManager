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
    }
    public class Task
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public List<Todo> Todos { get; set; }

        public Task( string name, List<Todo> todos)
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

        public Todo( string name, bool isComplete)
        {
            Name = name;
            IsComplete = isComplete;
        }
    public Todo()
    {
        
    }
}

}