using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _attachedRigidBody;

    [SerializeField]
    private float _ropeLength = 5f;

    [SerializeField]
    private float _ropeChangeRate = 1f;

    private float _ropeMovement = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMove(float ropeMovement)
    {
        _ropeMovement = ropeMovement;
    }

    private void OnDrawGizmos()
    {
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
        _ropeLength += _ropeMovement * _ropeChangeRate * Time.fixedDeltaTime;
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
            // by adding a force in the opposite direction of the offset.
            float forceMultiplier = Vector3.Dot(Physics.gravity, -directionToAttachedRigidbody);
           
            Vector3 velPerpendicularToRope = _attachedRigidBody.velocity - Vector3.Dot(_attachedRigidBody.velocity, -directionToAttachedRigidbody) * directionToAttachedRigidbody;
            //Vector3 velPerpendicularToRope = Vector3.Dot(_attachedRigidBody.velocity, -directionToAttachedRigidbody);
            
            //Vector3 centripetalAcceleration = Vector3.Scale(velPerpendicularToRope, velPerpendicularToRope / _ropeLength);
            float centripetalAcceleration = velPerpendicularToRope.magnitude * velPerpendicularToRope.magnitude / offsetToAttachedRigidbody.magnitude;
            _attachedRigidBody.AddForce(_attachedRigidBody.mass * directionToAttachedRigidbody * (forceMultiplier - centripetalAcceleration), ForceMode.Force);
            Vector3 newPosition = transform.position + directionToAttachedRigidbody * _ropeLength;
            _attachedRigidBody.transform.position = newPosition;
        }
        

        
        


    }


}
