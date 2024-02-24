using System;
using System.Collections.Generic;
using LittleBitGames.Ads;
using LittleBitGames.Ads.AdUnits;
using LittleBitGames.Ads.Collections.Extensions;
using LittleBitGames.Environment.Ads;
using LittleBitGames.Environment.Events;
using UnityEngine.Scripting;
using Wrapper;

namespace CasWrapper
{
    public class CasSdkAnalytics : IMediationNetworkAnalytics
    {
        private const string SdkSourceName = "cas_sdk";
        private const string Currency = "USD";

        private readonly IReadOnlyList<IAdUnit> _adUnits;

        public event Action<IDataEventAdImpression, AdType> OnAdRevenuePaidEvent;

        [Preserve]
        public CasSdkAnalytics(IAdsService adsService)
        {
            _adUnits = adsService.AdUnits;

            if (adsService.Initializer.IsInitialized)
            {
                Subscribe();
            }
            else
            {
                adsService.Initializer.OnMediationInitialized += Subscribe;
            }
        }

        private void Subscribe()
        {
            //Debug.LogError(_adUnits.Count);
            foreach (var adUnit in _adUnits)
            {
                if (adUnit is CASInterAd)
                {
                    //Debug.LogError("IsInterAds");
                    adUnit.Events.OnAdRevenuePaid += delegate(string s, IAdInfo info)
                    {
                        OnAdRevenuePaid(s, info, AdType.Inter);
                    };
                }
                
                if (adUnit is CASRewardedAd)
                {
                    //Debug.LogError("IsRewardAds");
                    adUnit.Events.OnAdRevenuePaid += delegate(string s, IAdInfo info)
                    {
                        OnAdRevenuePaid(s, info, AdType.Rewarded);
                    };
                }
                //Debug.LogError(adUnit.GetType());
            }
        }

        private void OnAdRevenuePaid(string adUnitId, IAdInfo adInfo, AdType adType)
        {

            var adImpressionEvent = new DataEventAdImpression(
                new SdkSource(SdkSourceName),
                adInfo.NetworkName,
                adInfo.AdFormat,
                adInfo.AdUnitIdentifier,
                Currency,
                adInfo.Revenue);

            //Debug.LogError("OnAdRevenuePaidEVENT");
            OnAdRevenuePaidEvent?.Invoke(adImpressionEvent, adType);
        }
    }
}