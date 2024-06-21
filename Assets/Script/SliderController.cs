using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class SliderController : MonoBehaviour
    {
        [SerializeField] private Text   valueText;
        [SerializeField] private Slider slider;

        private int progress;

        public void OnSliderChanged(float value)
        {
            valueText.text = value.ToString();
        }

        public void UpdateProgress()
        {
            progress++;
            slider.value = progress;
        }
    }
}