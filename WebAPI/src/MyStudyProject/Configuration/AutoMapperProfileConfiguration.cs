using System;
using System.Collections.Generic;
using AutoMapper;
using MyStudyProject.Core.Cqrs.Results;
using MyStudyProject.Core.Models.Queries;
using MyStudyProject.ViewModels;
using Tweetinvi;
using Tweetinvi.Models;

namespace MyStudyProject.Configuration
{
    public class AutoMapperProfileConfiguration : Profile
    {
        protected override void Configure()
        {
            CreateMap<MessageQueryResult, MessageViewModel>();
        }
    }
}
