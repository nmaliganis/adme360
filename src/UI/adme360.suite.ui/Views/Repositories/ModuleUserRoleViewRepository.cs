using System.Collections.Generic;
using adme360.suite.ui.Controls;
using adme360.suite.ui.Views.Components.UsersRolesDepartments;

namespace adme360.suite.ui.Views.Repositories
{
    public sealed class ModuleUserRoleViewRepository
    {
        private readonly IDictionary<string, BaseModule> _userRoleViewRepository;
        private ModuleUserRoleViewRepository()
        {
            _userRoleViewRepository = new Dictionary<string, BaseModule>()
            {
                {"UserManagement", new UcClientsUsers()},
                {"RoleManagement", new UcClientsRoles()},
                {"UserEmployeeDepartmentManagement", new UcClientsEmployeeDepartments()},
                {"UserEmployeeRoleManagement", new UcClientsEmployeeRoles()},
            };
        }

        public static ModuleUserRoleViewRepository ViewRepository { get; } = new ModuleUserRoleViewRepository();

        public BaseModule this[string index] => _userRoleViewRepository[index];
    }
}
