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
                    finalYRotationSpeed = eventRotationModificationService.SeismicEvent(finalYRotationSpeed, eventToRead.timing, eventToRead.amplitude, eventToRead.frequency);
                    break;
                case EventEnum.SolarFlareEvent:
                    finalYRotationSpeed = eventRotationModificationService.SolarFlareEvent(finalYRotationSpeed, eventToRead.timing, eventToRead.amplitude, eventToRead.delay);
                    break;
                case EventEnum.MeteorologicEvent:
                    finalYRotationSpeed = eventRotationModificationService.MeteorologicEvent(finalYRotationSpeed, eventToRead.timing, eventToRead.amplitude, eventToRead.delay);
                    break;
                case EventEnum.TsunamiEvent:
                    finalYRotationSpeed = eventRotationModificationService.TsunamiEvent(finalYRotationSpeed, eventToRead.timing, eventToRead.amplitude, eventToRead.maxTravelDistance);
                    break;
            }
        }
        generalRotation.YspeedRotation = finalYRotationSpeed;
    }

}
