using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the camera to look at the tip of the crane.
/// Might be replaced by Cinemachine.
/// </summary>
public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private bool _followTarget = true;

    [SerializeField]
    private GameObject _camera;
    private void Update()
    {
        if (_followTarget && _target != null)
        {
            transform.LookAt(_target);
        }
    }

    public void SetActive(bool active)
    {
        _camera.SetActive(active);
    }

}
