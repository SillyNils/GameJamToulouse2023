using System;
using System.Collections;
using UnityEngine;

public enum EventEnum { SeismicEvent, SolarFlareEvent, MeteorologicEvent, TsunamiEvent };

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

    ArrayList eventList = new ArrayList();
    EventRotationModificationService eventRotationModificationService;

    public GeneralRotation generalRotation;

    public ArrayList EventList { get => eventList; set => eventList = value; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
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
                    finalYRotationSpeed = eventRotationModificationService.SeismicEvent(finalYRotationSpeed, eventToRead.timing, eventToRead.amplitude, eventToRead.frequency);
                    break;
                case EventEnum.SolarFlareEvent:
                    if (eventWithTimingComplete(eventToRead.initTime, eventToRead.timing))
                    {
                        eventList.Remove(eventToRead);
                        break;
                    }
                    finalYRotationSpeed = eventRotationModificationService.SolarFlareEvent(finalYRotationSpeed, eventToRead.timing, eventToRead.amplitude, eventToRead.delay);
                    break;
                case EventEnum.MeteorologicEvent:
                    if (eventWithTimingComplete(eventToRead.initTime, eventToRead.timing))
                    {
                        eventList.Remove(eventToRead);
                        break;
                    }
                    finalYRotationSpeed = eventRotationModificationService.MeteorologicEvent(finalYRotationSpeed, eventToRead.timing, eventToRead.amplitude, eventToRead.delay);
                    break;
                case EventEnum.TsunamiEvent:
                    finalYRotationSpeed = eventRotationModificationService.TsunamiEvent(finalYRotationSpeed, eventToRead.timing, eventToRead.amplitude, eventToRead.maxTravelDistance);
                    break;
            }
        }
        generalRotation.YspeedRotation = finalYRotationSpeed;
    }

    bool eventWithTimingComplete(float initTime, float timing)
    {
        return (Time.fixedTime - initTime) >= timing;
    }

    bool eventWithSuccessComplete(float amplitude)
    {
        return amplitude <= 1;
    }

    void reduceAmplitudeEvent(EventObject eventToRead, bool globalIsInNormalState)
    {
        if(globalIsInNormalState)
        {
            eventToRead.validTime += Time.fixedDeltaTime;
            eventToRead.amplitude = eventToRead.initAmplitude * (1 - eventToRead.validTime / eventToRead.timing);
        }
    }
}
