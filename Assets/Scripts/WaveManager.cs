using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.UIElements;
using UnityEngine;

class WaveEvent
{
    List<EventObject> _events = new List<EventObject>();

    public List<EventObject> events { get => _events; set => _events = value; }
}

public class WaveManager : MonoBehaviour
{
    [Header("Event type parameter")]
    [SerializeField] private EventEnum _type;
 
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

    [Header("EventManager parameter")]
    [SerializeField] private EventManager eventManager;

    [Header("UI")]
    [SerializeField] private PopupManager _popupManager;

    private bool _waveComplete;
    private List<WaveEvent> _waves = new();
    private int _waveIndex;
    private int _eventIndex;
    private EventObject lastEvent;
    private int _nbSimultaneousEvent;
    private float _minimalTimeBetweenEvent;
    private float _timeSinceLastEventTriggered;
    private bool _coroutineStarted;

    public EventObject LastEvent { get => lastEvent; set => lastEvent = value; }


    // Start is called before the first frame update
    void Start()
    {
        _waves = new List<WaveEvent>();
        _waveIndex = 0;
        _eventIndex = 0;
        _nbSimultaneousEvent = 3;
        _minimalTimeBetweenEvent = 5f;
        _timeSinceLastEventTriggered = Time.time;
        _waveComplete = false;
        _coroutineStarted = false;
        lastEvent = null;
        firstWave();
        secondWave();
        thirdWave();
        forthWave();
        fifthWave();
        sixthWave();
        unlimitedWave();
    }

    // Update is called once per frame
    void Update()
    {
        updateWaveEvent();
    }

    void firstWave()
    {
        //_popupManager.SeismPanel();
        WaveEvent waveEvent = new();
        waveEvent.events.Add(addCustomEvent(EventEnum.SeismicEvent, 0.5f, 1f, 0, 120f, 0));
        _waves.Add(waveEvent);
    }

    void secondWave()
    {
        //_popupManager.CloudPanel();
        WaveEvent waveEvent = new WaveEvent();
        waveEvent.events.Add(addCustomEvent(EventEnum.MeteorologicEvent, 10f, 4f, 2f, 0f, 0));
        _waves.Add(waveEvent);
    }

    void thirdWave()
    {
        _popupManager.SolarflarePanel();
        WaveEvent waveEvent = new WaveEvent();
        waveEvent.events.Add(addCustomEvent(EventEnum.SolarFlareEvent, 10f, 4f, 2f, 0f, 0));
        _waves.Add(waveEvent); 
    }

    void forthWave()
    {
        WaveEvent waveEvent = new WaveEvent();
        waveEvent.events.Add(addCustomEvent(EventEnum.SeismicEvent, 5f, 4f, 0, 120f, 0));
        waveEvent.events.Add(addCustomEvent(EventEnum.MeteorologicEvent, 5f, 4f, 2.5f, 0f, 0));
        _waves.Add(waveEvent);
    }

    void fifthWave()
    {
        WaveEvent waveEvent = new WaveEvent();
        waveEvent.events.Add(addCustomEvent(EventEnum.SeismicEvent, 5f, 4f, 0, 125f, 0));
        waveEvent.events.Add(addCustomEvent(EventEnum.SolarFlareEvent, 10f, 4f, 2.5f, 0f, 0));
        _waves.Add(waveEvent); 
    }

    void sixthWave()
    {
        WaveEvent waveEvent = new WaveEvent();
        waveEvent.events.Add(addCustomEvent(EventEnum.SeismicEvent, 5f, 4f, 0, 120f, 0));
        waveEvent.events.Add(addCustomEvent(EventEnum.MeteorologicEvent, 15f, 4f, 4f, 0f, 0));
        waveEvent.events.Add(addCustomEvent(EventEnum.SolarFlareEvent, 12f, 4f, 3f, 0f, 0));
        _waves.Add(waveEvent); 
    }

