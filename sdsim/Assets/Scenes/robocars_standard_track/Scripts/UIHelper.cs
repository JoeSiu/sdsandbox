using UnityEngine.UI;

namespace UIHelper
{
    [System.Serializable]
    public struct SliderWithText
    {
        public Slider sliderObject;
        public Text textObject;

        public float Value
        {
            get { return sliderObject.value; }
            set { sliderObject.value = value; }
        }

        public string Text
        {
            get { return textObject.text; }
            set { textObject.text = value; }
        }
    }
}