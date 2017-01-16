using UnityEngine;
using System.Collections;

public class BasicControls : MonoBehaviour {


	public float acceleration = 10.0f;

	[Header("Developer Options")]
	public bool PhoneMode = false;
	public bool DebugMode = false;


	void Start () 
	{
	
	}

	void Update () 
	{
		if (PhoneMode) PhoneControls (); else PCControls ();
	}

	private void PhoneControls()
	{
		
	}

	private void PCControls ()
	{
		if ( Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) ) Move_Right();
		if ( Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow ) ) Move_Left ();
		if ( Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow   ) ) Move_Up   ();
		if ( Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow ) ) Move_Down ();
	}

	private void Move_Right	() 	{ gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 ( acceleration, 0, 0)); }
	private void Move_Left	() 	{ gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (-acceleration, 0, 0)); }
	private void Move_Up	() 	{ gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0,  acceleration)); }
	private void Move_Down 	() 	{ gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0, -acceleration)); }
}
