using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	Rect title;
	Rect firstButton;
	Rect secondButton;
	Rect thirdButton;
	Rect fourthButton;
	Rect copyBox;
	float boxOffsetWidth;
	float boxOffsetHeight;
	public Font font;
	public GUIStyle style = new GUIStyle();
	public GUIStyle buttonStyle = new GUIStyle();
	GUIStyle footer = new GUIStyle();
	
	bool firstMenu;
	void Start () {
		firstMenu = true;
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
		float titleBoxHeight = Screen.height / 4;
		float titlePosWidth = Screen.width/2 - titleBoxWidth/2; 
		
		float boxWidth = Screen.width/2;
		float boxHeight = Screen.height/8;
		float boxPosWidth = Screen.width/4;

		
		float offset = Screen.height / 8;
		
		title = new Rect(titlePosWidth, offset, titleBoxWidth,titleBoxHeight);
		
		firstButton= 	new Rect(boxPosWidth,titleBoxHeight+offset,boxWidth,boxHeight);
		secondButton = 	new Rect(boxPosWidth,titleBoxHeight+boxHeight+offset,boxWidth,boxHeight);
		thirdButton = 	new Rect(boxPosWidth,titleBoxHeight+boxHeight*2+offset,boxWidth,boxHeight);
		fourthButton =	new Rect(boxPosWidth,titleBoxHeight+boxHeight*3+offset,boxWidth,boxHeight);
		copyBox = new Rect(boxPosWidth,Screen.height - boxHeight/2 ,boxWidth,boxHeight/3 );
	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.backgroundColor = Color.yellow;
		GUI.Box (title,"Flips",style);
		GUI.backgroundColor = Color.magenta;
		if(firstMenu){
			if(GUI.Button (firstButton,"Play",buttonStyle))
			{
				firstMenu = false;
			}
			if(GUI.Button (secondButton,"Score",buttonStyle))
			{
				print ("Score");
			}
			if(GUI.Button (thirdButton,"Quit",buttonStyle))
			{
				Application.Quit ();
			}
		}else{
			if(GUI.Button (firstButton,"Easy",buttonStyle))
			{
				Application.LoadLevel(2);
			}
			if(GUI.Button (secondButton,"Medium",buttonStyle))
			{
				Application.LoadLevel(3);
			}
			if(GUI.Button (thirdButton,"Hard",buttonStyle))
			{
				Application.LoadLevel(4);
			}
			if(GUI.Button (fourthButton,"Back",buttonStyle))
			{
				firstMenu = true;
			}
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
