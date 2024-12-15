using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace Tower.Runtime.Core.Phone
{
    public class CurtainUIController : MonoBehaviour
    {
        [SerializeField] private PhoneController phoneController;
        
        [SerializeField] private TMP_Text powerText;
        [SerializeField] private Slider powerSlider;

        private void Update()
        {
            var powerRounded = math.round(phoneController.currentPower);
            powerText.text = $"{powerRounded}%";
            powerSlider.value = powerRounded/100f;
        }
    }
}