using ChartboostSDK;

using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class Ads : MonoBehaviour {


	public string BanneradUnitId = "ca-app-pub-7968657504800150/3626343626";
	public string InterstetialadUnitId = "ca-app-pub-7968657504800150/5103076820";
	// Banner
	BannerView bannerView;
	
	// Interstitial
	InterstitialAd interstitial;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void RequestBanner()
	{
		// Create a 320x50 banner at the Bottom of the screen.
		bannerView = new BannerView(BanneradUnitId, AdSize.Banner, AdPosition.Bottom);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		bannerView.LoadAd(request);
	}

	public void ShowBanner() {
		bannerView.Show ();
	}

	public void HideBanner() {
		bannerView.Hide ();
	}

	public void DestroyBanner() {
		if (bannerView != null) {
			bannerView.Destroy ();
		}
	}
	
	public void RequestInterstitial()
	{
		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(InterstetialadUnitId);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(request);
	}

	public void ShowInterstitial() {
		if (interstitial.IsLoaded ()) {
			interstitial.Show ();
		}
		else {
			Chartboost.cacheInterstitial (CBLocation.Default);
			Chartboost.showInterstitial (CBLocation.Default);
		}
	}

	public void DestroyInterstitial() {
		if(interstitial != null)
			interstitial.Destroy ();
	}

	public void RequestChartboost(){
		Chartboost.cacheInterstitial (CBLocation.Default);
	}

	public void ShowChartboost(){
		Chartboost.showInterstitial (CBLocation.Default);
	}
	
	void OnDisable(){
		DestroyBanner ();
	}
}
