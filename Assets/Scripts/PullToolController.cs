using UnityEngine;
using System.Collections;

public class PullToolController : MonoBehaviour {

	private GameObject player;
	private int frameCounter;
	public float speed;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		frameCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(frameCounter < 2) {
			frameCounter++;
		}
		else {
			Destroy (this.gameObject);
		}
	}
	
	void OnCollisionEnter(Collision other) {
		Vector3 relative = other.transform.position - transform.position;
		Vector3 movementNormal = Vector3.Normalize(relative);
		if(other.gameObject.tag == "boulder") {
			Debug.Log ("pulled: "+other.gameObject.tag);
			rigidbody2D.AddForce(new Vector2(movementNormal.x, movementNormal.y) * speed);
		}
		Destroy (this.gameObject);
	}
}
