using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackManagerUI : MonoBehaviour
{
    [HideInInspector]
    public TrackManager manager;

   [Header("UI Settings")]
    public Button prevButton;
    public Button nextButton;
    public Text currentIndexText;

     private void Awake()
    {
        prevButton.onClick.AddListener(delegate { ButtonHandler(0); });
        nextButton.onClick.AddListener(delegate { ButtonHandler(1); });
    }

     private void ButtonHandler(int idx_)
    {
        if (manager != null)
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
        }
        else
        {
            Debug.LogWarning("No day track manager in scene!");
        }
    }

     public void UpdateUI(int index)
    {
        currentIndexText.text = "Current track index: " + index;
    }
}
