using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _emptyParentTransform;

    [SerializeField] private float _YplayerMovementClampCenter;
    [SerializeField] private float _YplayerMovementClampExtent;
    [SerializeField] private float _YplayerCenter;
    [SerializeField] private float _ZplayerMovementClampCenter;
    [SerializeField] private float _ZplayerMovementClampExtent;
    [SerializeField] private float _ZplayerCenter;
    [SerializeField] private float _delta;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 input = new Vector2(Input.GetAxis("X axis"), Input.GetAxis("Y axis"));

            if (input.magnitude > 1)
            {
                input.Normalize();
            }

            Quaternion parentRot = _emptyParentTransform.rotation;
            Vector3 euler = parentRot.eulerAngles;
            //float newY = (euler.y - input.x + 180) % 360 - 180;

            float newY =  (- input.x / Mathf.Sin(Mathf.Deg2Rad*euler.z) + 180) % 360 - 180;
            /// deplacement sur la longitude
            float newZ = (input.y + 180) % 360 - 180; /// deplacement sur la latitude

            Vector2 newYZNormalized = new Vector2(newY, newZ).normalized; /// balek

            euler.y += _delta * newY;
            ///Mathf.Clamp(newY,
            ///_YplayerMovementClampCenter - _YplayerMovementClampExtent ,
            ///_YplayerMovementClampCenter + _YplayerMovementClampExtent );
            euler.z = _ZplayerCenter + _delta * newZ;
            ///Mathf.Clamp(newZ,
               /// _ZplayerMovementClampCenter - _ZplayerMovementClampExtent,
               /// _ZplayerMovementClampCenter + _ZplayerMovementClampExtent); /// crée le meme mouvement que la fonction du dessus
            parentRot.eulerAngles = euler;
            _emptyParentTransform.rotation = parentRot;

        if (input != Vector2.zero)
        {
            Quaternion localRot = transform.localRotation;
            localRot.eulerAngles = new Vector3(0, Vector2.SignedAngle(Vector2.down, input), 0);
            transform.localRotation = localRot;
        }
    }
}
