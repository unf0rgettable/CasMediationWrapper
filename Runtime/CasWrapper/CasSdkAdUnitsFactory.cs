using CAS;
using CasWrapper;
using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads.AdUnits;
using Wrapper;

namespace LittleBitGames.Ads
{
    internal class CasSdkAdUnitsFactory
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IMediationManager _mediationManager;

        public CasSdkAdUnitsFactory(ICoroutineRunner coroutineRunner, IMediationManager mediationManager)
        {
            _mediationManager = mediationManager;

            _coroutineRunner = coroutineRunner;
        }

        public IAdUnit CreateInterAdUnit() =>
            new CASInterAd(null, new CasSdkInterEvents(_mediationManager), _coroutineRunner, _mediationManager);

        public IAdUnit CreateRewardedAdUnit() =>
            new CASRewardedAd(null, new CasSdkRewardAdEvents(_mediationManager), _coroutineRunner, _mediationManager);
        
        public IAdUnit CreateBannerAdUnit() =>
            new CASBannerAd(null, new CasSdkBannerAdEvents(_mediationManager), _coroutineRunner, _mediationManager);
    }
}