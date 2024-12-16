using UnityEngine;

namespace Corp_Kaktus.Scripts.Utils
{
    public class ShowInPlayModeComponent : MonoBehaviour
    {
        private void Start()
        {
            gameObject.SetActive(true);
        }
        
    }
}