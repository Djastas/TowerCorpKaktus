using Tower.Runtime.Core.Phone;
using UnityEngine;

namespace Corp_Kaktus.Scripts.Trash
{
    public class PhoneChargeComponent : MonoBehaviour
    {
        public float chargeSpeed;
        
        private PhoneController _phoneController;

        public void StartCharge()
        {
            _phoneController = FindObjectOfType<PhoneController>();
            _phoneController.chargePower = chargeSpeed;
        }

        public void StopCharge()
        {
            _phoneController.chargePower = 0;
        }
    }
}