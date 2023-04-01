using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherEvent : MonoBehaviour
{
    public GeneralRotation generalRotation;

    [Header("Timing parameter")]
    [SerializeField] private float _timing;

    [Header("Amplitude parameter")]
    [SerializeField] private float _amplitude;

    [Header("Delay parameter")]
    [SerializeField] private float _delay;

    [Header("Frequency parameter")]
    [SerializeField] private float _frequency;

    [Header("Max travel distance parameter")]
    [SerializeField] private float _maxTravelDistance;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //SismicEventTrigger(_timing, _amplitude, _frequency);
    }


    void SismicEventTrigger(float timing, float amplitude, float frequency)
    {
        // param timing : duree d'action dans la SafeZone 
        float initXspeed = 100f;
        generalRotation.YspeedRotation = Mathf.Clamp(initXspeed + amplitude * 0.01f * Mathf.Sin(frequency * 0.01f * Time.time),50f,150f);
    }

    void SolarFlareEventTrigger(float timing, float amplitude, float delay)
    {
        // param timing : durée de l'event
    }

    void MeteorologicEventTrigger(float timing, float amplitude, float delay)
    {
        // param timing : durée de l'event
    }

    void TsunamiEventTrigger(float timing, float amplitude, float _maxTravelDistance)
    {
        // param timing : durée de l'event
    }

}
