using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TrackEnum { BaseNeutre, SeismicEvent, SolarFlareEvent, MeteorologicEvent, MeteorEvent, Looser };

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource _baseNeutre_audiosource;
    [SerializeField] AudioSource _seisme_audiosource;
    [SerializeField] AudioSource _tempete_audiosource;
    [SerializeField] AudioSource _intemperie_audiosource;
    [SerializeField] AudioSource _meteorite_audiosource;
    [SerializeField] AudioSource _looser_audiosource;
    [SerializeField] AudioSource _buttonClick_audiosource;

    [Header("EventManager parameter")]
    [SerializeField] private WaveManager waveManager;

    [Header("QTEAreaDectectionLeft parameter")]
    [SerializeField] private QTEAreaDectection qteAreaDectectionLeft;
    
    [Header("QTEAreaDectectionRight parameter")]
    [SerializeField] private QTEAreaDectection qteAreaDectectionRight;

    [SerializeField] float _fadeRate;
    [SerializeField] EventEnum _track;
    private bool _looserIsplaying = false;

    public EventEnum Track { get => _track; set => _track = value; }


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
        if ((qteAreaDectectionLeft.GameOver == true|| qteAreaDectectionRight.GameOver == true) && !_looserIsplaying)
        {
            //game over
            StartCoroutine(LooserPlaying());

            _baseNeutre_audiosource.volume = 0;
            _seisme_audiosource.volume = 0;
            _tempete_audiosource.volume = 0;
            _intemperie_audiosource.volume = 0;
            _meteorite_audiosource.volume = 0;
        }
        else if (waveManager.LastEvent == null)
        {
            //base neutre
            _baseNeutre_audiosource.volume += _fadeRate;

            _seisme_audiosource.volume -= _fadeRate;
            _tempete_audiosource.volume -= _fadeRate;
            _intemperie_audiosource.volume -= _fadeRate;
            _meteorite_audiosource.volume -= _fadeRate;
        } else {
            switch (waveManager.LastEvent.type)
            {
                /*
                case TrackEnum.BaseNeutre://base neutre

                    _baseNeutre_audiosource.volume += _fadeRate;

                    _seisme_audiosource.volume -= _fadeRate;
                    _tempete_audiosource.volume -= _fadeRate;
                    _intemperie_audiosource.volume -= _fadeRate;
                    _meteorite_audiosource.volume -= _fadeRate;
                    break;
                */
                case EventEnum.SeismicEvent://seisme
                    _seisme_audiosource.volume += _fadeRate;

                    _baseNeutre_audiosource.volume -= _fadeRate;
                    _tempete_audiosource.volume -= _fadeRate;
                    _intemperie_audiosource.volume -= _fadeRate;
                    _meteorite_audiosource.volume -= _fadeRate;
                    break;

                case EventEnum.SolarFlareEvent://tempete
                    _tempete_audiosource.volume += _fadeRate;

                    _seisme_audiosource.volume -= _fadeRate;
                    _baseNeutre_audiosource.volume -= _fadeRate;
                    _intemperie_audiosource.volume -= _fadeRate;
                    _meteorite_audiosource.volume -= _fadeRate;
                    break;

                case EventEnum.MeteorologicEvent://intemperie
                    _intemperie_audiosource.volume += _fadeRate;

                    _seisme_audiosource.volume -= _fadeRate;
                    _tempete_audiosource.volume -= _fadeRate;
                    _baseNeutre_audiosource.volume -= _fadeRate;
                    _meteorite_audiosource.volume -= _fadeRate;
                    break;

                case EventEnum.MeteorEvent://meteorite
                    _meteorite_audiosource.volume += _fadeRate;

                    _seisme_audiosource.volume -= _fadeRate;
                    _tempete_audiosource.volume -= _fadeRate;
                    _intemperie_audiosource.volume -= _fadeRate;
                    _baseNeutre_audiosource.volume -= _fadeRate;
                    break;
                /*
                case TrackEnum.Looser://looser

                    if (_looserIsplaying == false)
                    {
                        StartCoroutine(LooserPlaying());

                        _baseNeutre_audiosource.volume = 0;
                        _seisme_audiosource.volume = 0;
                        _tempete_audiosource.volume = 0;
                        _intemperie_audiosource.volume = 0;
                        _meteorite_audiosource.volume = 0;
                    }
                    break;
                */
            }
        }
    }

    IEnumerator LooserPlaying()//gere laudio de la defaite
    {
        _looserIsplaying= true;
        _looser_audiosource.Play();
        _looserIsplaying = _looser_audiosource.isPlaying;
        yield return _looserIsplaying == false;
    }


    public void PlayClickSound()
    {
        _buttonClick_audiosource.Play();
    }
}

