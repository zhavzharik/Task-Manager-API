using AutoMapper;
using MyTasks.Application.Common.Mappings;
using MyTasks.Application.MyTasks.Commands.CreateMyTask;
using MyTasks.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyTasks.WebApi.Models
{
    public class CreateMyTaskDto : IMapWith<CreateMyTaskCommand>
    {
        [Required]
        public MyTaskType Type { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime CompletedDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateMyTaskDto, CreateMyTaskCommand>()
                .ForMember(mytaskCommand => mytaskCommand.Type,
                    opt => opt.MapFrom(mytaskDto => mytaskDto.Type))
                .ForMember(mytaskCommand => mytaskCommand.Description,
                    opt => opt.MapFrom(mytaskDto => mytaskDto.Description))
                .ForMember(mytaskCommand => mytaskCommand.CompletedDate,
                    opt => opt.MapFrom(mytaskDto => mytaskDto.CompletedDate));
        }
    }
}
