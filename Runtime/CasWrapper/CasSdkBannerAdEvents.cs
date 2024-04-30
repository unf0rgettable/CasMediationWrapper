using System;
using CAS;
using LittleBitGames.Ads.AdUnits;

namespace CasWrapper
{
    public class CasSdkBannerAdEvents : IAdUnitEvents
    {
        public event Action<string, IAdInfo> OnAdRevenuePaid;
        public event Action<string, IAdInfo> OnAdLoaded;
        public event Action<string, IAdErrorInfo> OnAdLoadFailed;
        public event Action<string, IAdInfo> OnAdFinished;
        public event Action<string, IAdInfo> OnAdClicked;
        public event Action<string, IAdInfo> OnAdHidden;
        public event Action<string, IAdErrorInfo, IAdInfo> OnAdDisplayFailed;

        public CasSdkBannerAdEvents(IMediationManager mediationManager)
        {
            mediationManager.GetAdView(AdSize.Banner).OnClicked += OnOnClicked;
            mediationManager.GetAdView(AdSize.Banner).OnLoaded += OnOnLoaded;
            mediationManager.GetAdView(AdSize.Banner).OnImpression += OnOnImpression;
            mediationManager.GetAdView(AdSize.Banner).OnFailed += OnOnFailed;
        }

        private void OnOnFailed(IAdView view, AdError error)
        {
            OnAdLoadFailed?.Invoke(null, error != null ? new AdErrorInfo(error) : null);
        }

        private void OnOnImpression(IAdView view, AdMetaData data)
        {
            OnAdRevenuePaid?.Invoke(null, new AdInfo(data));
            OnAdFinished?.Invoke(null, new AdInfo(data));
        }

        private void OnOnLoaded(IAdView view)
        {
            OnAdLoaded?.Invoke(null, null);
        }

        private void OnOnClicked(IAdView view)
        {
            OnAdClicked?.Invoke(null, null);
        }
    }
}