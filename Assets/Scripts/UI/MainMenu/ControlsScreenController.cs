using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsScreenController : MainMenuScreen
{
    public void Back()
    {
        MainMenuController.Instance.ActivateScreen<TitleScreenController>(this);
    }
}
