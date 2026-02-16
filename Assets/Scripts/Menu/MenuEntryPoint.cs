using Menu.Levels;
using SceneLoading;
using VContainer.Unity;

namespace Menu
{
    public class MenuEntryPoint: IInitializable
    {
        private IAsyncSceneLoading _asyncSceneLoading;
        private SetupLevelSequence _setupLevelSequence;

        public MenuEntryPoint(IAsyncSceneLoading asyncSceneLoading, SetupLevelSequence setupLevelSequence)
        {
            _asyncSceneLoading = asyncSceneLoading;
            _setupLevelSequence = setupLevelSequence;
        }

        public async void Initialize()
        {
            await _setupLevelSequence.Setup(1);            // button enable / disable
            // music for menu
            _asyncSceneLoading.LoadingIsDone(true);
            // loading is done
            
            // await animation
            // button enabled
            
        }
    }
}