    void unlimitedWave()
    {
        WaveEvent waveEvent = new WaveEvent();
        waveEvent.events.Add(addCustomEvent(EventEnum.MeteorologicEvent, 13f, 4f, 0, 0f, 0));
        waveEvent.events.Add(addCustomEvent(EventEnum.SolarFlareEvent, 15f, 4f, 0, 0f, 0));
        waveEvent.events.Add(addCustomEvent(EventEnum.MeteorologicEvent, 21f, 4f, 0, 0f, 0));
        waveEvent.events.Add(addCustomEvent(EventEnum.SeismicEvent, 6f, 4f, 0, 120f, 0));
        waveEvent.events.Add(addCustomEvent(EventEnum.SeismicEvent, 7f, 4f, 0, 120f, 0));
        waveEvent.events.Add(addCustomEvent(EventEnum.SolarFlareEvent, 9f, 4f, 0, 0f, 0));
        waveEvent.events.Add(addCustomEvent(EventEnum.MeteorologicEvent, 11f, 4f, 0, 0f, 0));
        waveEvent.events.Add(addCustomEvent(EventEnum.MeteorologicEvent, 13f, 4f, 0, 0f, 0));
        waveEvent.events.Add(addCustomEvent(EventEnum.SolarFlareEvent, 16f, 4f, 0, 0f, 0));
        waveEvent.events.Add(addCustomEvent(EventEnum.SeismicEvent, 8f, 4f, 0, 120f, 0));
        waveEvent.events.Add(addCustomEvent(EventEnum.SeismicEvent, 9f, 4f, 0, 120f, 0));
        waveEvent.events.Add(addCustomEvent(EventEnum.SeismicEvent, 10f, 4f, 0, 120f, 0));
        waveEvent.events.Add(addCustomEvent(EventEnum.SolarFlareEvent, 21f, 4f, 0, 0f, 0));
        waveEvent.events.Add(addCustomEvent(EventEnum.SolarFlareEvent, 12f, 4f, 0, 0f, 0));
        waveEvent.events.Add(addCustomEvent(EventEnum.MeteorologicEvent, 24f, 4f, 0, 0f, 0));
        waveEvent.events.Add(addCustomEvent(EventEnum.MeteorologicEvent, 26f, 4f, 0, 0f, 0));
        waveEvent.events.Add(addCustomEvent(EventEnum.SolarFlareEvent, 10f, 4f, 0, 0f, 0));
        waveEvent.events.Add(addCustomEvent(EventEnum.SolarFlareEvent, 8f, 4f, 0, 0f, 0));
        waveEvent.events.Add(addCustomEvent(EventEnum.SolarFlareEvent, 6f, 4f, 0, 0f, 0));
        _waves.Add(waveEvent); 
    }

    EventObject addCustomEvent(EventEnum type, float timing, float amplitude, float delay, float frequency, float maxTravelDistance)
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
        return eventToAdd;
    }

    void updateWaveEvent()
    {
        foreach (WaveEvent wave in _waves)
        {
            if (_waves.IndexOf(wave) == _waveIndex)
            {
                // CurrentWave
                if (wave.events.Count > _eventIndex)
                {
                    // Des events de la Wave sont encore � trigger
                    if (eventManager.EventList.Count < _nbSimultaneousEvent && (Time.time - _timeSinceLastEventTriggered) >= _minimalTimeBetweenEvent)
                    {
                        eventManager.addEvent(wave.events[_eventIndex]);
                        lastEvent = wave.events[_eventIndex];
                        _timeSinceLastEventTriggered = Time.time;
                        _eventIndex++;
                    }
                }
                else
                {
                    // Tous les events de la Wave ont �t� trigger
                    _waveComplete = eventManager.EventList.Count == 0;
                    if(_waveComplete && !_coroutineStarted)
                    {
                        StartCoroutine(waitBetweenWaves());
                    }
                    
                }
            }
        }
    }

    IEnumerator waitBetweenWaves()
    {
        _coroutineStarted = true;
        Debug.Log("debut waitBetweenWaves");
        if (_waveIndex == 0)
        {
            _popupManager.SeismPanel();
            Debug.LogError("debut waitBetweenWaves");
            while (!_popupManager.ButtonClicked)
            {
                yield return 0;
            }
            _waveIndex = _waveIndex + 1;
            _eventIndex = 0;
            _waveComplete = false;
        } else if (_waveIndex == 1)
        {
            _popupManager.CloudPanel();
            Debug.LogError("debut waitBetweenWaves");
            while (!_popupManager.ButtonClicked)
            {
                yield return 0;
            }
            _waveIndex = _waveIndex + 1;
            _eventIndex = 0;
            _waveComplete = false;
        } else if (_waveIndex == 2)
        {
            _popupManager.SolarflarePanel();
            Debug.LogError("debut waitBetweenWaves");
            while (!_popupManager.ButtonClicked)
            {
                yield return 0;
            }
            _waveIndex = _waveIndex + 1;
            _eventIndex = 0;
            _waveComplete = false;
        } else
        {
        Debug.Log(_waveIndex);
        yield return new WaitForSeconds(5f);
        _waveIndex = _waveIndex + 1 ;
        _eventIndex = 0;
        _waveComplete = false;
        Debug.Log(_waveIndex);
        }
        Debug.Log("fin waitBetweenWaves");
        _coroutineStarted = false;
    }

    IEnumerator addEvent()
    {
        Debug.Log("debut event");
        if (eventManager.EventList.Count < 3)
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
        Debug.Log("fin event");
    }
}
