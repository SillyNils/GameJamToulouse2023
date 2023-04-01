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

    [Header("autre paramatre")]
    [SerializeField] private bool _isInNormalState;

    //teste
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // zone de calcule sur l'axe X

        _XtiltAngle += Time.deltaTime; // fait varier tiltrotation en le * par le tmeps en cours

        float tiltAroundX = Mathf.Sin(_XtiltAngle) *  _XspeedRotation;

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
    }


    public void IsInNormalState(Quaternion xQ, Quaternion yQ, Quaternion zQ)
    {

    }
}
