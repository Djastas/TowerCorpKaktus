using System;
using UnityEngine;
using UnityEngine.UI;

namespace Corp_Kaktus.Scripts.Trash
{
    public class LogoController : MonoBehaviour
    {
        public float time;
        public float speed;
        public AnimationCurve curve;
        
        public Image image;

        private void Update()
        {
            time += Time.deltaTime * speed;

            var imageColor = image.color;
            imageColor.a = curve.Evaluate(time);
            image.color = imageColor;
        }
    }
}