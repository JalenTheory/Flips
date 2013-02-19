using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	GUITexture texture;
	public bool fadein;	
	Color start;
	Color end;
	
	public float ratio;
	public float timer;
	void Start () {
		texture = GameObject.Find ("Metropolia").GetComponent<GUITexture>();
		fadein = true;
		texture.color = new Color(texture.color.r,texture.color.g,texture.color.b,0.0f);
		start = texture.color;
		end = new Color(texture.color.r,texture.color.g,texture.color.b,1.0f);
		timer = Time.deltaTime*0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if(fadein){
			ratio += timer;
			texture.color = Color.Lerp(texture.color,end,ratio);
			if(ratio > 1){
				fadein = false;
				ratio = 0;
			}
		}else{
			ratio += timer;
			texture.color = Color.Lerp(texture.color,start,ratio);
			if(ratio > 1){
				Application.LoadLevel(1);
			}
		}
	}
}
