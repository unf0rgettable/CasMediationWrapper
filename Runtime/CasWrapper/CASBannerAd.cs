using CAS;
using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads.AdUnits;

namespace CasWrapper
{
    public class CASBannerAd: AdUnitLogic
    {
        private readonly IMediationManager _mediationManager;

        public CASBannerAd(IAdUnitKey key, IAdUnitEvents events,
            ICoroutineRunner coroutineRunner, IMediationManager mediationManager) : base(key, events, coroutineRunner)
        {
            _mediationManager = mediationManager;
        }

        protected override bool IsAdReady() => _mediationManager.GetAdView(AdSize.Banner).isReady;

        protected override void ShowAd() => _mediationManager.GetAdView(AdSize.Banner).SetActive(true);

        public override void Load() => _mediationManager.GetAdView(AdSize.Banner).Load();
    }
}