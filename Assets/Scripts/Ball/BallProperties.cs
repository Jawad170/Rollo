using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallProperties : MonoBehaviour {
	//Rigid Body Variables
	Dictionary<string, float> MaindictionaryProperties = new Dictionary<string, float> ();

	private float B_UP_mass= 0;
	private float B_UP_drag = 0;
	private float B_UP_angularDrag = 0;

	//Transform Variables.
	private float B_UP_scaleX = 0;
	private float B_UP_scaleY = 0;
	private float B_UP_scaleZ = 0;


	private Rigidbody ballRigidBody;
	private Transform ballTransform;

	// Use this for initialization
	void Start () {
		initializeMaindictionaryProperties ();
	}

	void backUpAllStats(){
		B_UP_mass = MaindictionaryProperties ["Mass_Rigid"];
		B_UP_drag = MaindictionaryProperties ["drag_Rigid"];
		B_UP_angularDrag = MaindictionaryProperties ["AngularDrag_Rigid"];

		B_UP_scaleX = MaindictionaryProperties ["ScaleX_Transform"];
		B_UP_scaleY = MaindictionaryProperties ["ScaleY_Transform"];
		B_UP_scaleZ = MaindictionaryProperties ["ScaleZ_Transform"];
	}

	void ApplyBackedUpStats(bool apply = false){
		MaindictionaryProperties ["Mass_Rigid"] = B_UP_mass;
		MaindictionaryProperties ["drag_Rigid"] = B_UP_drag;
		MaindictionaryProperties ["AngularDrag_Rigid"] = B_UP_angularDrag;

		MaindictionaryProperties ["ScaleX_Transform"] = B_UP_scaleX;
		MaindictionaryProperties ["ScaleY_Transform"] = B_UP_scaleY;
		MaindictionaryProperties ["ScaleZ_Transform"] = B_UP_scaleZ;

		if (apply == true) {
			applyPropertiesOnBall ();
		}
	}

	void initializeMaindictionaryProperties(){
		MaindictionaryProperties.Add ("Mass_Rigid", 0);
		MaindictionaryProperties.Add ("drag_Rigid", 0);
		MaindictionaryProperties.Add ("AngularDrag_Rigid", 0);
		MaindictionaryProperties.Add ("ScaleX_Transform", 0);
		MaindictionaryProperties.Add ("ScaleY_Transform", 0);
		MaindictionaryProperties.Add ("ScaleZ_Transform", 0);
	
	}

	// Update is called once per frame
	void Update () {
	}

	float getMass(){
		return MaindictionaryProperties["Mass_Rigid"];
	}

	void setMass(float incomingMass){
		MaindictionaryProperties["Mass_Rigid"] = incomingMass;
	}

	float getDrag(){
		return MaindictionaryProperties["drag_Rigid"];
	}

	void setDrag(float incomingDrag){
		MaindictionaryProperties["drag_Rigid"] = incomingDrag;
	}

	float getAngularDrag(){
		return MaindictionaryProperties["AngularDrag_Rigid"];
	}

	void setAngularDrag(float incomingAngularDrag){
		MaindictionaryProperties["AngularDrag_Rigid"] = incomingAngularDrag;
	}

	float getScaleX(){
		return MaindictionaryProperties["ScaleX_Transform"];
	}

	float getScaleY(){
		return MaindictionaryProperties["ScaleY_Transform"];
	}

	float getScaleZ(){
		return MaindictionaryProperties["ScaleZ_Transform"];
	} 

	void setScaleX(float incomingScaleX){
		MaindictionaryProperties["ScaleX_Transform"] = incomingScaleX;
	}

	void setScaleY(float incomingScaleY){
		MaindictionaryProperties["ScaleY_Transform"] = incomingScaleY;
	}

	void setScaleZ(float incomingScaleZ){
		MaindictionaryProperties["ScaleZ_Transform"] = incomingScaleZ;
	}

	void applyPropertiesOnBall(){
		ballRigidBody = gameObject.GetComponent<Rigidbody> ();
		ballRigidBody.mass = MaindictionaryProperties["Mass_Rigid"];
		ballRigidBody.drag = MaindictionaryProperties["drag_Rigid"];
		ballRigidBody.angularDrag = MaindictionaryProperties["AngularDrag_Rigid"];

		ballTransform = gameObject.GetComponent<Transform> ();
		ballTransform.localScale = new Vector3 (MaindictionaryProperties["ScaleX_Transform"], MaindictionaryProperties["ScaleY_Transform"], MaindictionaryProperties["ScaleZ_Transform"]);
		//Debug.Log (gameObject.GetComponent<Rigidbody> ().mass.ToString ());

	}

	void setAndApplyPropertiesOnBall
	   (float incomingMass_Rigid= float.NaN,
		float incomingdrag_Rigid = float.NaN,
		float incomingAngularDrag_Rigid = float.NaN,
		float incomingScaleX_Transform = float.NaN,
		float incomingScaleY_Transform = float.NaN,
		float incomingScaleZ_Transform = float.NaN,
		bool apply = false)
	{
		Dictionary<string, float> tempdictionaryProperties = new Dictionary<string, float> ();
		tempdictionaryProperties.Add ("Mass_Rigid", incomingMass_Rigid);
		tempdictionaryProperties.Add ("drag_Rigid", incomingdrag_Rigid);
		tempdictionaryProperties.Add ("AngularDrag_Rigid", incomingAngularDrag_Rigid);
		tempdictionaryProperties.Add ("ScaleX_Transform", incomingScaleX_Transform);
		tempdictionaryProperties.Add ("ScaleY_Transform", incomingScaleY_Transform);
		tempdictionaryProperties.Add ("ScaleZ_Transform", incomingScaleZ_Transform);

		

		List<string> dicKeys = new List<string> (tempdictionaryProperties.Keys);

		for (int i = 0; i < dicKeys.Count; i++) {
			if (float.IsNaN (tempdictionaryProperties [dicKeys [i]]) == false) {
				MaindictionaryProperties [dicKeys [i]] = tempdictionaryProperties [dicKeys [i]];
			}
			Debug.Log (MaindictionaryProperties [dicKeys [i]]  +  dicKeys [i]);
		}
		if (apply == true) {
			applyPropertiesOnBall ();
		}

		

	}
};
