using System;
using CAS;
using LittleBitGames.Environment.Ads;

namespace Wrapper
{
    public class CASInitializer : IMediationNetworkInitializer
    {
        public event Action OnMediationInitialized;
        private IMediationManager _mediationManager;
        public IMediationManager MediationManager => _mediationManager;
        public bool IsInitialized { get; private set; }
        public void Initialize()
        {
            _mediationManager = MobileAds.BuildManager()
                // Optional initialize listener
                .WithCompletionListener((config) => {
                    string initErrorOrNull = config.error;
                    string userCountryISO2OrNull = config.countryCode;
                    bool protectionApplied = config.isConsentRequired;
                    IMediationManager manager = config.manager;
                    IsInitialized = true;
                    OnMediationInitialized?.Invoke();
                })
                .Build();
        }
    }
}