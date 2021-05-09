using System;
using UnityEngine;
using GoogleMobileAds.Api;

namespace Admob
{
    public class AdManager : MonoBehaviour
    {
        private RewardedAd _rewardedAd;
        private InterstitialAd _interstitial;
        private BannerView _bannerView;

        [Header("Rewarded")]
        [SerializeField] private string _androidRewardedAdUnitId;
        [SerializeField] private string _iphoneRewardedAdUnitId;
        [Header("Interstilitial")]
        [SerializeField] private string _androidInterstilitialAdUnitId;
        [SerializeField] private string _iphoneInterstilitialAdUnitId;
        [Header("Banner")]
        [SerializeField] private string _androidBannerAdUnitId;
        [SerializeField] private string _iphoneBannerAdUnitId;

        void Start()
        {
            /**
             * Google Mobile Ads SDK's�n� ba�lat�n.
             * Initialize the Google Mobile Ads SDK.
             */
            MobileAds.Initialize(initStatus => { });

            RequestRewarded();
            RequestInterstitial();
            RequestBanner();
        }

        #region RewardedAd
        private void RequestRewarded()
        {
#if UNITY_ANDROID
            string adUnitId = _androidRewardedAdUnitId;
#elif UNITY_IPHONE
        string adUnitId = _iphoneRewardedAdUnitId;
#else
        string adUnitId = "unexpected_platform";
#endif
            /**
             * Bir �d�ll� Reklam� Ba�latma(Olu�turdu�umuz _rewardedAd de�i�kenine bir reklam kimli�i atamak.)
             * Initialize an RewardedAd.(Assigning an advertisement ID to the _rewardedAd variable that we created.)
             */
            this._rewardedAd = new RewardedAd(adUnitId);

            /**
             * Reklam kapat�ld���nda �a�r�l�r.
             * Called when the ad is closed.
             */
            this._rewardedAd.OnAdClosed += RewardedOnAdClosed;

            /**
             * Bo� bir reklam iste�i olu�turun.
             * Create an empty ad request.
             */
            AdRequest request = new AdRequest.Builder().Build();

            /**
             * �d��l� reklam� istekle birlikte y�kleyin.
             * Load the rewarded ad with the request.
             */
            this._rewardedAd.LoadAd(request);
        }

        /**
         * Bu method, reklam� g�stermek istedi�imizde �a�r�l�r.
         * This method is called when we want to show the ad.
         */
        public void ShowRewarded()
        {
            /**
             * If the ad is loaded
             * Reklam y�klenmi� ise
             */
            if (this._rewardedAd.IsLoaded())
            {
                /** 
                 * Show ad
                 * Reklam� g�ster
                 */
                this._rewardedAd.Show();
            }
        }

        /**
         * Bu method, �d�ll� reklam kapat�ld���nda etkindir.
         * This method is active when the rewarded ad is closed.
         */
        public void RewardedOnAdClosed(object sender, EventArgs args)
        {
            RequestRewarded();
        }
        #endregion

        #region Interstilitial
        private void RequestInterstitial()
        {
#if UNITY_ANDROID
            string adUnitId = _androidInterstilitialAdUnitId;
#elif UNITY_IPHONE
        string adUnitId = _iphoneInterstilitialAdUnitId;
#else
        string adUnitId = "unexpected_platform";
#endif
            /**
             * Bir Ge�i� Reklam� Ba�latma(Olu�turdu�umuz _interstitial de�i�kenine bir reklam kimli�i atamak.)
             * Initialize an InterstitialAd.(Assigning an advertisement ID to the _interstitial variable that we created.)
             */
            this._interstitial = new InterstitialAd(adUnitId);

            /**
             * Reklam kapat�ld���nda �a�r�l�r.
             * Called when the ad is closed.
             */
            this._interstitial.OnAdClosed += InterstilitialOnAdClosed;

            /**
             * Bo� bir reklam iste�i olu�turun.
             * Create an empty ad request.
             */
            AdRequest request = new AdRequest.Builder().Build();

            /**
             * Ge�i� reklam�n� istekle birlikte y�kleyin.
             * Load the interstitial with the request.
             */
            this._interstitial.LoadAd(request);
        }

        /**
         * Bu method, reklam� g�stermek istedi�imizde �a�r�l�r.
         * This method is called when we want to show the ad.
         */
        public void ShowInterstitial()
        {
            /**
             * If the ad is loaded
             * Reklam y�klenmi� ise
             */
            if (this._interstitial.IsLoaded())
            {
                /** 
                 * Show ad
                 * Reklam� g�ster
                 */
                this._interstitial.Show();
            }
        }

        /**
         * Bu method, ge�i� reklam� kapat�ld���nda etkindir.
         * This method is active when the interstitial ad is closed.
         */
        public void InterstilitialOnAdClosed(object sender, EventArgs args)
        {
            RequestInterstitial();
        }
        #endregion

        #region Banner
        private void RequestBanner()
        {
#if UNITY_ANDROID
            string adUnitId = _androidBannerAdUnitId;
#elif UNITY_IPHONE
            string adUnitId = _iphoneBannerAdUnitId;
#else
            string adUnitId = "unexpected_platform";
#endif

            /**
             * Ekran�n alt�nda 320x50 boyutunda bir banner olu�turun.
             * Create a 320x50 banner at the bottom of the screen.
             */
            this._bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

            /**
             * Bo� bir reklam iste�i olu�turun.
             * Create an empty ad request.
             */
            AdRequest request = new AdRequest.Builder().Build();

            /**
             * Banner'� istekle birlikte y�kleyin.
             * Load the banner with the request.
             */
            this._bannerView.LoadAd(request);
        }
        #endregion
    }
}