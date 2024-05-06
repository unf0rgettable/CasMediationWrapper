using CAS;
using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads.AdUnits;

namespace CasWrapper
{
    public class CASRewardedAd : AdUnitLogic
    {
        private readonly IMediationManager _mediationManager;

        public CASRewardedAd(IAdUnitKey key, IAdUnitEvents events,
            ICoroutineRunner coroutineRunner, IMediationManager mediationManager) : base(key, events, coroutineRunner)
        {
            _mediationManager = mediationManager;
        }

        protected override bool IsAdReady() => _mediationManager.IsReadyAd(AdType.Rewarded);

        protected override void ShowAd() => _mediationManager.ShowAd(AdType.Rewarded);

        public override void Load()
        {
            //_mediationManager.LoadAd(AdType.Rewarded);
        }
    }
}