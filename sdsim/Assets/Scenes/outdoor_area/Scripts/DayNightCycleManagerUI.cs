using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UIHelper;

public class DayNightCycleManagerUI : MonoBehaviour
{
    public DayNightCycleManager manager;

    [Header("UI Settings")]
    public Toggle enableCycleToggle;
    public SliderWithText currentTime;
    public SliderWithText startTime;
    public SliderWithText endTime;
    public SliderWithText speed;
    public SliderWithText angle;
    public SliderWithText sunStrengthMultiplier;
    public SliderWithText moonStrengthMultiplier;

    private void OnEnable()
    {
        if (manager != null)
        {
            // Add listeners for each UI items
            enableCycleToggle.onValueChanged.AddListener(delegate { ToggleHandler(); });
            currentTime.sliderObject.onValueChanged.AddListener(delegate { SliderHandler(0); });
            startTime.sliderObject.onValueChanged.AddListener(delegate { SliderHandler(1); });
            endTime.sliderObject.onValueChanged.AddListener(delegate { SliderHandler(2); });
            speed.sliderObject.onValueChanged.AddListener(delegate { SliderHandler(3); });
            angle.sliderObject.onValueChanged.AddListener(delegate { SliderHandler(4); });
            sunStrengthMultiplier.sliderObject.onValueChanged.AddListener(delegate { SliderHandler(5); });
            moonStrengthMultiplier.sliderObject.onValueChanged.AddListener(delegate { SliderHandler(6); });
        }
        else
        {
            Debug.LogWarning("No day night cycle manager in scene!");
        }
    }

    private void ToggleHandler()
    {
        manager.enable = enableCycleToggle.isOn;
    }

    private void SliderHandler(int idx_)
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
            case 5:
                manager.sunStrengthMultiplier = sunStrengthMultiplier.Value;
                break;
            case 6:
                manager.moonStrengthMultiplier = moonStrengthMultiplier.Value;
                break;
        }
    }

    private void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        currentTime.Value = manager.currentTime;

        currentTime.Text = "Current Time: " + manager.currentTime.ToString("0.00");
        startTime.Text = "Start Time: " + manager.startTime.ToString("0.00");
        endTime.Text = "End Time: " + manager.endTime.ToString("0.00");
        speed.Text = "Speed: " + manager.speed.ToString("0.00");
        angle.Text = "Angle: " + manager.angle.ToString("0.00");
        sunStrengthMultiplier.Text = "Sun Strength: " + manager.sunStrengthMultiplier.ToString("0.00");
        moonStrengthMultiplier.Text = "Moon Strength: " + manager.moonStrengthMultiplier.ToString("0.00");
    }
}
