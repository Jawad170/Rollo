using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicControlsV2 : MonoBehaviour {
	private CharacterController cr;
	private Dictionary<string, double> speedVariables = new Dictionary<string, double> ();
	private Vector3 lastpostin = Vector3.zero;
	// Use this for initialization
	void Start () {
		initializeSpeedVariables ();
	}

	void initializeSpeedVariables(){
		speedVariables.Add ("TopSpeed", 15.0);
		speedVariables.Add("CurrentSpeed", 0.0);
		speedVariables.Add ("Acceleration", 0.0);
		speedVariables.Add("Deceleration", 0.0);
		speedVariables.Add ("CurrentDecelerationSpeed", 0.0);
		speedVariables.Add ("ReverseTopSpeed", -15.0);
		speedVariables.Add ("TimeToReachTopSpeed",100);//((20.0/60.0)/60.0))
		speedVariables.Add ("Gravity", System.Convert.ToDouble(Physics.gravity.y));
		speedVariables.Add ("Friction", 0.999999);
		speedVariables.Add ("ForwardForce", 100.0);
		speedVariables.Add ("ChangeOfSpeedDecay", 0.001);
		lastpostin = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (speedVariables ["CurrentDecelerationSpeed"]);

		if (Input.GetKey ("w")) {
			speedVariables ["CurrentDecelerationSpeed"] = 0.0;
			if (speedVariables ["Acceleration"] - 1.0 >= 0.0) {
				speedVariables ["Acceleration"] = 0.0;
			} else {
				speedVariables ["Acceleration"] = (speedVariables ["TopSpeed"] - speedVariables ["CurrentSpeed"]) / speedVariables ["TimeToReachTopSpeed"];
			}

			if (speedVariables ["CurrentSpeed"] < speedVariables ["TopSpeed"]) {
				speedVariables ["CurrentSpeed"] += speedVariables ["Acceleration"];
				float floatAcceleration = (float)speedVariables ["CurrentSpeed"];
				gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0, floatAcceleration));
			} else {
				float floatAcceleration = (float)speedVariables ["TopSpeed"];
			}

		} else if (Input.GetKey ("s")) {
			speedVariables ["Acceleration"] = 0.0;
			if (speedVariables ["CurrentDecelerationSpeed"] - 1.0 < -15.0) {
				speedVariables ["CurrentDecelerationSpeed"] = -15.0;
			} else {
				speedVariables["Deceleration"] = (speedVariables["ReverseTopSpeed"] - speedVariables["CurrentDecelerationSpeed"]) / speedVariables["TimeToReachTopSpeed"];
			}

			if (speedVariables ["CurrentDecelerationSpeed"] > speedVariables ["ReverseTopSpeed"]) {
				speedVariables ["CurrentDecelerationSpeed"] += speedVariables ["Deceleration"];
				float floatDeceleration = (float)speedVariables ["CurrentDecelerationSpeed"];
				gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0, floatDeceleration));
			} else {
				float floatDeceleration = (float)speedVariables ["CurrentDecelerationSpeed"];
				gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0, floatDeceleration));
			}

		}

	}
}		
//referencs http://www.smartconversion.com/Articles/14.aspx https://www.unitjuggler.com/convert-acceleration-from-kmmin2-to-ms2.html








































































// why did  you scroll down here? go back up





































/*double ChangeOfSpeed = (System.Convert.ToDouble(speedVariables ["TopSpeed"]) - System.Convert.ToDouble(speedVariables ["CurrentSpeed"])) * speedVariables["ChangeOfSpeedDecay"];
			if (speedVariables ["ChangeOfSpeedDecay"] < 1.0) {
				speedVariables ["ChangeOfSpeedDecay"] += speedVariables ["ChangeOfSpeedDecay"] / 1.1;
			}
			speedVariables["Acceleration"] = ((System.Convert.ToDouble(ChangeOfSpeed) / System.Convert.ToDouble(speedVariables ["TimeToReachTopSpeed"])) /  12960.0);//from km/h2 to m

			speedVariables ["Friction"] /= 1.1;
			//double test =  ((System.Convert.ToDouble(ChangeOfSpeed) / System.Convert.ToDouble(speedVariables ["TimeToReachTopSpeed"])) /  12960.0) * speedVariables["Friction"];
			//Debug.Log(speedVariables ["Acceleration"]+ " Current Speed1");
			//double friction = (speedVariables ["ForwardForce"] - (speedVariables ["Acceleration"] * 5)) / (5 * speedVariables ["Gravity"]);

			//speedVariables ["Acceleration"] = speedVariables ["Acceleration"] - test;
			//speedVariables ["Acceleration"] = System.Math.Abs(speedVariables ["Acceleration"] + friction);
			Debug.Log (speedVariables["CurrentSpeed"] + " CurrentSpeed");
			//Debug.Log(speedVariables ["Acceleration"]+ " Current Speed2");
			float floatAcceleration =  (float)speedVariables ["Acceleration"];
			speedVariables ["CurrentSpeed"] += speedVariables["Acceleration"] ;
			gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,floatAcceleration));*/