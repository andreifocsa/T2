using System;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SphereScript : MonoBehaviour
{
    GameObject sphere;
    float distanceTravelled = 0.0f;
    int hits = 0;
    double record = 0.0f;
    Vector3 lastPosition;
    TextMeshProUGUI distanceText;
    void Start()
    {
        sphere = GameObject.Find("Sphere");
        lastPosition = sphere.transform.position;
        var obj = GameObject.Find("DistanceTravelled");
        distanceText = obj.GetComponent<TextMeshProUGUI>();
        var xrGrabObject = sphere.GetComponent<XRGrabInteractable>();
        xrGrabObject.selectEntered.AddListener((args) =>
        {
            distanceTravelled = 0;
        });
        xrGrabObject.selectExited.AddListener((args) =>
        {
            hits++;
        });
    }

    void Update()
    {
        distanceTravelled += Vector3.Distance(sphere.transform.position, lastPosition);
        if (distanceTravelled > record)
            record = Math.Round(distanceTravelled, 2);
        lastPosition = sphere.transform.position;

        distanceText.text = "Distance travelled: " + Math.Round(distanceTravelled, 2) + "m" + Environment.NewLine + "Number of hits: " + hits + Environment.NewLine + "Record: " + record + "m";
    }
}
