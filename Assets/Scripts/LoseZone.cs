using UnityEngine;
using System.Collections;

public class LoseZone : MonoBehaviour 
{
	[Header("Relevant GameObjects")]
	public GameObject 	LevelManager	=	null	;

	[Header("Development Tools")]
	public bool 		DebugMode 		= 	false	;

	void OnTriggerEnter(Collider C)
	{
		if (C.gameObject.tag == "Player") 
		{
			if (DebugMode) Debug.Log ("LoseZone: Player entered fail lose, probably fell over the edge. Level Failed.");

			LevelManager.GetComponent<LevelManager> ().Lose ();
		}
	}
}
