using UnityEngine;
using System.Collections;

public class FollowParent : MonoBehaviour {

	public string ToFollow;
	public Transform playerToFollow;
	private GameObject toFollow;
	public float z;

	// 340, 19, 346
	void Start() {
		if(playerToFollow == null) {
			toFollow = GameObject.FindGameObjectWithTag(ToFollow);
			Debug.Log (gameObject.tag+" is following " +toFollow.gameObject.tag);
			transform.rotation = new Quaternion (340.0f, 19.0f, 346.0f, transform.rotation.w);
		}
		else {
			Debug.Log (playerToFollow.position);
			toFollow.transform.position = playerToFollow.position;
		}
	}

	void Update() {
		if(toFollow == null) {
			toFollow = GameObject.FindGameObjectWithTag(ToFollow);
		}
		if(playerToFollow == null) {
			playerToFollow = toFollow.transform;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		//if(transform.parent.position.y != transform.position.y && transform.parent)
		transform.position = new Vector3(playerToFollow.position.x, playerToFollow.position.y-1.5f, playerToFollow.position.z-z);
		transform.localEulerAngles = new Vector3 (334.0f, 19.1f, 324.0f);
	}
}
