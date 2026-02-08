using UnityEngine;

namespace SceneLoading
{
    public class LoadingView : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingScreen;
        
        public void SetActiveScreen(bool isActive) => _loadingScreen.SetActive(isActive);
        
    }
}