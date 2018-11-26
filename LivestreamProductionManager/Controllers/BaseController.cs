using LivestreamProductionManager.Implementations;
using LivestreamProductionManager.Interfaces;
using LivestreamProductionManager.ViewModels.FightingGames;
using System.Web.Mvc;

namespace LivestreamProductionManager.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IConfigReader _configReader = new JsonFileConfigReader();

        public JsonResult DisplayMessage(bool succes, string message)
        {
            return Json(new SnackbarViewModel(succes, message), JsonRequestBehavior.DenyGet);
        }
    }
}