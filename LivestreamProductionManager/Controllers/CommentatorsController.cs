using LivestreamProductionManager.ViewModels.Commentators;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LivestreamProductionManager.Controllers
{
    public class CommentatorsController : BaseController
    {
        public PartialViewResult GetCommentatorRow(int id)
        {
            return PartialView("CommentatorRow", id);
        }

        [HttpPost]
        public JsonResult UpdateCommentators(List<CommentatorViewModel> commentatorViewModels)
        {
            if (commentatorViewModels == null)
            {
                return DisplayMessage(false, "Commentator list was null");
            }

            if (commentatorViewModels.Count == 0)
            {
                return DisplayMessage(false, "Commentator list count is 0");
            }

            for (int i = 0; i < commentatorViewModels.Count; i++)
            {
                if (string.IsNullOrEmpty(commentatorViewModels[i].Name))
                {
                    return DisplayMessage(false, string.Format("Commentator name of {0} cannot be empty", i));
                }
            }

            //Save files
            return DisplayMessage(true, "Successfully saved commentator files");
        }
    }
}