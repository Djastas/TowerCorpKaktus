using System.Collections.Generic;
using Corp_Kaktus.Scripts.Utils;
using UnityEngine;

namespace Corp_Kaktus.Scripts.Render.Parallax
{
    public class ParallaxController : SingletonMonoBehavior<ParallaxController>
    {
        public List<ParallaxesObject> parallaxesObjects;
        public Vector2 parallaxValue;
        public float parallaxMultiplier;
        
        [SerializeField] private bool forceUpdate;
        
        private Vector2 lastParallaxValue;
        private void Update()
        {
            if (parallaxValue == lastParallaxValue && !forceUpdate) { return; }

            // ReSharper disable once ForCanBeConvertedToForeach
            // list can be update on runtime
            for (var index = 0; index < parallaxesObjects.Count; index++)
            {
                var parallaxesObject = parallaxesObjects[index];
                
                parallaxesObject.UpdatePos(parallaxValue * parallaxMultiplier);
            }
        }

        
    }
}