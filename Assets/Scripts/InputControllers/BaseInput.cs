using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInput : MonoBehaviour
{
    public abstract float GetArmMovement();
    public abstract float GetCartMovement();
    public abstract float GetRopeMovement();
}
