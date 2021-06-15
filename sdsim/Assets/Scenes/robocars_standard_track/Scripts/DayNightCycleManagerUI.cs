using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycleManagerUI : MonoBehaviour
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

    [HideInInspector]
    public DayNightCycleManager manager;

    [Header("UI Settings")]
    public Toggle enableCycleToggle;
    public SliderWithText currentTime;
    public SliderWithText startTime;
    public SliderWithText endTime;
    public SliderWithText speed;
    public SliderWithText angle;

    private void Awake()
    {
        enableCycleToggle.onValueChanged.AddListener(delegate { ToggleHandler(); });
        currentTime.sliderObject.onValueChanged.AddListener(delegate { SliderHandler(0); });
        startTime.sliderObject.onValueChanged.AddListener(delegate { SliderHandler(1); });
        endTime.sliderObject.onValueChanged.AddListener(delegate { SliderHandler(2); });
        speed.sliderObject.onValueChanged.AddListener(delegate { SliderHandler(3); });
        angle.sliderObject.onValueChanged.AddListener(delegate { SliderHandler(4); });
    }

    private void ToggleHandler()
    {
        if (manager != null)
        {
            manager.enable = enableCycleToggle.isOn;
        }
        else
        {
            Debug.LogWarning("No day night cycle manager in scene!");
        }
    }

    private void SliderHandler(int idx_)
    {
        if (manager != null)
        {
            switch (idx_)
            {
                case 0:
                    manager.currentTime = currentTime.Value;
                    break;
                case 1:
                    manager.startTime = startTime.Value;
                    break;
                case 2:
                    manager.endTime = endTime.Value;
                    break;
                case 3:
                    manager.speed = speed.Value;
                    break;
                case 4:
                    manager.angle = angle.Value;
                    break;
            }
        }
        else
        {
            Debug.LogWarning("No day night cycle manager in scene!");
        }
    }

    public void UpdateUI()
    {
        currentTime.Value = manager.currentTime;

        currentTime.Text = "Current Time: " + manager.currentTime.ToString("0.00");
        startTime.Text = "Start Time: " + manager.startTime.ToString("0.00");
        endTime.Text = "End Time: " + manager.endTime.ToString("0.00");
        speed.Text = "Speed: " + manager.speed.ToString("0.00");
        angle.Text = "Angle: " + manager.angle.ToString("0.00");
    }
}
