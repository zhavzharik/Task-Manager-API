﻿using AutoMapper;
using MyTasks.Application.Common.Mappings;
using System;
using MyTasks.Domain;


namespace MyTasks.Application.MyTasks.Queries.GetMyTaskDescription
{
    public class MyTaskDescriptionVm : IMapWith<MyTask>
    {
        public Guid Id { get; set; }
        public MyTaskType Type { get; set; }
        public string Description { get; set; }
        public DateTime CompletedDate { get; set; }
        public CompletedStatus IsCompleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MyTask, MyTaskDescriptionVm>()
                .ForMember(taskVm => taskVm.Id,
                    opt => opt.MapFrom(taskVm => taskVm.Id))
                .ForMember(taskVm => taskVm.Type,
                    opt => opt.MapFrom(taskVm => taskVm.Type))
                .ForMember(taskVm => taskVm.Description,
                    opt => opt.MapFrom(taskVm => taskVm.Description))
                .ForMember(taskVm => taskVm.CompletedDate,
                    opt => opt.MapFrom(taskVm => taskVm.CompletedDate))
                .ForMember(taskVm => taskVm.IsCompleted,
                    opt => opt.MapFrom(taskVm => taskVm.IsCompleted));
        }
    }
}
