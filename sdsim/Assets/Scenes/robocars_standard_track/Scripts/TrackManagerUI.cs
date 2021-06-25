using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackManagerUI : MonoBehaviour
{
    public TrackManager manager;

    [Header("UI Settings")]
    public Button prevButton;
    public Button nextButton;
    public Text currentIndexText;

    private void OnEnable()
    {
        // Add listeners for each UI items
        if (manager != null)
        {
            prevButton.onClick.AddListener(delegate { ButtonHandler(0); });
            nextButton.onClick.AddListener(delegate { ButtonHandler(1); });
        }
        else
        {
            Debug.LogWarning("No track manager in scene!");
        }
    }

    private void ButtonHandler(int idx_)
    {
        switch (idx_)
        {
            case 0:
                manager.SetTrack(manager.GetTransform(-1));
                break;
            case 1:
                manager.SetTrack(manager.GetTransform(1));
                break;
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        currentIndexText.text = "Current track index: " + manager.trackIndex;
    }
}
