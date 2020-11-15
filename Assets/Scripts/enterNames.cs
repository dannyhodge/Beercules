using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class enterNames : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;
	public GameObject player5;
	public GameObject player6;
	public GameObject player7;
	public GameObject player8;
	public GameObject player9;
	public GameObject player10;
	public GameObject allplayers;
	public GameObject leftside;
	public GameObject rightside;

	public GameObject title;

	public GameObject button;

	public GameObject bottomStuff;

	public int count = 0;

	public List<string> names = new List<string>();

	public int screenWidth;
	public int screenHeight;

	void Start() {

		if( Application.platform == RuntimePlatform.Android) {
			screenWidth = Screen.width;
			screenHeight = Screen.height;
		}
		else {
			screenWidth = Screen.width;
			screenHeight = Screen.height;

		}
		if(screenWidth <= 500) {                                      //J1
			Vector3 temp = new Vector3(0.6f, 0.6f, 1);
			Vector3 tempTitle = new Vector3(0.3f, 0.3f, 1);
			title.transform.localScale = tempTitle;
			button.transform.localScale = temp;
			allplayers.transform.localScale = temp;

			leftside.transform.Translate(Vector3.left * 80f);
			rightside.transform.Translate(Vector3.right * -10f);
			allplayers.transform.Translate(Vector3.down * 50f);
			button.transform.Translate(Vector3.up * 170f);
			title.transform.Translate(Vector3.up * 10f);
			title.transform.Translate(Vector3.left * 370f);
		}
		else if(screenWidth <= 600) {                                      //s4 mini
			Vector3 temp = new Vector3(0.8f, 0.8f, 1);
			Vector3 tempTitle = new Vector3(0.5f, 0.5f, 1);
			title.transform.localScale = tempTitle;
			button.transform.localScale = temp;
			allplayers.transform.localScale = temp;

			leftside.transform.Translate(Vector3.left * 60f);
			rightside.transform.Translate(Vector3.right * 20f);
			allplayers.transform.Translate(Vector3.down * 50f);

			button.transform.Translate(Vector3.up * 130f);

			title.transform.Translate(Vector3.down * 10f);
			title.transform.Translate(Vector3.left * 250f);
		}
		else if(screenWidth <= 900) {                              //J5
			Vector3 temp = new Vector3(1.1f, 1.1f, 1);
			Vector3 tempTitle = new Vector3(0.7f, 0.7f, 1);
			title.transform.localScale = tempTitle;
			allplayers.transform.localScale = temp;
			button.transform.localScale = temp;

			leftside.transform.Translate(Vector3.left * 30f);
			rightside.transform.Translate(Vector3.right * 50f);
			allplayers.transform.Translate(Vector3.down * 50f);
	
			title.transform.Translate(Vector3.up * 0f);
			title.transform.Translate(Vector3.left * 150f);
		}

		else if(screenWidth <= 1100) { 
			Vector3 temp = new Vector3(1.4f, 1.4f, 1);
			Vector3 tempTitle = new Vector3(1.1f, 1.1f, 1);
			title.transform.localScale = tempTitle;
			allplayers.transform.localScale = temp;
			button.transform.localScale = temp;
			leftside.transform.Translate(Vector3.left * 30f);
			rightside.transform.Translate(Vector3.right * 120f);
			allplayers.transform.Translate(Vector3.down * 50f);
			button.transform.Translate(Vector3.down * 230f);
			title.transform.Translate(Vector3.up * 60f);
			title.transform.Translate(Vector3.right * 60f);
		}
		else if(screenWidth <= 1400) {                            //Nexus 7
			Vector3 temp = new Vector3(1.6f, 1.6f, 1);
			Vector3 tempTitle = new Vector3(1.25f, 1.25f, 1);
			title.transform.localScale = tempTitle;

			button.transform.localScale = temp;
			allplayers.transform.localScale = temp;

			leftside.transform.Translate(Vector3.left * 10f);
			rightside.transform.Translate(Vector3.right * 140f);
			allplayers.transform.Translate(Vector3.down * 80f);

			button.transform.Translate(Vector3.down * 150f);
			title.transform.Translate(Vector3.down * 10f);
			title.transform.Translate(Vector3.right * 120f);
		}
		else {
			Vector3 temp = new Vector3(1.8f, 1.8f, 1);
			Vector3 tempTitle = new Vector3(1.25f, 1.25f, 1);
			title.transform.localScale = tempTitle;
			button.transform.localScale = temp;
			allplayers.transform.localScale = temp;

			leftside.transform.Translate(Vector3.left * 30f);
			rightside.transform.Translate(Vector3.right * 200f);
			allplayers.transform.Translate(Vector3.down * 80f);
			button.transform.Translate(Vector3.down * 450f);
			title.transform.Translate(Vector3.down * 110f);
			title.transform.Translate(Vector3.right * 130f);
		}



	}


	void Update() {
		if(Input.GetKeyDown(KeyCode.Escape)) {

			SceneManager.LoadScene(0, LoadSceneMode.Single);
		}
	}


	public void OpenGame() {

		PlayerPrefs.SetString("Player1", "");
		PlayerPrefs.SetString("Player2", "");
		PlayerPrefs.SetString("Player3", "");
		PlayerPrefs.SetString("Player4", "");
		PlayerPrefs.SetString("Player5", "");
		PlayerPrefs.SetString("Player6", "");
		PlayerPrefs.SetString("Player7", "");
		PlayerPrefs.SetString("Player8", "");
		PlayerPrefs.SetString("Player9", "");
		PlayerPrefs.SetString("Player10", "");

		if(player1.GetComponent<InputField>().text != "") {
			count++;
			names.Add(player1.GetComponent<InputField>().text);
	
		}
		if(player2.GetComponent<InputField>().text != "") {
			count++;
			names.Add(player2.GetComponent<InputField>().text);
		}
		if(player3.GetComponent<InputField>().text != "") {
			count++;
			names.Add(player3.GetComponent<InputField>().text);
		}
		if(player4.GetComponent<InputField>().text != "") {
			count++;
			names.Add(player4.GetComponent<InputField>().text);
		}
		if(player5.GetComponent<InputField>().text != "") {
			count++;
			names.Add(player5.GetComponent<InputField>().text);
		}
		if(player6.GetComponent<InputField>().text != "") {
			count++;
			names.Add(player6.GetComponent<InputField>().text);

		}
		if(player7.GetComponent<InputField>().text != "") {
			count++;
			names.Add(player7.GetComponent<InputField>().text);

		}
		if(player8.GetComponent<InputField>().text != "") {
			count++;
			names.Add(player8.GetComponent<InputField>().text);

		}
		if(player9.GetComponent<InputField>().text != "") {
			count++;
			names.Add(player9.GetComponent<InputField>().text);

		}
		if(player10.GetComponent<InputField>().text != "") {
			count++;
			names.Add(player10.GetComponent<InputField>().text);

		}

	

		if(names.Count >= 1) { 
		PlayerPrefs.SetString("Player1", names[0]);
		}
		if(names.Count >= 2) { 
		PlayerPrefs.SetString("Player2", names[1]);
		}
		if(names.Count >= 3) { 
		PlayerPrefs.SetString("Player3", names[2]);
		}
		if(names.Count >= 4) { 
		PlayerPrefs.SetString("Player4", names[3]);
		}
		if(names.Count >= 5) { 
		PlayerPrefs.SetString("Player5", names[4]);
		}
		if(names.Count >= 6) { 
		PlayerPrefs.SetString("Player6", names[5]);
		}
		if(names.Count >= 7) { 
		PlayerPrefs.SetString("Player7", names[6]);
		}
		if(names.Count >= 8) { 
		PlayerPrefs.SetString("Player8", names[7]);
		}
		if(names.Count >= 9) { 

		PlayerPrefs.SetString("Player9", names[8]);
		}
		if(names.Count >= 10) { 

		PlayerPrefs.SetString("Player10", names[9]);
		}




		PlayerPrefs.SetInt("playerCount", count);

		if(count == 0) {
			bottomStuff.SetActive(true);
		}

		else {
		SceneManager.LoadScene(2, LoadSceneMode.Single);
		}
	}
}
