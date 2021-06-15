using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PathCreation;

public class TrackManager : MonoBehaviour
{
    public TrackManagerUI trackManagerUI;

    [Header("Track Settings")]
    public PathManager pathManager;
    public Transform track;
    public List<Transform> trackTransforms;

    private int trackIndex;

    private void Awake()
    {
        trackIndex = 0;

        if (trackManagerUI)
            trackManagerUI.manager = this;
    }

    private void Start()
    {
        SetTrack(trackTransforms[0]);
    }

    public Transform GetTransform(int step)
    {
        trackIndex += step;

        if (trackIndex < 0)
            trackIndex = trackTransforms.Count - 1;

        if (trackIndex > trackTransforms.Count - 1)
            trackIndex = 0;
            
        return trackTransforms[trackIndex];
    }

    public void SetTrack(Transform newTransform)
    {
        track.position = newTransform.position;
        track.rotation = newTransform.rotation;
        track.localScale = newTransform.localScale;


        // Hacky way of force reset car
        var car = GameObject.FindObjectOfType<Car>().GetComponent<Car>();
        Transform start = track.transform.Find("donkey_start");
        car.startPos = start.position;
        car.startRot = start.rotation;
        car.RestorePosRot();

        // Reset current active span
        pathManager.pathCreator = track.GetComponentInChildren<PathCreator>();
        pathManager.InitCarPath();
        pathManager.carPath.GetClosestSpan(start.position);
    }

}
