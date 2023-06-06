using AutoMapper;
using ToDoTemplate.Application.Common.Mapping;
using ToDoTemplate.Application.TodoEntities.Commands.UpdateTodoEntity;
using ToDoTemplate.Domain.Enums;

namespace WebApi.Model.TodoEntity
{
    public class UpdateTodoEntity : IMap<UpdateTodoEntityCommand>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Priority? PriorityToDo { get; set; }
        public bool IsDone { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTodoEntity, UpdateTodoEntityCommand>()
                .ForMember(com => com.Id, ent => ent.MapFrom(x => x.Id))
                .ForMember(com => com.Title, ent => ent.MapFrom(x => x.Title))
                .ForMember(com => com.Description, ent => ent.MapFrom(x => x.Description))
                .ForMember(com => com.PriorityToDo, ent => ent.MapFrom(x => x.PriorityToDo))
                .ForMember(com => com.IsDone, ent => ent.MapFrom(x => x.IsDone));
        }
    }
}
