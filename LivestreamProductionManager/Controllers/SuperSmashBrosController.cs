using LivestreamProductionManager.Implementations.SuperSmashBros;
using LivestreamProductionManager.ViewModels.FightingGames.SuperSmashBros;
using LivestreamProductionManager.ViewModels.SuperSmashBros;
using System;
using System.Web.Mvc;

namespace LivestreamProductionManager.Controllers
{
    public class SuperSmashBrosController : BaseController
    {
        private readonly SmashOverlayManager _smashOverlayManager = new SmashOverlayManager();

        [HttpPost]
        public PartialViewResult GetManageCompetitors(string series, string game, string format, string pathToSeries, string pathToGame, string pathToFormat)
        {
            try
            {
                var superSmashBrosBaseViewModel = new SuperSmashBrosBaseViewModel(series, game, format, pathToSeries, pathToGame, pathToFormat)
                {
                    Characters = _configReader.GetCharactersFromConfig(pathToGame),
                    Ports = _configReader.GetPortsFromConfig(pathToGame)
                };

                return PartialView($"~/Views/{series}/{format}/ManageCompetitors.cshtml", superSmashBrosBaseViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public PartialViewResult GetCrewPlayers(int count, string series, string game, string format)
        {
            return PartialView($"~/Views/{series}/{format}/CrewPlayerRow.cshtml", count);
        }

        [HttpPost]
        public JsonResult UpdateSingles(SinglesViewModel singlesViewModel)
        {
            try
            {
                _smashOverlayManager.UpdateSinglesOverlay(singlesViewModel);

                return DisplayMessage(true, "Successfully saved competitor files");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);

                return DisplayMessage(false, "Something went wrong while saving competitor files, see the console for details: " + ex.Message);
            }
        }

        [HttpPost]
        public JsonResult UpdateDoubles(DoublesViewModel doublesViewModel)
        {
            try
            {
                _smashOverlayManager.UpdateDoublesOverlay(doublesViewModel);

                return DisplayMessage(true, "Successfully saved competitor files");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);

                return DisplayMessage(false, "Something went wrong while saving competitor files, see the console for details: " + ex.Message);
            }
        }

        [HttpPost]
        public JsonResult UpdateCrews(CrewsViewModel crewsViewModel)
        {
            if (crewsViewModel.Crew1.Players == null || crewsViewModel.Crew2.Players == null)
            {
                return DisplayMessage(false, "Crew 1 or 2 players is null");
            }

            //Save files

            return DisplayMessage(true, "Successfully saved competitor files");
        }

    }
}