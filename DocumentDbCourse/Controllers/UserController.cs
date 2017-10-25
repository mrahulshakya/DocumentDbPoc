using DocumentDbCourse.Repository;
using DocumentDbCourse.ViewModels;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DocumentDbCourse.Controllers
{
    public class UserController : ControllerBase
    {

        public UserController(IRepositoryConfiguration config, INamedSettingResolver resolver) : base(config, resolver)
        {
        }

        // GET: User
        public async Task<ActionResult> Index()
        {
            var data = new UserViewModel();
            data.AllUsers = await UserRepository.GetAsync(x=> x.Id != 0).ToList();
            return View();
        }
    }
}