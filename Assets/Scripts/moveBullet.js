#pragma strict

var bulletSpeed : float = 30;

function Update ()
{
transform.Translate(0, 0, bulletSpeed * .1*Time.deltaTime);
}

function Start () {
	Destroy(this.gameObject, 2.0f);
}

