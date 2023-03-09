using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlls all aspects of the crane. Takes input from the input class, and passes it to the other controllers.
/// </summary>
public class CraneController : MonoBehaviour
{

    [SerializeField]
    private CartController _cart;
    
    [SerializeField]
    private ArmController _arm;
    
    [SerializeField]
    private RopeController _rope;

    [SerializeField]
    private UserInput _input;


    private void Update()
    {
        if (_input != null)
        {
            // Update the movement values of all crane parts.
            _arm.SetMove(_input.GetArmMovement());
            _cart.SetMove(_input.GetCartMovement());
            _rope.ChangeLength(_input.GetRopeMovement());
        }
    }



}
