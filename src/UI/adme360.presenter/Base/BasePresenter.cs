using adme360.view;
using adme360.presenter.ServiceAgents.Base;

namespace adme360.presenter.Base
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