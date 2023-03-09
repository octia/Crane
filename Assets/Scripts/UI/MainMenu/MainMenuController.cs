using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
#region Singleton
    public static MainMenuController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("How did this happen?");
            Destroy(gameObject);
        }
    }
#endregion    


    private Dictionary<System.Type, MainMenuScreen> _screens = new Dictionary<System.Type, MainMenuScreen>();

    /// <summary>
    /// In order to be accessible, every UI screen has to be registered here. Should be called only once per inheriting class.
    /// </summary>
    /// <param name="screen">Screen to register.</param>
    public void RegisterScreen(MainMenuScreen screen)
    {
        _screens.Add(screen.GetType(), screen);
    }

    /// <summary>
    /// Activates a screen and return it. Optionally disables the calling screen.
    /// </summary>
    /// <param name="caller">The calling screen - used to disable it</param>
    /// <param name="disableCaller">Should the caller be disabled?</param>
    /// <typeparam name="T">The type of the screen to be activated.</typeparam>
    /// <returns>The activated screen.</returns>
    public T ActivateScreen<T>(MainMenuScreen caller, bool disableCaller = true) where T : MainMenuScreen
    {
        if (_screens.TryGetValue(typeof(T), out MainMenuScreen screen))
        {
            screen.SetActive(true);
            if (disableCaller && caller != null)
            {
                caller.SetActive(false);
            }
            return (T)screen;
        }
        else
        {
            Debug.LogError($"Screen {typeof(T)} not found");
            return null;
        }
    }


}
