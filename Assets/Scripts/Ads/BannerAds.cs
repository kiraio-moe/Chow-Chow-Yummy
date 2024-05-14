using UnityEngine;
using GoogleMobileAds.Api;

namespace Aili.Ads
{
    [AddComponentMenu("Aili/Ads/Banner Ads")]
    public class BannerAds : MonoBehaviour
    {
        [Header("Ad Settings")]
        [SerializeField]
        string m_AdUnitID = "ca-app-pub-3940256099942544/6300978111";

        [SerializeField]
        AdSize m_AdSize = AdSize.Banner;

        [SerializeField]
        AdPosition m_AdPosition = AdPosition.Bottom;

        void Start()
        {
            CreateBannerAds(m_AdUnitID, m_AdSize, m_AdPosition);
        }

        BannerView CreateBannerAds(string adUnitId, AdSize adSize, AdPosition adPosition)    
        {
            // this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
            BannerView bannerView = new BannerView(adUnitId, adSize, adPosition);

            // Create an empty ad request.
            AdRequest request = new AdRequest();

            // Load the banner with the request.
            bannerView.LoadAd(request);

            return bannerView;
        }
    }
}
