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
        StartCoroutine(SetRandomBackground());
    }

    IEnumerator SetRandomBackground()
    {
        while (true)
        {
            if (enable)
            {
                if (RenderSettings.skybox != HDRISky)
                    RenderSettings.skybox = HDRISky;

                RenderSettings.skybox.mainTexture = Skys[Random.Range(0, Skys.Count)];
                RenderSettings.skybox.SetFloat("_Rotation", Random.Range(0, 360));
                yield return new WaitForSeconds(speed);
            }
            else
            {
                if (RenderSettings.skybox != defaultSky)
                    RenderSettings.skybox = defaultSky;

                yield return null;
            }
        }
    }
}
