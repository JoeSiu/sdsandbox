using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ReflectionProbe))]
public class ReflectionProbeUpdate : MonoBehaviour
{
    [Tooltip("Reflection update rate in second")]
    public float updateRate = 5.0f;
    private ReflectionProbe reflectionProbe;
    private RenderTexture targetTexture;

    private void Awake()
    {
        reflectionProbe = GetComponent<ReflectionProbe>();

        InvokeRepeating("UpdateReflection", updateRate, updateRate);
    }

    public void UpdateReflection()
    {
        reflectionProbe.RenderProbe(targetTexture = null);
    }
}
