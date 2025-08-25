using System;
using CAS;
using LittleBitGames.Environment.Ads;
using UnityEngine;

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
            _mediationManager = MobileAds.BuildManager().WithManagerIdAtIndex(0).WithCompletionListener((config) => {
                string initErrorOrNull = config.error;
                if (!string.IsNullOrEmpty(initErrorOrNull))
                {
                    Debug.LogError("CAS init ERROR: " + initErrorOrNull);
                }
                else
                {
                    string userCountryISO2OrNull = config.countryCode;
                    IMediationManager manager = config.manager;
                
                    Debug.LogWarning("CAS country code: " + userCountryISO2OrNull);
                
                    bool protectionApplied = config.isConsentRequired;
                
                    Debug.LogWarning("cas init!");
                    IsInitialized = true;
                    OnMediationInitialized?.Invoke();
                
                    ConsentFlow.Status consentFlowStatus = config.consentFlowStatus;
                }

            }).Initialize();
        }
    }
}