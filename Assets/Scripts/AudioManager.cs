using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.FlowStateWidget;


public enum TrackEnum { BaseNeutre, SeismicEvent, SolarFlareEvent, MeteorologicEvent, MeteorEvent, Looser };

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource _baseNeutre_audiosource;
    [SerializeField] AudioSource _seisme_audiosource;
    [SerializeField] AudioSource _tempete_audiosource;
    [SerializeField] AudioSource _intemperie_audiosource;
    [SerializeField] AudioSource _meteorite_audiosource;
    [SerializeField] AudioSource _looser_audiosource;

    [Header("EventManager parameter")]
    [SerializeField] private EventManager eventManager;

    [Header("EventManager parameter")]
    [SerializeField] private GameManager gameManager;

    [SerializeField] float _fadeRate;
    [SerializeField] TrackEnum _track;
    private bool _looserIsplaying = false;


    // Start is called before the first frame update
    void Start()
    {
        _baseNeutre_audiosource.volume = 1;
        _seisme_audiosource.volume = 0;
        _tempete_audiosource.volume = 0;
        _intemperie_audiosource.volume = 0;
        _meteorite_audiosource.volume = 0;
        _looser_audiosource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        EventObject eventActif = eventManager.EventList.Count > 0 ? eventManager.EventList[eventManager.EventList.Count - 1] : null;

        if (gameManager.GameOverPanel == true)
        {
            //game over
            StartCoroutine(LooserPlaying());

            _baseNeutre_audiosource.volume = 0;
            _seisme_audiosource.volume = 0;
            _tempete_audiosource.volume = 0;
            _intemperie_audiosource.volume = 0;
            _meteorite_audiosource.volume = 0;
        } else if (eventActif == null)
        {
            
            //base neutre
            _baseNeutre_audiosource.volume += _fadeRate;

            _seisme_audiosource.volume -= _fadeRate;
            _tempete_audiosource.volume -= _fadeRate;
            _intemperie_audiosource.volume -= _fadeRate;
            _meteorite_audiosource.volume -= _fadeRate;
        } else
        {
            switch (eventActif.type)
            {
                case EventEnum.SeismicEvent:
                    //base seisme
                    _seisme_audiosource.volume += _fadeRate;

                    _baseNeutre_audiosource.volume -= _fadeRate;
                    _tempete_audiosource.volume -= _fadeRate;
                    _intemperie_audiosource.volume -= _fadeRate;
                    _meteorite_audiosource.volume -= _fadeRate;
                    break;

                case EventEnum.SolarFlareEvent:
                    //base tempete
                    _tempete_audiosource.volume += _fadeRate;

                    _seisme_audiosource.volume -= _fadeRate;
                    _baseNeutre_audiosource.volume -= _fadeRate;
                    _intemperie_audiosource.volume -= _fadeRate;
                    _meteorite_audiosource.volume -= _fadeRate;
                    break;

                case EventEnum.MeteorologicEvent:
                    //base intemperie
                    _intemperie_audiosource.volume += _fadeRate;

                    _seisme_audiosource.volume -= _fadeRate;
                    _tempete_audiosource.volume -= _fadeRate;
                    _baseNeutre_audiosource.volume -= _fadeRate;
                    _meteorite_audiosource.volume -= _fadeRate;
                    break;

                case EventEnum.MeteorEvent:
                    //base meteorite
                    _meteorite_audiosource.volume += _fadeRate;

                    _seisme_audiosource.volume -= _fadeRate;
                    _tempete_audiosource.volume -= _fadeRate;
                    _intemperie_audiosource.volume -= _fadeRate;
                    _baseNeutre_audiosource.volume -= _fadeRate;
                    break;
            }
        }
    }

    IEnumerator LooserPlaying()
    {
        //gere laudio de la defaite
        _looserIsplaying= true;
        _looser_audiosource.Play();
        _looserIsplaying = _looser_audiosource.isPlaying;
        yield return _looserIsplaying == false;
    }
}
