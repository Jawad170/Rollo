using UnityEngine;
using System.Collections;

public class BasicControls : MonoBehaviour {


	[Header("Basic Details")]
	public float 	acceleration 	=	10.0f	;

	[Header("Development Tools")]
	public  bool 	DebugMode		= 	false	;
	private bool	PhoneMode		= 	false	;

	void Start()
	{
		if (PlayerPrefs.GetInt ("PhoneMode") == 1) PhoneMode = true;
	}

	void Update () 
	{
		if (PhoneMode) PhoneControls (); else PCControls ();
	}

	public void Stop()
	{
		gameObject.GetComponent<Rigidbody> ().velocity 		  = Vector3.zero;
		gameObject.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
		gameObject.GetComponent<Rigidbody> ().useGravity 	  = false		;

		DebugMode.Log ("Ahmed is noob");
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
