using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalManager : MonoBehaviour {
	bool active = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private string debuffChecker(string typeOfEffect){
		if (typeOfEffect.Contains ("Upward Winds")) {
			return "Upward Winds";
		}
		else{
			return "Nothing";
		}
	}

	private void getNumbersFromString(string variable, out float windPower){
		string localwindpower = string.Empty;
		bool start = false;
		foreach (char c in variable) {
			if (c == '(') {
				break;
			}
			if (c >= '0' && c <= '9') {
				localwindpower += c;
		}

	}
		windPower = System.Convert.ToSingle(localwindpower);
	}

	private void OnTriggerStay(Collider otherGameObject){
		if (otherGameObject.name.ToString () == "Rollo") {
			if (active == false) {
				string typeOfEffect = gameObject.name.ToString ();
				typeOfEffect = debuffChecker (typeOfEffect: typeOfEffect);
				Debug.Log (typeOfEffect);
				switch(typeOfEffect){
				case "Upward Winds":
					float windPower;
					getNumbersFromString (gameObject.name.ToString (), out windPower);
					otherGameObject.GetComponent<BallProperties> ().upwardsWinds (windPower: windPower);
					break;
				}
			
			}
		}
	
	}



	}
