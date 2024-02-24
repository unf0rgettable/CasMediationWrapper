using CAS;
using LittleBitGames.Ads.AdUnits;
using UnityEngine;

namespace CasWrapper
{
    public class AdErrorInfo : IAdErrorInfo
    {
        public string Message { get; }
        public int MediatedNetworkErrorCode { get; }
        public string MediatedNetworkErrorMessage { get; }

        public AdErrorInfo(AdError adError)
        {
            MediatedNetworkErrorCode = (int)adError;
            MediatedNetworkErrorMessage = adError.GetMessage();
            Debug.LogError(MediatedNetworkErrorMessage);
        }
    }
}