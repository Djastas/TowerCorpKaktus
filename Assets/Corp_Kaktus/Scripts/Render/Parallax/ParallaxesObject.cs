using System;
using UnityEngine;

namespace Corp_Kaktus.Scripts.Render.Parallax
{
    public class ParallaxesObject : MonoBehaviour
    {
        [Range(-2,2)] [SerializeField] private float parallaxMultiplier;

        private Vector2 startPos;
        private void Start()
        {
            try
            {
                ParallaxController.Instance.parallaxesObjects.Add(this);
            }
            catch (Exception e)
            {
                Debug.LogWarning("Cant found ParallaxController. parallax will not be applied to this object");
                return;
            }
            startPos = transform.localPosition;
        }

        public void UpdatePos(Vector2 parallaxValue) 
            => transform.localPosition = startPos + (parallaxValue * parallaxMultiplier);
    }
}