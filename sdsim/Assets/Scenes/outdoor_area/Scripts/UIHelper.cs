using UnityEngine.UI;

namespace UIHelper
{
    [System.Serializable]
    public struct SliderWithText
    {
        public Slider sliderObject;
        private Text textObject;

        public float Value
        {
            get { return sliderObject.value; }
            set
            { sliderObject.value = value; }
        }

        public string Text
        {
            get
            {
                if (!textObject)
                    textObject = sliderObject.GetComponentInChildren<Text>();
                return textObject.text;
            }
            set
            {
                if (!textObject)
                    textObject = sliderObject.GetComponentInChildren<Text>();
                textObject.text = value;
            }
        }
    }
}