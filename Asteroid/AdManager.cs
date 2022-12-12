using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private bool testMode = true;
    public static AdManager Instance;
    private string gameId = "5067605";
    private GameOverHandler gameOverHandler;


    void Awake(){
        if (Instance != null && Instance != this){
            Destroy(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject);


            Advertisement.Initialize(gameId, testMode, this);
        }
    }

    public void ShowAd(GameOverHandler gameOverHandler){
        this.gameOverHandler = gameOverHandler;

        Advertisement.Show("rewardedVideo", this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialize complete");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads initialize failed: {error} - {message}");
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log($"Unity Ads loaded {placementId}");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Unity Ads failed to load {placementId} {error} {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
    }

    public void OnUnityAdsShowClick(string placementId)
    {
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        switch(showCompletionState){
            case UnityAdsShowCompletionState.COMPLETED:
                gameOverHandler.ContinueGame();
                break;
            case UnityAdsShowCompletionState.SKIPPED:
            Debug.Log("Skipped");
                break;
            case UnityAdsShowCompletionState.UNKNOWN:
            Debug.Log("Warning, ad failed");
                break;
        }
    }
}

