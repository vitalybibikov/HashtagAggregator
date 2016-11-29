using System;

using AutoMapper;
using MyStudyProject.Core.Models.Queries;
using MyStudyProject.ViewModels;

namespace MyStudyProject.Configuration
{
    public class AutoMapperProfileConfiguration : Profile
    {
        protected override void Configure()
        {
            CreateMap<MessageViewModel, MessagesQuery>();
            CreateMap<UserViewModel, UserInfoQuery>();
        }
    }
}
