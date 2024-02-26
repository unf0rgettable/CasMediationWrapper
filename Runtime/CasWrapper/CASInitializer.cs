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
            _mediationManager = MobileAds.BuildManager().WithManagerIdAtIndex(0)
                .WithInitListener(InitCompleteAction).Initialize();
        }

        private void InitCompleteAction(bool success, string error)
        {
            Debug.LogWarning("cas init!");
            IsInitialized = true;
            OnMediationInitialized?.Invoke();
        }
    }
}