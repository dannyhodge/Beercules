using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;

public class menuScript : MonoBehaviour {

	public bool standard = true;
	public bool passItAround = true;
	public GameObject standardTick;
	public GameObject extremeTick;
	public GameObject passTick;
	public GameObject namesTick;

	public GameObject bottomStuff;

	public GameObject title;

	public int screenWidth;
	public int screenHeight;

	public string adID = "null";

	public GameObject debug;

	public NativeExpressAdView bannerView;
	//s4 mini is 960 x 540

	void Start () {


		if(Screen.orientation == ScreenOrientation.Landscape) {
		Screen.orientation = ScreenOrientation.Portrait;  //do this first

		}
		screenWidth = Screen.width;
		screenHeight = Screen.height;

		if(screenWidth >= screenHeight) {
			screenWidth = Screen.height;
			screenHeight = Screen.width;
		}


  /*		if( Application.platform == RuntimePlatform.Android) {
			screenWidth = Screen.width;
			screenHeight = Screen.height;
			debug.GetComponent<Text>().text = "Android";
		}
		else {
			screenWidth = Screen.width;
			screenHeight = Screen.height;
			debug.GetComponent<Text>().text = "PC";

  		} */

		if(screenWidth <= 500) {
			Vector3 temp = new Vector3(0.6f, 0.6f, 1);
			bottomStuff.transform.localScale = temp;
	//		adPosition.transform.localScale = temp;
			bottomStuff.transform.Translate(Vector3.up * -20f);
	//		adPosition.transform.Translate(Vector3.up * 30f);
			title.transform.Translate(Vector3.up * 130f);
			title.GetComponent<Text>().fontSize = 120;
		}

		else if(screenWidth <= 600) {
			Vector3 temp = new Vector3(0.9f, 0.9f, 1);
			bottomStuff.transform.localScale = temp;
//			adPosition.transform.localScale = temp;
			bottomStuff.transform.Translate(Vector3.up * 70f);
//			adPosition.transform.Translate(Vector3.up * 70f);
			title.transform.Translate(Vector3.up * 110f);
			title.GetComponent<Text>().fontSize = 150;
		}
		else if(screenWidth <= 900) {
			Vector3 temp = new Vector3(1.2f, 1.2f, 1);
			bottomStuff.transform.localScale = temp;
	//		adPosition.transform.localScale = temp;
			bottomStuff.transform.Translate(Vector3.up * 100f);
	//		adPosition.transform.Translate(Vector3.up * 100f);
			title.transform.Translate(Vector3.up * 110f);
			title.GetComponent<Text>().fontSize = 180;
			title.transform.Translate(Vector3.down * 20f);
		}

		else if(screenWidth <= 1080) {
			Vector3 temp = new Vector3(1.4f, 1.4f, 1);
			Vector3 tempTitle = new Vector3(1.1f, 1.1f, 1);
			title.transform.localScale = tempTitle;
			bottomStuff.transform.localScale = temp;
		//	adPosition.transform.localScale = temp;
			bottomStuff.transform.Translate(Vector3.down * 100f);
			title.transform.Translate(Vector3.right * 60f);
		
		
		}
		else if(screenWidth <= 1400) {
			Vector3 temp = new Vector3(1.4f, 1.4f, 1);
			bottomStuff.transform.localScale = temp;
		//	adPosition.transform.localScale = temp;
			bottomStuff.transform.Translate(Vector3.down * 100f);
	//		adPosition.transform.Translate(Vector3.down * 100f);
			title.transform.Translate(Vector3.down * 110f);
			title.GetComponent<Text>().fontSize = 300;
		}
		else {
			Vector3 temp = new Vector3(1.8f, 1.8f, 1);
			Vector3 tempTitle = new Vector3(1.25f, 1.25f, 1);
			bottomStuff.transform.localScale = temp;
	//		adPosition.transform.localScale = temp;
			title.transform.localScale = tempTitle;
			bottomStuff.transform.Translate(Vector3.down * 100f);
	//		adPosition.transform.Translate(Vector3.down * 100f);
			title.transform.Translate(Vector3.down * 110f);
			title.transform.Translate(Vector3.right * 150f);
		//title.GetComponent<Text>().fontSize = 350;
		}
		RequestBanner();
	}


	private void RequestBanner()
	{


		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-3804976617812716/4394413705";
		#elif UNITY_IPHONE
		string adUnitId = "unused";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		AdRequest adRequest = new AdRequest.Builder()
			.AddTestDevice("2645D5FFD3A4D7B1")
			.Build();


		if(screenWidth <= 500)   {
		bannerView = new NativeExpressAdView(adUnitId, new AdSize(280, 250), 10, 120);  //SIZE MUST BE SAME AS ADMOB SIZE
		}
		else if(screenWidth <= 600)   {
		bannerView = new NativeExpressAdView(adUnitId, new AdSize(280, 250), 40, 140);  //SIZE MUST BE SAME AS ADMOB SIZE
		}
		else if(screenWidth <= 900) {
		bannerView = new NativeExpressAdView(adUnitId, new AdSize(280, 250), 40, 120 + (screenWidth / 16));  //SIZE MUST BE SAME AS ADMOB SIZE 40 + (screenWidth / 16)
		}
		else if(screenWidth <= 1100) {
		bannerView = new NativeExpressAdView(adUnitId, new AdSize(300, 300), 10 + (screenWidth / 20), 50 + (screenWidth / 14));  //1920 x 1080
		}
		else if(screenWidth <= 1400) {
		bannerView = new NativeExpressAdView(adUnitId, new AdSize(340, 340), 42 + (screenWidth / 13), 120 + (screenWidth / 6));  //Nexus 7
		}
		else if (screenWidth <= 1800) {
		bannerView = new NativeExpressAdView(adUnitId, new AdSize(340, 340), 15 + (screenWidth / 13), 50 + (screenWidth / 12));  //1440 x 2560
		}
		else {
		bannerView = new NativeExpressAdView(adUnitId, new AdSize(340, 340), 42 + (screenWidth / 13), 120 + (screenWidth / 6));  //SIZE MUST BE SAME AS ADMOB SIZE
		}

		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		bannerView.LoadAd(request);
	
	}



	

	void Update() {

	//	debug.GetComponent<Text>().text = "Width: " + screenWidth + ", Height: " + screenHeight;



		if(standardTick.GetComponent<Toggle>().isOn == true) {
			
			PlayerPrefs.SetString("level","standard");

		}
		else {
			PlayerPrefs.SetString("level","extreme");
	
		}
		if(passTick.GetComponent<Toggle>().isOn == true) {
			PlayerPrefs.SetString("type","passiton");
		}
		else {
			PlayerPrefs.SetString("type","names");
		}

	
	}



	public void Play() {
		if(PlayerPrefs.GetString("type")=="names") {
		SceneManager.LoadScene(1, LoadSceneMode.Single);
		}
		else if(PlayerPrefs.GetString("type")=="passiton") {

		SceneManager.LoadScene(2, LoadSceneMode.Single);
		}
		bannerView.Destroy();
	}





}
