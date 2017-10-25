using DocumentDbCourse.Models;
using DocumentDbCourse.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocumentDbCourse.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected IDocumentDbRepository<User> UserRepository { get; }
        protected IRepositoryConfiguration config { get; }

        public ControllerBase(IRepositoryConfiguration config, INamedSettingResolver resolver)
        {
            UserRepository = resolver.Resolve<IDocumentDbRepository<User>>(config.UserCollectionId);
        }

        // GET: ControllerBase
        public ActionResult Index()
        {
            return View();
        }
    }
}