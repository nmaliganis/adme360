using System.Collections.Generic;
using adme360.suite.ui.Controls;
using adme360.suite.ui.Views.Components.Containers;

namespace adme360.suite.ui.Views.Repositories
{
    public sealed class ModuleContainerViewRepository
    {
        public readonly IDictionary<string, BaseModule> ContainersViewRepository;
        private ModuleContainerViewRepository()
        {
            ContainersViewRepository = new Dictionary<string, BaseModule>()
            {
                {"ContainerManagement", new UcClientsManagementContainers()},
                {"ContainerMonitoring", new UcClientsMonitoringContainers()},
            };
        }

        public static ModuleContainerViewRepository ViewRepository { get; } = new ModuleContainerViewRepository();

        public BaseModule this[string index] => ContainersViewRepository[index];
    }
}
