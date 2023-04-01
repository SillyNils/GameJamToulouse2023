using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralRotation : MonoBehaviour
{
    [Header("X roation parameter")]
    [SerializeField] private float _XspeedRotation;
    [SerializeField] float _XtiltAngle;

    [Header("Y roation parameter")]
    [SerializeField] private float _YspeedRotation;
    [SerializeField] float _YtiltAngle;

    [Header("Z roation parameter")]
    [SerializeField] private float _ZspeedRotation;
    [SerializeField] float _ZtiltAngle;

    [Header("dead zone paramatre")]
    [SerializeField] private bool _globalisInNormalState = false;
    [SerializeField] private bool _XisInNormalState = false;
    [SerializeField] private bool _YisInNormalState = false;
    [SerializeField] private bool _ZisInNormalState = false;
    private float _XZdeadZoneSize = 5f;
    private float _YdeadZoneSize = 100f;

    public float XspeedRotation { get => _XspeedRotation; set => _XspeedRotation = value; }
    public float YspeedRotation { get => _YspeedRotation; set => _YspeedRotation = value; }
    public float ZspeedRotation { get => _ZspeedRotation; set => _ZspeedRotation = value; }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // zone de calcule sur l'axe X

        _XtiltAngle += Time.deltaTime; // fait varier tiltrotation en le * par le tmeps en cours

        float tiltAroundX = _XtiltAngle *  _XspeedRotation;

        Quaternion Xquaternion= Quaternion.Euler(tiltAroundX,0, 0);


        // zone calcule sur l'axe Y

        _YtiltAngle += Time.deltaTime; // fait varier tiltrotation en le * par le tmeps en cours

        float tiltAroundY = _YtiltAngle * _YspeedRotation;

        Quaternion Yquaternion = Quaternion.Euler(0, tiltAroundY, 0);

        // zone calcule sur l'axe Z
        _ZtiltAngle += Time.deltaTime; // fait varier tiltrotation en le * par le tmeps en cours

        float tiltAroundZ = _ZtiltAngle * _ZspeedRotation;

        Quaternion Zquaternion = Quaternion.Euler(0, 0, tiltAroundZ);


        // zone de calcule de la rotation global X+Y+Z

        transform.rotation = Xquaternion * Yquaternion * Zquaternion;

        IsInNormalState(_XspeedRotation,_YspeedRotation,_ZspeedRotation);

    }


    public void IsInNormalState(float Xspeed,float Yspeed,float Zspeed)// crée un dead zone dite etat normal et verifie si l'un des parametre en sort
    {

        if(Xspeed < _XZdeadZoneSize && Xspeed > -_XZdeadZoneSize)//verifie la dead zone sur l'axe X
        {
            _XisInNormalState= true;
        }

        if(Yspeed < (_YdeadZoneSize +5) && Yspeed > (_YdeadZoneSize - 5))//verifie la dead zone sur l'axe Y !! a une valeur differente !!
        {
            _YisInNormalState= true;
        }
        
        if(Zspeed < _XZdeadZoneSize && Zspeed > -_XZdeadZoneSize)//verifie la dead zone sur l'axe Z
        {
            _ZisInNormalState= true;
        }

        if(_XisInNormalState && _YisInNormalState && _ZisInNormalState)// met en commun les different etats et trigger la stabiliter general du system
        {
            _globalisInNormalState= true;
        }
    }

}
