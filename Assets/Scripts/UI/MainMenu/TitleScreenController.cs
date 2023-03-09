using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenController : MainMenuScreen
{
    
    public void Play()
    {
        MainMenuController.Instance.ActivateScreen<LoadingScreenController>(this);
    }

    public void Controls()
    {
        MainMenuController.Instance.ActivateScreen<ControlsScreenController>(this);
    }

    public void Quit()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

}
