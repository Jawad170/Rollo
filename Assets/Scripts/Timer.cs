using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public float StartTime 			= 15.00f 	;
	public float CurrentTime        = 15.00f	;
	public float ReductionPerFrame  = 0.0166f	;

	public bool DebugMode = false;

	void Start()
	{
		CurrentTime = StartTime;
	}

	void FixedUpdate () 
	{
		if (CurrentTime > 0) 
		{
			CurrentTime -= ReductionPerFrame;
			gameObject.GetComponent<Text> ().text = CurrentTime.ToString ("00.00");
		} 
		else 
		{
			CurrentTime = 0;
			LoseToTime ();
		}
	}

	public void LoseToTime()
	{
		if (DebugMode) Debug.Log ("Timer: Lost to time running out!");
	}
}
