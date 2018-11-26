using System;
using System.IO;
using System.Web.Mvc;

namespace LivestreamProductionManager.Controllers
{
    public class FightingGamesController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Fight Games";

            return View();
        }

        public JsonResult GetSeries()
        {
            var series = _configReader.GetSeries();
            try
            {
                return Json(series, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult GetGames(string pathToSeries)
        {
            var games = _configReader.GetGames(pathToSeries);

            try
            {
                return Json(games, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult GetFormats(string pathToGame)
        {
            var formats = _configReader.GetFormats(pathToGame);

            try
            {
                return Json(formats, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}