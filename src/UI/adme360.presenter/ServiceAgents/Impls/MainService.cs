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
    public class MainService : BaseService<MainUiModel>, IMainService
    {
        private static readonly string _serviceName = "MainService";

        public MainService() : base(_serviceName)
        {

        }
    }
}
