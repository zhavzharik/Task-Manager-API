using AutoMapper;
using MyTasks.Application.Common.Mappings;
using MyTasks.Application.MyTasks.Commands.UpdateMyTask;
using MyTasks.Domain;
using System;

namespace MyTasks.WebApi.Models
{
    public class UpdateMyTaskDto : IMapWith<UpdateMyTaskCommand>
    {
        public Guid Id { get; set; }
        public MyTaskType Type { get; set; }
        public string Description { get; set; }
        public DateTime CompletedDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateMyTaskDto, UpdateMyTaskCommand>()
                .ForMember(mytaskCommand => mytaskCommand.Id,
                    opt => opt.MapFrom(mytaskDto => mytaskDto.Id))
                .ForMember(mytaskCommand => mytaskCommand.Type,
                    opt => opt.MapFrom(mytaskDto => mytaskDto.Type))
                .ForMember(mytaskCommand => mytaskCommand.Description,
                    opt => opt.MapFrom(mytaskDto => mytaskDto.Description))
                .ForMember(mytaskCommand => mytaskCommand.CompletedDate,
                    opt => opt.MapFrom(mytaskDto => mytaskDto.CompletedDate));
        }
    }
}
