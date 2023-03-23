using Abp.Authorization;
using OneToOneCrud.Authorization.Roles;
using OneToOneCrud.Authorization.Users;

namespace OneToOneCrud.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
