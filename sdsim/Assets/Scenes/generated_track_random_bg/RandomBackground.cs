using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBackground : MonoBehaviour
{
    public RandomBackgroundUI randomBackgroundUI;

    public bool enable = true;

    public float speed = 0.1f;

    public Material defaultSky;
    public Material HDRISky;

    public List<Texture> Skys = new List<Texture>();

    private void Awake()
    {
        if (randomBackgroundUI)
            randomBackgroundUI.manager = this;

        StartRandomBackground();
    }

    public void StartRandomBackground()
    {
        RenderSettings.skybox = HDRISky;
        InvokeRepeating("SetRandomBackground", 0, speed);
    }

    public void CancelRandomBackground()
    {
        RenderSettings.skybox = defaultSky;
        CancelInvoke("SetRandomBackground");
    }

    void SetRandomBackground()
    {
        RenderSettings.skybox.mainTexture = Skys[Random.Range(0, Skys.Count)];
    }
}
