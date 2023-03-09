using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Control the rope of the crane - pull the attached object towards the anchor of the rope.
/// The anchor is at the position of the transform of the rope controller.
/// </summary>
public class RopeController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _attachedRigidBody;

    [SerializeField]
    private float _ropeLength = 5f;

    [SerializeField]
    private float _minRopeLength = 1f;

    [SerializeField]
    private float _maxRopeLength = 100f;

    /// <summary>
    /// The speed at which the rope length changes per second.
    /// </summary>
    [SerializeField]
    private float _ropeChangeRate = 1f;

    [SerializeField]
    private bool _blockXRotation = true;
    [SerializeField]
    private bool _blockYRotation = true;
    [SerializeField]
    private bool _blockZRotation = true;

    private float _lengthChangeDir = 0f;


    /// <summary>
    /// Change the length of the rope.
    /// </summary>
    /// <param name="legnthChangeDir">Range (-1, 1) Positive value means lengthening the rope.</param>
    public void ChangeLength(float legnthChangeDir)
    {
        legnthChangeDir = Mathf.Clamp(legnthChangeDir, -1f, 1f);
        _lengthChangeDir = legnthChangeDir;
    }

    private void OnDrawGizmos()
    {
        // Draw a sphere representing the length of the rope.
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _ropeLength);
    }

    private void FixedUpdate()
    {
        ChangeRopeLength();
        AffectAttachedRigidBody();
    }

    private void ChangeRopeLength()
    {
        if (!Mathf.Approximately(_lengthChangeDir, 0))
        {
            _ropeLength += _lengthChangeDir * _ropeChangeRate * Time.fixedDeltaTime;
            _ropeLength = Mathf.Clamp(_ropeLength, _minRopeLength, _maxRopeLength);
        }
    }


    private void AffectAttachedRigidBody()
    {
        Transform attachedRigidBodyTransform = _attachedRigidBody.transform;
        Vector3 offsetToAttachedRigidbody = attachedRigidBodyTransform.position - transform.position;
        Vector3 directionToAttachedRigidbody = offsetToAttachedRigidbody.normalized;

        // Set the distance to the rope length.

        if (offsetToAttachedRigidbody.magnitude > _ropeLength)
        {
            // allow swinging of the object, 
            // by adding an acceleration towards the anchor of the rope.

            float inwardAcceleration = Vector3.Dot(Physics.gravity, -directionToAttachedRigidbody); // acceleration towards the anchor of the rope, due to gravity acting on the rope.
            Vector3 tangentialVelocity = _attachedRigidBody.velocity - directionToAttachedRigidbody * Vector3.Dot(_attachedRigidBody.velocity, -directionToAttachedRigidbody);
            float centripetalAcceleration = tangentialVelocity.magnitude * tangentialVelocity.magnitude / offsetToAttachedRigidbody.magnitude;
            
            // Apply an acceleration from the attached rigidbody to the anchor, with magnitude equal to inward acceleration-outward acceleration.
            Vector3 accelerationToApply = -directionToAttachedRigidbody * (centripetalAcceleration - inwardAcceleration);

            _attachedRigidBody.AddForce(accelerationToApply, ForceMode.Acceleration);
            
            
            // Prevent the object from escaping the rope.
            Vector3 newPosition = transform.position + directionToAttachedRigidbody * _ropeLength;
            _attachedRigidBody.MovePosition(newPosition);

            // Prevent the object from rotating, if required.
            if (_blockXRotation || _blockYRotation || _blockZRotation)
            {
                BlockRotation();
            }
            

        }

    }


    private void BlockRotation()
    {
        Vector3 newRotationEuler = _attachedRigidBody.rotation.eulerAngles;
        if (_blockXRotation)
        {
            newRotationEuler.x = transform.rotation.x;
        }
        if (_blockYRotation)
        {
            newRotationEuler.y = transform.rotation.y;
        }
        if (_blockZRotation)
        {
            newRotationEuler.z = transform.rotation.z;
        }
        _attachedRigidBody.MoveRotation(Quaternion.Euler(newRotationEuler));
            
    }

}
