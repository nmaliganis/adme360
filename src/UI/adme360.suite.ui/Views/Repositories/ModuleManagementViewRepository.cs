using System.Collections.Generic;
using adme360.suite.ui.Controls;
using adme360.suite.ui.Views.Components.EmployeesToursVehicles;

namespace adme360.suite.ui.Views.Repositories
{
    public sealed class ModuleManagementViewRepository
    {
        private readonly IDictionary<string, BaseModule> _managementViewRepository;
        private ModuleManagementViewRepository()
        {
            _managementViewRepository = new Dictionary<string, BaseModule>()
            {
                {"EmployeeManagement", new UcClientsEmployees()},
                {"EmployeeTourManagement", new UcClientsEmployeesTours()},
                {"TourManagement", new UcClientsTours()},
                {"HistoryTourManagement", new UcClientsHistoryTours()},
                {"VehicleManagement", new UcClientsVehicles()},
                {"PosManagement", new UcClientsPos()},
            };
        }

        public static ModuleManagementViewRepository ViewRepository { get; } = new ModuleManagementViewRepository();

        public BaseModule this[string index] => _managementViewRepository[index];
    }
}
