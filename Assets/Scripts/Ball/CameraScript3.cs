using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript3 : MonoBehaviour {
	private GameObject rollo = null ;
	public float radius = 15.0f;
	private double phi = 270.0;
	public double phiSensetivity = 1.0;
	private Vector3 oldrollo =Vector3.zero;
	// Use this for initialization
	void Start () {
		rollo = GameObject.FindGameObjectWithTag ("Player");
		gameObject.GetComponent<Transform> ().position = rollo.GetComponent<Transform> ().position;
		gameObject.GetComponent<Transform> ().position = new Vector3 (rollo.GetComponent<Transform>().position.x, 7, (rollo.GetComponent<Transform>().position.x - radius));

		float x, y;
		calculatePoint(System.Convert.ToSingle(rollo.GetComponent<Transform> ().position.x) ,System.Convert.ToSingle(rollo.GetComponent<Transform> ().position.z), out x, out y);
		gameObject.GetComponent<Transform> ().position = new Vector3 (x, 7, y);

	}

	private double phiInceremter(){
		if (phi == 360.0) {
			phi = 0.0;
			return phi;
		} else {
			phi += phiSensetivity;
			return phi;
		}
	}

	private double phiDecrementer(){
		if (phi == 0.0) {
			phi = 360.0;
			return phi;
		} else {
			phi -= phiSensetivity;
			return phi;
		}
	}

	private double degreesToRadians(double angle)
	{
		return System.Math.PI * angle / 180.0;
	}

	private void calculatePoint (float incomingX, float incomingZ, out float x, out float y){
		Debug.Log (( (degreesToRadians (phi))) + "INPHI");
		x = incomingX + (radius * System.Convert.ToSingle((System.Math.Cos (degreesToRadians(phi)))));
		y= incomingZ + (radius * System.Convert.ToSingle((System.Math.Sin (degreesToRadians(phi)))));
	} 
	// Update is called once per frame
	void Update () {
		if (oldrollo != Vector3.zero) {
			if (oldrollo != rollo.transform.position) {
				Vector3 difference = rollo.transform.position - oldrollo;
				gameObject.transform.position += difference;
				oldrollo = rollo.transform.position;
			}
		}
		oldrollo =  rollo.transform.position;

		if (Input.GetAxis ("MOUSEX") < 0 && Input.GetMouseButton (1)) {
			float x, y;
			calculatePoint(System.Convert.ToSingle(rollo.GetComponent<Transform> ().position.x) ,System.Convert.ToSingle(rollo.GetComponent<Transform> ().position.z), out x, out y);
			gameObject.GetComponent<Transform> ().position = new Vector3 (x, gameObject.GetComponent<Transform>().position.y, y);
			phiDecrementer ();
		}
		if (Input.GetAxis ("MOUSEX") > 0 && Input.GetMouseButton (1)) {
			float x, y;
			calculatePoint(System.Convert.ToSingle(rollo.GetComponent<Transform> ().position.x) ,System.Convert.ToSingle(rollo.GetComponent<Transform> ().position.z), out x, out y);
			gameObject.GetComponent<Transform> ().position = new Vector3 (x, gameObject.GetComponent<Transform>().position.y, y);
			phiInceremter ();
			//Debug.Log (phi);

		}
		gameObject.GetComponent<Transform> ().LookAt (rollo.GetComponent<Transform>());
	}
}
