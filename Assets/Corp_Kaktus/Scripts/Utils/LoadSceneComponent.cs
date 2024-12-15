using UnityEngine;
using UnityEngine.SceneManagement;

namespace Corp_Kaktus.Scripts.Utils
{
    public class LoadSceneComponent : MonoBehaviour
    {
        [SerializeField] private string sceneName;


        public void LoadScene() => SceneManager.LoadScene(sceneName);
    }
} 