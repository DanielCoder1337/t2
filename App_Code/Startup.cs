
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core.Composing;
using Umbraco.Web;
using Umbraco.Web.Mvc;
public class StartupComposer : ComponentComposer<ApplicationComponent>, IUserComposer
    {
        public override void Compose(Composition composition)
        {
            base.Compose(composition);
        }
    }
    public class ApplicationComponent : IComponent{
        public void Initialize()
        {
        }
        public void Terminate()
        { }
    }
