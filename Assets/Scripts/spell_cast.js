#pragma strict


public var fireball : Transform;
public var spells : Transform;
var fireKeyInput : KeyCode; 
var timer : int;
var barkSound : AudioSource;

function Update ()
{
	if(Input.GetKeyDown(fireKeyInput))
	//Fireball key 1
	{
		barkSound.Play();
		Instantiate (fireball, spells.position, spells.rotation);
	}
}

function Start () {
	
}

