using DG.Tweening;
using SceneLoading;
using UnityEngine;
using VContainer.Unity;

namespace Boot
{
    public class Bootstrap : IInitializable
    {
        private IAsyncSceneLoading _asyncSceneLoading;

        public Bootstrap(IAsyncSceneLoading asyncSceneLoading) =>
            _asyncSceneLoading = asyncSceneLoading;

        public async void Initialize()
        {
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            DOTween.SetTweensCapacity(5000, 100);
            await _asyncSceneLoading.LoadSceneAsync(SceneName.MENU);
        }
    }
}