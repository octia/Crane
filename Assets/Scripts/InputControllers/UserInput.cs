using UnityEngine;


/// <summary>
/// This class is somewhat redundant. It was meant to be used in case of substituting user input with automatic input during the tutorial.
/// Currently, it only serves as a consolidation of input-grabbing functions in one place.
/// Could be used to easily add support for automatic input (like during a tutorial) or for one-pc multiplayer. 
/// </summary>
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

    public bool GetCameraSwitch()
    {
        return Input.GetKeyDown(KeyCode.Tab);
    }
}