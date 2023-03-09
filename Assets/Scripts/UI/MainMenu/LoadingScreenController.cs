using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenController : MainMenuScreen
{
    [SerializeField]
    private int _sceneIndexToLoad = 1;

    [SerializeField]
    private float _minimumLoadingTime = 2f; // this is to show that there is a loading screen, this would (probably) not exist in an actual game.

    [SerializeField]
    private Image _loadingBar;

    public override void SetActive(bool active)
    {
        base.SetActive(active);
        if (active)
        {
            StartCoroutine(LoadGame());
        }
    }

    private IEnumerator LoadGame()
    {
        float startTime = Time.time;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_sceneIndexToLoad, LoadSceneMode.Single);
        asyncLoad.allowSceneActivation = false;
        do
        {
            _loadingBar.fillAmount = asyncLoad.progress;
            yield return null;
        }
        while (asyncLoad.progress < 0.9f);

        float endTime = startTime + _minimumLoadingTime;
        float loadFinishTime = Time.time;
        float timeLeftToWait = endTime - Time.time; 
        while (Time.time < endTime)
        {

            // a sneaky way to load the last 10% of the loading bar  
            float timeSinceSceneLoaded = Time.time - loadFinishTime;
            _loadingBar.fillAmount = 0.9f + (timeSinceSceneLoaded / timeLeftToWait) * 0.1f; 
            yield return null;
        }
        
        asyncLoad.allowSceneActivation = true; // this immediately activates the scene, and immediately disables and unloads the current one.

    
    }




}
