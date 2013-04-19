using UnityEngine;
using System.Collections;

public class CardScript : MonoBehaviour {

	Transform _tr;
	float timer;
	Quaternion startRotation;
	Quaternion endRotation;
	public bool rotateIn;
	public bool rotateOut;
	public bool faceIn;
	public string cardTag;
	
	
		//transform.localScale +=  new Vector3(screenrartio,screenrartio,0);

	void Start () {
		_tr  = GetComponent<Transform>();
		timer = 0;
		startRotation = _tr.rotation;
		float degrees = 180;
		endRotation = Quaternion.Euler (0,degrees,0)*_tr.rotation;
		rotateIn = false;
		rotateOut = false;
		faceIn = false; 
		int screenrartio = Screen.height/Screen.width;
		transform.localScale -=  new Vector3(screenrartio,screenrartio,0);
	}
	
	void Update(){
		if(rotateIn){
			timer +=Time.deltaTime*2;
			_tr.rotation = Quaternion.Lerp (_tr.rotation,endRotation,timer);
			Reset ();
		}else if (rotateOut){
			timer +=Time.deltaTime*2;
			_tr.rotation = Quaternion.Lerp (_tr.rotation,startRotation,timer);
			Reset ();
		}	
	}
	
	public void StartRotation(){
		if(!faceIn){
			rotateIn = true;
			faceIn = true;
		}else if (faceIn){
			rotateOut = true;
			faceIn = false;
		}
	}
	void Reset(){
		if(timer>=1){
				timer =0;
				rotateOut = false; 
				rotateIn = false;
		}
	}
	public bool RotationOver(){
		if(!rotateOut && !rotateIn)
			return true;
		else 
			return false;
	}
}
