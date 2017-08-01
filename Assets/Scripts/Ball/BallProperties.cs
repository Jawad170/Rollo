using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallProperties : MonoBehaviour {
	//Rigid Body Variables
	private Dictionary<string, float> MaindictionaryProperties = new Dictionary<string, float> ();

	private float B_UP_mass= 0;
	private float B_UP_drag = 0;
	private float B_UP_angularDrag = 0;

	//Transform Variables.
	private float B_UP_TransformX = 0;
	private float B_UP_TransformY = 0;
	private float B_UP_TransformZ = 0;

	//Scale Variables
	private float B_UP_ScaleX = 0;
	private float B_UP_ScaleY = 0;
	private float B_UP_ScaleZ = 0;

	private Rigidbody ballRigidBody;
	private Transform ballTransform;

	// Use this for initialization
	void Start () {
		initializeMaindictionaryProperties ();
		//initializeGameObject ();

	}

	public void setGameObject(){
		
	}

	public void backUpAllStats(){
		B_UP_mass = MaindictionaryProperties ["Mass_Rigid"];
		B_UP_drag = MaindictionaryProperties ["drag_Rigid"];
		B_UP_angularDrag = MaindictionaryProperties ["AngularDrag_Rigid"];

		B_UP_TransformX = MaindictionaryProperties ["x_Transform"];
		B_UP_TransformY = MaindictionaryProperties ["y_Transform"];
		B_UP_TransformZ = MaindictionaryProperties ["z_Transform"];

		B_UP_ScaleX = MaindictionaryProperties ["x_Scale"];
		B_UP_ScaleY = MaindictionaryProperties ["y_Scale"];
		B_UP_ScaleZ = MaindictionaryProperties ["z_Scale"];
	}

	public void ApplyBackedUpStats(bool apply = false){
		MaindictionaryProperties ["Mass_Rigid"] = B_UP_mass;
		MaindictionaryProperties ["drag_Rigid"] = B_UP_drag;
		MaindictionaryProperties ["AngularDrag_Rigid"] = B_UP_angularDrag;

		MaindictionaryProperties ["x_Transform"] = B_UP_TransformX;
		MaindictionaryProperties ["y_Transform"] = B_UP_TransformY;
		MaindictionaryProperties ["z_Transform"] = B_UP_TransformZ;

		MaindictionaryProperties ["x_Scale"] = B_UP_ScaleX;
		MaindictionaryProperties ["y_Scale"] = B_UP_ScaleY;
		MaindictionaryProperties ["z_Scale"] = B_UP_ScaleZ;

		if (apply == true) {
			applyPropertiesOnBall ();
		}
	}

	public void initializeMaindictionaryProperties(){
		ballRigidBody = gameObject.GetComponent<Rigidbody> ();
		MaindictionaryProperties.Add ("Mass_Rigid", ballRigidBody.mass);
		MaindictionaryProperties.Add ("drag_Rigid", ballRigidBody.drag);
		MaindictionaryProperties.Add ("AngularDrag_Rigid", ballRigidBody.angularDrag);

		ballTransform = gameObject.GetComponent<Transform> ();
		MaindictionaryProperties.Add ("x_Transform", ballTransform.localPosition.x);
		MaindictionaryProperties.Add ("y_Transform", ballTransform.localPosition.y);
		MaindictionaryProperties.Add ("z_Transform", ballTransform.localPosition.z);
		MaindictionaryProperties.Add ("x_Scale", ballTransform.localScale.x);
		MaindictionaryProperties.Add ("y_Scale", ballTransform.localScale.y);
		MaindictionaryProperties.Add ("z_Scale", ballTransform.localScale.z);

		//ballTransform. = new Vector3 (MaindictionaryProperties["x_Transform"], MaindictionaryProperties["y_Transform"], MaindictionaryProperties["z_Transform"]);
		//Debug.Log (gameObject.GetComponent<Rigidbody> ().mass.ToString ());

	
	}
		
	// Update is called once per frame
	void Update () {
	}

	public float getMass(){
		return MaindictionaryProperties["Mass_Rigid"];
	}

	[System.Obsolete("Method setMass is Deprecated, please use setAndApplyPropertiesOnBall instead")]
	public void setMass(float incomingMass){
		MaindictionaryProperties["Mass_Rigid"] = incomingMass;
	}

	public float getDrag(){
		return MaindictionaryProperties["drag_Rigid"];
	}
	[System.Obsolete("Method setDrag is Deprecated, please use setAndApplyPropertiesOnBall instead")]
	public void setDrag(float incomingDrag){
		MaindictionaryProperties["drag_Rigid"] = incomingDrag;
	}

	public float getAngularDrag(){
		return MaindictionaryProperties["AngularDrag_Rigid"];
	}

	[System.Obsolete("Method setAngularDrag is Deprecated, please use setAndApplyPropertiesOnBall instead")]
	public void setAngularDrag(float incomingAngularDrag){
		MaindictionaryProperties["AngularDrag_Rigid"] = incomingAngularDrag;
	}

	public float getTransformX(){
		return MaindictionaryProperties["x_Transform"];
	}

	public float getTransformY(){
		return MaindictionaryProperties["y_Transform"];
	}

	public float getTransformZ(){
		return MaindictionaryProperties["z_Transform"];
	} 

	public float getScaleX(){
		return MaindictionaryProperties["x_Scale"];
	}

	public float getScaleY(){
		return MaindictionaryProperties["y_Scale"];
	}

	public float getScaleZ(){
		return MaindictionaryProperties["z_Scale"];
	}

	[System.Obsolete("Method setScaleX is Deprecated, please use setAndApplyPropertiesOnBall instead")]
	public void setScaleX(float incomingScaleX){
		MaindictionaryProperties["x_Scale"] = incomingScaleX;
	}

	[System.Obsolete("Method setScaleY is Deprecated, please use setAndApplyPropertiesOnBall instead")]
	public void setScaleY(float incomingScaleY){
		MaindictionaryProperties["y_Scale"] = incomingScaleY;
	}

	[System.Obsolete("Method setScaleZ is Deprecated, please use setAndApplyPropertiesOnBall instead")]
	public void setScaleZ(float incomingScaleZ){
		MaindictionaryProperties["z_Scale"] = incomingScaleZ;
	}

	[System.Obsolete("Method setTransformX is Deprecated, please use setAndApplyPropertiesOnBall instead")]
	public void setTransformX(float incomingTransformX){
		MaindictionaryProperties["x_Transform"] = incomingTransformX;
	}

	[System.Obsolete("Method setTransformY is Deprecated, please use setAndApplyPropertiesOnBall instead")]
	public void setTransformY(float incomingTransformY){
		MaindictionaryProperties["y_Transform"] = incomingTransformY;
	}

	[System.Obsolete("Method setTransformZ is Deprecated, please use setAndApplyPropertiesOnBall instead")]
	public void setTransformZ(float incomingTransformZ){
		MaindictionaryProperties["z_Transform"] = incomingTransformZ;
	}

	public void initializeGameObject(){
		//Debug.Log (CurrentGameObject.GetComponent<Rigidbody> ().mass);
		setAndApplyPropertiesOnBall (incomingMass_Rigid: gameObject.GetComponent<Rigidbody> ().mass, incomingdrag_Rigid: gameObject.GetComponent<Rigidbody> ().drag,
			incomingAngularDrag_Rigid: gameObject.GetComponent<Rigidbody> ().angularDrag, incoming_x_Transform: gameObject.GetComponent<Transform> ().position.x,
			incoming_y_Transform: gameObject.GetComponent<Transform> ().position.y, incoming_z_Transform: gameObject.GetComponent<Transform> ().position.z,
			incoming_x_Scale:gameObject.GetComponent<Transform>().localScale.x, incoming_y_Scale:gameObject.GetComponent<Transform>().localScale.y,
			incoming_z_Scale:gameObject.GetComponent<Transform>().localScale.z, apply: false);
	}

	public void printAllVariables(){
		List<string> dickeys = new List<string> (MaindictionaryProperties.Keys);
		for(int i = 0; i < dickeys.Count; i++){
			Debug.Log(dickeys[i].ToString() + " : " + MaindictionaryProperties[dickeys[i]].ToString());
		}
	}

	public void applyPropertiesOnBall(){
		ballRigidBody = gameObject.GetComponent<Rigidbody> ();
		ballRigidBody.mass = MaindictionaryProperties["Mass_Rigid"];
		ballRigidBody.drag = MaindictionaryProperties["drag_Rigid"];
		ballRigidBody.angularDrag = MaindictionaryProperties["AngularDrag_Rigid"];

		ballTransform = gameObject.GetComponent<Transform> ();
		ballTransform.localScale += new Vector3 (MaindictionaryProperties["x_Scale"], MaindictionaryProperties["y_Scale"], MaindictionaryProperties["z_Scale"]);
		//ballTransform. = new Vector3 (MaindictionaryProperties["x_Transform"], MaindictionaryProperties["y_Transform"], MaindictionaryProperties["z_Transform"]);
		//Debug.Log (gameObject.GetComponent<Rigidbody> ().mass.ToString ());

	}

	//---------------------------------- Environmental Effects

	public void upwardsWinds(float windPower){
		gameObject.GetComponent<BasicControlsV3> ().upwardsWinds (windPower: windPower);
	}

	//----------------------------------End of Environmantal effects

	public void ReverseControls(){
		gameObject.GetComponent<BasicControlsV3> ().ReverseControls();
	}

	public void ReverseControlResetter(){
		gameObject.GetComponent<BasicControlsV3> ().ReverseControlResetter ();
	}

	public void SlowSpeed(float factor){
		gameObject.GetComponent<BasicControlsV3> ().SlowSpeedControlFactor (factor: factor);
	}

	public void ResetSpeedSlow(){
		gameObject.GetComponent<BasicControlsV3> ().ResetSpeedControlFactor ();
	}

	public void modifyScale(float scaleX, float scaleY, float scaleZ){
		ballTransform = gameObject.GetComponent<Transform> ();
		ballTransform.localScale += new Vector3 (scaleX, scaleY, scaleZ);
	}

	public void speedMultiplier(float multiplier){
		gameObject.GetComponent<BasicControlsV3> ().speedMultipler (multiplier: multiplier);
	}

	public void resetSpeedMultipler(float multiplier){
		gameObject.GetComponent<BasicControlsV3> ().resetSpeedMultipler (multiplier: multiplier);
	}

	public void setAndApplyPropertiesOnBall
	   (float incomingMass_Rigid= float.NaN,
		float incomingdrag_Rigid = float.NaN,
		float incomingAngularDrag_Rigid = float.NaN,
		float incoming_x_Transform = float.NaN,
		float incoming_y_Transform = float.NaN,
		float incoming_z_Transform = float.NaN,
		float incoming_x_Scale = float.NaN,
		float incoming_y_Scale = float.NaN,
		float incoming_z_Scale = float.NaN,
		bool apply = false)
	{
		Dictionary<string, float> tempdictionaryProperties = new Dictionary<string, float> ();
		tempdictionaryProperties.Add ("Mass_Rigid", incomingMass_Rigid);
		tempdictionaryProperties.Add ("drag_Rigid", incomingdrag_Rigid);
		tempdictionaryProperties.Add ("AngularDrag_Rigid", incomingAngularDrag_Rigid);
		tempdictionaryProperties.Add ("x_Transform", incoming_x_Transform);
		tempdictionaryProperties.Add ("y_Transform", incoming_y_Transform);
		tempdictionaryProperties.Add ("z_Transform", incoming_z_Transform);
		tempdictionaryProperties.Add ("x_Scale", incoming_x_Scale);
		tempdictionaryProperties.Add ("y_Scale", incoming_y_Scale);
		tempdictionaryProperties.Add ("z_Scale", incoming_z_Scale);

		

		List<string> dicKeys = new List<string> (tempdictionaryProperties.Keys);

		for (int i = 0; i < dicKeys.Count; i++) {
			if (float.IsNaN (tempdictionaryProperties [dicKeys [i]]) == false) {
				MaindictionaryProperties [dicKeys [i]] = tempdictionaryProperties [dicKeys [i]];
			}
			//Debug.Log (MaindictionaryProperties [dicKeys [i]]  +  dicKeys [i]);
		}
		if (apply == true) {
			applyPropertiesOnBall ();
		}

		

	}
};
