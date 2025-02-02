using UnityEngine;
using UnityEngine.Advertisements;
public class Admanager : MonoBehaviour
{
   public static Admanager Instance { get; private set; }
   private static Admanager instance;

   [SerializeField] private string gameID;
   [SerializeField] private string interstitialAdID;
   [SerializeField] private bool testMode;

   private void Awake()
   {
      instance = this;
      Advertisement.Initialize(gameID, true);
   }
   
   public void ShowRewardedAd()
   {
      ShowOptions options = new ShowOptions();
      Advertisement.Show(interstitialAdID, options);
   }
}
