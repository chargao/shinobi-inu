using UnityEngine;
using System.Collections;

public class LightsOut : MonoBehaviour {

	public GameObject mainLight;

	// Use this for initialization
	void Start () {
		mainLight.light.intensity = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
