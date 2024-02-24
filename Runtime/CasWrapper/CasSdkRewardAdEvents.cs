using System;
using CAS;
using LittleBitGames.Ads.AdUnits;

namespace CasWrapper
{
    public class CasSdkRewardAdEvents : IAdUnitEvents
    {
        public event Action<string, IAdInfo> OnAdRevenuePaid;
        public event Action<string, IAdInfo> OnAdLoaded;
        public event Action<string, IAdErrorInfo> OnAdLoadFailed;
        public event Action<string, IAdInfo> OnAdFinished;
        public event Action<string, IAdInfo> OnAdClicked;
        public event Action<string, IAdInfo> OnAdHidden;
        public event Action<string, IAdErrorInfo, IAdInfo> OnAdDisplayFailed;

        public CasSdkRewardAdEvents(IMediationManager mediationManager)
        {
            mediationManager.OnRewardedAdClicked += () => OnAdClicked?.Invoke(null, null);
            mediationManager.OnRewardedAdLoaded += () => OnAdLoaded?.Invoke(null, null);
            mediationManager.OnRewardedAdFailedToLoad += error =>
            {
                OnAdLoadFailed?.Invoke(null, error != null ? new AdErrorInfo(error) : null);
            };
            mediationManager.OnRewardedAdImpression += meta => { OnAdRevenuePaid?.Invoke(null, new AdInfo(meta));};
            mediationManager.OnRewardedAdShown += () => OnAdFinished?.Invoke(null, null);
            mediationManager.OnRewardedAdClicked += () => OnAdHidden?.Invoke(null, null);
            mediationManager.OnRewardedAdFailedToShow += error =>
            {
                OnAdDisplayFailed?.Invoke(error, null, null);
            };
        }
    }
}