using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour {

	Rect title;
	Rect easyButton;
	Rect mediumButton;
	Rect hardButton;
	Rect quitButton;
	Rect copyBox;
	float boxOffsetWidth;
	float boxOffsetHeight;
	public Font font;
	public GUIStyle style = new GUIStyle();
	public GUIStyle buttonStyle = new GUIStyle();
	GUIStyle footer = new GUIStyle();
	
	
	void Start () {
		style.font = font;
		style.fontSize = Screen.width/6;
		style.alignment = TextAnchor.MiddleCenter;

		buttonStyle.font = font;
		buttonStyle.fontSize = Screen.width/10;
		buttonStyle.alignment = TextAnchor.MiddleCenter;
		
		footer.font = font;
		footer.fontSize = Screen.width/30;
		footer.alignment = TextAnchor.MiddleCenter;
		
		float titleBoxWidth = Screen.width / 3 * 2;		//All boxes width
		float titleBoxHeight = Screen.height / 3;
		float titlePosWidth = Screen.width/2 - titleBoxWidth/2; 
		
		float boxWidth = Screen.width/2;
		float boxHeight = Screen.height/8;
		float boxPosWidth = Screen.width/4;

		
		float offset = Screen.height / 8;
		
		title = new Rect(titlePosWidth, offset, titleBoxWidth,titleBoxHeight);
		
		easyButton= new Rect(boxPosWidth,titleBoxHeight+offset+2,boxWidth,boxHeight);
		mediumButton = new Rect(boxPosWidth,titleBoxHeight+boxHeight+offset,boxWidth,boxHeight);
		hardButton = new Rect(boxPosWidth,titleBoxHeight+boxHeight*2+offset,boxWidth,boxHeight);
		quitButton = new Rect(boxPosWidth,titleBoxHeight+boxHeight*3+offset,boxWidth,boxHeight);
		copyBox = new Rect(boxPosWidth,Screen.height - boxHeight/2 ,boxWidth,boxHeight/3 );
	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.backgroundColor = Color.yellow;
		GUI.Box (title,"Flips",style);
		GUI.backgroundColor = Color.magenta;
		if(GUI.Button (easyButton,"Easy",buttonStyle))
		{
			print ("Next");
		}
		if(GUI.Button (mediumButton,"Medium",buttonStyle))
		{
			print ("Score");
		}
		if(GUI.Button (hardButton,"Hard",buttonStyle))
		{
			print ("Quit");
		}
		if(GUI.Button (quitButton,"Back",buttonStyle))
		{
			print ("Quit");
		}
		GUI.Box (copyBox,"Metropolia Portal 2013",footer);
	}
		
}

/*	1/6				4/6					1/6
 * *********************************************************
 * 
 * 						Title						1/3
 * 
 * **********************************************************
 * 			*			Play		*
 * 			*
 * 			*			Score		*			2/3
 * 			*
 * 			*			Quit		*
 * 			*
 * 			*
 * 						Credit
 *************************************************
 *
 *
 **/
