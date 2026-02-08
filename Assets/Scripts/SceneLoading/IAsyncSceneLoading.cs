using Cysharp.Threading.Tasks;

namespace SceneLoading
{
    public interface IAsyncSceneLoading
    {
        UniTask LoadSceneAsync(string sceneName);
        UniTask UnloadAsync(string sceneName);
        void LoadingIsDone(bool isDone);
    }
}