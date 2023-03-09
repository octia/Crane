using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class MainMenuScreen : MonoBehaviour
{
    [SerializeField]
    protected Canvas _canvas;
    
    /// <summary>
    /// If overriden, please call this base implementation first.
    /// </summary>
    protected virtual void Start()
    {
        _canvas = GetComponent<Canvas>();
        
        // Register has to be called in the Start method, because the MainMenuController is initialized in Awake.
        Register();
    }

    private void Register()
    {
        MainMenuController.Instance.RegisterScreen(this);
    }


    public virtual void SetActive(bool active)
    {
        _canvas.enabled = active;
    }


    #if UNITY_EDITOR


    /// <summary>
    /// A quick helper function to switch to this screen in the editor.
    /// </summary>
    [ContextMenu("Switch to this screen")]
    [ExecuteAlways]
    public void SwitchToThisScreen()
    {
        MainMenuScreen[] screens = transform.parent.GetComponentsInChildren<MainMenuScreen>();
        foreach (MainMenuScreen screen in screens)
        {
            screen._canvas.enabled = false; // ignore any SetActive overrides by manually disabling the canvas
        }
        _canvas.enabled = true;
    }
    #endif

}
