using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OneToOneCrud.Configuration;

namespace OneToOneCrud.Web.Host.Startup
{
    [DependsOn(
       typeof(OneToOneCrudWebCoreModule))]
    public class OneToOneCrudWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public OneToOneCrudWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OneToOneCrudWebHostModule).GetAssembly());
        }
    }
}
