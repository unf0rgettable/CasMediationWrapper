using LittleBit.Modules.CoreModule;
using LittleBitGames.Ads;
using LittleBitGames.Ads.AdUnits;
using LittleBitGames.Environment.Ads;

namespace Wrapper
{
    public class CASServiceBuilder : IAdsServiceBuilder
    {
        private readonly CASInitializer _initializer;
        
        private IAdUnit _inter, _rewarded;
        private CasSdkAdUnitsFactory _adUnitsFactory;

        public IMediationNetworkInitializer Initializer => _initializer;
        
        public CASServiceBuilder(ICoroutineRunner coroutineRunner)
        {
            _initializer = new CASInitializer();

            if (_initializer.IsInitialized)
            {
                _adUnitsFactory = new CasSdkAdUnitsFactory(coroutineRunner, _initializer.MediationManager);
            }
            else
            {
                _initializer.OnMediationInitialized += () =>
                {
                    _adUnitsFactory = new CasSdkAdUnitsFactory(coroutineRunner, _initializer.MediationManager);
                };
            }
        }
        
        public void BuildInterAdUnit()
        {
            _adUnitsFactory.CreateInterAdUnit();
        }

        public void BuildRewardedAdUnit()
        {
            _adUnitsFactory.CreateRewardedAdUnit();
        }

        //заглушил баннер!!!
        public IAdsService GetResult() => new AdsService(_initializer, _inter, _rewarded, null);
    }
}