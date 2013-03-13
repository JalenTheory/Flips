using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ControlScript : MonoBehaviour {

	public int cardCheck;
	public int totalCardUp;
	int hitCount;
	public bool gameOver;
	float endTime;
	bool once;
	public Transform []cardUp = new Transform[2]; 
	Camera cam;
	int maxCard;
	void Start () {
		cam = (Camera)FindObjectOfType(typeof(Camera));

		cardCheck = 0;
		totalCardUp =0;
		hitCount = 0;
		gameOver = false;
		once =true;
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
   		RaycastHit hit;
        if (Input.GetMouseButtonDown(0)&&Physics.Raycast(ray, out hit)&&cardCheck<2){
            if(hit.collider.tag == "Card"){
				Transform tr = hit.transform.root;
				CardScript script = tr.GetComponent<CardScript>();
				script.StartRotation();
				cardUp[cardCheck] = hit.collider.gameObject.transform.root;
				cardCheck++;
				hitCount++;
			}
		}
		if(cardCheck >= 2)CheckCard ();
		if(totalCardUp == maxCard && once){
			gameOver = true;
			endTime = Time.timeSinceLevelLoad;
			once = false;
		}
	}
	void CheckCard(){	
		CardScript scriptA = cardUp[0].GetComponent<CardScript>();
		CardScript scriptB = cardUp[1].GetComponent<CardScript>();
		if(scriptA.RotationOver() && scriptB.RotationOver()){
			if(scriptA.cardTag == scriptB.cardTag){
				totalCardUp += 2;
				cardCheck = 0;
			}else{
				scriptA.StartRotation();
				scriptB.StartRotation();
				cardCheck = 0;
			}
		}	
	}
	public int GetHitCount(){
		return hitCount;
	}
	public float GetEndTime(){
		return endTime;
	}
	public void SetMaxCard(int n){
		maxCard = n;
	}
	
	
	public static Material[] RandomizeMaterial(Material[] mat)
    {
		List<KeyValuePair<int, Material>> list = new List<KeyValuePair<int, Material>>();
		foreach (Material m in mat)
		{
		    list.Add(new KeyValuePair<int, Material>(Random.Range(0,99999), m));
		}
		// Sort the list by the random number
		var sorted = from item in list
			     orderby item.Key
			     select item;
		// Allocate new string array
		Material[] result = new Material[mat.Length];
		// Copy values to array
		int index = 0;
		foreach (KeyValuePair<int, Material> pair in sorted)
		{
		    result[index] = pair.Value;
		    index++;
		}
		// Return copied array
		return result;
    }
}
