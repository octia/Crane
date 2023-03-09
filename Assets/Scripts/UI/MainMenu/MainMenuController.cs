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

    public void RegisterScreen(MainMenuScreen screen)
    {
        Debug.Log("Registering screen: " + screen.GetType());
        _screens.Add(screen.GetType(), screen);
    }

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
