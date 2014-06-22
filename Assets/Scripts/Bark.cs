using UnityEngine;
using System.Collections;

public class Bark : MonoBehaviour {

	public GameObject bark_sprite;
	public float force = 10;
	public float speed = 10;
	public AudioSource bark;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		if(Input.GetMouseButtonDown(0)){
			bark.Play();
			Debug.Log("eff eff!");
			GameObject projectile;
			Instantiate(bark_sprite);
			projectile = GameObject.FindGameObjectWithTag("bark_tag");
			projectile.rigidbody.velocity = transform.TransformDirection( new Vector3( 0, 0, speed));
			//projectile = Instantiate(bark_sprite, transform.position, transform.rotation);
			//projectile.rigidbody2d.AddForce(bark_sprite.transform.forward projectile.rigidbody.mass force, ForceMode.Impulse);


		}
	}
}

/*
var projectile: GameObject; var force: float;

function Update(){ if(Input.GetMouseButtonDown(0)){ projectile.rigidbody.AddForce(projectile.transform.forward projectile.rigidbody.mass force, ForceMode.Impulse);
		
	}

var newProjectile = Instantiate( projectile, transform.position, transform.rotation );
newProjectile.velocity = transform.TransformDirection( Vector3( 0, 0, speed)
	
}*/