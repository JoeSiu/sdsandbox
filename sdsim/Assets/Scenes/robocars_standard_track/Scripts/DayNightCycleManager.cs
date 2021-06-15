using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycleManager : MonoBehaviour
{
    [System.Serializable]
    public class Lighting
    {
        public GameObject lightObject;
        public Gradient lightColor;
        public AnimationCurve lightIntensity;

        private Light lightComponent;

        public void Init()
        {
            lightComponent = lightObject.GetComponent<Light>();
        }

        public void SetLight(float normalizedTime)
        {
            lightComponent.color = lightColor.Evaluate(normalizedTime);
            lightComponent.intensity = lightIntensity.Evaluate(normalizedTime);
        }
    }

    [Header("Controller Settings")]
    public DayNightCycleManagerUI dayNightCycleUI;
    public bool enable = true;
    [Tooltip("Time of day in 24 hour format")]
    [Range(0, 24)] public float currentTime = 9.0f;
    public float startTime = 0.0f;
    public float endTime = 24.0f;
    public Lighting sun;
    public Lighting moon;
    [Tooltip("Sun's angle")]
    [Range(0, 360)] public float angle = 0;
    [Tooltip("Sun's rotation speed")]
    public float speed = 0.01f;

    private void Awake()
    {
        sun.Init();
        moon.Init();

        if (dayNightCycleUI)
            dayNightCycleUI.manager = this;
    }

    private void Update()
    {
        Tick();

        sun.SetLight(NormalizedTime(currentTime));
        moon.SetLight(NormalizedTime(currentTime));

        SetRotation(currentTime);

        if (dayNightCycleUI)
            dayNightCycleUI.UpdateUI();
    }

    private void Tick()
    {
        if (currentTime > endTime)
            currentTime = startTime;

        if (enable)
            currentTime += Time.deltaTime * speed;
    }

    private Vector3 newRotation;
    private void SetRotation(float time)
    {
        newRotation.x = ConvertTimeToRotation(time);
        newRotation.y = angle;

        transform.rotation = Quaternion.Euler(newRotation);
    }

    private float ConvertTimeToRotation(float time)
    {
        return (360 / 24) * time;
    }

    private float NormalizedTime(float time)
    {
        return time / 24;
    }
}
