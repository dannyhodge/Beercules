using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using GoogleMobileAds;
using GoogleMobileAds.Api;






public class loadQsAs : MonoBehaviour {

	public bool question;
	public GameObject questionUI;
	public GameObject answerUI;
	public GameObject drinksUI;
	public int currLine;
	public List<string> data = new List<string> ();
	public List<int> finishedqs = new List<int> ();
	public int qCounter = 0;

	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	public Sprite sprite4;
	public Sprite sprite5;

	public string filePath;
	public GameObject panel;
	public GameObject pathUI;

	public List<string> catagories = new List<string>();
	public string[] colours = { "#0095FFFF" , "#87DD24FF", "#85A4DCFF" , "AFC4FFFF" , "F19805FF" , "4DADE9FF" , "CC4167FF" , "3B6F58FF" , "109F86FF" , "F90363FF" , "5647CAFF" , "F4D917FF" , "98E151FF" };

	public int screenWidth;
	public int screenHeight;
	public GameObject topPanel;

	public string lastCat;
	public string lastQ;

	public bool standard = true;
	public bool passItOn = true;

	public int count = 0;

	public BannerView bannerView;



	//START
	void Start () {

		if( Application.platform == RuntimePlatform.Android) {
			screenWidth = Screen.width;
			screenHeight = Screen.height;
		}
		else {
			screenWidth = Screen.height;
			screenHeight = Screen.width;
		
		}

		Screen.orientation = ScreenOrientation.LandscapeLeft;
		RectTransform rt = answerUI.GetComponent<RectTransform>() as RectTransform;
		rt.sizeDelta = new Vector2(screenHeight - (screenHeight/12), 371);

		RequestBanner();



		if(screenWidth <= 500) {

			questionUI.GetComponent<Text> ().fontSize = 40;
			answerUI.GetComponent<Text> ().fontSize = 30;
			drinksUI.GetComponent<Text> ().fontSize = 40;
			Debug.Log("500");
			questionUI.transform.Translate(Vector3.down * 50f);
			answerUI.transform.Translate(Vector3.down * 100f);
			Vector3 temp = new Vector3(0.8f, 0.8f, 1);
			topPanel.transform.localScale = temp;
			topPanel.transform.Translate(Vector3.up * 11f);

		}
		//s4 mini is 960 x 540
		else if(screenWidth <= 540) {
			questionUI.GetComponent<Text> ().fontSize = 50;
			answerUI.GetComponent<Text> ().fontSize = 40;
			drinksUI.GetComponent<Text> ().fontSize = 50;
			Debug.Log("600");
			questionUI.transform.Translate(Vector3.down * 30f);
			answerUI.transform.Translate(Vector3.down * 50f);
			Vector3 temp = new Vector3(0.8f, 0.8f, 1);
			topPanel.transform.localScale = temp;
			topPanel.transform.Translate(Vector3.up * 11f);

		}
		else if(screenWidth <= 600) {
			questionUI.GetComponent<Text> ().fontSize = 60;
			answerUI.GetComponent<Text> ().fontSize = 50;
			drinksUI.GetComponent<Text> ().fontSize = 60;
			Debug.Log("600");
			questionUI.transform.Translate(Vector3.down * 30f);
			answerUI.transform.Translate(Vector3.down * 20f);
			Vector3 temp = new Vector3(0.8f, 0.8f, 1);
			topPanel.transform.localScale = temp;
			topPanel.transform.Translate(Vector3.up * 11f);

		}
		else if(screenWidth <= 900) {
			questionUI.GetComponent<Text> ().fontSize = 70;
			answerUI.GetComponent<Text> ().fontSize = 60;
			drinksUI.GetComponent<Text> ().fontSize = 70;
			Debug.Log("900");
			questionUI.transform.Translate(Vector3.down * 30f);
			answerUI.transform.Translate(Vector3.up * 30f);
			Vector3 temp = new Vector3(1, 1, 1);
			topPanel.transform.localScale = temp;

		}
		else if(screenWidth <= 1100) {
			Vector3 temp = new Vector3(1.8f, 1, 1);
			questionUI.GetComponent<Text> ().fontSize = 90;
			answerUI.GetComponent<Text> ().fontSize = 75;
			drinksUI.GetComponent<Text> ().fontSize = 85;
			questionUI.transform.Translate(Vector3.up * 800f);
			answerUI.transform.Translate(Vector3.up * 290f);


			topPanel.transform.localScale = temp;
		
		}
		else if(screenWidth <= 1400) {
			Vector3 temp = new Vector3(1f, 1, 1);
			questionUI.GetComponent<Text> ().fontSize = 100;
			answerUI.GetComponent<Text> ().fontSize = 90;
			drinksUI.GetComponent<Text> ().fontSize = 95;
			questionUI.transform.Translate(Vector3.up * 80f);
			answerUI.transform.Translate(Vector3.up * 380f);
		

			topPanel.transform.localScale = temp;
		}
		else if(screenWidth <= 1600) {
			questionUI.GetComponent<Text> ().fontSize = 130;
			answerUI.GetComponent<Text> ().fontSize = 115;
			drinksUI.GetComponent<Text> ().fontSize = 130;
			questionUI.transform.Translate(Vector3.up * 120f);
			answerUI.transform.Translate(Vector3.up * 480f);
			//	drinksUI.transform.Translate(Vector3.right * 400f);
			//	drinksUI.transform.Translate(Vector3.up * 400f);
			Vector3 temp = new Vector3(1.4f, 1.4f, 1);
			topPanel.transform.localScale = temp;
			topPanel.transform.Translate(Vector3.down * 20f);
		}
		else {
			
			questionUI.GetComponent<Text> ().fontSize = 150;
			answerUI.GetComponent<Text> ().fontSize = 135;
			drinksUI.GetComponent<Text> ().fontSize = 150;
			questionUI.transform.Translate(Vector3.up * 120f);
			answerUI.transform.Translate(Vector3.up * 480f);
		//	drinksUI.transform.Translate(Vector3.right * 400f);
		//	drinksUI.transform.Translate(Vector3.up * 400f);
			Vector3 temp = new Vector3(1.5f, 1.5f, 1);
			topPanel.transform.localScale = temp;
	//		mrHelper.GetComponent<Text>().text  = "X: " + drinksUI.transform.position.x + "Y: " +  drinksUI.transform.position.y;
		}

	

	
		TextAsset questionData = Resources.Load<TextAsset>("standardnames");


	
		if(PlayerPrefs.GetString("level") == "standard" && PlayerPrefs.GetString("type") == "passiton") {
			 questionData = Resources.Load<TextAsset>("standardpass");

		}
		if(PlayerPrefs.GetString("level") == "extreme" && PlayerPrefs.GetString("type") == "passiton") {
			 questionData = Resources.Load<TextAsset>("extremepass");
		}

		if(PlayerPrefs.GetString("level") == "standard" && PlayerPrefs.GetString("type") == "names") {
			
			 questionData = Resources.Load<TextAsset>("standardnames");

		}

		if(PlayerPrefs.GetString("level") == "extreme" && PlayerPrefs.GetString("type") == "names") {
			 questionData = Resources.Load<TextAsset>("extremenames");
		}
	


		string currLine;
		questionUI.GetComponent<Text> ().text = null;
		answerUI.GetComponent<Text> ().text = null;
		drinksUI.GetComponent<Text> ().text = null;




		string[] linesFromFile = questionData.text.Split('\n');

		foreach (string line in linesFromFile)
		{
			data.Add(line);
	
		}


		for(int i = 3; i < data.Count - 3; i += 3) {

			if(catagories.Contains(data[i]) != true) {
				catagories.Add(data[i]);
			}
		
		}

		RandomNumber();

}

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape)) {
			bannerView.Destroy();
			SceneManager.LoadScene(0, LoadSceneMode.Single);
		}

		if (Input.GetKeyDown (KeyCode.A) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {

			if (qCounter <= (data.Count - 4)) {
				RandomNumber ();
		

			} else {
				questionUI.GetComponent<Text> ().text = "Finished Questions!";
				answerUI.GetComponent<Text> ().text = "Click to restart";
				drinksUI.SetActive(false);
				ResetQs();
			}
				
		}
			
	}

	private void RequestBanner()
	{


		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-3804976617812716/2359277305";
		#elif UNITY_IPHONE
		string adUnitId = "unused";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		AdRequest adRequest = new AdRequest.Builder()
		.Build();

		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);  //SIZE MUST BE SAME AS ADMOB SIZE

		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		bannerView.LoadAd(request);

		}

	public void RandomNumber() {
		drinksUI.SetActive(true);
		int randomQ = (int)UnityEngine.Random.Range(0, data.Count - 1);
		bool dontQ = false;
		if (randomQ % 3 != 0) {
			randomQ -= 1;
			if (randomQ % 3 != 0) {
				randomQ -= 1;
			}


		}


			
			foreach (int q in finishedqs) {
				if (randomQ == q) {

					dontQ = true;

				} else {

				if(data[randomQ] == lastCat && data[randomQ+1] == lastQ) {
					dontQ = true;
				}

				}
			}

		if (dontQ == true) {
				RandomNumber ();
			} else {
				RandomQuestion (randomQ);
			}
		dontQ = false;

	}

		public void RandomQuestion(int randNum) {
		string name = "Flobble";
		string questionAfterName = "Hello";
		if(PlayerPrefs.GetString("type")=="names") {
		 name = AddingName();
		 questionAfterName = data [randNum+1].Replace("Flobble", name);
		}
		else {
			questionAfterName = data [randNum+1];
		}
		//Debug.Log(data[randNum]);


		questionUI.GetComponent<Text> ().text = data[randNum];
		answerUI.GetComponent<Text> ().text = questionAfterName;
		drinksUI.GetComponent<Text>().text = "x" + data[randNum + 2];
			

		lastCat = data [randNum];
		lastQ = data [randNum + 1];




		if (int.Parse( data [randNum + 2]) == 0) {
			
			drinksUI.SetActive(false);

				}
		else {
			drinksUI.SetActive(true);
		}


				
					
	
		finishedqs.Add (randNum);
		qCounter += 3;

		}

	string AddingName() {
		int rand = UnityEngine.Random.Range(1, PlayerPrefs.GetInt("playerCount")+1);
		string tempName = "Flobble";
		if(rand==1) {

			
			tempName = PlayerPrefs.GetString("Player1");
		

		}
		 if(rand==2) {

				tempName = PlayerPrefs.GetString("Player2");
			
		}
		 if(rand==3) {

				tempName = PlayerPrefs.GetString("Player3");
			
		}
		 if(rand==4) {

				tempName = PlayerPrefs.GetString("Player4");
			
		}
		 if(rand==5) {
		
				tempName = PlayerPrefs.GetString("Player5");
			
		}
		 if(rand==6) {

				tempName = PlayerPrefs.GetString("Player6");
			
		}
		 if(rand==7) {
		
				tempName = PlayerPrefs.GetString("Player7");
			
		}
		 if(rand==8) {

				tempName = PlayerPrefs.GetString("Player8");
			
		}
		 if(rand==9) {

				tempName = PlayerPrefs.GetString("Player9");
			
		}
		 if(rand==10) {
		
				tempName = PlayerPrefs.GetString("Player10");
			
		}
		//Debug.Log(tempName);
		if(tempName=="") {
			tempName = AddingName();
		}
		return tempName;
	}

	void ResetQs() {
		finishedqs.Clear();
		finishedqs.Add(0);
		qCounter = 0;
	
	}

	}

