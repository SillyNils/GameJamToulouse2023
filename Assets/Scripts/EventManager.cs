using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum EventEnum { SeismicEvent, SolarFlareEvent, MeteorologicEvent, TsunamiEvent, MeteorEvent };

public class EventObject
{
    public EventEnum type;
    public float timing;
    public float amplitude;
    public float delay;
    public float frequency;
    public float maxTravelDistance;
    public float validTime = 0;
    public float initTime;
    public float initAmplitude;
}

public class EventManager : MonoBehaviour
{
    List<EventObject> eventList = new List<EventObject>();

    public GeneralRotation generalRotation;

    public List<EventObject> EventList { get => eventList; set => eventList = value; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rotationModification();
    }

    public void addEvent(EventObject eventToAdd)
    {
        eventList.Add(eventToAdd);
    }

    void rotationModification()
    {
        float initYRotationSpeed = 100f;
        float finalYRotationSpeed = initYRotationSpeed;


        foreach (EventObject eventToRead in eventList)
        {
            switch (eventToRead.type)
            {
                case EventEnum.SeismicEvent:
                    reduceAmplitudeEvent(eventToRead, generalRotation.GlobalIsInNormalState);
                    if(eventWithSuccessComplete(eventToRead.amplitude))
                    {
                        eventList.Remove(eventToRead);
                        break;
                    }
                    finalYRotationSpeed = seismicEvent(finalYRotationSpeed, eventToRead.timing, eventToRead.amplitude, eventToRead.frequency);
                    break;
                case EventEnum.SolarFlareEvent:
                    if (eventWithTimingComplete(eventToRead.initTime, eventToRead.timing))
                    {
                        eventList.Remove(eventToRead);
                        break;
                    }
                    finalYRotationSpeed = solarFlareEvent(finalYRotationSpeed, eventToRead.timing, eventToRead.amplitude, eventToRead.delay);
                    break;
                case EventEnum.MeteorologicEvent:
                    if (eventWithTimingComplete(eventToRead.initTime, eventToRead.timing))
                    {
                        eventList.Remove(eventToRead);
                        break;
                    }
                    finalYRotationSpeed = meteorologicEvent(finalYRotationSpeed, eventToRead.timing, eventToRead.amplitude, eventToRead.delay);
                    break;
                case EventEnum.TsunamiEvent:
                    finalYRotationSpeed = tsunamiEvent(finalYRotationSpeed, eventToRead.timing, eventToRead.amplitude, eventToRead.maxTravelDistance);
                    break;
                case EventEnum.MeteorEvent:
                    finalYRotationSpeed = meteorEvent(finalYRotationSpeed, eventToRead.timing, eventToRead.amplitude, eventToRead.frequency, eventToRead.maxTravelDistance);
                    break;
            }
        }
        generalRotation.YspeedRotation = finalYRotationSpeed;
    }

    bool eventWithTimingComplete(float initTime, float timing)
    {
        return (Time.time - initTime) >= timing;
    }

    bool eventWithSuccessComplete(float amplitude)
    {
        return amplitude <= 1;
    }

    void reduceAmplitudeEvent(EventObject eventToRead, bool globalIsInNormalState)
    {
        if(globalIsInNormalState)
        {
            eventToRead.validTime += Time.deltaTime;
            eventToRead.amplitude = eventToRead.initAmplitude * (1 - eventToRead.validTime / eventToRead.timing);
        }
    }

    public float seismicEvent(float initYspeed, float timing, float amplitude, float frequency)
    {
        // param timing : duree d'action dans la SafeZone
        ///Debug.Log(amplitude * Mathf.Sin(frequency * 0.01f * Time.time));
        return initYspeed + amplitude * Mathf.Sin(frequency * 0.01f * Time.time);
        
    }

    public float solarFlareEvent(float initYspeed, float timing, float amplitude, float delay)
    {
        // param timing : durée de l'event
        if(Time.time <= delay)
        {
            return initYspeed;
        }
        if (Time.time <= timing/3)
        {
            return initYspeed + (Time.time - delay) / (timing/3 - delay) * amplitude;
        }
        return initYspeed + amplitude + (timing / 3 - Time.time)/(2*timing / 3) * amplitude;
    }

    public float meteorologicEvent(float initYspeed, float timing, float amplitude, float delay)
    {
        // param timing : durée de l'event
        if (Time.time <= 2 * timing / 3)
        {
            return initYspeed - amplitude * Time.time / (2*timing/3);
        }
        if (Time.time <= timing - delay)
        {
            return initYspeed - amplitude - (((2 * timing / 3) - Time.time) / ((timing / 3) + delay)) * amplitude;
        }
        return initYspeed;
    }

    public float tsunamiEvent(float initYspeed, float timing, float amplitude, float _maxTravelDistance)
    {
        // param timing : durée de l'event
        return initYspeed;
    }

    public float meteorEvent(float initYspeed, float timing, float amplitude, float frequency, float _maxTravelDistance)
    {
        // param timing : durée de l'event
        return initYspeed;
    }
}
