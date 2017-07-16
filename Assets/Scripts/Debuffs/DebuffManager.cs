using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DebuffManager : MonoBehaviour {
	BallProperties ballPropertiesFunctions = new BallProperties();
	private float targetTime = 5.0f;
	private bool startTimer = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (startTimer == true) {
			targetTime -= Time.deltaTime;
		}
		if (targetTime <= 0.0f) {
			ballPropertiesFunctions.modifyScale (-ballPropertiesFunctions.getScaleX (), -ballPropertiesFunctions.getScaleY (), -ballPropertiesFunctions.getScaleZ ());
			startTimer = false;
			targetTime = 5.0f;
		}
		//Debug.Log (gameObject.name);
	}
		

	void OnTriggerEnter(Collider otherGameObject){
		//Debug.Log ();
		string typeOfDebuff = gameObject.name.ToString();

		switch (typeOfDebuff) {
		case "Double Size Debuff":
			//initialize instance of the properties of the ball.
			ballPropertiesFunctions.setGameObject (incomingGameObject: otherGameObject.gameObject);
			ballPropertiesFunctions.initializeGameObject ();
			//ballPropertiesFunctions.backUpAllStats ();
			//Get current Scale.
			float scaleX = ballPropertiesFunctions.getScaleX ();
			float scaleY = ballPropertiesFunctions.getScaleY ();
			float scaleZ = ballPropertiesFunctions.getScaleZ ();

			ballPropertiesFunctions.modifyScale (scaleX, scaleY, scaleZ);

			
			startTimer = true;

				
			//ballPropertiesFunctions.printAllVariables ();

			//Debug.Log (scaleX);
			//Debug.Log (scaleY);
			//Debug.Log (scaleZ);
			//Debug.Log (ballPropertiesScript.initializeGameObject(otherGameObject));
			break;
			
		}
	}
}
