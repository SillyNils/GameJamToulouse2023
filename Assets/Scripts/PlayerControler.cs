using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Windows;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private float _Playerspeed = 100;
    [SerializeField] private Transform _emptyParentTransform;

    [SerializeField] private float _YplayerMovementClampCenter;
    [SerializeField] private float _YplayerMovementClampExtent;
    [SerializeField] private float _YplayerCenter;
    [SerializeField] private float _ZplayerMovementClampCenter;
    [SerializeField] private float _ZplayerMovementClampExtent;
    [SerializeField] private float _ZplayerCenter;
    [SerializeField] private float _deltaDeplacement;
    [SerializeField] private float _deltaInput;

    private float _deltaForce;

    [SerializeField] private GeneralRotation _YGrotation;

    private bool _PlayerIsInNormalState = true;
    [SerializeField] private float _PlayerSafeZone;

    public bool playerIsInNormalState { get => _PlayerIsInNormalState; set => _PlayerIsInNormalState = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerInNormalState();

        Vector2 input = new Vector2(UnityEngine.Input.GetAxis("X axis"), UnityEngine.Input.GetAxis("Y axis"));

            if (input.magnitude > 1)
            {
                input.Normalize();
            }
 

        _Playerspeed = _Playerspeed + input.x * _deltaInput; // calcule de la nouvelle vitesse joueur

        _deltaForce = _Playerspeed - _YGrotation.YspeedRotation; // calcule le delat de vitesse entre Vnoyaux et Vplayers
        
        
        

            Quaternion parentRot = _emptyParentTransform.rotation;
            Vector3 euler = parentRot.eulerAngles;
            //float newY = (euler.y - input.x + 180) % 360 - 180;

            float newY =  (- _deltaForce/ Mathf.Sin(Mathf.Deg2Rad*euler.z) + 180) % 360 - 180;
            /// deplacement sur la longitude
            float newZ = (input.y + 180) % 360 - 180; /// deplacement sur la latitude

            Vector2 newYZNormalized = new Vector2(newY, newZ).normalized; /// balek

            euler.y += _deltaDeplacement * newY;
            ///Mathf.Clamp(newY,
            ///_YplayerMovementClampCenter - _YplayerMovementClampExtent ,
            ///_YplayerMovementClampCenter + _YplayerMovementClampExtent );
            euler.z = _ZplayerCenter + _deltaDeplacement * newZ;

            parentRot.eulerAngles = euler;
            _emptyParentTransform.rotation = parentRot;

        if (input != Vector2.zero)
        {
            Quaternion localRot = transform.localRotation;
            localRot.eulerAngles = new Vector3(0, Vector2.SignedAngle(Vector2.down, input), 0);
            transform.localRotation = localRot;
        }
    }

    public void PlayerInNormalState()
    {
        /*Debug.Log(Mathf.Rad2Deg * _emptyParentTransform.rotation.y);
        Debug.Log(_PlayerIsInNormalState);*/


       if (Mathf.Rad2Deg * _emptyParentTransform.rotation.y >= _PlayerSafeZone || Mathf.Rad2Deg * _emptyParentTransform.rotation.y <= -_PlayerSafeZone)
        {
            _PlayerIsInNormalState = false;
        }
        else
        {
            _PlayerIsInNormalState = true;
        }
    }

    public void qteSpeedReset()
    {
        Quaternion parentRot = _emptyParentTransform.rotation;
        Vector3 euler = parentRot.eulerAngles;

        euler.y = 0;
        euler.z = _ZplayerCenter;

        parentRot.eulerAngles = euler;
        _emptyParentTransform.rotation = parentRot;


        _Playerspeed = _YGrotation.YspeedRotation + (_Playerspeed - _YGrotation.YspeedRotation) * 0.5f;
    }
}
