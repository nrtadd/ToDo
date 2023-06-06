using AutoMapper;
using ToDoTemplate.Application.Common.Mapping;
using ToDoTemplate.Application.TodoEntities.Commands.CreateTodoEntity;
using ToDoTemplate.Domain.Enums;

namespace WebApi.Model.TodoEntity
{
    public class CreateTodoEntity : IMap<CreateTodoEntityCommand>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority PiorityToDo { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTodoEntity, CreateTodoEntityCommand>()
                .ForMember(com => com.Title, ent => ent.MapFrom(x => x.Title))
                .ForMember(com => com.Description, ent => ent.MapFrom(x => x.Description))
                .ForMember(com => com.PiorityToDo, ent => ent.MapFrom(x => x.PiorityToDo));
        }
    }
}
