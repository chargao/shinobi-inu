using UnityEngine;
using System.Collections;

public class FollowParent : MonoBehaviour {

	// 340, 11, 355

	// Update is called once per frame
	void FixedUpdate () {
		if(transform.parent.position.y != transform.position.y && transform.parent)
			transform.position = new Vector3(transform.position.x, transform.parent.position.y, -5.5f);
	}
}
