namespace LivestreamProductionManager.ViewModels.FightingGames
{
    public class SnackbarViewModel
    {
        public string Success { get; set; }
        public string Message { get; set; }

        public SnackbarViewModel(bool success, string message)
        {
            Success = success.ToString();
            Message = message;
        }
    }
}