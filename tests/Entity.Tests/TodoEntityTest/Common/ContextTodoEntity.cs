using Microsoft.EntityFrameworkCore;
using ToDoTemplate.Domain.Entities;
using ToDoTemplate.Infastructure.Persistence;

namespace Entity.Tests.TodoEntityTest.Common
{
    public class ContextTodoEntity
    {
        public static Guid UserID = Guid.NewGuid();
        public static Guid EntitytoDelete = Guid.NewGuid();
        public static Guid EntitytoUpdate = Guid.NewGuid();
        public static Guid EntitytoGet = Guid.NewGuid();
        public static Guid SecondEntitytoGet = Guid.NewGuid();
        public static AppDbContext CreateDb()
        {
            var db = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var context = new AppDbContext(db);
            context.Database.EnsureCreated();
            context.todoEntities.AddRange(
                new TodoEntity
                {
                    Id = EntitytoDelete,
                    UserId = UserID,
                    Title = "TitleEntityforDelete",
                    Description = "DescriptionEntityforDelete",
                    PriorityToDo = 0,
                    IsDone = false,
                    CreationDate = DateTime.Now,
                    EditDate = null,
                    todoList = null,

                },
                new TodoEntity
                {
                    Id = SecondEntitytoGet,
                    UserId = UserID,
                    Title = "TitleEntityforGet",
                    Description = "DescriptionEntityforGet",
                    PriorityToDo = 0,
                    IsDone = false,
                    CreationDate = DateTime.Now,
                    EditDate = null,
                    todoList = null,

                },
                new TodoEntity
                {
                    Id = EntitytoGet,
                    UserId = UserID,
                    Title = "TitleEntityforGetList",
                    Description = "DescriptionEntityforGetList",
                    PriorityToDo = 0,
                    IsDone = false,
                    CreationDate = DateTime.Now,
                    EditDate = null,
                    todoList = null,

                },
                new TodoEntity
                {
                    Id = EntitytoUpdate,
                    UserId = UserID,
                    Title = "TitleEntityforUpdate",
                    Description = "DescriptionEntityforUpdate",
                    PriorityToDo = 0,
                    IsDone = false,
                    CreationDate = DateTime.Now,
                    EditDate = null,
                    todoList = null,

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

