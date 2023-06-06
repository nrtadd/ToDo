using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTemplate.Domain.Entities;
using ToDoTemplate.Infastructure.Persistence;

namespace Entity.Tests.TodoListTest.Common
{
    public class ContextTodoList
    {
        public static Guid UserID = Guid.NewGuid();
        public static Guid ListEntitytoDelete = Guid.NewGuid();
        public static Guid ListEntitytoUpdate = Guid.NewGuid();
        public static Guid ListEntitytoGet = Guid.NewGuid();
        public static Guid ListSecondEntitytoGet = Guid.NewGuid();
        public static AppDbContext CreateDb()
        {
            var db = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var context = new AppDbContext(db);
            context.Database.EnsureCreated();
            context.todoLists.AddRange(
               
                new TodoList
                {
                    Id = ListEntitytoDelete,
                    UserId = UserID,
                    CreationDate = DateTime.Now,
                    EditDate = null,
                    Title = "ListForDelete",
                    Todos= new List<TodoEntity>(),

                },
                new TodoList
                {
                    Id = ListEntitytoUpdate,
                    UserId = UserID,
                    CreationDate = DateTime.Now,
                    EditDate = null,
                    Title = "ListForUpdate",
                    Todos = new List<TodoEntity>(),

                },
                new TodoList
                {
                    Id = ListEntitytoGet,
                    UserId = UserID,
                    CreationDate = DateTime.Now,
                    EditDate = null,
                    Title = "ListForGet",
                    Todos = new List<TodoEntity>(),

                },
                new TodoList
                {
                    Id = ListSecondEntitytoGet,
                    UserId = UserID,
                    CreationDate = DateTime.Now,
                    EditDate = null,
                    Title = "ListForGetSecond",
                    Todos = new List<TodoEntity>(),

                }

                );
            context.SaveChanges();
            return context;
        }
        public static void RemoveDateBase(AppDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
