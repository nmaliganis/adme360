using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using dl.wm.models.DTOs.Dashboards;
using dl.wm.models.DTOs.Users;
using dl.wm.models.DTOs.Users.Accounts;
using dl.wm.presenter.Exceptions;
using dl.wm.presenter.ServiceAgents.Contracts;
using dl.wm.presenter.ServiceAgents.Impls.Base;
using Newtonsoft.Json;
using RestSharp;

namespace dl.wm.presenter.ServiceAgents.Impls
{
    public class DashboardService : BaseService<DashboardUiModel>, IDashboardService
    {
        private static readonly string _serviceName = "DashboardService";

        public DashboardService() : base(_serviceName)
        {

        }
    }
}
