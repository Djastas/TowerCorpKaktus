using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Corp_Kaktus.Scripts.Render.Parallax
{
    public class ParallaxMouseComponent : MonoBehaviour
    {
        [SerializeField] private PlayerInput input;
        private void Start()
        {
            input.actions.FindAction("Look").started += context =>
            {
                ParallaxController.Instance.parallaxValue += context.ReadValue<Vector2>();
                
            };
           
        }
    }
}