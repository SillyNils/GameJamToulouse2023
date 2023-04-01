using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherEvent : MonoBehaviour
{
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
        
    }

    
    void SismicEventTrigger(float timing, float amplitude, float frequency)
    {
        // param timing : durée d'action dans la SafeZone

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
