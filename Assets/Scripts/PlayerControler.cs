using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _emptyParentTransform;
    [SerializeField] private int _playerMovementClamp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 input = new Vector2(Input.GetAxis("X axis"), Input.GetAxis("Y axis"));

        if(input != Vector2.zero)
        {
            if (input.magnitude > 1)
            {
                input.Normalize();
            }

            Quaternion parentRot = _emptyParentTransform.rotation;
            Vector3 euler = parentRot.eulerAngles;
            euler.x = Mathf.Clamp((euler.x - input.y + 180) % 360 - 180, -_playerMovementClamp, _playerMovementClamp);
            euler.z = Mathf.Clamp((euler.z - input.x + 180) % 360 - 180, -_playerMovementClamp, _playerMovementClamp);
            parentRot.eulerAngles = euler;
            _emptyParentTransform.rotation = parentRot;


            Quaternion localRot = transform.localRotation;
            localRot.eulerAngles = new Vector3(0, Vector2.Angle(Vector2.right, input), 0);
            transform.localRotation = localRot;
        }

    }
}
