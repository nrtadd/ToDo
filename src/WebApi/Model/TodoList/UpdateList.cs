using AutoMapper;
using ToDoTemplate.Application.Common.Mapping;
using ToDoTemplate.Application.TodoLists.Command.UpdateTodoList;

namespace WebApi.Model.TodoList
{
    public class UpdateList : IMap<UpdateTodoListCommand>
    {
        public Guid id { get; set; }
        public string? Title { get; set; }
        public List<Guid>? Todos { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateList, UpdateTodoListCommand>()
                .ForMember(com => com.Title, ent => ent.MapFrom(x => x.Title))
                .ForMember(com => com.Todos, ent => ent.MapFrom(x => x.Todos));
        }
    }
}
