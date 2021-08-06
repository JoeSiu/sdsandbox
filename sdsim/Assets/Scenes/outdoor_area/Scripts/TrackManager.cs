using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PathCreation;

public class TrackManager : MonoBehaviour
{
    [Header("Track Settings")]
    public PathManager pathManager;
    public Transform track;
    public List<Transform> trackTransforms;

    public int trackIndex;

    private void Awake()
    {
        trackIndex = 0;
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
        // Set the track to a new position
        track.position = newTransform.position;
        track.rotation = newTransform.rotation;
        track.localScale = newTransform.localScale;

        // Hacky way of force reset all cars
        CarSpawner carSpawner = CarSpawner.FindObjectOfType<CarSpawner>();
        Transform start = track.transform.Find("donkey_start");
        foreach (var car in Car.FindObjectsOfType<Car>())
        {
            car.startPos = start.position;
            car.startRot = start.rotation;
            car.Set(carSpawner.GetCarStartPosRot().Item1, carSpawner.GetCarStartPosRot().Item2);
        }

        // Reset current active span
        pathManager.pathCreator = track.GetComponentInChildren<PathCreator>();
        pathManager.InitCarPath();
        pathManager.carPath.GetClosestSpan(start.position);
    }
}
