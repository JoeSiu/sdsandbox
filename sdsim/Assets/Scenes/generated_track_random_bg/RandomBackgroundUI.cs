using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UIHelper;

public class RandomBackgroundUI : MonoBehaviour
{
    public RandomBackground manager;

    [Header("UI Settings")]
    public Toggle enableRandomBGToggle;
    public SliderWithText speed;

    private void OnEnable()
    {
        if (manager != null)
        {
            enableRandomBGToggle.onValueChanged.AddListener(delegate { ToggleHandler(); });
            speed.sliderObject.onValueChanged.AddListener(delegate { SliderHandler(0); });

            UpdateUI();
        }
        else
        {
            Debug.LogWarning("No random background manager in scene!");
        }
    }

    private void ToggleHandler()
    {
        manager.enable = enableRandomBGToggle.isOn;
    }

    private void SliderHandler(int idx_)
    {
        switch (idx_)
        {
            case 0:
                manager.speed = speed.Value;
                // manager.ReloadRandomBackground();
                UpdateUI();
                break;
        }
    }

    private void UpdateUI()
    {
        speed.Text = "Current Speed = " + manager.speed.ToString("0.00");
    }
}
