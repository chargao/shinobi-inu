using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed;

	private int facingRight;
	private int facingUp;
	private float moveX;
	private float moveY;

	void Awake()
	{
		DontDestroyOnLoad (this);
	}

	// Use this for initialization
	void Start () {
		facingRight = -1;
		facingUp = -1;
	}

	void Update()
	{

	}

	void FixedUpdate()
	{
		MoveHorizontal();
		//MoveVertical ();

		if(rigidbody2D.velocity.y != 0)
		{
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0.0f);
		}
	}

	void FlipHorizontal()
	{
		facingRight = -1 * facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	void FlipVertical()
	{
		facingUp = -1 * facingUp;
	}

	void MoveHorizontal()
	{
		moveX = Input.GetAxis ("Horizontal");
		if((moveX < 0 && facingRight==1) || (moveX > 0 && facingRight==-1))
			FlipHorizontal();
		if(moveX != 0)
			rigidbody2D.velocity = new Vector2(facingRight * maxSpeed, rigidbody2D.velocity.y);
	}
	void MoveVertical() {
		moveY = Input.GetAxis ("Vertical");
		if((moveY < 0 && facingUp==1) || (moveY > 0 && facingUp==-1)) {
			FlipVertical();
		}
		if(moveY != 0) {
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, facingUp * maxSpeed);
		}
	}

	void OnCollisionEnter2D(GameObject other) {
		Debug.Log ("hello");
	}
}
