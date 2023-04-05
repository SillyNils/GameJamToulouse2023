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

        switch(_track)
        {
            case TrackEnum.BaseNeutre://base neutre

                _baseNeutre_audiosource.volume += _fadeRate;

                _seisme_audiosource.volume -= _fadeRate;
                _tempete_audiosource.volume -= _fadeRate;
                _intemperie_audiosource.volume -= _fadeRate;
                _meteorite_audiosource.volume -= _fadeRate;
                break;
            
            case TrackEnum.SeismicEvent://seisme
                _seisme_audiosource.volume += _fadeRate;

                _baseNeutre_audiosource.volume -= _fadeRate;
                _tempete_audiosource.volume -= _fadeRate;
                _intemperie_audiosource.volume -= _fadeRate;
                _meteorite_audiosource.volume -= _fadeRate;
                break;

            case TrackEnum.SolarFlareEvent://tempete
                _tempete_audiosource.volume += _fadeRate;

                _seisme_audiosource.volume -= _fadeRate;
                _baseNeutre_audiosource.volume -= _fadeRate;
                _intemperie_audiosource.volume -= _fadeRate;
                _meteorite_audiosource.volume -= _fadeRate;
                break;

            case TrackEnum.MeteorologicEvent://intemperie
                _intemperie_audiosource.volume += _fadeRate;

                _seisme_audiosource.volume -= _fadeRate;
                _tempete_audiosource.volume -= _fadeRate;
                _baseNeutre_audiosource.volume -= _fadeRate;
                _meteorite_audiosource.volume -= _fadeRate;
                break;

            case TrackEnum.MeteorEvent://meteorite
                _meteorite_audiosource.volume += _fadeRate;

                _seisme_audiosource.volume -= _fadeRate;
                _tempete_audiosource.volume -= _fadeRate;
                _intemperie_audiosource.volume -= _fadeRate;
                _baseNeutre_audiosource.volume -= _fadeRate;
                break;

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

        }
    }

    IEnumerator LooserPlaying()//gere laudio de la defaite
    {
        _looserIsplaying= true;
        _looser_audiosource.Play();
        _looserIsplaying = _looser_audiosource.isPlaying;
        yield return _looserIsplaying == false;
    }
}
