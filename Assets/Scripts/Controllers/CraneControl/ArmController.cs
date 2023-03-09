using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{



    [SerializeField]
    [Range(0f, 150f)]
    private float _movementForceMultiplier = 10f;

    private Rigidbody _rigidbody;
    
    private float _armMovement = 0f;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = Vector3.zero;
    }
    

    /// <summary>
    /// Move the arm clockwise or anticlockwise.
    /// </summary>
    /// <param name="armMovement">Range (-1, 1) Positive value means clockwise movement. </param>
    public void SetMove(float armMovement)
    {
        armMovement = Mathf.Clamp(armMovement, -1f, 1f);
        _armMovement = armMovement;
    }

    private void FixedUpdate()
    {
        if(!Mathf.Approximately(_armMovement, 0))
        {
            _rigidbody.MoveRotation(Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f));
            _rigidbody.AddTorque(_rigidbody.mass * transform.up * _armMovement * _movementForceMultiplier);
        }
    }

}
