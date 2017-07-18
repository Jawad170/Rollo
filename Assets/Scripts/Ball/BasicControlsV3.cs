using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicControlsV3 : MonoBehaviour {
	private Dictionary<string, float> speedVariables = new Dictionary<string, float> ();
	// Use this for initialization
	void Start () {
		initializeSpeedVariables ();
	}

	private void initializeSpeedVariables(){
		speedVariables.Add ("TopSpeed", 25.0f);
		speedVariables.Add ("ReverseTopSpeed", -15.0f);
		speedVariables.Add ("LeftAndRightSpeed", 15.0f);
		speedVariables.Add ("ReverseControlFactor", 1.0f);
		speedVariables.Add ("SpeedControlFactor", 1.0f);
	}

	public void ReverseControls(){
		speedVariables ["ReverseControlFactor"] = -1;
	}

	public void ReverseControlResetter(){
		speedVariables ["ReverseControlFactor"] = 1;
	}

	public void SlowSpeedControlFactor(float factor){
		gameObject.GetComponent<Rigidbody> ().velocity =new  Vector3 (0, 0, 1);
		speedVariables ["SpeedControlFactor"] = factor;
		speedVariables ["TopSpeed"] = speedVariables ["TopSpeed"] * speedVariables ["SpeedControlFactor"];
		speedVariables ["ReverseTopSpeed"] = speedVariables ["ReverseTopSpeed"] * speedVariables ["SpeedControlFactor"];

	}

	public void ResetSpeedControlFactor(){
		speedVariables ["TopSpeed"] = speedVariables ["TopSpeed"] / speedVariables ["SpeedControlFactor"];
		speedVariables ["ReverseTopSpeed"] = speedVariables ["ReverseTopSpeed"] / speedVariables ["SpeedControlFactor"];
		speedVariables ["SpeedControlFactor"] = 1;
	}

	// Update is called once per frame
	void Update () {
		float forward = (speedVariables ["TopSpeed"] * speedVariables ["ReverseControlFactor"]) ;
		float backward =  (speedVariables ["ReverseTopSpeed"] * speedVariables ["ReverseControlFactor"]) ;
		float left = (speedVariables ["ReverseTopSpeed"] * speedVariables ["ReverseControlFactor"]);
		float right = ((speedVariables ["ReverseTopSpeed"] * speedVariables ["ReverseControlFactor"]) ) * -1;
		Debug.Log (forward);
		if (Input.GetKey ("w")) {
			gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0, forward));
		} else if (Input.GetKey ("s")) {
			gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0, backward));
		}

		if (Input.GetKey ("a")) {
			gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (left, 0, 0));
		} else if (Input.GetKey ("d")) {
			gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (right, 0, 0));
		}
	}
}
