using UnityEngine;
using System.Collections;

public class FollowParent : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if(transform.parent.position.y != transform.position.y && transform.parent)
			transform.position = new Vector3(transform.position.x, transform.parent.position.y);
	}
}
