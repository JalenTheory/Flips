using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {

	Rect box;
	Rect scoreBox;
	Rect hitBox;
	Rect timeBox;
	Rect ratioBox;
	Rect quitButton;
	Rect playAgain;
	ControlScript script;
	const string gameOver ="Game Over";
	const string scoreBoard="Score Board";

	
	
	
	void Start () {
		float offsetW = Screen.width / 4;
		float offsetH = Screen.height /4;
		float boxHeight = 50;
		box = new Rect(Screen.width / 6, Screen.height / 6, Screen.width *2/ 3, Screen.height * 2 / 3);
		scoreBox = new Rect(Screen.width / 2f - offsetW, Screen.height / 2f - offsetH, Screen.width * 0.5f, boxHeight);
		hitBox = new Rect(Screen.width / 2f - offsetW, Screen.height / 2f - offsetH + boxHeight, Screen.width * 0.5f, boxHeight);
		timeBox = new Rect(Screen.width / 2f - offsetW, Screen.height / 2f - offsetH + boxHeight*2, Screen.width * 0.5f, boxHeight);
		ratioBox = new Rect(Screen.width / 2f - offsetW, Screen.height / 2f - offsetH + boxHeight*3, Screen.width * 0.5f, boxHeight);
		playAgain =new Rect(Screen.width / 2f - offsetW, Screen.height / 2f - offsetH + boxHeight*4, Screen.width * 0.5f, boxHeight);
		quitButton =new Rect(Screen.width / 2f - offsetW, Screen.height / 2f - offsetH + boxHeight*5, Screen.width * 0.5f, boxHeight);
		script = GameObject.Find ("Control").GetComponent<ControlScript>();
		
	}
	
	// Update is called once per frame
	void OnGUI () {
		if(script.gameOver){
			GUI.Box (box,gameOver);
			GUI.Box(scoreBox,scoreBoard);
			GUI.Box(hitBox,"Hit: "+ script.GetHitCount().ToString ()); PlayerPrefs.SetInt("HitCount",script.GetHitCount());
			GUI.Box(timeBox,"Time: "+ script.GetEndTime().ToString ("0.00")); PlayerPrefs.SetFloat("Time", script.GetEndTime());
			GUI.Box(ratioBox,"Ratio: "+ ((float)script.GetHitCount()/6.0f).ToString("0.00"));  
			if(GUI.Button(playAgain,"PlayAgain")){
				Application.LoadLevel(Application.loadedLevel);
			}
			if(GUI.Button(quitButton,"Menu")){
				Application.LoadLevel(1);
			}
			
		}
	}
	
}

