using dl.wm.presenter.ServiceAgents.Base;
using dl.wm.view;

namespace dl.wm.presenter.Base
{
    public class BasePresenter<TV,TS>
        where TV : IView 
        where TS : IService
    {
        public BasePresenter(TV view, TS service)
        {
            View = view;
            Service = service;
        }

        protected TV View { get; private set; }
        protected TS Service { get; private set; }
    }
}