using UnityEngine;
using System.Collections;

public class FollowBall : MonoBehaviour 
{
	[Header("Basic Details")]
	public float 		CameraDistance	=	15.0f	;

	[Header("Relevant GameObjects")]
	public GameObject 	Rollo			=	null	;

	[Header("Development Tools")]
	public bool			DebugMode		= 	false	;

	void FixedUpdate () 
	{
		DelayedFollow();
	}

	public void DelayedFollow()
	{
		Vector3 NewPos = Rollo.transform.position;
		NewPos.y += CameraDistance;

		float FollowSpeed = Mathf.Abs (NewPos.x - transform.position.x);

		if ( Mathf.Abs (NewPos.z - transform.position.z) > FollowSpeed ) 
			FollowSpeed = Mathf.Abs (NewPos.z - transform.position.z);

		if (DebugMode) Debug.Log ("Camera: FollowBall: Follow Speed [" + FollowSpeed.ToString("##.##") + "]");

		transform.position = Vector3.Lerp (transform.position, NewPos, Time.deltaTime	*	FollowSpeed);
	}
}
