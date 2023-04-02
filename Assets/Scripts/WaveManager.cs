using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
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

    [Header("Event type parameter")]
    [SerializeField] private EventEnum _type;

    [SerializeField] private EventManager eventManager;


    private bool _readyToEvent = true;

    // Start is called before the first frame update
    void Start()
    {
        //addEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_readyToEvent)
        StartCoroutine(addEvent());
    }

    IEnumerator addEvent()
    {
        Debug.Log("debut event");
        _readyToEvent= false;
        if(eventManager.EventList.Count < 3)
        {
            EventObject eventToAdd = new EventObject();
            eventToAdd.type = _type;
            eventToAdd.timing = _timing;
            eventToAdd.amplitude = _amplitude;
            eventToAdd.initAmplitude = _amplitude;
            eventToAdd.delay = _delay;
            eventToAdd.frequency = _frequency;
            eventToAdd.maxTravelDistance = _maxTravelDistance;
            eventToAdd.initTime = Time.time;
            eventManager.addEvent(eventToAdd);
        }
        yield return new WaitForSeconds(20f);
        _readyToEvent= true;
        Debug.Log("fin event");
    }
}