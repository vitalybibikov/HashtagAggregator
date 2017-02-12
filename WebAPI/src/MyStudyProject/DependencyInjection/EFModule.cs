using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using MyStudyProject.Data.Contracts.Interface;
using MyStudyProject.Data.DataAccess.Context;

namespace MyStudyProject.DependencyInjection
{
    public class EFModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<SqlApplicationDbContext>().As<IApplicationContext>();
        }
    }
}
