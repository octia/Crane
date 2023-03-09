using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CartController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField]
    [Range(0f, 100f)]
    private float _movementForceMultiplier = 10f;

    private float _forwardMovement = 0f;

    private Vector3 _startingLocalPos = Vector3.zero;

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startingLocalPos = transform.localPosition;
    }

    /// <summary>
    /// Move the cart forward or backward.
    /// </summary>
    /// <param name="forwardMovement">Range (-1, 1) Positive value means movement away from the base of the crane. </param>
    public void SetMove(float forwardMovement)
    {
        forwardMovement = Mathf.Clamp(forwardMovement, -1f, 1f);
        _forwardMovement = forwardMovement;
    }

    private void FixedUpdate()
    {
        // Allow no local rotation, and no local movement except for the z axis
        // This is neccessary due to a unity bug(?), causing the rigidbody to not rotate along with the partent, after the parent has its center of mass reset
        transform.localPosition = new Vector3(_startingLocalPos.x, _startingLocalPos.y, transform.localPosition.z);
        transform.localRotation = Quaternion.identity;
        

        // Move the cart accoring to input
        if(!Mathf.Approximately(_forwardMovement, 0))
        {
            _rigidbody.AddForce(_rigidbody.mass * transform.forward * _forwardMovement * _movementForceMultiplier);
        }

    }
}
