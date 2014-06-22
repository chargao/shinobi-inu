using UnityEngine;
using System.Collections;

public class SwordController : MonoBehaviour {

	private int frameCounter;
	private NPCController enemy;

	// Use this for initialization
	void Start () {
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

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "enemy") {
			Debug.Log ("killed: "+other.gameObject.tag);
			other.gameObject.
		}
		Destroy (this.gameObject);
	}
}
