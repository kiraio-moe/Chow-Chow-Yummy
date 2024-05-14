using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;
using Aili.Utils;

namespace Aili.Ads
{
    [AddComponentMenu("Aili/Ads/Interstitial Ads")]
    public class InterstitialAds : MonoBehaviour
    {
        [SerializeField]
        string m_AdUnitID = "ca-app-pub-3940256099942544/6300978111";

        InterstitialAd interstitialAd;

        void Start()
        {
            LoadInterstitialAd();
        }

        public void LoadInterstitialAd()
        {
            Debug.Log("Loading the interstitial ad...");

            // Clean up the old ad before loading a new one.
            if (interstitialAd != null)
            {
                interstitialAd.Destroy();
                interstitialAd = null;
            }

            // create our request used to load the ad.
            AdRequest adRequest = new AdRequest();

            // send the request to load the ad.
            InterstitialAd.Load(m_AdUnitID, adRequest,
                (InterstitialAd ad, LoadAdError error) =>
                {
                    // if error is not null, the load request failed.
                    if (error != null || ad == null)
                    {
                        Debug.LogError($"Interstitial ad failed to load an ad with error: {error}");
                        return;
                    }

                    Debug.Log($"Interstitial ad loaded with response: {ad.GetResponseInfo()}");

                    interstitialAd = ad;
                    RegisterEventHandlers(interstitialAd);
                });
        }

        public void ShowAd()
        {
            if (interstitialAd != null && interstitialAd.CanShowAd())
            {
                Debug.Log("Showing interstitial ad.");
                interstitialAd.Show();
            }
            else
                Debug.LogError("Interstitial ad is not ready yet.");
        }


        private void RegisterEventHandlers(InterstitialAd ad)
        {
            // Raised when the ad is estimated to have earned money.
            ad.OnAdPaid += (AdValue adValue) =>
            {
                Debug.Log(String.Format("Interstitial ad paid {0} {1}.",
                    adValue.Value,
                    adValue.CurrencyCode));
            };
            // Raised when an impression is recorded for an ad.
            ad.OnAdImpressionRecorded += () =>
            {
                Debug.Log("Interstitial ad recorded an impression.");
            };
            // Raised when a click is recorded for an ad.
            ad.OnAdClicked += () =>
            {
                Debug.Log("Interstitial ad was clicked.");
            };
            // Raised when an ad opened full screen content.
            ad.OnAdFullScreenContentOpened += () =>
            {
                Debug.Log("Interstitial ad full screen content opened.");
            };
            // Raised when the ad closed full screen content.
            ad.OnAdFullScreenContentClosed += () =>
            {
                Debug.Log("Interstitial ad full screen content closed.");
                LoadInterstitialAd();
            };
            // Raised when the ad failed to open full screen content.
            ad.OnAdFullScreenContentFailed += (AdError error) =>
            {
                Debug.LogError($"Interstitial ad failed to open full screen content with error: {error}");
                LoadInterstitialAd();
            };
        }
    }
}
