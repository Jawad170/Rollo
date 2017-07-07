using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	[Header("Basic Details")]
	public int  		LevelNumber		=	0				;
	public string 		LevelName		=	"Not Set Yet"	;

	[Header("Relevant GameObjects")]
	public GameObject 	Rollo			=	null			;
	public GameObject 	Timer			=	null			;
	public GameObject[] Lights			=	null			;
	public float 		WaitDuration	= 	1.0f			;

	[Header("Development Tools")]
	public bool 		PhoneMode		= 	false			;
	public bool 		DebugMode		= 	false			;

	void Start () 
	{
		if (PhoneMode) 	PlayerPrefs.SetInt ("PhoneMode", 1);
		else 			PlayerPrefs.SetInt ("PhoneMode", 0);

		if (DebugMode) 	Debug.Log ("Level Manager: Started Level #" + LevelNumber + " - " + LevelName);
	}

	public void Lose()
	{
		StartCoroutine ("RestartLevel" );
	}

	public void Win()
	{
		//COMING SOON
	}

	public void Pause()
	{
		//NEEDS MORE WORK
		Timer.GetComponent<Timer>().Enabled = false;
	}

	private void FadeOutLights()
	{
		if (DebugMode) Debug.Log ("Level Manager: Lost, turning off lights.");

		foreach ( GameObject light in Lights )
		{
			light.GetComponent<Light> ().intensity = 0.0f;
		}
	}

	private IEnumerator RestartLevel()
	{
		FadeOutLights ();

		Rollo.GetComponent<BasicControls> ().Stop ();

		if (DebugMode) Debug.Log ("Level Manager: Restarting Level [ " + Application.loadedLevel + " ] in " + WaitDuration + " seconds.");

		yield return new WaitForSecondsRealtime (WaitDuration);

		Application.LoadLevel(Application.loadedLevel);
	}
}
