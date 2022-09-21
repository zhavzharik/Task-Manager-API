using AutoMapper;
using MyTasks.Application.Common.Mappings;
using MyTasks.Application.MyTasks.Commands.MarkMyTaskCompleted;
using MyTasks.Domain;
using System;

namespace MyTasks.WebApi.Models
{
    public class MarkMyTaskCompletedDto : IMapWith<MarkMyTaskCompletedCommand>
    {
        public Guid Id { get; set; }
        public CompletedStatus IsCompleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MarkMyTaskCompletedDto, MarkMyTaskCompletedCommand>()
                .ForMember(mytaskCommand => mytaskCommand.Id,
                    opt => opt.MapFrom(mytaskDto => mytaskDto.Id))
                .ForMember(mytaskCommand => mytaskCommand.IsCompleted,
                    opt => opt.MapFrom(mytaskDto => mytaskDto.IsCompleted));        
        }
    } 
}
