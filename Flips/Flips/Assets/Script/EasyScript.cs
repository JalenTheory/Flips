using UnityEngine;
using System.Collections;


public class EasyScript : MonoBehaviour {	
	public GameObject card;
	GameObject[] cards = new GameObject[6];
	public Material[]  mat = new Material[6];
	public Material [] shufMat = new Material[6];
	ControlScript script;
	
	 

	
	void Start () {
		 
		script = GetComponent<ControlScript>();
		shufMat = ControlScript.RandomizeMaterial(mat);
		int count = 0;
		
		for(int i=0;i<3;i++){
			for(int j=0;j<2;j++){
				Vector3 pos = new Vector3(i*20,j*20,0);
				cards[i] = (GameObject)Instantiate(card,pos,transform.rotation);
				Transform c = cards[i].transform.Find ("Face");
				if(c == null)Debug.LogError ("No Face Object");
				c.renderer.material = new Material(Shader.Find("Diffuse"));
				c.renderer.material = shufMat[count];
				cards[i].GetComponent<CardScript>().cardTag = shufMat[count].name;
				count++;
			}
		}
		script.SetMaxCard(6);
		 
	}
	
	public int time = 0; 
	public bool pausebool = false;
	void OnGUI () 
	{
		if(!pausebool){
			time++;	 
			if(GUI.Button (new Rect(Screen.width-100,10,50,30),"Pause")){pausebool = true;}
		}
		
		else{if(GUI.Button (new Rect(Screen.width-100,10,50,30),"Pause")){pausebool = false;}
	 		
			
		}
		
		GUI.Box(new Rect(10,10,100,30), "Time "+time/120);
					if(GUI.Button (new Rect(Screen.width-100,60,50,30),"Menu")){Application.LoadLevel(1);}
	
		
	}
 
}
