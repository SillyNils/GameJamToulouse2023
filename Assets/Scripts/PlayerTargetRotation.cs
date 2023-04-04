using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTargetRotation : MonoBehaviour
{
    [SerializeField] private int _speed ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float tiltAroundY = Time.deltaTime * _speed;

        Quaternion Yquaternion = Quaternion.Euler(0, 0, tiltAroundY);
        transform.rotation = Yquaternion;
    }
}
