using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OneToOneCrud.Authorization;

namespace OneToOneCrud
{
    [DependsOn(
        typeof(OneToOneCrudCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class OneToOneCrudApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<OneToOneCrudAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(OneToOneCrudApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
