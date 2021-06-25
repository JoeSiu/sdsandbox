using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBackground : MonoBehaviour
{
    public bool enable = true;

    public float speed = 0.1f;

    public Material defaultSky;
    public Material HDRISky;

    public List<Texture> Skys = new List<Texture>();

    private void Awake()
    {
        StartRandomBackground();
    }

    private void Update()
    {
        if (enable && !IsInvoking("SetRandomBackground"))
        {
            StartRandomBackground();
        }
        else if (!enable && IsInvoking("SetRandomBackground"))
        {
            CancelRandomBackground();
        }
    }

    public void StartRandomBackground()
    {
        RenderSettings.skybox = HDRISky;
        InvokeRepeating("SetRandomBackground", speed, speed);
    }

    public void CancelRandomBackground()
    {
        RenderSettings.skybox = defaultSky;
        CancelInvoke("SetRandomBackground");
    }

    public void ReloadRandomBackground()
    {
        CancelRandomBackground();
        StartRandomBackground();
    }

    void SetRandomBackground()
    {
        RenderSettings.skybox.mainTexture = Skys[Random.Range(0, Skys.Count)];
        Debug.Log("called");
    }
}
