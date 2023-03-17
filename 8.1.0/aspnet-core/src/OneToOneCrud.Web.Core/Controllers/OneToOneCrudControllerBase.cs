using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace OneToOneCrud.Controllers
{
    public abstract class OneToOneCrudControllerBase: AbpController
    {
        protected OneToOneCrudControllerBase()
        {
            LocalizationSourceName = OneToOneCrudConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
