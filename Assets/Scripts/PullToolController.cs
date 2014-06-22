using UnityEngine;
using System.Collections;

public class PullToolController : MonoBehaviour {

	private GameObject player;
	private int frameCounter;
	public float speed;
	private Transform thing;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		frameCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(frameCounter < 10) {
			frameCounter++;
		}
		else {
			//Destroy (this.gameObject);
		}
	}
	
	void OnControllerColliderHit(ControllerColliderHit hit) {
		Debug.Log ("hit");
		if(hit.transform.tag=="boulder") {
			thing = hit.transform;
		}

		if(thing!=null) {
			Vector3 D = transform.position - thing.position;
			float dist = D.magnitude;
			Vector3 pullDirection = D.normalized;

			if(dist>50) {thing = null;}
			else if(dist>3) {
				float pullF = 10;

				//thing.rigidbody.velocity += pullDirection*(pullDirection * Time.deltaTime);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		
		//touched = true;
		Debug.Log ("hi");
	}
}
