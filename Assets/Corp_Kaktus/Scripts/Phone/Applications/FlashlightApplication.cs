using UnityEngine;

namespace Tower.Runtime.Core.Phone.Applications
{
    public class FlashlightApplication : Application
    {
        [SerializeField] private PhoneController phoneController;

        public void SwitchFlashlight()
        {
            phoneController.SwitchFlashlight();
            
        }

        public override void Open() { }
        public override void Close() { }
    }
}