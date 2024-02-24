using System;
using CAS;
using LittleBitGames.Ads.AdUnits;

namespace CasWrapper
{
    public class AdInfo : IAdInfo
    {
        public string AdUnitIdentifier { get; }
        public string AdFormat { get; }
        public string NetworkName { get; }
        public string NetworkPlacement { get; }
        public string Placement { get; }
        public string CreativeIdentifier { get; }
        public double Revenue { get; }
        public string RevenuePrecision { get; }
        public string DspName { get; }

        public AdInfo(AdMetaData adMetaData)
        {
            AdUnitIdentifier = adMetaData.identifier;
            
            switch (adMetaData.type)
            {
                case AdType.Banner:
                    AdFormat = "banner";
                    break;
                case AdType.Interstitial:
                    AdFormat = "interstitial";
                    break;
                case AdType.Rewarded:
                    AdFormat = "rewarded";
                    break;
                case AdType.Native:
                    AdFormat = "native";
                    break;
                case AdType.None:
                    AdFormat = "none";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            NetworkName = adMetaData.network.ToString();
            NetworkPlacement = "Undefined";
            Placement = "Undefined";
            CreativeIdentifier = adMetaData.creativeIdentifier;
            Revenue = adMetaData.revenue;
            RevenuePrecision = "Undefined";
            DspName = "Undefined";
        }
    }
}