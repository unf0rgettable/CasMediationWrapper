using CAS;
using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads.AdUnits;

namespace Wrapper
{
    public class CASInterAd: AdUnitLogic
    {
        private readonly IMediationManager _mediationManager;

        public CASInterAd(IAdUnitKey key, IAdUnitEvents events,
            ICoroutineRunner coroutineRunner, IMediationManager mediationManager) : base(key, events, coroutineRunner)
        {
            _mediationManager = mediationManager;
        }

        protected override bool IsAdReady() => _mediationManager.IsReadyAd(AdType.Interstitial);

        protected override void ShowAd() => _mediationManager.ShowAd(AdType.Interstitial);

        public override void Load()
        {
            //_mediationManager.LoadAd(AdType.Interstitial);
        }
    }
}