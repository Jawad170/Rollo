using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	[Header("Basic Details")]
	public float 	StartTime 			= 15.00f 	;
	public float 	CurrentTime      	= 15.00f	;
	public float 	ReductionPerFrame	= 0.0166f	;

	[Header("Relevant GameObjects")]
	public GameObject 	LevelManager	=	null	;

	[Header("Development Tools")]
	public bool		DebugMode			= 	false	;
	public bool		Enabled				= 	true	;

	void Start()
	{
		CurrentTime = StartTime;
	}

	void FixedUpdate () 
	{
		if (Enabled)
		{
			if (CurrentTime > 0) 
			{
				CurrentTime -= ReductionPerFrame;
				gameObject.GetComponent<Text> ().text = CurrentTime.ToString ("00.00");
			} 
			else
			{
				LoseToTime();
			}
		}
	}

	public void LoseToTime()
	{
		if (DebugMode) Debug.Log ("Timer: Lost to time running out!");

		Enabled 	= false;
		CurrentTime = 0.0f ;

		gameObject.GetComponent<Text> ().text = CurrentTime.ToString ("00.00");

		LevelManager.GetComponent<LevelManager> ().Lose ();
	}
}
