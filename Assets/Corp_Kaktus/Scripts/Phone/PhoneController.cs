using System;
using UnityEngine;

namespace Tower.Runtime.Core.Phone
{
    public class PhoneController : MonoBehaviour
    {
        public float currentPower = 100;
        public Application currentApplication;

        public float chargePower;

        private void Update()
        {
            if (currentPower < 100) 
            {
                currentPower += chargePower * Time.deltaTime;
            }
           
            if (currentPower <= 0) { return; }
            
            if (flashlightIsActive)
            {
                currentPower -= flashlightPowerConsumption * Time.deltaTime;
            }

            if (currentPower <= 0)
            {
                Flashlight.SetActive(false);
            }
            
        }
        
        public float flashlightPowerConsumption;
        public bool flashlightIsActive;
        [SerializeField] private GameObject Flashlight;
        
        public void SwitchFlashlight()
        {
            flashlightIsActive = !flashlightIsActive;
            ActivateFlashlight(flashlightIsActive);
        }

        public void ActivateFlashlight(bool activate)
        {
            if (currentPower > 0)
            {
                Flashlight.SetActive(activate);
            }
        }
    }
}
