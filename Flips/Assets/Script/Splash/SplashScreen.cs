using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	GUITexture texture;
	bool fadein,fadeOut;	
	Color start;
	Color end;
	
	float ratio;
	float timer;
	void Start () {
		texture = GameObject.Find ("Metropolia").GetComponent<GUITexture>();
		fadein = true;fadeOut = false;
		texture.color = new Color(texture.color.r,texture.color.g,texture.color.b,0.0f);
		start = texture.color;
		end = new Color(texture.color.r,texture.color.g,texture.color.b,1.0f);
		timer = Time.deltaTime*0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if(fadein){
			ratio += timer*0.7f;
			texture.color = Color.Lerp(texture.color,end,ratio);
			if(ratio > 1){
				fadein = false;
				ratio = 0;
				StartCoroutine(WaitSplash ());
			}
		}else if (fadeOut){
			ratio += timer*0.7f;
			texture.color = Color.Lerp(texture.color,start,ratio);
			if(ratio > 0.5f){
				Application.LoadLevel(1);
			}
		}
	}
	IEnumerator WaitSplash(){
		yield return new WaitForSeconds(1.0f);
		fadeOut = true;
	}
}
