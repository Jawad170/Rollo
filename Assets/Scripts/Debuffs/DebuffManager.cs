using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffManager : MonoBehaviour {
	BallProperties ballPropertiesFunctions = new BallProperties();
	private float targetTime = 5.0f;
	private bool startTimer = false;
	private bool active = false;
	private string currentDebuff = "Nothing";
	private GameObject ballObject;
	private float slowingFactor = 0.001f;
	private float speedMultipler = 0.01f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (startTimer == true) {
			targetTime -= Time.deltaTime;
			//Debug.Log (targetTime);
		}
		if (targetTime <= 0.0f) {
			if (currentDebuff == "Double Size Debuff") {//after the timer is finished. check what kind of debuff is it to act accordingly.
				ballPropertiesFunctions.modifyScale (-ballPropertiesFunctions.getScaleX (), -ballPropertiesFunctions.getScaleY (), -ballPropertiesFunctions.getScaleZ ());
				startTimer = false;
				targetTime = 5.0f;
				destroyCurrentObject ();
			} else if (currentDebuff == "Reverse Control Debuff") {
				ballObject.GetComponent<BallProperties> ().ReverseControlResetter ();
				startTimer = false;
				targetTime = 5.0f;
				destroyCurrentObject ();
			} else if (currentDebuff == "Half Speed") {
				ballObject.GetComponent<BallProperties> ().ResetSpeedSlow ();
				startTimer = false;
				targetTime = 5.0f;
				destroyCurrentObject ();
			} else if (currentDebuff == "Speed Multiplier") {
				ballObject.GetComponent<BallProperties> ().resetSpeedMultipler (multiplier: speedMultipler);
				startTimer = false;
				targetTime = 5.0f;
				destroyCurrentObject();
			}
		}
	}

	private void destroyCurrentObject(){
		Destroy (gameObject);
	}

	private void HideCurrentObject(){
		MeshRenderer render = gameObject.GetComponentInChildren<MeshRenderer> ();
		render.enabled = false;
	}

	private string debuffChecker(string typeOfDebuff){
		if (typeOfDebuff.Contains ("Double Size")) {
			return "Double Size Debuff";
		} else if (typeOfDebuff.Contains ("Reverse Control")) {
			return "Reverse Control Debuff";
		} else if (typeOfDebuff.Contains ("Half Speed")) {
			return "Half Speed";
		} else if (typeOfDebuff.Contains ("Speed Multiplier")) {
			return "Speed Multiplier";
		}
		else{
			return "Nothing";
		}
	}

	private void getNumbersFromString(string variable, out float multiplerValue, out float duration){
		string tempmultiplier = string.Empty;
		string tempduration = string.Empty;
		bool start = false;
		foreach (char c in variable) {
			if (c == '(') {
				break;
			}
			if (c == '-') {
				start = true;
			}
			if (c >= '0' && c <= '9') {
				if (start == false) {
					tempmultiplier += c;
				} else {
					tempduration += c;
				}
			}
		}

		multiplerValue = System.Convert.ToSingle(tempmultiplier);
		duration = System.Convert.ToSingle(tempduration);
	}

	private void OnTriggerEnter(Collider otherGameObject){
		//Debug.Log (otherGameObject.name);
		if(otherGameObject.name.ToString() == "Rollo"){
		if (active == false) {//Check if user already touched the Debuff.
			string typeOfDebuff = gameObject.name.ToString ();//we get the type of debuff from the name of the gameobject. so we need to name our debuff models accordingly.
			typeOfDebuff = debuffChecker(typeOfDebuff:typeOfDebuff);
			try{//start of try
				switch (typeOfDebuff) {//Switch that checks what the debuff Does.
					case "Double Size Debuff"://first case is a debuff that doubles the size.
						currentDebuff = "Double Size Debuff";
						//ballPropertiesFunctions.setGameObject (incomingGameObject: otherGameObject.gameObject);//set a ballProperties class so we do modifications to the ball. we send the ball gameobject to it.
						ballPropertiesFunctions = otherGameObject.GetComponent<BallProperties>();
						//get the current size of the ball.
						float scaleX = ballPropertiesFunctions.getScaleX ();
						float scaleY = ballPropertiesFunctions.getScaleY ();
						float scaleZ = ballPropertiesFunctions.getScaleZ ();
						//double the size of the ball.
						ballPropertiesFunctions.modifyScale (scaleX, scaleY, scaleZ);
						startTimer = true;//start the timer. so when it ends to return the player to his original size.
						HideCurrentObject ();//hide the current object. but dont destroy it. or else the script will be cancel it an wont returnn user to original size.
						active = true;//set active to true. as the debuff is only hidden not destroyed yet. so if the user touches it again it doesnt trigger and re- double his sizze.
						break;//break out of the first case.
					//-------------------------------------------------------------------------------------------
					case "Reverse Control Debuff":
						currentDebuff = "Reverse Control Debuff";
						otherGameObject.GetComponent<BallProperties> ().ReverseControls ();
						ballObject = otherGameObject.gameObject;
						startTimer = true;
						active = true;
						HideCurrentObject ();
						break;
					//-------------------------------------------------------------------------------------------
					case "Half Speed":
						currentDebuff = "Half Speed";
						targetTime = 2.0f;
						otherGameObject.GetComponent<BallProperties> ().SlowSpeed (factor: slowingFactor);
						ballObject = otherGameObject.gameObject;
						startTimer = true;
						active = true;
						HideCurrentObject ();
						break;
					case "Speed Multiplier":
						currentDebuff = "Speed Multiplier";
						ballObject = otherGameObject.gameObject;
						float multiplierValue, duration;
						getNumbersFromString(gameObject.name.ToString(), out multiplierValue, out duration);
						speedMultipler = multiplierValue;
						targetTime = duration;
						otherGameObject.GetComponent<BallProperties>().speedMultiplier(multiplier:multiplierValue);
						startTimer = true;
						HideCurrentObject();
						active = true;
						break;
				}
			}catch{
			}// End of try
		}//End of Active
		}
	}
}
