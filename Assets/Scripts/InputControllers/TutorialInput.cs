using System.ComponentModel.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInput : BaseInput
{
    public override float GetArmMovement()
    {
        return Input.GetAxis("Horizontal");
    }

    public override float GetCartMovement()
    {
        return Input.GetAxis("Vertical");
    }

    public override float GetRopeMovement()
    {
        return Input.GetAxis("Height");
    }
}