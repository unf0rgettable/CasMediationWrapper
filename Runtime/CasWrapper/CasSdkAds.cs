using LittleBitGames.Ads;
using LittleBitGames.Ads.Configs;
using LittleBitGames.Environment.Ads;
using UnityEngine.Scripting;
using Wrapper;

namespace CasWrapper
{
    public class CasSdkAds
    {
        private readonly CASServiceBuilder _builder;
        private readonly AdsConfig _adsConfig;
        private readonly ICreator _creator;
        private IAdsService _adsService;

        
        [Preserve]
        public CasSdkAds(ICreator creator)
        {
            _creator = creator;
            _builder = creator.Instantiate<CASServiceBuilder>();
            
        }
        
        public IAdsService CreateAdsService()
        {
            var adsService = _builder.QuickBuild();

            _adsService = adsService;
            _adsService.Run();

            return _adsService;
        }

        public IMediationNetworkAnalytics CreateAnalytics() => _creator.Instantiate<CasSdkAnalytics>(_adsService);
    }
}