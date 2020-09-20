using System.Collections.Generic;
using adme360.suite.ui.Controls;
using adme360.suite.ui.Views.Components;

namespace adme360.suite.ui.Views.Repositories
{
    public sealed class ModuleViewRepository
    {
        private readonly IDictionary<string, BaseModule> _publishersViewRepository;
        private ModuleViewRepository()
        {
            _publishersViewRepository = new Dictionary<string, BaseModule>()
            {
                {"DicomSettings", new UcSettingsDicom()},
                {"DicomClients", new UcClientsDicom()},
                {"LabelSettings", new UcSettingsLabel()},
            };
        }

        public static ModuleViewRepository ViewRepository { get; } = new ModuleViewRepository();

        public BaseModule this[string index] => _publishersViewRepository[index];
    }
}
