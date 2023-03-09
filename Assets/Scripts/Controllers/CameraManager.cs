using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private UserInput _userInput;

    [SerializeField]
    private List<CameraController> _cameras;

    private int _currentCameraIndex = 0;

    private void Update()
    {
        if (_userInput != null)
        {
            if (_userInput.GetCameraSwitch())
            {
                _cameras[_currentCameraIndex].SetActive(false);
                _currentCameraIndex = (_currentCameraIndex + 1) % _cameras.Count;
                _cameras[_currentCameraIndex].SetActive(true);
            }
        }
    }

}
