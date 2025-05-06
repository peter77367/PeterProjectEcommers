using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Services.userservices;
using Autofac;
using Context;
using Infrastructrure;

namespace Presentation
{
    public class Autofac
    {
        public static IContainer Inject()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<PeterDbContext>().As<PeterDbContext>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<UserRepo>().As<IUserRepo>();
            builder.RegisterType<UserService>().As<IUserService>();
            //builder.RegisterType<AutherRepository>().As<IAutherRepository>();
            //builder.RegisterType<AutherServices>().As<IAutherServices>();
            //builder.RegisterType<PublisherRepository>().As<IPublisherRepository>();
            //builder.RegisterType<PublisherServices>().As<IPublisherServices>();
            //builder.RegisterType<Autofact>().As<IUnitOfWork>();
            return builder.Build();
        }
    }
}
