using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TaskManger.Model;

namespace TaskManger.DATA
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks => Set<TaskItem>();


        public void SeedData()
        {
            if (!Tasks.Any())
            {
                Tasks.AddRange(
                    new TaskItem
                    {
                        Title = "Buy groceries",
                        Description = "Milk, Bread, Eggs",
                        DueDate = new DateTime(2025, 5, 1),
                        IsComplete = false
                    },
                    new TaskItem
                    {
                        Title = "Walk the dog",
                        Description = "Evening walk in the park",
                        DueDate = DateTime.Today.AddDays(1),
                        IsComplete = false
                    },
                    new TaskItem
                    {
                        Title = "Pay utility bills",
                        Description = "Electricity and water",
                        DueDate = DateTime.Today.AddDays(2),
                        IsComplete = true
                    }
                );

                SaveChanges();
            }
        }
        }
}
