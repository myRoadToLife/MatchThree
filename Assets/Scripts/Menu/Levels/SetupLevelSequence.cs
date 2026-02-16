using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Menu.Levels
{
    public class SetupLevelSequence
    {
        public LevelSequenceConfig CurrentLevelSequenceConfig { get; private set; }
        
        public async UniTask Setup(int currentLevel)
        {
            if (currentLevel <= 5)
                await LoadLevels("Levels1_5");
            else
                await LoadLevels("Levels6_10");
        }

        private async UniTask LoadLevels(string key)
        {
            AsyncOperationHandle<LevelSequenceConfig> levels =
                Addressables.LoadAssetAsync<LevelSequenceConfig>(key);

            await levels.ToUniTask();
            if (levels.Status == AsyncOperationStatus.Succeeded)
            {
                CurrentLevelSequenceConfig = levels.Result;
                Addressables.Release(levels);
            }
        }
    }
}