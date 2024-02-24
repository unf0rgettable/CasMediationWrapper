using System;
using CAS;
using LittleBitGames.Ads.AdUnits;

namespace CasWrapper
{
    public class CasSdkInterEvents : IAdUnitEvents
    {
        public event Action<string, IAdInfo> OnAdRevenuePaid;
        public event Action<string, IAdInfo> OnAdLoaded;
        public event Action<string, IAdErrorInfo> OnAdLoadFailed;
        public event Action<string, IAdInfo> OnAdFinished;
        public event Action<string, IAdInfo> OnAdClicked;
        public event Action<string, IAdInfo> OnAdHidden;
        public event Action<string, IAdErrorInfo, IAdInfo> OnAdDisplayFailed;

        public CasSdkInterEvents(IMediationManager mediationManager)
        {
            mediationManager.OnInterstitialAdClicked += () => OnAdClicked?.Invoke(null, null);
            mediationManager.OnInterstitialAdLoaded += () => OnAdLoaded?.Invoke(null, null);
            mediationManager.OnInterstitialAdFailedToLoad += error =>
            {
                OnAdLoadFailed?.Invoke(null, error != null ? new AdErrorInfo(error) : null);
            };
            mediationManager.OnInterstitialAdImpression += meta => { OnAdRevenuePaid?.Invoke(null, new AdInfo(meta));};
            mediationManager.OnInterstitialAdShown += () => OnAdFinished?.Invoke(null, null);
            mediationManager.OnInterstitialAdClosed += () => OnAdHidden?.Invoke(null, null);
            mediationManager.OnInterstitialAdFailedToShow += error =>
            {
                OnAdDisplayFailed?.Invoke(error, null, null);
            };
        }
    }
}