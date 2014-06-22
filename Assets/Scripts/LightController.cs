using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {

	public GameObject dogeLight;
	public GameObject humanLight;
	public GameObject dogeBark;
	public GameObject Human;
	public GameObject Doge;
	private bool isDoge;
	private GameObject camera;

	private GameObject player;

	void Start() {
		isDoge = true;
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update() {
		if(Input.GetKey(KeyCode.R)) {
			if(isDoge) {
				switchToHuman();
			}
			else {
				switchToDoge();
			}
		}
		if(player == null) {
			player = GameObject.FindGameObjectWithTag ("Player");
		}
	}

	public void switchToHuman() {
		Vector3 pos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
		Instantiate (Human, pos, Quaternion.identity);
		Destroy (player.gameObject);


	}

	public void switchToDoge() {
		Vector3 pos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
		Destroy (player.gameObject);
		
		Instantiate (Doge, pos, Quaternion.identity);
	}
}
