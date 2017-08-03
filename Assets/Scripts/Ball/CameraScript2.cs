using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript2 : MonoBehaviour {
	private GameObject rollo = null ;
	private Vector3 oldrollo =Vector3.zero;
	public float cameraDistance = 15.0f;
	// Use this for initialization
	void Start () {
		rollo = GameObject.FindGameObjectWithTag ("Player");
		gameObject.GetComponent<Transform> ().position = rollo.GetComponent<Transform> ().position;
		gameObject.GetComponent<Transform> ().position = rollo.GetComponent<Transform> ().position - new Vector3 (0, 0, 15);
		gameObject.GetComponent<Transform> ().position += new Vector3 (0, 7, 0);
		gameObject.GetComponent<Transform> ().LookAt (rollo.GetComponent<Transform>());
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

		if (Input.GetAxis ("MOUSEX") < 0) {
			Vector3 negativeZRegion = rollo.GetComponent<Transform> ().position - new Vector3 (0, 0, 15);
			Vector3 positiveXRegion = rollo.GetComponent<Transform> ().position + new Vector3 (15, 0, 0);
			//Vector3 positiveZRegion = rollo.GetComponent<Transform> ().position + new Vector3 (0, 0, 15);
			Vector3 negativeXRegion = rollo.GetComponent<Transform> ().position - new Vector3 (15, 0, 0);
			Debug.Log (negativeXRegion + "NEGATIVE X");
			Debug.Log (positiveXRegion+ "POSITIVR X");
			//Debug.Log (positiveZRegion);
			Debug.Log (negativeZRegion+ "NEGATIVE Z");
			if (gameObject.GetComponent<Transform> ().position.x > negativeZRegion.x && gameObject.GetComponent<Transform> ().position.z > negativeZRegion.z) {
				gameObject.GetComponent<Transform> ().position += new Vector3 (-1, 0, -1);
			} else if(gameObject.GetComponent<Transform> ().position.x > negativeXRegion.x && gameObject.GetComponent<Transform> ().position.z < negativeXRegion.z){
				gameObject.GetComponent<Transform> ().position += new Vector3 (-1, 0, 1);
			}
			//gameObject.GetComponent<Transform> ().position += new Vector3 (-1, 0, 1);
		}
		if (Input.GetAxis ("MOUSEX") > 0) {
			Vector3 negativeZRegion = rollo.GetComponent<Transform> ().position - new Vector3 (0, 0, 15);
			Vector3 positiveXRegion = rollo.GetComponent<Transform> ().position + new Vector3 (15, 0, 0);
			//Vector3 positiveZRegion = rollo.GetComponent<Transform> ().position + new Vector3 (0, 0, 15);
			Vector3 negativeXRegion = rollo.GetComponent<Transform> ().position - new Vector3 (15, 0, 0);
			if (gameObject.GetComponent<Transform> ().position.x < negativeZRegion.x && gameObject.GetComponent<Transform> ().position.z > negativeZRegion.z) {

				gameObject.GetComponent<Transform> ().position += new Vector3 (1, 0, -1);
			}else if (gameObject.GetComponent<Transform> ().position.x < positiveXRegion.x && gameObject.GetComponent<Transform> ().position.z < positiveXRegion.z) {
				gameObject.GetComponent<Transform> ().position += new Vector3 (1, 0, 1);
			} 

			Debug.Log ("--");
			//gameObject.GetComponent<Transform> ().position += new Vector3 (1, 0, -1);
		}
		gameObject.GetComponent<Transform> ().LookAt (rollo.GetComponent<Transform>());
	}
}
