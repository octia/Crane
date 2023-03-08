using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public float GetArmMovement()
    {
        return Input.GetAxis("Horizontal");
    }

    public float GetCartMovement()
    {
        return Input.GetAxis("Vertical");
    }

    public float GetRopeMovement()
    {
        return Input.GetAxis("Height");
    }
}