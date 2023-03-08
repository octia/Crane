using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    private Rigidbody _rigidbody;



    [SerializeField]
    [Range(0f, 100f)]
    private float _movementForceMultiplier = 10f;

    private float _armMovement = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = Vector3.up;
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
            //_rigidbody.angularVelocity = transform.up * _armMovement * _movementForceMultiplier;
            _rigidbody.AddTorque(transform.up * _armMovement * _movementForceMultiplier);
            //_rigidbody.AddForce(transform.up * _armMovement * _movementForceMultiplier * 100f);
        }
    }

}
