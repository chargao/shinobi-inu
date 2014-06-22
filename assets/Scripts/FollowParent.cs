using UnityEngine;
using System.Collections;

public class FollowParent : MonoBehaviour {

	public string ToFollow;
	private GameObject toFollow;
	public float z;

	// 340, 19, 346
	void Start() {
		toFollow = GameObject.FindGameObjectWithTag(ToFollow);
		transform.rotation = new Quaternion (340.0f, 19.0f, 346.0f, transform.rotation.w);
	}

	void Update() {
		if(toFollow == null) {
			toFollow = GameObject.FindGameObjectWithTag(ToFollow);
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		//if(transform.parent.position.y != transform.position.y && transform.parent)
		transform.position = new Vector3(toFollow.transform.position.x, toFollow.transform.position.y-1.5f, toFollow.transform.position.z-z);
		transform.localEulerAngles = new Vector3 (334.0f, 19.1f, 324.0f);
	}
}
