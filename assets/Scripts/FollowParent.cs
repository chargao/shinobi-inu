using UnityEngine;
using System.Collections;

public class FollowParent : MonoBehaviour {

	public GameObject ToFollow;

	// 340, 19, 346
	void Start() {
		transform.rotation = new Quaternion (340.0f, 19.0f, 346.0f, transform.rotation.w);
	}

	// Update is called once per frame
	void FixedUpdate () {
		//if(transform.parent.position.y != transform.position.y && transform.parent)
		transform.position = new Vector3(ToFollow.transform.position.x, ToFollow.transform.position.y-1.5f, ToFollow.transform.position.z-4.5f);
		transform.localEulerAngles = new Vector3 (334.0f, 19.1f, 324.0f);
	}
}
