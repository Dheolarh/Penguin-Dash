using UnityEngine;
using UnityEngine.Advertisements;

public class Admanager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static Admanager Instance { get { return instance; } }
    private static Admanager instance;

    [SerializeField] private string gameID;
    [SerializeField] public string rewardedAdID;
    [SerializeField] private bool testMode;
    private GameResetState gameResetState;

    private void Awake()
    {
        instance = this;
        Advertisement.Initialize(gameID, testMode, this);
        gameResetState = FindObjectOfType<GameResetState>();
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.isInitialized && Advertisement.isSupported)
        {
            Debug.Log("Loading Rewarded Ad...");
            Advertisement.Load(rewardedAdID, this);
        }
        else
        {
            Debug.LogError("Unity Ads not initialized or supported.");
        }
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.LogError($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        if (placementId == rewardedAdID)
        {
            Debug.Log("Ad Loaded: " + placementId);
            gameResetState.StopCountdown();
            Debug.Log("Stopped Countdown");
            Advertisement.Show(placementId, this);
        }
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.LogError($"Unity Ads failed to load ad for placement {placementId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.LogError($"Unity Ads failed to show ad for placement {placementId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Unity Ads ad started for placement: " + placementId);
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("Unity Ads ad clicked for placement: " + placementId);
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("Unity Ads ad show complete for placement: " + placementId + " with result: " + showCompletionState);
        gameResetState.OnUnityAdsShowComplete(placementId, showCompletionState);
    }
}