using UnityEngine;
using System.Collections;

public class LoseZone : MonoBehaviour 
{

	public float FadeOutSpeed = 3.0f;

	public GameObject Light1;
	public GameObject Light2;

	public bool DebugMode = false;

	void OnTriggerEnter(Collider C)
	{
		if (C.gameObject.tag == "Player") 
		{
			if (DebugMode) Debug.Log ("LoseZone: Player entered fail lose, probably fell over the edge. Level Failed.");

			Light1.GetComponent<Animator> ().Play ("Light_FadeOut_01");
			Light2.GetComponent<Animator> ().Play ("Light_FadeOut_02");

			if (DebugMode) Debug.Log ("LoseZone: Playing fail animation [Light Fadouts].");

			StartCoroutine ("Lost");
		}
	}

	IEnumerator Lost()
	{

		if (DebugMode) Debug.Log ("LoseZone: Restarting Level [ " + Application.loadedLevel + " ].");

		yield return new WaitForSecondsRealtime (FadeOutSpeed);

		Application.LoadLevel(Application.loadedLevel);
	}
}
