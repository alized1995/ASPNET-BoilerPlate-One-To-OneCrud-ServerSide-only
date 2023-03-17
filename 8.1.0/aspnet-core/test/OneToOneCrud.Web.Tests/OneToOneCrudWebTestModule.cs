using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OneToOneCrud.EntityFrameworkCore;
using OneToOneCrud.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace OneToOneCrud.Web.Tests
{
    [DependsOn(
        typeof(OneToOneCrudWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class OneToOneCrudWebTestModule : AbpModule
    {
        public OneToOneCrudWebTestModule(OneToOneCrudEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OneToOneCrudWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(OneToOneCrudWebMvcModule).Assembly);
        }
    }
}