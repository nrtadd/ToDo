using AutoMapper;
using ToDoTemplate.Application.Common.Mapping;
using ToDoTemplate.Application.TodoLists.Command.CreateTodoList;

namespace WebApi.Model.TodoList
{
    public class CreateList : IMap<CreateTodoListCommand>
    {
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateList, CreateTodoListCommand>()
                .ForMember(com => com.Title, ent => ent.MapFrom(x => x.Title));
        }
    }

}
